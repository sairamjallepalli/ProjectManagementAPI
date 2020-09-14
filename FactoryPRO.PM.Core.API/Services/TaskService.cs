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
    public class TaskService : ITaskService
    {

        private ITaskRepository _taskRepository;
        private IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="response"></param>
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<TaskDTO> GetTasksByUserID(int UserID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByUserID(UserID);
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (TblTasks Task in Tasks)
            {
                TaskDTO taskobj = _mapper.Map<TaskDTO>(Task);
                tasks.Add(taskobj);
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public List<TaskDTO> GetTasksByList(string ListID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByList(ListID);
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (TblTasks Task in Tasks)
            {
                TaskDTO taskobj = _mapper.Map<TaskDTO>(Task);
                tasks.Add(taskobj);
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProjectID"></param>
        /// <returns></returns>
        public List<TaskDTO> GetTasksByProject(string ProjectID)
        {
            List<TblTasks> Tasks = (List<TblTasks>)_taskRepository.GetTasksByProject(ProjectID);
            List<TaskDTO> tasks = new List<TaskDTO>();

            foreach (TblTasks Task in Tasks)
            {
                TaskDTO taskobj = _mapper.Map<TaskDTO>(Task);
                tasks.Add(taskobj);
            }
            return tasks;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        public bool CreateTask(TaskDTO Task)
        {
            var result = false;
            TblTasks task = _mapper.Map<TblTasks>(Task);
            result = _taskRepository.CreateTask(task);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        public bool UpdateTask(TaskDTO Task)
        {
            var result = false;
            TblTasks task = _mapper.Map<TblTasks>(Task);
            result = _taskRepository.UpdateTask(task);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        public bool DeleteTask(TaskDTO Task)
        {
            var result = false;
            TblTasks task = _mapper.Map<TblTasks>(Task);
            result = _taskRepository.DeleteTask(task);
            return result;
        }

    }
}
