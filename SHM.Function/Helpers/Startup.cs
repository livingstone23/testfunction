using AutoMapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHM.Domain.Helper;
using SHM.Function.Data;
using SHM.Function.Helpers;



[assembly: WebJobsStartup(typeof(Startup))]
namespace SHM.Function.Helpers;
public class Startup : IWebJobsStartup
{
    public void Configure(IWebJobsBuilder builder)
    {



        //Production
        //string connectionString = "";

        //QA
        //string connectionString = "";

        //QA--LOCAL
        string connectionString = "Data Source=TITAN_LCANO;Initial Catalog=SAH_IMSAPA_CLD_TST_03;Persist Security Info=True;User ID=sa;Password=123456";


        builder.Services.AddDbContext<FunctionDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        #region Mapper
        var mapperConfig = new MapperConfiguration(m =>
        {
            m.AddProfile(new MapHelperProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
        #endregion


        //Habilitamos el servicio de bus de mensajes
        //builder.Services.AddSingleton<IMessageBus, MessageBus.MessageBus>();


        builder.Services.BuildServiceProvider();


    }
}

