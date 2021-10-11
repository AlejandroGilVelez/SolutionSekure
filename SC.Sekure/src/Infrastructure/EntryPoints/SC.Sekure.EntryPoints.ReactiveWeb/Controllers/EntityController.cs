using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SC.Sekure.Domain.Model.Entities;
using SC.Sekure.Domain.Model.Entities.Gateway;
using SC.Sekure.Domain.UseCase.DomainUseCase.Common;
using SC.Sekure.EntryPoints.ReactiveWeb.EntryPointsReactiveWeb.Base;
using SC.Sekure.Helpers.ObjectsUtils.HelperObjectUtils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.Sekure.EntryPoints.ReactiveWeb.Controllers
{
    /// <summary>
    /// EntityController
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class EntityController : AppControllerBase<EntityController>
    {
        private readonly IManageEntityUseCase testNegocio;

        /// <summary>
        /// Build
        /// </summary>
        /// <param name="testNegocio"></param>
        public EntityController(IManageEntityUseCase testNegocio,
                                IOptions<AppSettings> appParametersService,
                                IManageEventsUseCase eventsService) : base(appParametersService, eventsService)
        {
            this.testNegocio = testNegocio;
        }

        /// <summary>
        /// Obtiene todos los objetos de tipo <see cref="Entity"/>
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna la lista</response>
        /// <response code="400">Si existe algun problema al consultar</response>
        /// <response code="406">Si no se envia el ambiente correcto</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> Get()
        {
            return await HandleRequest(async () => await testNegocio.GetAllUsers(), new Guid().ToString());
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> Create([FromBody] Entity entity)
        {
            return await HandleRequest(async () => await testNegocio.GetAllUsers(entity), new Guid().ToString());
        }
    }
}