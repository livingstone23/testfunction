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
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Sahc0100.Functions;



public class EntityMasterGeneralAdd
{

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;
    


    public EntityMasterGeneralAdd(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
    }


    [FunctionName("EntityMasterGeneralAdd")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)] HttpRequest req, ILogger log)
    {
        try
        {

            return _responseDto = await CreateEntityMasterGeneral(req, _responseDto);

        }
        catch (Exception e)
        {
            
            await ElasticAlert.LogErrorToElastic(e, "EntityMasterGeneralAdd");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;
        }
    }

    private async Task<ResponseDto> CreateEntityMasterGeneral(HttpRequest req, ResponseDto response)
    {

        try
        {
            MapHelper mapHelper = new MapHelper(_mapper);

            string requestBody = await req.ReadAsStringAsync();

            EntityMasterGeneralGetDTO newEntityMasterGeneralDTO;

            try
            {

                if (string.IsNullOrEmpty(requestBody))
                {
                    response.IsSuccess = false;
                    response.Message = "El Json para registrar  EntityMasterGeneral no es consistente.";
                    return response;
                }

                try
                {
                    newEntityMasterGeneralDTO = JsonConvert.DeserializeObject<EntityMasterGeneralGetDTO>(requestBody);
                }
                catch (Exception e)
                {

                    await ElasticAlert.LogErrorToElastic(e, "InsideCreateEntityMasterGeneral--EntityMasterGeneralAdd");

                    response.IsSuccess = false;
                    response.Message = e.Message;
                    return response;
                }

                //Validamos si ya existe la cedula
                EntityMasterGeneral entityMasterFound = await _db.EntityMasterGenerals.Where(e => e.IdType == newEntityMasterGeneralDTO.IdType && e.TaxId == newEntityMasterGeneralDTO.TaxId).FirstOrDefaultAsync();

                if (entityMasterFound != null)
                {
                    response.IsSuccess = false;
                    response.Message = $"EntityMaster ya existe con el entityMasterKey {entityMasterFound.EntityMasterGeneralKey}";
                    return response;
                }
                


                //Validamos si existe consistencia del modelo



                //Preparamos el objetos para crear
                newEntityMasterGeneralDTO.EntityMasterGeneralKey = Guid.NewGuid();
                newEntityMasterGeneralDTO.Created = TimeZoneHelperTest.GetPanamaTime();
                EntityMasterGeneral newEntityMasterGeneral = _mapper.Map<EntityMasterGeneral>(newEntityMasterGeneralDTO);

                using (var dbContextTransaction = _db.Database.BeginTransaction())
                {
                    try
                    {

                        _db.EntityMasterGenerals.Add(newEntityMasterGeneral);
                        _db.SaveChanges();
                        dbContextTransaction.Commit();
                        response.Result = newEntityMasterGeneralDTO;

                        //MapeoServiceBus
                        ServiceBusDTO newServiceBusDto = new ServiceBusDTO();
                        newServiceBusDto.Method = Method.Post.ToString();
                        newServiceBusDto.Key = newEntityMasterGeneralDTO.EntityMasterGeneralKey.ToString();
                        newServiceBusDto.Timestamp = newEntityMasterGeneralDTO.Created;
                        newServiceBusDto.Action = ActionData.Add.ToString();
                        newServiceBusDto.Api = await mapHelper.GetRoute(Environment.GetEnvironmentVariable("RouteSahc100"), nameof(EntityMasterGeneralAdd));
                        newServiceBusDto.MessageId = Guid.NewGuid();
                        


                        if (newEntityMasterGeneralDTO.CreateB2CUser == true)
                        {

                            int b2cFound = await _db.EntityMasterGenerals.Where(e => e.Email == newEntityMasterGeneralDTO.Email  && e.B2CKey != null).CountAsync();
                            if (b2cFound >0 )
                            {

                                response.Message += $", Ya existe Usuario B2C con el Email: {newEntityMasterGeneralDTO.Email}";
                                return response;
                            }

                            //Obtenemos el total de usuario con el mismo nombre y que contienen un usuairo B2C
                            int totalEntity = await _db.EntityMasterGenerals.Where(e => e.FirstName == newEntityMasterGeneralDTO.FirstName && e.LastName == newEntityMasterGeneralDTO.LastName && e.B2CKey != null).CountAsync();


                            B2CUserDTO b2cUserCreated = await B2C.RegisterNewUser(newEntityMasterGeneralDTO, totalEntity);

                            if (b2cUserCreated != null)
                            {
                                try
                                {

                                    newEntityMasterGeneral.B2CKey = b2cUserCreated.B2CKey;
                                    newEntityMasterGeneral.B2CUser = b2cUserCreated.B2CUser;
                                    _db.Entry(newEntityMasterGeneral).State = EntityState.Modified;
                                    await _db.SaveChangesAsync();
                                    response.Result = newEntityMasterGeneral;

                                }
                                catch (Exception e)
                                {
                                    await ElasticAlert.LogErrorToElastic(e, "InsideCreateEntityMasterGeneral--EntityMasterGeneralAdd");
                                    response.IsSuccess = false;
                                    response.Message = e.Message;
                                    return response;
                                }
                            }
                        }


                        return response;

                    }
                    catch (Exception e)
                    {
                        
                        await ElasticAlert.LogErrorToElastic(e, "InsideCreateEntityMasterGeneral--EntityMasterGeneralAdd");
                        
                        dbContextTransaction.Rollback();
                        response.IsSuccess = false;
                        response.Message = e.Message;
                        return response;
                    }
                }

            }
            catch (Exception e)
            {

                await ElasticAlert.LogErrorToElastic(e, "InsideCreateEntityMasterGeneral--EntityMasterGeneralAdd");
                
                response.IsSuccess = false;
                response.Message = e.Message;
                return response;
            }


        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "InsideCreateEntityMasterGeneral--EntityMasterGeneralAdd");

            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }
}

