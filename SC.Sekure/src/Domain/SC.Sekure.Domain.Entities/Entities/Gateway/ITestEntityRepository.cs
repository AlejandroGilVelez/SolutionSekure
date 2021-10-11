using System;
using System.Collections.Generic;

namespace SC.Sekure.Domain.Model.Entities.Gateway
{
    /// <summary>
    /// ITestEntityRepository
    /// </summary>
    public interface ITestEntityRepository
    {
        /// <summary>
        /// FindAll
        /// </summary>
        /// <returns>Entity list</returns>
        List<Entity> FindAll(Entity entity = null);
    }
}