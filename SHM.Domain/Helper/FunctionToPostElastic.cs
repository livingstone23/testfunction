using Newtonsoft.Json;
using SHM.Domain.Models.Helper;
using System.Net.Http.Headers;
using System.Text;



namespace SHM.Domain.Helper;



public static class FunctionToPostElastic
{

    public static async Task<int> PostToElasticAsync(ElasticPost elasticPost)
    {

        try
        {

            var elasticUrl = $"https://555726965ff1478cac9f2aaa62e928e9.eastus.azure.elastic-cloud.com/search-{Environment.GetEnvironmentVariable("FunElast_ComponentReference")}-{Environment.GetEnvironmentVariable("FunElast_Enviroment")}-{Environment.GetEnvironmentVariable("FunElast_ProyectReference")}/_doc?pipeline=ent-search-generic-ingestion";
            using (var httpClient = new HttpClient())
            {

                var jsonContent = new StringContent(JsonConvert.SerializeObject(elasticPost), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("kbn-xsrf", "reporting");
                httpClient.DefaultRequestHeaders.Add("Authorization", Environment.GetEnvironmentVariable("FunElast_ElasticApiKey"));

                var response = await httpClient.PostAsync(elasticUrl, jsonContent);

                response.EnsureSuccessStatusCode();

                var result = (int)response.StatusCode;

                return result;

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

}

