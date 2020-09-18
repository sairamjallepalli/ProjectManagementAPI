using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProjectService
    {
        List<ProjectDTO> GetProjects(string ModuleID, string UserGUID);

        List<ProjectDTO> GetProjectsBySpaceID(string ModuleID, string SpaceID);

        ProjectDTO GetProjectByID(string ProjectID, string  ModuleID);

        List<ProjectDTO> GetProjectsByUserID(string ModuleID, string UserGUID);

        List<CustomFieldsDTO> GetCustomFieldsByProject(string ProjectID, string UserGUID);
        ProjectDTO CreateProject(FullProjectDTO fullProject);

        ProjectDTO UpdateProject(FullProjectDTO fullProject);

        bool DeleteProject(ProjectDTO Project);
    }
}
