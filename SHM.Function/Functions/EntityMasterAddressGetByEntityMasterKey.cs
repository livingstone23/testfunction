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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Sahc0100.Functions;



public class EntityMasterAddressGetByEntityMasterKey
{
    

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;

    
    public EntityMasterAddressGetByEntityMasterKey(FunctionDbContext db, IMapper mapper)
    {

        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;

    }
    
    
    [FunctionName("EntityMasterAddressGetByEntityMasterKey")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "EntityMasterAddressGetByEntityMasterKey/{EntityMasterGeneralKey:Guid?}")] HttpRequest req, Guid? EntityMasterGeneralKey, ILogger log)
    {
        try
        {

            return _responseDto = await GetEntityMasterAddress(EntityMasterGeneralKey, _responseDto);

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "EntityMasterAddressGetByEntityMasterKey");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;
        }
    }


    private async Task<ResponseDto> GetEntityMasterAddress(Guid? EntityMasterGeneralKey, ResponseDto response)
    {

        MapHelper mapHelper = new MapHelper(_mapper);

        try
        {

            List<EntityMasterAddress> EntityMasterAddressList = new List<EntityMasterAddress>();

            using (_db)
            {


                if (EntityMasterGeneralKey != null)
                {


                    EntityMasterAddressList = await _db.EntityMasterAddress
                                                            .Include(x => x.Countries)
                                                            .Include(x => x.Provinces)
                                                            .Include(x => x.Districts)
                                                            .Include(x => x.Townships)
                                                            .Include(x => x.SourceMasters)
                                                            .Include(x => x.EntityMasterAddresstypes)
                                                            .Where(x => x.EntityMasterGeneralKey == EntityMasterGeneralKey)
                                                            .ToListAsync();
                        
                        
                }



                if (!EntityMasterAddressList.Any())
                {
                    response.IsSuccess = false;
                    response.Message = mapHelper.GetMessageSinRegistros();
                    return response;
                }

                List<EntityMasterAddressDTO> entityMasterAddressDTO = _mapper.Map<List<EntityMasterAddressDTO>>(EntityMasterAddressList);

                response.Result = entityMasterAddressDTO;
                return response;

            }


        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "InsideGetEntityMasterAddress--EntityMasterAddressGetByEntityMasterKey");

            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }


}

