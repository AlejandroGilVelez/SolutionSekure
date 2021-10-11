using AutoMapper;
using credinet.comun.api;
using Microsoft.Extensions.DependencyInjection;
using SC.Sekure.Domain.Model.Entities.Gateway;
using SC.Sekure.Domain.UseCase;
using SC.Sekure.Domain.UseCase.DomainUseCase.Common;
using SC.Sekure.DrivenAdapters.Mongo;

namespace SC.Sekure.AppServices
{
    /// <summary>
    /// ConfigurationServices
    /// </summary>
    public static class ConfigurationServices
    {
        /// <summary>
        /// AgregarServicios
        /// </summary>
        /// <param name="services"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AgregarServicios(this IServiceCollection services)
        {

            services.AddSingleton<IMensajesHelper, MensajesApiHelper>();
            services.AddSingleton<IManageEventsUseCase, ManageEventsUseCase>();

            services.AddScoped<IManageEntityUseCase, ManageTestEntityUseCase>();

            services.AddScoped<ITestEntityRepository>(provider => new EntityAdapter(
               services.BuildServiceProvider().GetRequiredService<IMapper>(),
               services.BuildServiceProvider().GetService<System.Net.Http.IHttpClientFactory>()));

            //REGISTRE ACÁ SUS SERVICIOS
            return services;
        }
    }
}
