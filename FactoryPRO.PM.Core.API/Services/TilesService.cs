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
        /// <param name="UserID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        public TilesDTO GetTilesCount(int UserID,string ModuleID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByUserID(UserID);
            List<TblProjects> Projects = (List<TblProjects>)_projectRepository.GetProjectsByUserID(UserID, ModuleID);
            TilesDTO tilesDTO = new TilesDTO();
            tilesDTO.ActiveTasksCount = Tasks.Count();
            tilesDTO.OverDueTasksCount = Tasks.Where(x => x.DueDate < DateTime.Now).Count();
            tilesDTO.TotalProjectsCount = Projects.Count();
            return tilesDTO;
        }
    }
}
