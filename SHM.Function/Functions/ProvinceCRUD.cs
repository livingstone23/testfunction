using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SHM.Domain.Dto;
using SHM.Function.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHM.Function.Functions
{
    //public  class ProvinceCRUD
    //{

    //    private ResponseDto _responseDto;
    //    private readonly FunctionDbContext _db;
    //    private readonly IMapper _mapper;


    //    public ProvinceCRUD(FunctionDbContext db, IMapper mapper)
    //    {
    //        this._responseDto = new ResponseDto();
    //        _db = db;
    //        _mapper = mapper;
    //    }



    //    [FunctionName("ProvinceCRUD")]
    //    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post","put", Route = "Province/{CountryKey:Guid?}/{ProvinceKey:Guid?}")] HttpRequest req, Guid? CountryKey, Guid? ProvinceKey, ILogger log)
    //    {
    //        //ResponseDto responseDto = new ResponseDto();
    //        try
    //        {
    //            switch (req.Method)
    //            {
    //                case "GET":
    //                    await GetProvince(req, _responseDto);
    //                    break;
    //                //case "POST":
    //                //    await CreateProvince(req, responseDto);
    //                //    break;
    //                //case "PUT":
    //                //    await UpdateProvince(req, responseDto);
    //                //    break;


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


    //    private async Task GetProvince(HttpRequest req, ResponseDto response)
    //    {


    //        string CountryKey = req.Query["CountryKey"];
    //        if (string.IsNullOrEmpty(CountryKey))
    //        {
    //            throw new Exception($"No Se envía el CountryKey de país Para el Catálogo de Provincias.");
    //        }



    //        string ProvinceKey = req.Query["ProvinceKey"];

    //        List<Province> Provinces;

    //        using (_db)
    //        {
    //            if (string.IsNullOrEmpty(ProvinceKey))
    //            {
    //                Provinces = _db.Provinces.Where(x => x.CountryKey == Guid.Parse(CountryKey)).ToList();
    //            }
    //            else
    //            {
    //                Provinces = _db.Provinces.Where(x => x.ProvinceKey == Guid.Parse(ProvinceKey) &&  x.CountryKey== Guid.Parse(CountryKey)).ToList();
    //            }

    //            if (Provinces == null)
    //            {
    //                throw new Exception($"No existen Paises creados.");
    //            }

    //            List<ProvinceDTO> ListProvinceDtos = new List<ProvinceDTO>();
    //            foreach (var reg in Provinces)
    //            {
    //                ListProvinceDtos.Add(_mapper.Map<ProvinceDTO>(reg));
    //            }

    //            response.Result = ListProvinceDtos;
    //        }
    //    }

    //    //private async Task CreateProvince(HttpRequest req, ResponseDto response)
    //    //{
    //    //    string requestBody = await req.ReadAsStringAsync();

    //    //    CountryDTO newCountryDTO;
    //    //    try
    //    //    {
    //    //        if (string.IsNullOrEmpty(requestBody))
    //    //        {
    //    //            response.IsSuccess = false;
    //    //            response.Message = "El Json para la creación no es consistente.";
    //    //            return;
    //    //        }

    //    //        try
    //    //        {
    //    //            newCountryDTO = JsonConvert.DeserializeObject<CountryDTO>(requestBody);
    //    //        }
    //    //        catch (Exception e)
    //    //        {
    //    //            response.IsSuccess = false;
    //    //            response.Message = e.Message;
    //    //            return;
    //    //        }

    //    //        newCountryDTO.Active = true;
    //    //        newCountryDTO.CountryKey = Guid.NewGuid();
    //    //        newCountryDTO.CreatedDate = DateTime.Now;
    //    //        newCountryDTO.CreatedBy = "Admin";
    //    //        newCountryDTO.LastModifiedDate = DateTime.Now;
    //    //        Country newCountry = _mapper.Map<Country>(newCountryDTO);
    //    //        try
    //    //        {
    //    //            _db.Countries.Add(newCountry);
    //    //            _db.SaveChanges();
    //    //        }
    //    //        catch (Exception e)
    //    //        {
    //    //            response.IsSuccess = false;
    //    //            response.Message = e.Message;
    //    //            return;
    //    //        }


    //    //    }
    //    //    catch (Exception e)
    //    //    {
    //    //        response.IsSuccess = false;
    //    //        response.Message = e.Message;
    //    //        return;
    //    //    }

    //    //}

    //    //private async Task UpdateProvince(HttpRequest req, ResponseDto response)
    //    //{
    //    //    string key = req.Query["key"];
    //    //    string requestBody = await req.ReadAsStringAsync();
    //    //    CountryDTO countryUpdateDto = new CountryDTO();


    //    //    try
    //    //    {
    //    //        if (string.IsNullOrEmpty(requestBody))
    //    //        {
    //    //            response.IsSuccess = false;
    //    //            response.Message = "El Json para la Actualización no es consistente.";
    //    //            return;
    //    //        }

    //    //        try
    //    //        {
    //    //            countryUpdateDto = JsonConvert.DeserializeObject<CountryDTO>(requestBody);
    //    //        }
    //    //        catch (Exception e)
    //    //        {
    //    //            response.IsSuccess = false;
    //    //            response.Message = e.Message;
    //    //            return;
    //    //        }


    //    //        var country = _db.Countries.Where(x => x.CountryKey == Guid.Parse(key)).FirstOrDefault();

    //    //        if (country == null)
    //    //        {
    //    //            response.IsSuccess = false;
    //    //            response.Message = $"El Estado civil con el Key: {key} no existe.";
    //    //            return;
    //    //        }

    //    //        country.Name = countryUpdateDto.Name;
    //    //        country.Nationality = countryUpdateDto.Nationality;
    //    //        country.Abbreviation = countryUpdateDto.Abbreviation;
    //    //        country.LastModifiedBy = "Admin";
    //    //        country.LastModifiedDate = DateTime.Now;
    //    //        country.Active = countryUpdateDto.Active;

    //    //        try
    //    //        {
    //    //            _db.Countries.Update(country);
    //    //            _db.SaveChanges();
    //    //            _responseDto.Result = country;
    //    //            return;
    //    //        }
    //    //        catch (Exception e)
    //    //        {
    //    //            response.IsSuccess = false;
    //    //            response.Message = e.Message;
    //    //            return;
    //    //        }


    //    //    }
    //    //    catch (Exception e)
    //    //    {
    //    //        response.IsSuccess = false;
    //    //        response.Message = e.Message;
    //    //        return;
    //    //    }

    //    //}


    //}

}
