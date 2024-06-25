using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AutoMapper;
using SHM.Domain.Dto;
using SHM.Function.Data;
using SHM.Domain.Helper;
using Microsoft.EntityFrameworkCore;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Models.Sahc0100;
using Microsoft.Graph.Models;
using System.Collections.Generic;

namespace Sahc0100.Functions;

public class EntityMasterSearch {

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;

    public EntityMasterSearch(FunctionDbContext db, IMapper mapper) {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
    }



    [FunctionName("EntityMasterSearch")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "EntityMasterSearch/{TaxId?}")] HttpRequest req, string TaxId, ILogger log) {
        try {
            await GetEntityBySearch(TaxId, _responseDto);
        } catch (Exception e) {
            await ElasticAlert.LogErrorToElastic(e, "EntityMasterSearch");
            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
        }
        return _responseDto;
    }

    private async Task<ResponseDto> GetEntityBySearch(string searchValue, ResponseDto response) {

        MapHelper mapHelper = new MapHelper(_mapper);
        try {
            if (string.IsNullOrWhiteSpace(searchValue)) {
                response.IsSuccess = false;
                response.Message = "El número de identificación no puede ser nulo";
                return response;
            }

            var query = _db.EntityMasterGenerals
            .AsQueryable()
            .Where(x => x.TaxId.Contains(searchValue)
                        || x.FirstName.Contains(searchValue)
                        || x.LastName.Contains(searchValue)
                        || x.DisplayName.Contains(searchValue)
                        || x.BusinessName.Contains(searchValue)
                        || x.MiddleName.Contains(searchValue)
                        || x.MarriedSurName.Contains(searchValue))
            .OrderByDescending(x => x.TaxId.Contains(searchValue))      // Prioridad máxima a TaxId
            .ThenByDescending(x => x.FirstName.Contains(searchValue))   // Siguiente prioridad a FirstName
            .ThenByDescending(x => x.LastName.Contains(searchValue))    // y así sucesivamente...
            .ThenByDescending(x => x.DisplayName.Contains(searchValue))
            .ThenByDescending(x => x.BusinessName.Contains(searchValue))
            .ThenByDescending(x => x.MiddleName.Contains(searchValue))
            .ThenByDescending(x => x.MarriedSurName.Contains(searchValue))
            .Take(20);

            List<EntityMasterGeneral> results = await query
            .Include(x => x.Country)
            .Include(x => x.CivilStatus)
            .Include(x => x.EntityMasterAddresses)
            .ThenInclude(y => y.Countries)
            .ToListAsync();


            if (results == null ) {
                response.IsSuccess = false;
                response.Message = mapHelper.GetMessageSinRegistros();
                return response;
            }

            response.Result = _mapper.Map<List<EntityMasterGeneralGetDTO>>(results);
            return response;

        } catch (Exception e) {

            await ElasticAlert.LogErrorToElastic(e, "InsideGetEntityMasterByTaxId--EntityMasterByTaxId");

            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }

}

