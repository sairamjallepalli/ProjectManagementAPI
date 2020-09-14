using AutoMapper;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.API.DTO;
//using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public AutoMapperConfig()
        {
            CreateMap<TblSpace, SpaceDTO>();
            CreateMap<SpaceDTO, TblSpace>();
            CreateMap<TblSpace, SpaceTreeDTO>();
            CreateMap<SpaceTreeDTO, TblSpace>();
            CreateMap<TblProjects, ProjectDTO>();
            CreateMap<ProjectDTO, TblProjects>();
            CreateMap<TblList, ListDTO>();
            CreateMap<ListDTO, TblList>();
            CreateMap<TblCustomFields, CustomFieldsDTO>();
            CreateMap<CustomFieldsDTO, TblCustomFields>();
            CreateMap<TblTasks, TaskDTO>();
            CreateMap<TaskDTO, TblTasks>();
        }
}
}
