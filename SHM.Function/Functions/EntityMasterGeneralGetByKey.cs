using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SHM.Domain.Dto;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Helper;
using SHM.Domain.Models.Helper;
using SHM.Domain.Models.Sahc0100;
using SHM.Function.Data;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace Sahc0100.Functions;



public class EntityMasterGeneralGetByKey
{
    

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;
    

    public EntityMasterGeneralGetByKey(FunctionDbContext db, IMapper mapper)
    {

        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;

    }

    
    [FunctionName("EntityMasterGeneralGetByKey")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function,  "get", Route = "EntityMasterGeneralGetByKey/{EntityMasterGeneralKey:Guid?}")] HttpRequest req, Guid? EntityMasterGeneralKey, ILogger log)
    {

        try
        {

            return _responseDto = await GetEntityMasterGeneral(EntityMasterGeneralKey, _responseDto);

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "EntityMasterGeneralGetByKey");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;

        }

    }


    private async Task<ResponseDto> GetEntityMasterGeneral(Guid? EntityMasterGeneralKey, ResponseDto response)
    {

        MapHelper mapHelper = new MapHelper(_mapper);
        
        try
        {

            EntityMasterGeneral EntityMasterGeneralItem = new EntityMasterGeneral();

            using (_db)
            {

                if (EntityMasterGeneralKey != null)
                {

                    EntityMasterGeneralItem = await _db.EntityMasterGenerals
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
                                                    .Where(x => x.EntityMasterGeneralKey == EntityMasterGeneralKey)
                                                    .FirstOrDefaultAsync();
                    
                }
                


                if (EntityMasterGeneralItem == null)
                {
                    response.IsSuccess = false;
                    response.Message = mapHelper.GetMessageSinRegistros();
                    return response;
                }

                EntityMasterGeneralGetDTO entityMasterGeneralDTO = _mapper.Map<EntityMasterGeneralGetDTO>(EntityMasterGeneralItem);

                if (EntityMasterGeneralItem.EntityMasterAddresses.Any())
                {
                    mapHelper.MapEntityMasterGeneral(entityMasterGeneralDTO, EntityMasterGeneralItem.EntityMasterAddresses);
                }

                response.Result = entityMasterGeneralDTO;
                return response;

            }

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "InsideGetEntityMasterGeneral--EntityMasterGeneralGetByKey");

            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }


}

