using System;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using SHM.Domain.Dto;
using SHM.Function.Data;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using SHM.Domain.Dto.Sahc0100;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.WebJobs.Extensions.Http;
using SHM.Domain.Helper;

namespace Sahc0100.Functions;

public class EntityMasterSearchParams {

    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;

    public EntityMasterSearchParams(FunctionDbContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    [FunctionName("EntityMasterSearchParams")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger log) {
        try {
            return await GetEntityBySearchParams(req);
        } catch (Exception e) {
            await ElasticAlert.LogErrorToElastic(e, "EntityMasterSearchParams");
            var response = new ResponseDto();
            log.LogError(e, "Error processing EntityMasterSearchParams");
            response.IsSuccess = false;
            response.Message = "Internal server error.";
            return new BadRequestObjectResult(response);
        }
    }

    private async Task<IActionResult> GetEntityBySearchParams(HttpRequest req) {
        var response = new ResponseDto();
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var searchParams = JsonConvert.DeserializeObject<EntityMasterGeneralGetDTO>(requestBody);

        if (searchParams == null || (string.IsNullOrWhiteSpace(searchParams.TaxId) &&
            string.IsNullOrWhiteSpace(searchParams.FirstName) &&
            string.IsNullOrWhiteSpace(searchParams.LastName) &&
            string.IsNullOrWhiteSpace(searchParams.DisplayName) &&
            string.IsNullOrWhiteSpace(searchParams.BusinessName) &&
            string.IsNullOrWhiteSpace(searchParams.MiddleName) &&
            string.IsNullOrWhiteSpace(searchParams.MarriedSurName))) {
            response.IsSuccess = false;
            response.Message = "Al menos un campo debe ser proporcionado para la búsqueda.";
            return new BadRequestObjectResult(response);
        }

        var query = _db.EntityMasterGenerals.AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchParams.TaxId))
            query = query.Where(x => x.TaxId.Contains(searchParams.TaxId));
        if (!string.IsNullOrWhiteSpace(searchParams.FirstName))
            query = query.Where(x => x.FirstName.Contains(searchParams.FirstName));
        if (!string.IsNullOrWhiteSpace(searchParams.LastName))
            query = query.Where(x => x.LastName.Contains(searchParams.LastName));
        if (!string.IsNullOrWhiteSpace(searchParams.DisplayName))
            query = query.Where(x => x.DisplayName.Contains(searchParams.DisplayName));
        if (!string.IsNullOrWhiteSpace(searchParams.BusinessName))
            query = query.Where(x => x.BusinessName.Contains(searchParams.BusinessName));
        if (!string.IsNullOrWhiteSpace(searchParams.MiddleName))
            query = query.Where(x => x.MiddleName.Contains(searchParams.MiddleName));
        if (!string.IsNullOrWhiteSpace(searchParams.MarriedSurName))
            query = query.Where(x => x.MarriedSurName.Contains(searchParams.MarriedSurName));

        query = query.Take(50);
        var results = await query.ToListAsync();
        if (results == null || results.Count == 0) {
            response.IsSuccess = false;
            response.Message = "No se encontraron resultados para su búsqueda.";
            return new NotFoundObjectResult(response);
        }

        response.Result = _mapper.Map<List<EntityMasterGeneralGetDTO>>(results);
        response.IsSuccess = true;
        return new OkObjectResult(response);
    }

}

