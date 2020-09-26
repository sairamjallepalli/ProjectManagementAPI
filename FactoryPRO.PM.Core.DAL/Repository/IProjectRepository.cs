using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
   public  interface IProjectRepository
    {
        List<TblProjects> GetProjects(string ModuleID, string UserGUID);

        List<TblProjects> GetProjectsBySpaceID(string ModuleID,string SpaceID);
        
        List<TblProjects> GetProjectsByUserID(string ModuleID, string UserGUID);

        TblProjects GetProjectByID(string ProjectID);
        List<TblCustomFields> GetCustomFieldsByProject(string ProjectID, string UserGUID);

        TblProjects CreateProject(TblProjects Project, List<TblCustomFields> customFields);

        TblProjects UpdateProject(TblProjects Project, TblCustomFields customFields);

        bool DeleteProject(TblProjects Project);
        bool UpdateProjectStatusByID(string ProjectID);
    }
}
