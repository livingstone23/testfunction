using SHM.Domain.Models.Helper;

namespace SHM.Domain.Helper;


/// <summary>
/// Clase de ayuda para funcionalidad del tiempo
/// </summary>
public static class TimeZoneHelperTest
{

    /// <summary>
    /// Funcionalidad que permite obtener el horario de Panama
    /// </summary>
    /// <returns></returns>
    public static DateTime GetPanamaTime()
    {
        var expectedTimeZone = "America/Panama";
        Environment.SetEnvironmentVariable("TimeZoneInfoToken", expectedTimeZone);

        var actualTimeZone = TimeZoneInfo.FindSystemTimeZoneById(Environment.GetEnvironmentVariable("TimeZoneInfoToken"));
        var actualTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, actualTimeZone);

        return actualTime;
    }

}


/// <summary>
/// Funcion para envio de data a Elastic 
/// </summary>
public static class ElasticAlert
{
    public static  async Task LogErrorToElastic(Exception e, string azureFunctionName)
    {
        var elasticPost = new ElasticPost
        {
            message = e.Message,
            level = "Error",
            title = $"{TimeZoneHelperTest.GetPanamaTime()}__{azureFunctionName}",
            timestamp = TimeZoneHelperTest.GetPanamaTime(),
            azureFunctionName = azureFunctionName
        };

        await FunctionToPostElastic.PostToElasticAsync(elasticPost);
    }
}