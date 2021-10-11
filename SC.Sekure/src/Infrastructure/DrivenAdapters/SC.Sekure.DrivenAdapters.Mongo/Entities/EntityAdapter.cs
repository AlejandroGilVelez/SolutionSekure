using AutoMapper;
using Newtonsoft.Json;
using SC.Sekure.Domain.Model.Entities;
using SC.Sekure.Domain.Model.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SC.Sekure.DrivenAdapters.Mongo
{
    /// <summary>
    /// EntityAdapter
    /// </summary>
    public class EntityAdapter : ITestEntityRepository
    {
        private readonly IMapper mapper;
        private readonly IHttpClientFactory httpClientFactory;

        /// <summary>
        /// build
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="httpClientFactory"></param>
        public EntityAdapter(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            this.mapper = mapper;
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// FindAll
        /// </summary>
        /// <returns>Entity list</returns>
        public List<Entity> FindAll(Entity entity = null)
        {
            if (entity == null)
            {
                return mapper.Map<List<Entity>>(new List<Entities.Entity> { new Entities.Entity { Id = Guid.NewGuid(), descrip = "Test" } });
            }
            return mapper.Map<List<Entity>>(new List<Entities.Entity> { new Entities.Entity { Id = entity.Id, descrip = entity.descrip } });
        }

        /// <summary>
        /// FindAllByService
        /// </summary>
        /// <returns>Entity list</returns>
        public async Task<List<Entity>> FindAllByService(Entity entity = null)
        {

            var uri = "api/MethodToConsume";
            var client = httpClientFactory.CreateClient("ServiceToConsume");
            Uri completeUri = new Uri($"{client.BaseAddress}{uri}");
            var httpResponse = await client.GetAsync(completeUri);
            string jsonProduct = await httpResponse.Content.ReadAsStringAsync();

            return mapper.Map<List<Entity>>(JsonConvert.DeserializeObject<List<Entity>>(jsonProduct));
        }
    }
}