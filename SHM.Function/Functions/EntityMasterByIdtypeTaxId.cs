using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SHM.Domain.Dto;
using SHM.Domain.Dto.Sahc0100;
using SHM.Domain.Helper;
using SHM.Domain.Models.Sahc0100;
using SHM.Function.Data;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace Sahc0100.Functions;



public class EntityMasterByIdtypeTaxId
{


    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;


    public EntityMasterByIdtypeTaxId(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
    }


    [FunctionName("EntityMasterByIdtypeTaxId")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "EntityMasterByIdtypeTaxId/{Idtype:int?}/{TaxId?}")] HttpRequest req,int? Idtype,string TaxId, ILogger log)
    {
        try
        {

            await GetByIdtypeTaxIdEntityMaster(Idtype, TaxId, _responseDto);

        }
        catch (Exception e)
        {
            
            await ElasticAlert.LogErrorToElastic(e, "EntityMasterByIdtypeTaxId");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            
        }
        return _responseDto;
    }
    

    private async Task<ResponseDto> GetByIdtypeTaxIdEntityMaster(int? Idtype, string TaxId, ResponseDto response)
    {

        MapHelper mapHelper = new MapHelper(_mapper);
        try
        {
            
            if(Idtype == null)
            {
                response.IsSuccess = false;
                response.Message = "El tipo identificación no puede ser nulo";
                return response;
            }

            if (string.IsNullOrEmpty(TaxId))
            {
                response.IsSuccess = false;
                response.Message = "El número de identificación no puede ser nulo";
                return response;
            }
            

            EntityMasterGeneral EntityMasterGeneralItem = await _db.EntityMasterGenerals
                                                                    .Include(x =>x.Country)
                                                                    .Include(x =>x.CivilStatus)
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
                                                                    .Where(x => x.IdType == Idtype && x.TaxId == TaxId)
                                                                    .FirstOrDefaultAsync();


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
        catch (Exception e)
        {
            
            await ElasticAlert.LogErrorToElastic(e, "InsideGetByIdtypeTaxIdEntityMaster--EntityMasterByIdtypeTaxId");
            
            response.IsSuccess = false;
            response.Message = e.Message;
            return response;
        }
        
    }

}
