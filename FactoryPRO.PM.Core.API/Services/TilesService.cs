using AutoMapper;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
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
    public class TilesService : ITilesService
    {
        private IProjectRepository _projectRepository;
        private ITaskRepository _taskRepository;
        private IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskRepository"></param>
        /// <param name="projectRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="response"></param>
        public TilesService(ITaskRepository taskRepository, IProjectRepository projectRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="ModuleID"></param>
      /// <param name="UserGUID"></param>
      /// <returns></returns>
        public TilesDTO GetTilesCount(string ModuleID, string UserGUID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByUserID(UserGUID);
            List<TblProjects> Projects = (List<TblProjects>)_projectRepository.GetProjectsByUserID( ModuleID,UserGUID);
            TilesDTO tilesDTO = new TilesDTO();

            // For Tiles
            tilesDTO.ActiveProjectsCount = Projects.Where(x => x.ProjectStatus == 2).ToList().Count();  // In Progress Projects
            tilesDTO.PendingProjectsCount = Projects.Where(x => x.ProjectStatus == 3).ToList().Count(); // In Hold (Pending) Projects

            tilesDTO.TotalTasksCount = Tasks.Count();
            tilesDTO.CompletedTasksCount = Tasks.Where(x => x.TaskStatus == 4).ToList().Count();        // Completed Tasks

            tilesDTO.OverDueProjectsCount = Projects.Where(x => x.TargetDate < DateTime.Now).Count();
            tilesDTO.OverDueTasksCount = Tasks.Where(x => x.DueDate < DateTime.Now).Count();

            // For Pie Chart
            tilesDTO.NewProjectsCount = Projects.Where(x => x.ProjectStatus == 1).ToList().Count();  // New Projects
            tilesDTO.HoldProjectsCount = Projects.Where(x => x.ProjectStatus == 3).ToList().Count();  // Hold Projects
                //ActiveProjectsCount
            tilesDTO.CompletedProjectsCount = Projects.Where(x => x.ProjectStatus == 4).ToList().Count();  // Completed Projects
            tilesDTO.RejectedProjectsCount = Projects.Where(x => x.ProjectStatus == 5).ToList().Count();  // Rejected Projects

            return tilesDTO;
        }
    }
}
