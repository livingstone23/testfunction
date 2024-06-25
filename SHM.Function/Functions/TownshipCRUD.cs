namespace SHM.Function.Functions
{
    //public  class TownshipCRUD
    //{

    //    private ResponseDto _responseDto;
    //    private readonly FunctionDbContext _db;
    //    private readonly IMapper _mapper;


    //    public TownshipCRUD(FunctionDbContext db, IMapper mapper)
    //    {
    //        this._responseDto = new ResponseDto();
    //        _db = db;
    //        _mapper = mapper;
    //    }



    //    [FunctionName("TownshipCRUD")]
    //    public  async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post","put", Route = "Township/{ProvinceKey:Guid?}/{DistrictKey:Guid?}/{TownshipKey:Guid?}")] HttpRequest req, Guid? ProvinceKey, Guid? DistrictKey, Guid? TownshipKey, ILogger log)
    //    {
    //        //ResponseDto responseDto = new ResponseDto();
    //        try
    //        {
    //            switch (req.Method)
    //            {

    //                case "GET":
    //                    await GetTownship(req, _responseDto);
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


    //    private async Task GetTownship(HttpRequest req, ResponseDto response)
    //    {


    //        string ProvinceKey = req.Query["ProvinceKey"];
    //        string DistrictKey = req.Query["DistrictKey"];
    //        if (string.IsNullOrEmpty(ProvinceKey) || string.IsNullOrEmpty(DistrictKey))
    //        {
    //            throw new Exception($"No Se envía el ProvinceKey o el DistrictKey para el Catálogo de Municipios.");
    //        }



    //        string TownshipKey = req.Query["TownshipKey"];

    //        List<Township> townships;

    //        using (_db)
    //        {
    //            if (string.IsNullOrEmpty(TownshipKey))
    //            {
    //                townships = _db.TownShips.Where(x =>  x.DistrictKey == Guid.Parse(DistrictKey)).ToList();
    //            }
    //            else
    //            {
    //                townships = _db.TownShips.Where(x =>  x.DistrictKey == Guid.Parse(DistrictKey) && x.TownshipKey == Guid.Parse(TownshipKey)).ToList();
    //            }

    //            if (townships == null)
    //            {
    //                throw new Exception($"No existen Paises creados.");
    //            }

    //            List<TownshipDTO> ListTownshipDtos = new List<TownshipDTO>();
    //            foreach (var reg in townships)
    //            {
    //                ListTownshipDtos.Add(_mapper.Map<TownshipDTO>(reg));
    //            }

    //            response.Result = ListTownshipDtos;
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
