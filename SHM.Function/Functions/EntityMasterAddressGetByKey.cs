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



public class EntityMasterAddressGetByKey
{


    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;


    public EntityMasterAddressGetByKey(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;

    }


    [FunctionName("EntityMasterAddressGetByKey")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "EntityMasterAddressGetByKey/{EntityMasterAddressKey:Guid?}")] HttpRequest req, Guid? EntityMasterAddressKey, ILogger log)
    {
        try
        {

            return _responseDto = await GetEntityMasterAddress(EntityMasterAddressKey, _responseDto);

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "EntityMasterAddressGetByKey");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;
        }
    }

    private async Task<ResponseDto> GetEntityMasterAddress(Guid? EntityMasterAddressKey, ResponseDto response)
    {

        MapHelper mapHelper = new MapHelper(_mapper);

        try
        {

            EntityMasterAddress EntityMasterAddressItem = new EntityMasterAddress();

            using (_db)
            {


                if (EntityMasterAddressKey != null)
                {
                    EntityMasterAddressItem = await _db.EntityMasterAddress
                                                        .Include(x => x.Countries)
                                                        .Include(x => x.Provinces)
                                                        .Include(x => x.Districts)
                                                        .Include(x => x.Townships)
                                                        .Include(x => x.SourceMasters)
                                                        .Include(x => x.EntityMasterAddresstypes)
                                                        .Where(x => x.EntityMasterAddressKey == EntityMasterAddressKey)
                                                        .FirstOrDefaultAsync();


                }



                if (EntityMasterAddressItem == null)
                {
                    response.IsSuccess = false;
                    response.Message = mapHelper.GetMessageSinRegistros();
                    return response;
                }

                EntityMasterAddressDTO entityMasterAddressDTO = _mapper.Map<EntityMasterAddressDTO>(EntityMasterAddressItem);

                response.Result = entityMasterAddressDTO;
                return response;
            }


        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "InsideGetEntityMasterAddress--EntityMasterAddressGetByKey");
            
            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }

}

