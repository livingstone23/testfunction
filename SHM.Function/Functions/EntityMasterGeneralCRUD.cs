using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SHM.Domain.Dto;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Helper;
using SHM.Domain.Models.Sahc0100;
using SHM.Function.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sahc0100.Functions;

public  class EntityMasterGeneralCRUD
{

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;



    public EntityMasterGeneralCRUD(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
    }


    [FunctionName("EntityMasterGeneralCRUD")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post","put", Route = "EntityMasterGeneral/{EntityMasterGeneralKey:Guid?}")] HttpRequest req,Guid? EntityMasterGeneralKey, ILogger log)
    {
        try
        {

            switch (req.Method)
            {
                
                case "GET":
                    await GetEntityMasterGeneral(req, _responseDto); 
                    break;
                case "POST":
                    _responseDto = await CreateEntityMasterGeneral(req, _responseDto);
                    break;
                case "PUT":
                    _responseDto = await UpdateEntityMasterGeneral(req, _responseDto);
                    break;

            }
            
            return _responseDto;
            
        }
        catch (Exception e)
        {
            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;
        }
    }


    private async Task GetEntityMasterGeneral(HttpRequest req, ResponseDto response)
    {
        MapHelper mapHelper = new MapHelper(_mapper);
        try
        {
            
            string EntityMasterGeneralKey = req.Query["EntityMasterGeneralKey"];

            List<EntityMasterGeneral> EntityMasterGeneralItems;

            using(_db)
            {
                
                if(!string.IsNullOrEmpty(EntityMasterGeneralKey))
                {
                    EntityMasterGeneralItems = await _db.EntityMasterGenerals
                        .Include(x => x.Country)
                        .Include(x => x.CivilStatus)
                        .Where(x => x.EntityMasterGeneralKey == Guid.Parse(EntityMasterGeneralKey)).ToListAsync();

                    //EntityMasterGeneralItems = await _db.EntityMasterGenerals.Where(x => x.EntityMasterGeneralKey == Guid.Parse(EntityMasterGeneralKey)).ToListAsync();
                }
                else
                {
                    ///PREGUNTAR SI VAMOS A PAGINAR
                    throw new Exception($"No existen Registros de EntityMasterGeneralItems.");
                }
                

                if(EntityMasterGeneralItems == null)
                {
                    response.IsSuccess = false;
                    response.Message = mapHelper.GetMessageSinRegistros();
                    return;
                }
                
                List<EntityMasterGeneralDTO> ListEntityMasterGeneralDTO = _mapper.Map<List<EntityMasterGeneralDTO>>(EntityMasterGeneralItems);
                
                response.Result = ListEntityMasterGeneralDTO;    

            }
        }
        catch (Exception e)
        {
            
            response.IsSuccess = false;
            response.Message = e.Message;
            return;
        }

    }


    private async Task<ResponseDto> CreateEntityMasterGeneral(HttpRequest req, ResponseDto response)
    {

        try
        {
            
            string requestBody = await req.ReadAsStringAsync();

            EntityMasterGeneralDTO newEntityMasterGeneralDTO;

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
                    newEntityMasterGeneralDTO = JsonConvert.DeserializeObject<EntityMasterGeneralDTO>(requestBody);
                }
                catch (Exception e)
                {
                    response.IsSuccess = false;
                    response.Message = e.Message;
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
                        return response;

                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        response.IsSuccess = false;
                        response.Message = e.Message;
                        return response;
                    }
                }

            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
                return response;
            }
            

        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }


    private async  Task<ResponseDto> UpdateEntityMasterGeneral(HttpRequest req, ResponseDto response)
    {

        try
        {
            
            string EntityMasterGeneralKey = req.Query["EntityMasterGeneralKey"];

            string requestBody = await req.ReadAsStringAsync();

            EntityMasterGeneralDTO EntityMasterGeneralSend = new EntityMasterGeneralDTO();

            if (string.IsNullOrEmpty(EntityMasterGeneralKey))
            {
                response.IsSuccess = false;
                response.Message = "No se obtiene el ID del Objeto a Editar. ";
                return response;
            }

            EntityMasterGeneral EntityMasterGeneral = await _db.EntityMasterGenerals
                                                                .Include(x => x.Country)
                                                                .Include(x => x.CivilStatus)
                                                                .Where(x => x.EntityMasterGeneralKey == Guid.Parse(EntityMasterGeneralKey))
                                                                .FirstOrDefaultAsync();

            if (EntityMasterGeneral == null)
            {
                response.IsSuccess = false;
                response.Message = "No se obtiene registro almacenado a actualizar. ";
                return response;
            }

            if (string.IsNullOrEmpty(requestBody))
            {
                response.IsSuccess = false;
                response.Message = "No se obtiene el objeto del JSON para la actualizar. ";
                return response;
            }

            try
            {
                EntityMasterGeneralSend = JsonConvert.DeserializeObject<EntityMasterGeneralDTO>(requestBody);
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
                return response;
            }

            //Validamos si existe consistencia del modelo.

            

            //Actualizamos las propiedades de los objetos.
            EntityMasterGeneral.FirstName = EntityMasterGeneralSend.FirstName;
            EntityMasterGeneral.MiddleName = EntityMasterGeneralSend.MiddleName;
            EntityMasterGeneral.LastName = EntityMasterGeneralSend.LastName;
            EntityMasterGeneral.MiddleLastName = EntityMasterGeneralSend.MiddleLastName;
            EntityMasterGeneral.MarriedSurName = EntityMasterGeneralSend.MarriedSurName;
            EntityMasterGeneral.DisplayName = EntityMasterGeneralSend.DisplayName;
            EntityMasterGeneral.BusinessName = EntityMasterGeneralSend.BusinessName;
            EntityMasterGeneral.CountryKey = EntityMasterGeneralSend.CountryKey;
            EntityMasterGeneral.BirthDay = EntityMasterGeneralSend.BirthDay;
            EntityMasterGeneral.Email = EntityMasterGeneralSend.Email;
            EntityMasterGeneral.Type = EntityMasterGeneralSend.Type.Value;
            EntityMasterGeneral.IdType = EntityMasterGeneralSend.IdType.Value;
            EntityMasterGeneral.TaxId = EntityMasterGeneralSend.TaxId;
            EntityMasterGeneral.TaxId1 = EntityMasterGeneralSend.TaxId1;
            EntityMasterGeneral.Gender = EntityMasterGeneralSend.Gender;
            EntityMasterGeneral.Mobile = EntityMasterGeneralSend.Mobile;
            EntityMasterGeneral.MobileCountryKey = EntityMasterGeneralSend.MobileCountryKey;
            EntityMasterGeneral.Telephone = EntityMasterGeneralSend.Telephone;
            EntityMasterGeneral.TelephoneCountryKey = EntityMasterGeneralSend.TelephoneCountryKey;
            EntityMasterGeneral.ApcDate = EntityMasterGeneralSend.ApcDate;
            EntityMasterGeneral.EntityMasterGeneralKey = EntityMasterGeneralSend.EntityMasterGeneralKey;
            EntityMasterGeneral.CivilStatusKey = EntityMasterGeneralSend.CivilStatusKey;
            EntityMasterGeneral.EntityMasterGroupKey = EntityMasterGeneralSend.EntityMasterGroupKey;
            EntityMasterGeneral.Modified = TimeZoneHelperTest.GetPanamaTime();
            EntityMasterGeneral.ModifiedBy = EntityMasterGeneralSend.ModifiedBy;


            using (var dbContextTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    
                    _db.Entry(EntityMasterGeneral).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    dbContextTransaction.Commit();

                    var updateEntityMasterGeneral = await _db.EntityMasterGenerals
                                                            .Include(x => x.Country)
                                                            .Include(x => x.CivilStatus)
                                                            .Where(x => x.EntityMasterGeneralKey == EntityMasterGeneral.EntityMasterGeneralKey)
                                                            .FirstOrDefaultAsync();

                    
                    response.Result = _mapper.Map<EntityMasterGeneralDTO>(updateEntityMasterGeneral); ;

                }
                catch (Exception e)
                {
                    dbContextTransaction.Rollback();
                    response.IsSuccess = false;
                    response.Message = e.Message;
                }
            }

        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
        }

        return response;

    }


}


