using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SHM.Domain.Dto;
using SHM.Function.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHM.Domain.Dto.Sahc0106;
using SHM.Domain.Models.Sahc0108;

namespace SHM.Function.Functions
{
    //public class RelationshipCRUD
    //{

    //    private ResponseDto _responseDto;
    //    private readonly FunctionDbContext _db;
    //    private readonly IMapper _mapper;

    //    public RelationshipCRUD(FunctionDbContext db, IMapper mapper)
    //    {
    //        this._responseDto = new ResponseDto();
    //        _db = db;
    //        _mapper = mapper;
    //    }

    //    [FunctionName("RelationshipCRUD")]
    //    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", "put", Route = "Relationship/{key:Guid?}")] HttpRequest req, Guid? key, ILogger log)
    //    {
    //        //ResponseDto responseDto = new ResponseDto();
    //        try
    //        {
    //            log.LogInformation("C# HTTP trigger function processed a request.");


    //            switch (req.Method)
    //            {
    //                case "GET":
    //                    await GetRelationship(req, _responseDto);
    //                    break;
    //                case "POST":
    //                    await CreateRelationship(req, _responseDto);
    //                    break;
    //                case "PUT":
    //                    await UpdateRelationship(req, _responseDto);
    //                    break;

    //            }

    //            return _responseDto;

    //        }
    //        catch (Exception e)
    //        {
    //            _responseDto.IsSuccess = false;
    //            _responseDto.Message = e.Message;
    //            return _responseDto;
    //        }
    //    }


    //    private async Task GetRelationship(HttpRequest req, ResponseDto response)
    //    {

    //        string key = req.Query["key"];

    //        List<RelationshipType> Relationship;

    //        using (_db)
    //        {
    //            if (string.IsNullOrEmpty(key))
    //            {
    //                Relationship = _db.Relationships.ToList();
    //            }
    //            else
    //            {
    //                Relationship = _db.Relationships.Where(x => x.RelationshipTypeKey == Guid.Parse(key)).ToList();
    //            }

    //            if (Relationship == null)
    //            {
    //                throw new Exception($"No existen status civiles creados.");
    //            }

    //            List<RelationshipTypeDTO> ListCivilStatusDtos = new List<RelationshipTypeDTO>();
    //            foreach (var reg in Relationship)
    //            {
    //                ListCivilStatusDtos.Add(_mapper.Map<RelationshipTypeDTO>(reg));
    //            }

    //            response.Result = ListCivilStatusDtos;
    //        }
    //    }

    //    private async Task CreateRelationship(HttpRequest req, ResponseDto response)
    //    {
    //        string requestBody = await req.ReadAsStringAsync();

    //        RelationshipTypeDTO newRelationDTO;
    //        try
    //        {
    //            if (string.IsNullOrEmpty(requestBody))
    //            {
    //                response.IsSuccess = false;
    //                response.Message = "El Json para la creación no es consistente.";
    //                return;
    //            }

    //            try
    //            {
    //                newRelationDTO = JsonConvert.DeserializeObject<RelationshipTypeDTO>(requestBody);
    //            }
    //            catch (Exception e)
    //            {
    //                response.IsSuccess = false;
    //                response.Message = e.Message;
    //                return;
    //            }

    //            newRelationDTO.Active = true;
    //            newRelationDTO.RelationshipTypeKey = Guid.NewGuid();
    //            newRelationDTO.Created = DateTime.Now;
    //            newRelationDTO.CreatedBy = Guid.NewGuid();
    //            newRelationDTO.Modified = DateTime.Now;
    //            RelationshipType newRelationship = _mapper.Map<RelationshipType>(newRelationDTO);
    //            try
    //            {
    //                _db.Relationships.Add(newRelationship);
    //                _db.SaveChanges();
    //            }
    //            catch (Exception e)
    //            {
    //                response.IsSuccess = false;
    //                response.Message = e.Message;
    //                return;
    //            }


    //        }
    //        catch (Exception e)
    //        {
    //            response.IsSuccess = false;
    //            response.Message = e.Message;
    //            return;
    //        }

    //    }

    //    private async Task UpdateRelationship(HttpRequest req, ResponseDto response)
    //    {
    //        string key = req.Query["key"];
    //        string requestBody = await req.ReadAsStringAsync();
    //        RelationshipTypeDTO relationshipUpdateDto = new RelationshipTypeDTO();


    //        try
    //        {
    //            if (string.IsNullOrEmpty(requestBody))
    //            {
    //                response.IsSuccess = false;
    //                response.Message = "El Json para la Actualización no es consistente.";
    //                return;
    //            }

    //            try
    //            {
    //                relationshipUpdateDto = JsonConvert.DeserializeObject<RelationshipTypeDTO>(requestBody);
    //            }
    //            catch (Exception e)
    //            {
    //                response.IsSuccess = false;
    //                response.Message = e.Message;
    //                return;
    //            }


    //            var relationship = _db.Relationships.Where(x => x.RelationshipTypeKey == Guid.Parse(key)).FirstOrDefault();

    //            if (relationship == null)
    //            {
    //                response.IsSuccess = false;
    //                response.Message = $"El Tipo de Relación con el Key: {key} no existe.";
    //                return;
    //            }

    //            relationship.Name = relationshipUpdateDto.Name;
    //            relationship.Description = relationshipUpdateDto.Description;
    //            relationship.ModifiedBy = Guid.NewGuid();
    //            relationship.Modified = DateTime.Now;
    //            relationship.Active = relationshipUpdateDto.Active;

    //            try
    //            {
    //                _db.Relationships.Update(relationship);
    //                _db.SaveChanges();
    //                _responseDto.Result = relationship;
    //                return;
    //            }
    //            catch (Exception e)
    //            {
    //                response.IsSuccess = false;
    //                response.Message = e.Message;
    //                return;
    //            }


    //        }
    //        catch (Exception e)
    //        {
    //            response.IsSuccess = false;
    //            response.Message = e.Message;
    //            return;
    //        }

    //    }


    //}


}
