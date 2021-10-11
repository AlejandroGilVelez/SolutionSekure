using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.Sekure.Domain.Model.Entities.Gateway
{
    /// <summary>
    /// Explenation of the interface
    /// </summary>
    public interface IManageEntityUseCase
    {
        /// <summary>
        /// The explanation of the method goes here...
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Entity</returns>
        Task<List<Entity>> GetAllUsers(Entity entity = null);
    }
}
