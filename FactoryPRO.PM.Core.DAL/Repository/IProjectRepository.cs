using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
   public  interface IProjectRepository
    {
        List<TblProjects> GetProjects(string ModuleID);

        List<TblProjects> GetProjectsBySpaceID(string ModuleID,string SpaceID);
        
        List<TblProjects> GetProjectsByUserID(long UserID, string ModuleID);

        TblProjects GetProjectByID(string ProjectID,string ModuleID);
        List<TblCustomFields> GetCustomFieldsByProject(string ProjectID);

        TblProjects CreateProject(TblProjects Project, List<TblCustomFields> customFields);

        TblProjects UpdateProject(TblProjects Project, TblCustomFields customFields);

        bool DeleteProject(TblProjects Project);
    }
}
