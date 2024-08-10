using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AutoMapper;
using SHM.Domain.Dto;
using SHM.Function.Data;
using SHM.Domain.Helper;
using Microsoft.EntityFrameworkCore;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Models.Sahc0100;


namespace Sahc0100.Functions;


public class EntityMasterByTaxId
{

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;


    public EntityMasterByTaxId(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
    }



    [FunctionName("EntityMasterByTaxId")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "EntityMasterByTaxId/{TaxId?}")] HttpRequest req, string TaxId, ILogger log)
    {
        try
        {

            await GetByIdtypeTaxIdEntityMaster(TaxId, _responseDto);

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "EntityMasterByTaxId");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;

        }
        return _responseDto;
    }

    private async Task<ResponseDto> GetByIdtypeTaxIdEntityMaster(string TaxId, ResponseDto response)
    {

        MapHelper mapHelper = new MapHelper(_mapper);
        try
        {

            

            if (string.IsNullOrEmpty(TaxId))
            {
                response.IsSuccess = false;
                response.Message = "El número de identificación no puede ser nulo";
                return response;
            }


            EntityMasterGeneral EntityMasterGeneralItem = await _db.EntityMasterGenerals
                                                                    .Include(x => x.Country)
                                                                    .Include(x => x.CivilStatus)
                                                                    .Include(x => x.EntityMasterAddresses)
                                                                    .ThenInclude(y => y.Countries)
                                                                    .Include(x => x.EntityMasterAddresses)
                                                                    .ThenInclude(y => y.Provinces)
                                                                    .Include(x => x.EntityMasterAddresses)
                                                                    .ThenInclude(y => y.Districts)
                                                                    .Include(x => x.EntityMasterAddresses)
                                                                    .ThenInclude(y => y.Townships)
                                                                    .Include(x => x.EntityMasterAddresses)
                                                                    .ThenInclude(y => y.SourceMasters)
                                                                    .Include(x => x.EntityMasterAddresses)
                                                                    .ThenInclude(y => y.EntityMasterAddresstypes)
                                                                    .Where(x =>  x.TaxId == TaxId)
                                                                    .FirstOrDefaultAsync();


            if (EntityMasterGeneralItem == null)
            {
                response.IsSuccess = false;
                response.Message = mapHelper.GetMessageSinRegistros();
                return response;
            }


            EntityMasterGeneralGetDTO entityMasterGeneralDTO = _mapper.Map<EntityMasterGeneralGetDTO>(EntityMasterGeneralItem);

            //if (EntityMasterGeneralItem.EntityMasterAddresses.Any())
            //{
            //    mapHelper.MapEntityMasterGeneral(EntityMasterGeneralGetDTO, EntityMasterGeneralItem.EntityMasterAddresses);
            //}

            response.Result = entityMasterGeneralDTO;
            return response;

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "InsideGetEntityMasterByTaxId--EntityMasterByTaxId");

            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }

}

