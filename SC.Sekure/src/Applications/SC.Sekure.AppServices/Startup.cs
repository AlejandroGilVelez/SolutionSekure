using AutoMapper;
using AutoMapper.Data;
using credinet.comun.api;
using credinet.comun.api.Swagger.Extensions;
using credinet.exception.middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using SC.AdministradorLlaves;

namespace SC.Sekure.AppServices
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Environment
        /// </summary>
        public IWebHostEnvironment Environment { get; }
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson().AddFluentValidation();
            services.AddCors(options =>
            {
                options.AddPolicy("cors", b => b.AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });

            var appSettings = Configuration.GetSection("AppSettings").Get<Helpers.ObjectsUtils.HelperObjectUtils.AppSettings>();

            //MongoDb
            //var mongoConnString = GetConnection(appSettings.CreditNetstoreDbLogin);
            //services.AddSingleton<IContext>(provider => new Context(mongoConnString, $"{appSettings.DataBaseCrediNetRequest}_{country}"));

            //SQL
            //var sqlCon = GetConnection(appSettings.SistecreditoDb);
            //services.AddDbContextPool<SistecreditoContext>(options => options.UseSqlServer(sqlCon));

            services.AddAutoMapper(typeof(Startup));

            services.AddHttpClient("ServiceToConsume", client =>
            {
                client.BaseAddress = new System.Uri(appSettings.ServiceApiUrl);
                client.DefaultRequestHeaders.Add("SCOrigen", Environment.EnvironmentName);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddRespuestaApiFactory();
            services.AddVersionedApiExplorer();
            services.AgregarServicios();
            services.HabilitarVesionamiento();
            services.ConfigurarSwaggerConVersiones(Environment, PlatformServices.Default.Application.ApplicationBasePath, new string[] { "SC.Sekure.AppServices.xml" });

            //this configuration take the extensions .xml for defect
            //services.ConfigurarSwaggerConVersiones(Environment, PlatformServices.Default.Application.ApplicationBasePath);
        }

        public string GetConnection(string urlKeyConexion)
        {
            var admLlaves = new ScAdministradorLlaves(Configuration);
            return admLlaves.ObtenerLlave(urlKeyConexion).GetAwaiter().GetResult();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseCors("cors");
            app.UseStaticFiles(); // For the wwwroot folder
            app.UseRouting();

            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger((c) =>
                {
                    c.PreSerializeFilters.Add((swaggerDoc, httpRequest) => { swaggerDoc.Info.Description = httpRequest.Host.Value; });
                });
                app.UseSwaggerUI(
                options =>
                {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                    options.InjectStylesheet($"../swagger.{env.EnvironmentName}.css");
                });
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseAmbienteHeaderMiddleware();
            app.UseOrigenHeaderMiddleware();
            app.UseMvc();
        }
    }
}