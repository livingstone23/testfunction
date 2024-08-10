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
using System.Linq;
using System.Threading.Tasks;



namespace Sahc0100.Functions;



public class EntityMasterAddressCRUD
{

    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;


    public EntityMasterAddressCRUD(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;

    }


    [FunctionName("EntityMasterAddressCRUD")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post","put", Route = "EntityMasterAddress/{EntityMasterAddressKey:Guid?}")] HttpRequest req, Guid? EntityMasterAddressKey, ILogger log)
    {
        try
        {

            switch (req.Method)
            {

                case "GET":
                    await GetEntityMasterAddress(req, _responseDto);
                    break;
                case "POST":
                    _responseDto = await CreateEntityMasterAddress(req, _responseDto);
                    break;
                case "PUT":
                    _responseDto = await UpdateEntityMasterAddress(req, _responseDto);
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

    private async Task GetEntityMasterAddress(HttpRequest req, ResponseDto response)
    {
        MapHelper mapHelper = new MapHelper(_mapper);
        //MessageHelper messageHelp = new MessageHelper();
        try
        {
            string EntityMasterAddressKey = req.Query["EntityMasterAddressKey"];

            EntityMasterAddress foundEntityMasterGeneralItems;
            
            using (_db)
            {

                if (!string.IsNullOrEmpty(EntityMasterAddressKey))
                {
                    foundEntityMasterGeneralItems = await _db.EntityMasterAddress
                                                    .Include(x => x.Countries)
                                                    .Include(x => x.Provinces)
                                                    .Include(x => x.Districts)
                                                    .Include(x => x.Townships)
                                                    .Include(x => x.SourceMasters)
                                                    .Include(x => x.EntityMasterAddresstypes)
                                                    .Where(x => x.EntityMasterAddressKey == Guid.Parse(EntityMasterAddressKey)).FirstOrDefaultAsync();

                    //EntityMasterGeneralItems = await _db.EntityMasterGenerals.Where(x => x.EntityMasterGeneralKey == Guid.Parse(EntityMasterGeneralKey)).ToListAsync();
                }
                else
                {
                    ///PREGUNTAR SI VAMOS A PAGINAR
                    throw new Exception($"No existen Registros en EntityMasterAddress.");
                }

                if (foundEntityMasterGeneralItems == null)
                {
                    response.IsSuccess = false;
                    response.Message = mapHelper.GetMessageSinRegistros();
                    return;
                }

                EntityMasterAddressDTO foundEntityMasterAddressDTO = _mapper.Map<EntityMasterAddressDTO>(foundEntityMasterGeneralItems);
                response.Result = foundEntityMasterAddressDTO;

            }

        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
        }
    }

    private async Task<ResponseDto> CreateEntityMasterAddress(HttpRequest req, ResponseDto response)
    {

        try
        {

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

    private async Task<ResponseDto> UpdateEntityMasterAddress(HttpRequest req, ResponseDto response)
    {

        try
        {
            return response;
        }
        catch (Exception e)
        {
            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }

    }


}

