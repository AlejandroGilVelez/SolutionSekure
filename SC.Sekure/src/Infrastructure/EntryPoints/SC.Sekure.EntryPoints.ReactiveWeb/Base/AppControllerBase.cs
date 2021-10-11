using credinet.comun.api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SC.Sekure.Domain.UseCase.DomainUseCase.Common;
using SC.Sekure.Helpers.ObjectsUtils.HelperObjectUtils;
using System;
using System.Threading.Tasks;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;


namespace SC.Sekure.EntryPoints.ReactiveWeb.EntryPointsReactiveWeb.Base
{
    /// <summary>
    /// AppControllerBase
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AppControllerBase<T> : BaseController<T>
    {
        /// <summary>
        /// Country by default
        /// </summary>
        public string Country => EnvironmentHelper.GetCountryOrDefault(_appSettings.Value.DefaultCountry);

        private readonly IManageEventsUseCase _eventsService;
        private readonly IOptions<AppSettings> _appSettings;

        /// <summary>
        /// AppControllerBase
        /// </summary>
        /// <param name="appParametersService"></param>
        /// <param name="eventsService"></param>
        public AppControllerBase(IOptions<AppSettings> appParametersService,
            IManageEventsUseCase eventsService)
        {
            _eventsService = eventsService;
            _appSettings = appParametersService;
        }

        /// <summary>
        /// Handle request
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="requestHandler"></param>
        /// <param name="logId"></param>
        ///// <param name="logBusinessException"></param>
        /// <returns></returns>
        public async Task<IActionResult> HandleRequest<TResult>(Func<Task<TResult>> requestHandler, string logId)
        {

            string actionName = ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            string eventName = $"{controllerName}.{actionName}";

            _eventsService.ConsoleProcessLog(eventName, logId, data: null);

            TResult result = await requestHandler();

            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", Country, result)));

        }
    }
}
