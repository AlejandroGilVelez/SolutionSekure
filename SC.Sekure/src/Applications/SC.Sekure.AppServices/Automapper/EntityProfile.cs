using AutoMapper;
using SC.Sekure.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SC.Sekure.AppServices.Automapper
{
    /// <summary>
    /// EntityProfile
    /// </summary>
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<Entity, DrivenAdapters.Mongo.Entities.Entity>();
            CreateMap<DrivenAdapters.Mongo.Entities.Entity, Entity>();
        }
    }
}
