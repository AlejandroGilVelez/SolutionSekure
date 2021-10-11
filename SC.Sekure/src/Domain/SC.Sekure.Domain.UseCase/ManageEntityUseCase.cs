using SC.Sekure.Domain.Model.Entities;
using SC.Sekure.Domain.Model.Entities.Gateway;
using SC.Sekure.Domain.UseCase.DomainUseCase.Common;
using SC.Sekure.Helpers.Commons.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Sekure.Domain.UseCase
{
    /// <summary>
    /// ManageTestEntityUseCase
    /// </summary>
    public class ManageTestEntityUseCase : IManageEntityUseCase
    {
        private readonly ITestEntityRepository testEntityRepository;
        private readonly IManageEventsUseCase manageEvents;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="testEntityRepository"></param>
        public ManageTestEntityUseCase(ITestEntityRepository testEntityRepository, IManageEventsUseCase manageEvents)
        {
            this.testEntityRepository = testEntityRepository;
            this.manageEvents = manageEvents;
        }

        /// <summary>
        /// <see cref="IManageEntityUseCase.GetAllUsers(Entity)"/>
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<List<Entity>> GetAllUsers(Entity entity = null)
        {
            try
            {
                this.manageEvents.ConsoleInfoLog("Se accede al useCase con la siguiente informacion ", entity);
                return testEntityRepository.FindAll(entity);
            }
            catch (CustomException cex)
            {
                this.manageEvents.ConsoleErrorLog("Se acaba de generar una excepcion :: ", cex);
                throw cex;
            }
            catch (Exception ex)
            {
                this.manageEvents.ConsoleErrorLog("Se acaba de generar una excepcion :: ", ex);
                throw ex;
            }
        }
    }
}
