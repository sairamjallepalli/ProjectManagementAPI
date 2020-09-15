using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryPRO.PM.Core.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.API.Services;
using FactoryPRO.PM.Core.Common;

namespace FactoryPRO.PM.Core.API.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private IProjectService _projectService;
      /// <summary>
      /// 
      /// </summary>
      /// <param name="projectService"></param>
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/Projects/GetProjects")]
        [HttpGet]
        public APIResponse GetProjects(string ModuleID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _projectService.GetProjects(ModuleID)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1,
                    returnMessage = ex.Message.ToString()
                };
            }
        }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="ModuleID"></param>
       /// <param name="SpaceID"></param>
       /// <returns></returns>
        [Route("api/Projects/GetProjectsBySpaceID")]
        [HttpGet]
        public APIResponse GetProjectsBySpaceID(string ModuleID,string SpaceID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _projectService.GetProjectsBySpaceID(ModuleID, SpaceID)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1,
                    returnMessage = ex.Message.ToString()
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        [Route("api/Projects/GetProjectByID")]
        [HttpGet]
        public APIResponse GetProjectByID(string ProjectID,string ModuleID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _projectService.GetProjectByID(ProjectID, ModuleID)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1,
                    returnMessage = ex.Message.ToString()
                };
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        [Route("api/Projects/GetCustomFieldsByProject")]
        [HttpGet]
        public APIResponse GetCustomFieldsByProject(string ProjectID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _projectService.GetCustomFieldsByProject(ProjectID)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1,
                    returnMessage = ex.Message.ToString()
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        [Route("api/Projects/GetProjectsByUserID")]
        [HttpGet]
        public APIResponse GetProjectsByUserID(long UserID, string ModuleID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _projectService.GetProjectsByUserID(UserID, ModuleID)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1,
                    returnMessage = ex.Message.ToString()
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
      
        [Route("api/Projects/CreateProject")]
        [HttpPost]
        public APIResponse CreateProject(FullProjectDTO project)
        {
            project.projectDTO.CreatedDate = DateTime.UtcNow;
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _projectService.CreateProject(project)
            };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1,
                    returnMessage = ex.Message.ToString()
                };
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="project"></param>
       /// <returns></returns>
        [Route("api/Projects/UpdateProject")]
        [HttpPost]
        public APIResponse UpdateProject(FullProjectDTO project)
        {
            project.projectDTO.UpdatedDate = DateTime.UtcNow;

            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _projectService.UpdateProject(project)
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    returnCode = -1,
                    returnMessage = ex.Message.ToString()
                };
            }

        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="project"></param>
       /// <returns></returns>
        [Route("api/Projects/DeleteProject")]
        [HttpGet]
        public bool DeleteProject(ProjectDTO project)
        {
            return _projectService.DeleteProject(project);
        }


    }
}
