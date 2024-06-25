using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SHM.Domain.Dto;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Enums;
using SHM.Domain.Helper;
using SHM.Domain.Models.Helper;
using SHM.Domain.Models.Sahc0100;
using SHM.Function.Data;
using System;
using System.Threading.Tasks;



namespace Sahc0100.Functions;



public class EntityMasterAddressAdd
{


    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;

    //se inhabilita el mensaje bus para pruebas
    //private readonly IMessageBus _messageBus;


    public EntityMasterAddressAdd(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
        
    }


    [FunctionName("EntityMasterAddressAdd")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)] HttpRequest req, ILogger log)
    {
        try
        {

            return _responseDto = await CreateEntityMasterAddress(req, _responseDto);

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "EntityMasterAddressAdd");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;

        }
    }


    private async Task<ResponseDto> CreateEntityMasterAddress(HttpRequest req, ResponseDto response)
    {

        try
        {

            MapHelper mapHelper = new MapHelper(_mapper);
            string requestBody = await req.ReadAsStringAsync();


            EntityMasterAddressDTO newEntityMasterAddressDTO;


            try
            {

                if (string.IsNullOrEmpty(requestBody))
                {
                    response.IsSuccess = false;
                    response.Message = "El Json para registrar  EntityMasterAddress no es consistente.";
                    return response;
                }

                try
                {
                    newEntityMasterAddressDTO = JsonConvert.DeserializeObject<EntityMasterAddressDTO>(requestBody);
                }
                catch (Exception e)
                {

                    await ElasticAlert.LogErrorToElastic(e, "IsideCreateEntityMasterAddress--EntityMasterAddressAdd");

                    response.IsSuccess = false;
                    response.Message = e.Message;
                    return response;
                }

                //Validamos si existe consistencia del modelo



                //Preparamos el objetos para crear
                newEntityMasterAddressDTO.EntityMasterAddressKey = Guid.NewGuid();
                newEntityMasterAddressDTO.Created = TimeZoneHelperTest.GetPanamaTime();
                EntityMasterAddress newEntityMasterAddress = _mapper.Map<EntityMasterAddress>(newEntityMasterAddressDTO);


                using (var dbContextTransaction = _db.Database.BeginTransaction())
                {

                    try
                    {

                        _db.EntityMasterAddress.Add(newEntityMasterAddress);
                        _db.SaveChanges();
                        dbContextTransaction.Commit();
                        response.Result = newEntityMasterAddressDTO;

                        //MapeoServiceBus
                        ServiceBusDTO newServiceBusDto = new ServiceBusDTO();
                        newServiceBusDto.Method = Method.Post.ToString();
                        newServiceBusDto.Key = newEntityMasterAddressDTO.EntityMasterAddressKey.ToString();
                        newServiceBusDto.Timestamp = newEntityMasterAddressDTO.Created;
                        newServiceBusDto.Action = ActionData.Add.ToString();
                        newServiceBusDto.Api = await mapHelper.GetRoute(Environment.GetEnvironmentVariable("RouteSahc100"), nameof(EntityMasterAddressAdd));
                        newServiceBusDto.MessageId = Guid.NewGuid();

                        //await _messageBus.PublishMessage(newServiceBusDto, Environment.GetEnvironmentVariable("QueuesNameForsahc100"));

                        return response;

                    }
                    catch (Exception e)
                    {

                        await ElasticAlert.LogErrorToElastic(e, "IsideCreateEntityMasterAddress--EntityMasterAddressAdd");

                        dbContextTransaction.Rollback();
                        response.IsSuccess = false;
                        response.Message = e.Message;
                        return response;

                    }

                }


            }
            catch (Exception e)
            {

                await ElasticAlert.LogErrorToElastic(e, "IsideCreateEntityMasterAddress--EntityMasterAddressAdd");

                response.IsSuccess = false;
                response.Message = e.Message;
                return response;

            }

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "IsideCreateEntityMasterAddress--EntityMasterAddressAdd");

            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }
    }


}

