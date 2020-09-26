using AutoMapper;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjectService : IProjectService 
    {
        private IProjectRepository _projectRepository;
        private ITaskRepository _tasktRepository;
        private IListRepository  _listRepository;
        private IMapper _mapper;

       /// <summary>
       /// 
       /// </summary>
       /// <param name="projectRepository"></param>
       /// <param name="mapper"></param>
       /// <param name="tasktRepository"></param>
       /// <param name="listRepository"></param>
        public ProjectService(IProjectRepository projectRepository, IMapper mapper, ITaskRepository tasktRepository, IListRepository listRepository)
        {
            _projectRepository = projectRepository;
            _tasktRepository = tasktRepository;
            _listRepository = listRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullProject"></param>
        /// <returns></returns>
        public ProjectDTO CreateProject(FullProjectDTO fullProject)
        {
            TblProjects projects = _mapper.Map<TblProjects>(fullProject.projectDTO);
            projects.CreatedDate = DateTime.UtcNow;
            projects.ProjectId = Guid.NewGuid().ToString();
            List<TblCustomFields> customFields = CastObject<CustomFieldsDTO, TblCustomFields>(fullProject.customFieldsDTO);
            projects = _projectRepository.CreateProject(projects, customFields);
            ProjectDTO projectdto = _mapper.Map<ProjectDTO>(projects);

            return projectdto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        public bool DeleteProject(ProjectDTO Project)
        {
            var result = false;
            TblProjects projects = _mapper.Map<TblProjects>(Project);
            result = _projectRepository.DeleteProject(projects);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public ProjectDTO GetProjectByID(string ProjectID)
        {
            TblProjects projects = _projectRepository.GetProjectByID(ProjectID);
            ProjectDTO space = _mapper.Map<ProjectDTO>(projects);
            return space;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<TOut> CastObject<TIn, TOut>(List<TIn> input)
        {
            List<TOut> lstOut = new List<TOut>();
            foreach (TIn tIn in input)
            {
                TOut tOut = _mapper.Map<TOut>(tIn);
                lstOut.Add(tOut);
            }
            return lstOut;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="ModuleID"></param>
       /// <param name="UserGUID"></param>
       /// <returns></returns>
        public List<ProjectDTO> GetProjectsByUserID(string ModuleID, string UserGUID)
        {
            List<TblProjects> Projects = (List<TblProjects>)_projectRepository.GetProjectsByUserID(ModuleID,UserGUID);
            List<ProjectDTO> projects = new List<ProjectDTO>();
            foreach (TblProjects project in Projects)
            {
                ProjectDTO projobj = _mapper.Map<ProjectDTO>(project);
                projects.Add(projobj);
            }
            return projects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <param name="UserGUID"></param>
        /// <returns></returns>
        public List<ProjectDTO> GetProjects(string ModuleID, string UserGUID)
        {
            List<TblProjects> Projects = (List<TblProjects>)_projectRepository.GetProjects(ModuleID, UserGUID);
            List<ProjectDTO> projects = new List<ProjectDTO>();
            foreach (TblProjects project in Projects)
            {
                ProjectDTO projobj = _mapper.Map<ProjectDTO>(project);
                projects.Add(projobj);
            }
            return projects;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="ModuleID"></param>
       /// <param name="SpaceID"></param>
       /// <returns></returns>
        public List<ProjectDTO> GetProjectsBySpaceID(string ModuleID,string SpaceID)
        {
            List<TblProjects> Projects = (List<TblProjects>)_projectRepository.GetProjectsBySpaceID(ModuleID,SpaceID);
            List<ProjectDTO> projects = new List<ProjectDTO>();
            foreach (TblProjects project in Projects)
            {
                ProjectDTO projobj = _mapper.Map<ProjectDTO>(project);
                projects.Add(projobj);
            }
            return projects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <param name="UserGUID"></param>
        /// <returns></returns>
        public List<CustomFieldsDTO> GetCustomFieldsByProject(string ProjectID, string UserGUID)
        {
            List<TblCustomFields> customFields = (List<TblCustomFields>)_projectRepository.GetCustomFieldsByProject(ProjectID,UserGUID);
            List<CustomFieldsDTO> customFieldsDTO = CastObject<TblCustomFields, CustomFieldsDTO>(customFields);
            return customFieldsDTO;
        }



       /// <summary>
       /// 
       /// </summary>
       /// <param name="fullProject"></param>
       /// <returns></returns>
        public ProjectDTO UpdateProject(FullProjectDTO fullProject)
        {
            var result = false;
            TblProjects projects = _mapper.Map<TblProjects>(fullProject.projectDTO);
            projects.UpdatedDate = DateTime.UtcNow;
            TblCustomFields customFields = _mapper.Map<TblCustomFields>(fullProject.customFieldsDTO);
            projects = _projectRepository.UpdateProject(projects,customFields);
            ProjectDTO projectdto = _mapper.Map<ProjectDTO>(projects);
            return projectdto;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public bool UpdateProjectStatusByID(string ProjectID)
        {
            List<TblList> lists = (List<TblList>)_listRepository.GetLists(ProjectID);
            List<ListDTO> lstDTO = CastObject<TblList, ListDTO>(lists);
            var lstCount = lstDTO.Where(m => m.ListStatus != 4).Count();
            if (lstCount > 0)
                return false;

            foreach (ListDTO lst in lstDTO )
            {
                List<TblTasks> Tasks = (List<TblTasks>)_tasktRepository.GetTasksByList(lst.ListId);
                List<TaskDTO> lstTaskDTO = CastObject<TblTasks, TaskDTO>(Tasks);

                var taskCount = lstTaskDTO.Where(m => m.TaskStatus != 4).Count();
                if (taskCount > 0)
                    return false;
            }
         
                return _projectRepository.UpdateProjectStatusByID(ProjectID);

        }

    }
}
