using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace SC.Sekure.AppServices
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("config/appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

            return WebHost.CreateDefaultBuilder(args)
                 .UseIISIntegration()
                 .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new System.Uri(hostingContext.Configuration["Serilog:ElasticsearchUrl"]))
                 {
                     AutoRegisterTemplate = true,
                     AutoRegisterTemplateVersion = Serilog.Sinks.Elasticsearch.AutoRegisterTemplateVersion.ESv7,
                     IndexFormat = hostingContext.Configuration["Serilog:IndexFormat"]
                 })
                 .Enrich.WithProperty("Environment", hostingContext.HostingEnvironment.EnvironmentName)
                 .Enrich.WithProperty("ApplicationName", hostingContext.HostingEnvironment.ApplicationName)
                 .Enrich.FromLogContext())
                 .UseConfiguration(config)
                 .UseStartup<Startup>();
        }
    }
}