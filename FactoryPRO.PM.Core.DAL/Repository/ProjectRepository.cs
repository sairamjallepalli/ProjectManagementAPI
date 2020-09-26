using FactoryPRO.PM.Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using FactoryPRO.PM.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private ProjectContext _projectContext;
        public ProjectRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public TblProjects CreateProject(TblProjects projects, List< TblCustomFields> customFields)
        {
            _projectContext.TblProjects.Add(projects);
            foreach(TblCustomFields customfield in customFields)
            {
                customfield.ProjectId = projects.ProjectId;
                _projectContext.TblCustomFields.Add(customfield);
            }
          
            _projectContext.SaveChanges();
            return projects;
        }

        public bool DeleteProject(TblProjects Projects)
        {
            var _projectobj = _projectContext.TblProjects.Where(m => m.ProjectId == Projects.ProjectId).FirstOrDefault();
            var _customobj = _projectContext.TblCustomFields.SingleOrDefault(m => m.ProjectId == Projects.ProjectId);
            if (_projectobj != null)
            {
                _projectContext.Entry<TblProjects>(_projectobj).State = EntityState.Deleted;
                _projectContext.SaveChanges();
            }
            if (_customobj != null)
            {
                _projectContext.Entry<TblCustomFields>(_customobj).State = EntityState.Deleted;
                _projectContext.SaveChanges();
            }
            return true;
        }

        public TblProjects GetProjectByID(string ProjectID)
        {
            return _projectContext.TblProjects.Where(m=>m.ProjectId==ProjectID).FirstOrDefault();
        }

        public List<TblProjects> GetProjectsByUserID( string ModuleID, string UserGUID)
        {
            List<TblProjects> projects = new List<TblProjects>();
            try
            {
                projects = _projectContext.TblProjects.Where(m => m.ModuleId == ModuleID && m.CreatedBy == UserGUID).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return projects;
        }

        public List<TblCustomFields> GetCustomFieldsByProject(string ProjectID, string UserGUID)
        {
            List<TblCustomFields> CustomFields = new List<TblCustomFields>();
            try
            {
                CustomFields = _projectContext.TblCustomFields.Where(m => m.ProjectId == ProjectID && m.CreatedBy == UserGUID ).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return CustomFields;
        }


        public List<TblProjects> GetProjects(string ModuleID, string UserGUID)
        {
            List<TblProjects> projects = new List<TblProjects>();
            try
            {
                projects = _projectContext.TblProjects.Where(m => m.ModuleId == ModuleID && m.CreatedBy == UserGUID).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return projects;
        }

        public List<TblProjects> GetProjectsBySpaceID(string ModuleID, string SpaceID)
        {
            List<TblProjects> projects = new List<TblProjects>();
            try
            {
                projects = _projectContext.TblProjects.Where(m => m.ModuleId == ModuleID && m.SpaceId ==SpaceID).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return projects;
        }

        public TblProjects UpdateProject(TblProjects Projects,TblCustomFields customFields)
        {
            var _projectobj = _projectContext.TblProjects.SingleOrDefault(m => m.ProjectId == Projects.ProjectId);
            var _customobj = _projectContext.TblCustomFields.SingleOrDefault(m => m.ProjectId == Projects.ProjectId);
            if (_projectobj != null )
            {
                Projects.CreatedDate = _projectobj.CreatedDate;
                //Projects.Pid = _projectobj.Pid;
                //_projectobj = Projects;

                _projectobj.UpdatedDate = DateTime.UtcNow;
                _projectobj.ProjectName = Projects.ProjectName;
                _projectobj.SpaceId = Projects.SpaceId;
                _projectobj.ModuleId = Projects.ModuleId;
                _projectobj.ProjectStatus = Projects.ProjectStatus;
                _projectobj.ProjectPhases = Projects.ProjectPhases;

                _projectobj.ProjectManager = Projects.ProjectManager;
                _projectobj.ProjectStartDate = Projects.ProjectStartDate;
                _projectobj.TargetDate = Projects.TargetDate;
                _projectobj.Resources = Projects.Resources;


                //  _projectContext.Entry<TblProjects>(_projectobj).State = EntityState.Modified;
                // _projectContext.Entry(_projectobj).State = EntityState.Modified;
                // _projectContext.Entry(Projects).State = EntityState.Detached;

                _projectContext.Update(_projectobj).Property(x => x.Pid).IsModified = false;
                _projectContext.SaveChanges();
            }

            if (_customobj != null)
            {
                //_customobj.DieCode = customFields.DieCode;
                //_customobj.MfgPart = customFields.MfgPart;
                //_customobj.Fgpart = customFields.Fgpart;
                _projectContext.Update(_customobj).Property(x => x.Cid).IsModified = false;
                _projectContext.SaveChanges();
            }
                return Projects;
        }


        public bool UpdateProjectStatusByID(string ProjectID)
        {
            var _listobj = _projectContext.TblProjects.Where(m => m.ProjectId == ProjectID).FirstOrDefault();

            if (_listobj != null)
            {
                _listobj.ProjectStatus = 4;
                // _projectContext.Update(_listobj).Property(x => x.Lid).IsModified = false;
                _projectContext.SaveChanges();
            }
            return true;
        }

    }
}
