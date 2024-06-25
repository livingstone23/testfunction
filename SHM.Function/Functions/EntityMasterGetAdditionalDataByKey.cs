using System;
using System.Linq;
using AutoMapper;
using SHM.Domain.Dto;
using SHM.Function.Data;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.WebJobs.Extensions.Http;
using SHM.Domain.Helper;
using SHM.Domain.Dto.Sahc0100;
using Castle.Core.Resource;

namespace Sahc0100.Functions;

public class EntityMasterGetAdditionalDataByKey {

    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;

    public EntityMasterGetAdditionalDataByKey(FunctionDbContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    [FunctionName("EntityMasterGetAdditionalDataByKey")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "EntityMasterGetAdditionalDataByKey/{EntityMasterGeneralKey:Guid?}")] HttpRequest req, Guid? EntityMasterGeneralKey, ILogger log) {
        try {
            return await GetEntityMasterAdditionalData(EntityMasterGeneralKey);
        } catch (Exception e) {
            await ElasticAlert.LogErrorToElastic(e, "EntityMasterGetAdditionalDataByKey");
            var response = new ResponseDto();
            log.LogError(e, "Error processing EntityMasterGetAdditionalDataByKey");
            response.IsSuccess = false;
            response.Message = "Internal server error.";
            return new BadRequestObjectResult(response);
        }
    }

    private async Task<IActionResult> GetEntityMasterAdditionalData(Guid? entityMasterGeneralKey) {
        var response = new ResponseDto();

        if (entityMasterGeneralKey == null) {
            response.IsSuccess = false;
            response.Message = "Debe proporcionar el id del cliente.";
            return new BadRequestObjectResult(response);
        }

        using (_db) {

            var query = from customer in _db.EntityMasterGenerals
                        join plcc in _db.EntityMasterGeneralPLCC on customer.EntityMasterGeneralKey equals plcc.EntityMasterGeneralKey
                        join agency in _db.EntityMasterGenerals on plcc.AssignedAgency equals agency.EntityMasterGeneralKey into agencyJoin
                        from agency in agencyJoin.DefaultIfEmpty()  // LEFT JOIN para la agencia
                        join agent in _db.EntityMasterGenerals on plcc.AssignedAgent equals agent.EntityMasterGeneralKey into agentJoin
                        from agent in agentJoin.DefaultIfEmpty()  // LEFT JOIN para el agente
                        join masterGroup in _db.EntityMasterGroups on customer.EntityMasterGroupKey equals masterGroup.EntityMasterGroupKey into groupJoin
                        from masterGroup in groupJoin.DefaultIfEmpty()  // LEFT JOIN para la entidad master group
                        where customer.EntityMasterGeneralKey == entityMasterGeneralKey

                        select new EntityMasterAdditionalDataDTO {
                            CustomerDisplayName = customer.DisplayName,
                            AgencyDisplayName = agency.DisplayName,
                            AgentDisplayName = agent.DisplayName,
                            GroupId = masterGroup.Id, 
                            GroupDescription = masterGroup.Description // Agregar la descripción del grupo
                        };

            var results = await query.FirstOrDefaultAsync();

            if (results == null) {
                response.IsSuccess = false;
                response.Message = "No se encontraron resultados para su búsqueda.";
                return new NotFoundObjectResult(response);
            }


            response.Result = results;
            response.IsSuccess = true;
            return new OkObjectResult(response);
        }


    }

}

