using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SHM.Domain.Dto;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Enums;
using SHM.Domain.Helper;
using SHM.Domain.Models.Sahc0100;
using SHM.Function.Data;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace Sahc0100.Functions;



public  class EntityMasterAddressUpdate
{


    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;
    //private readonly IMessageBus _messageBus;


    public EntityMasterAddressUpdate(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
        
    }



    [FunctionName("EntityMasterAddressUpdate")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req, ILogger log)
    {
        try
        {

            return _responseDto = await UpdateEntityMasterAdress(req, _responseDto);

        }
        catch (Exception e)
        {
            
            await ElasticAlert.LogErrorToElastic(e, "EntityMasterAddressUpdate");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;

        }
    }


    private async Task<ResponseDto> UpdateEntityMasterAdress(HttpRequest req, ResponseDto response)
    {

        try
        {
            MapHelper mapHelper = new MapHelper(_mapper);

            string requestBody = await req.ReadAsStringAsync();

            if (string.IsNullOrEmpty(requestBody))
            {
                response.IsSuccess = false;
                response.Message = "No se obtiene el objeto del JSON para la actualización. ";
                return response;
            }

            EntityMasterAddressDTO EntityMasterAddressSend = new EntityMasterAddressDTO();


            try
            {

                EntityMasterAddressSend = JsonConvert.DeserializeObject<EntityMasterAddressDTO>(requestBody);


                if (EntityMasterAddressSend == null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se obtiene el ID del Objeto a Editar. ";
                    return response;
                }


                EntityMasterAddress EntityMasterAddressFound = await _db.EntityMasterAddress
                                                                        .Include(x => x.Countries)
                                                                        .Include(x => x.Provinces)
                                                                        .Include(x => x.Districts)
                                                                        .Include(x => x.Townships)
                                                                        .Include(x => x.SourceMasters)
                                                                        .Include(x => x.EntityMasterAddresstypes)
                                                                        .Where(x => x.EntityMasterAddressKey == EntityMasterAddressSend.EntityMasterAddressKey)
                                                                        .FirstOrDefaultAsync();


                if (EntityMasterAddressFound == null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se obtiene registro almacenado a actualizar. ";
                    return response;
                }


                //Actualizamos las propiedades de los objetos.
                EntityMasterAddressFound.EntityMasterGeneralKey = EntityMasterAddressSend.EntityMasterGeneralKey;
                EntityMasterAddressFound.CountryKey = EntityMasterAddressSend.CountryKey;
                EntityMasterAddressFound.ProvinceKey = EntityMasterAddressSend.ProvinceKey;
                EntityMasterAddressFound.DistrictKey = EntityMasterAddressSend.DistrictKey;
                EntityMasterAddressFound.TownshipKey = EntityMasterAddressSend.TownshipKey;
                EntityMasterAddressFound.AddressName = EntityMasterAddressSend.AddressName;
                EntityMasterAddressFound.Active = EntityMasterAddressSend.Active;
                EntityMasterAddressFound.SourceMasterKey = EntityMasterAddressSend.SourceMasterKey;
                EntityMasterAddressFound.EntityMasterAddressKey = EntityMasterAddressSend.EntityMasterAddressKey;
                EntityMasterAddressFound.Modified = TimeZoneHelperTest.GetPanamaTime();
                EntityMasterAddressFound.ModifiedBy = EntityMasterAddressSend.ModifiedBy;


                using (var dbContextTransaction = _db.Database.BeginTransaction())
                {
                    try
                    {

                        _db.Entry(EntityMasterAddressFound).State = EntityState.Modified;
                        await _db.SaveChangesAsync();
                        dbContextTransaction.Commit();


                        var updateEntityMasterAddress = await _db.EntityMasterAddress
                                                                    .Include(x => x.Countries)
                                                                    .Include(x => x.Provinces)
                                                                    .Include(x => x.Districts)
                                                                    .Include(x => x.Townships)
                                                                    .Include(x => x.SourceMasters)
                                                                    .Include(x => x.EntityMasterAddresstypes)
                                                                    .Where(x => x.EntityMasterAddressKey == EntityMasterAddressSend.EntityMasterAddressKey)
                                                                    .FirstOrDefaultAsync();


                        response.Result = _mapper.Map<EntityMasterAddressDTO>(updateEntityMasterAddress);


                        //MapeoServiceBus
                        ServiceBusDTO newServiceBusDto = new ServiceBusDTO();
                        newServiceBusDto.Method = Method.Put.ToString();
                        newServiceBusDto.Key = EntityMasterAddressFound.EntityMasterAddressKey.ToString();
                        newServiceBusDto.Timestamp = EntityMasterAddressFound.Modified;
                        newServiceBusDto.Action = ActionData.Add.ToString();
                        newServiceBusDto.Api = await mapHelper.GetRoute(Environment.GetEnvironmentVariable("RouteSahc100"), nameof(EntityMasterAddressAdd));
                        newServiceBusDto.MessageId = Guid.NewGuid();

                        

                    }
                    catch (Exception e)
                    {

                        await ElasticAlert.LogErrorToElastic(e, "InsideUpdateEntityMasterAdress--EntityMasterAddressUpdate");

                        dbContextTransaction.Rollback();
                        response.IsSuccess = false;
                        response.Message = e.Message;
                        return response;
                    }
                } 

            }
            catch (Exception e)
            {

                await ElasticAlert.LogErrorToElastic(e, "InsideUpdateEntityMasterAdress--EntityMasterAddressUpdate");
                
                response.IsSuccess = false;
                response.Message = e.Message;
                return response;
            }

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "InsideUpdateEntityMasterAdress--EntityMasterAddressUpdate");
            
            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;
        }

        return response;

    }
}

