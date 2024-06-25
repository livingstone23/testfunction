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



public class EntityMasterGeneralUpdate
{

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;


    public EntityMasterGeneralUpdate(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
    }


    [FunctionName("EntityMasterGeneralUpdate")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req, ILogger log)
    {
        try
        {

            return _responseDto = await UpdateEntityMasterGenerals(req, _responseDto);

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "EntityMasterGeneralUpdate");
            
            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;
        }
    }


    private async Task<ResponseDto> UpdateEntityMasterGenerals(HttpRequest req, ResponseDto response)
    {

        try
        {
            MapHelper mapHelper = new MapHelper(_mapper);
            //string EntityMasterGeneralKey = req.Query["EntityMasterGeneralKey"];

            string requestBody = await req.ReadAsStringAsync();

            if (string.IsNullOrEmpty(requestBody))
            {
                response.IsSuccess = false;
                response.Message = "No se obtiene el objeto del JSON para la actualización. ";
                return response;
            }

            EntityMasterGeneralDTO EntityMasterGeneralSend = new EntityMasterGeneralDTO();

            try
            {
                var EntityMasterGeneralCatch = JsonConvert.DeserializeObject<EntityMasterGeneralGetDTO>(requestBody);

                //Convertimos la serializada
                EntityMasterGeneralSend = _mapper.Map<EntityMasterGeneralDTO>(EntityMasterGeneralCatch);


                if (EntityMasterGeneralSend == null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se obtiene el ID del Objeto a Editar. ";
                    return response;
                }

                EntityMasterGeneral EntityMasterGeneralFound = await _db.EntityMasterGenerals
                                                                .Include(x => x.Country)
                                                                .Include(x => x.CivilStatus)
                                                                .Where(x => x.EntityMasterGeneralKey == EntityMasterGeneralSend.EntityMasterGeneralKey)
                                                                .FirstOrDefaultAsync();


                if (EntityMasterGeneralFound == null)
                {
                    response.IsSuccess = false;
                    response.Message = "No se obtiene registro almacenado a actualizar. ";
                    return response;
                }

                //Actualizamos las propiedades de los objetos.
                EntityMasterGeneralFound.FirstName = EntityMasterGeneralSend.FirstName;
                EntityMasterGeneralFound.MiddleName = EntityMasterGeneralSend.MiddleName;
                EntityMasterGeneralFound.LastName = EntityMasterGeneralSend.LastName;
                EntityMasterGeneralFound.MiddleLastName = EntityMasterGeneralSend.MiddleLastName;
                EntityMasterGeneralFound.MarriedSurName = EntityMasterGeneralSend.MarriedSurName;
                EntityMasterGeneralFound.DisplayName = EntityMasterGeneralSend.DisplayName;
                EntityMasterGeneralFound.BusinessName = EntityMasterGeneralSend.BusinessName;
                EntityMasterGeneralFound.CountryKey = EntityMasterGeneralSend.CountryKey;
                EntityMasterGeneralFound.BirthDay = EntityMasterGeneralSend.BirthDay;
                EntityMasterGeneralFound.Email = EntityMasterGeneralSend.Email;
                EntityMasterGeneralFound.Type = EntityMasterGeneralSend.Type.Value;
                EntityMasterGeneralFound.IdType = EntityMasterGeneralSend.IdType.Value;
                EntityMasterGeneralFound.TaxId = EntityMasterGeneralSend.TaxId;
                EntityMasterGeneralFound.TaxId1 = EntityMasterGeneralSend.TaxId1;
                EntityMasterGeneralFound.Gender = EntityMasterGeneralSend.Gender;
                EntityMasterGeneralFound.Mobile = EntityMasterGeneralSend.Mobile;
                EntityMasterGeneralFound.MobileCountryKey = EntityMasterGeneralSend.MobileCountryKey;
                EntityMasterGeneralFound.Telephone = EntityMasterGeneralSend.Telephone;
                EntityMasterGeneralFound.TelephoneCountryKey = EntityMasterGeneralSend.TelephoneCountryKey;
                EntityMasterGeneralFound.ApcDate = EntityMasterGeneralSend.ApcDate;
                EntityMasterGeneralFound.EntityMasterGeneralKey = EntityMasterGeneralSend.EntityMasterGeneralKey;
                EntityMasterGeneralFound.CivilStatusKey = EntityMasterGeneralSend.CivilStatusKey;
                EntityMasterGeneralFound.EntityMasterGroupKey = EntityMasterGeneralSend.EntityMasterGroupKey;
                EntityMasterGeneralFound.Modified = TimeZoneHelperTest.GetPanamaTime();
                EntityMasterGeneralFound.ModifiedBy = EntityMasterGeneralSend.ModifiedBy;


                using (var dbContextTransaction = _db.Database.BeginTransaction())
                {
                    try
                    {

                        _db.Entry(EntityMasterGeneralFound).State = EntityState.Modified;
                        await _db.SaveChangesAsync();
                        dbContextTransaction.Commit();

                        var updateEntityMasterGeneral = await _db.EntityMasterGenerals
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
                                                                    .Where(x => x.EntityMasterGeneralKey == EntityMasterGeneralFound.EntityMasterGeneralKey)
                                                                    .FirstOrDefaultAsync();


                        response.Result = _mapper.Map<EntityMasterGeneralDTO>(updateEntityMasterGeneral);

                        //MapeoServiceBus
                        ServiceBusDTO newServiceBusDto = new ServiceBusDTO();
                        newServiceBusDto.Method = Method.Put.ToString();
                        newServiceBusDto.Key = EntityMasterGeneralFound.EntityMasterGeneralKey.ToString();
                        newServiceBusDto.Timestamp = EntityMasterGeneralFound.Modified;
                        newServiceBusDto.Action = ActionData.Update.ToString();
                        newServiceBusDto.Api = await mapHelper.GetRoute(Environment.GetEnvironmentVariable("RouteSahc100"), nameof(EntityMasterGeneralUpdate));
                        newServiceBusDto.MessageId = Guid.NewGuid();


                    }
                    catch (Exception e)
                    {

                        await ElasticAlert.LogErrorToElastic(e, "InsideUpdateEntityMasterGenerals--EntityMasterGeneralUpdate");

                        dbContextTransaction.Rollback();
                        response.IsSuccess = false;
                        response.Message = e.Message;
                    }
                }


            }
            catch (Exception e)
            {

                await ElasticAlert.LogErrorToElastic(e, "InsideUpdateEntityMasterGenerals--EntityMasterGeneralUpdate");

                response.IsSuccess = false;
                response.Message = e.Message;
                return response;
            }

        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "InsideUpdateEntityMasterGenerals--EntityMasterGeneralUpdate");

            response.IsSuccess = false;
            response.Message = e.Message;
        }

        return response;

    }

}

