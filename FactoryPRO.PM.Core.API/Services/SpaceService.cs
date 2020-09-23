using AutoMapper;
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
    public class SpaceService : ISpaceService
    {
        private ISpaceRepository _spaceRepository;
        private IProjectRepository _projectRepository;
        private IListRepository _listRepository;
        private ITaskRepository _taskRepository;
        private IMapper _mapper;

       /// <summary>
       /// 
       /// </summary>
       /// <param name="spaceRepository"></param>
       /// <param name="projectRepository"></param>
       /// <param name="listRepository"></param>
       /// <param name="taskRepository"></param>
       /// <param name="mapper"></param>
        public SpaceService(ISpaceRepository spaceRepository, IProjectRepository projectRepository, IListRepository listRepository, ITaskRepository taskRepository, IMapper mapper)
        {
            _spaceRepository = spaceRepository;
            _projectRepository = projectRepository;
            _listRepository = listRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Space"></param>
        /// <returns></returns>
        public SpaceDTO CreateSpace(SpaceDTO Space)
        {
            TblSpace space = _mapper.Map<TblSpace>(Space);
            space.SpaceId = Guid.NewGuid().ToString();
            space.CreatedDate = DateTime.Now;
            space =  _spaceRepository.CreateSpace(space);

            SpaceDTO spacedto = _mapper.Map<SpaceDTO>(space);
            return spacedto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Space"></param>
        /// <returns></returns>
        public bool DeleteSpace(SpaceDTO Space)
        {
            var result = false;
            TblSpace space = _mapper.Map<TblSpace>(Space);
            result = _spaceRepository.DeleteSpace(space);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SpaceID"></param>
        /// <returns></returns>
        public SpaceDTO GetSpaceByID(string SpaceID)
        { 
            TblSpace tblspace = new TblSpace();
            tblspace = _spaceRepository.GetSpaceByID(SpaceID);
            SpaceDTO spacedto = new SpaceDTO();
            spacedto = _mapper.Map<SpaceDTO>(tblspace);
            return spacedto;
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
        /// <returns></returns>
        public List<SpaceDTO> GetSpaces(string ModuleID, string UserGUID)
        {
            List<TblSpace> Spaces = new List<TblSpace>();
            Spaces = _spaceRepository.GetSpaces(ModuleID,UserGUID);
            List<SpaceDTO> spaces= CastObject<TblSpace, SpaceDTO>(Spaces);
            return spaces;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<SpaceTreeDTO> GetSpaceTree(string ModuleID, string UserGUID)
        {
            List<TblSpace> Spaces = new List<TblSpace>();
            Spaces = _spaceRepository.GetSpaces(ModuleID,UserGUID);

            List<SpaceTreeDTO> spaces = CastObject<TblSpace, SpaceTreeDTO>(Spaces);
            foreach (var space in spaces)
            {
                List<TblProjects> lstProjects = _projectRepository.GetProjectsBySpaceID(ModuleID,space.SpaceId);
                List<ProjectDTO> lstProjectDTO= CastObject<TblProjects, ProjectDTO>(lstProjects);
                space.children = lstProjectDTO;
                space.type = "space";
                space.name = space.SpaceName;
                foreach (var project in lstProjectDTO)
                {
                    List<TblList> lstPhases = _listRepository.GetList(project.ProjectId);
                    List<ListDTO> lstPhasesDTO = CastObject<TblList, ListDTO>(lstPhases);

                    project.children = lstPhasesDTO;
                    project.type = "project";
                    project.name = project.ProjectName;
                    
                    foreach (var phase in lstPhasesDTO)
                    {
                        List<TblTasks> lstTasks = _taskRepository.GetTasksByList(phase.ListId, UserGUID);
                        List<TaskDTO> lstTaskDTO = CastObject<TblTasks, TaskDTO>(lstTasks);
                        phase.tasksDTO = lstTaskDTO;
                        phase.type = "list";
                        phase.name = phase.ListName;
                    }
                }

             }

             return spaces;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Space"></param>
        /// <returns></returns>
        public SpaceDTO UpdateSpace(SpaceDTO Space)
        {
            TblSpace space = _mapper.Map<TblSpace>(Space);
            space =  _spaceRepository.UpdateSpace(space);

            SpaceDTO spacedto = new SpaceDTO();
            spacedto = _mapper.Map<SpaceDTO>(space);
            return spacedto;
        }
    }
}
