using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AutoMapper;
using SHM.Domain.Dto;
using SHM.Function.Data;
using SHM.Domain.Helper;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SHM.Domain.Models.dbo;


namespace Sahc0100.Functions;



public class LoginB2C
{


    private ResponseDto _responseDto;
    private readonly FunctionDbContext _db;
    private readonly IMapper _mapper;



    public LoginB2C(FunctionDbContext db, IMapper mapper)
    {
        this._responseDto = new ResponseDto();
        _db = db;
        _mapper = mapper;
    }


    [FunctionName("LoginB2C")]
    public async Task<ResponseDto> Run([HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)] HttpRequest req, ILogger log)
    {

        try
        {

            return _responseDto = await registerLogin(req, _responseDto);
            
        }
        catch (Exception e)
        {

            await ElasticAlert.LogErrorToElastic(e, "LoginB2C");

            _responseDto.IsSuccess = false;
            _responseDto.Message = e.Message;
            return _responseDto;

        }

    }

    private async Task<ResponseDto> registerLogin(HttpRequest req, ResponseDto response)
    {

        try
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            LoginData data = JsonConvert.DeserializeObject<LoginData>(requestBody);

            string user = data.user;
            string password = data.Password;

            UserTemp userTemp = null;
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
            {
                userTemp =await _db.UserTemps.Where(x => x.UserName == user && x.Password == password).FirstOrDefaultAsync();
                
            }

            if (userTemp is not null)
            {
                response.Result = "Bearer 12345645648979812f3asfdsa45645678f9sa4f56saf423af123f1s5sa4f6as4f56asd4f6asd4f65sa4f**fsaf1s411fsaf";
                return response;
            }

            response.IsSuccess = false;
            response.Message = "Usuario o Password invalida";
            return response;

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

public class LoginData
{
    public string user { get; set; }
    public string Password { get; set; }
}

