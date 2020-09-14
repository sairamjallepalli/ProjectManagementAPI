using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.API.Services;
using FactoryPRO.PM.Core.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FactoryPRO.PM.Core.API.Controllers
{
   /// <summary>
   /// 
   /// </summary>
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskService"></param>
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/Tasks/GetTasksByUserID")]
        [HttpGet]
        public APIResponse GetTasksByUserID(int UserID)
        {
            return new APIResponse
            {
                returnCode = 0,
                returnMessage = "Success",
                returnObject = _taskService.GetTasksByUserID(UserID)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/Tasks/GetTasksByList")]
        [HttpGet]
        public APIResponse GetTasksByList(string ListID)
        {
            return new APIResponse
            {
                returnCode = 0,
                returnMessage = "Success",
                returnObject = _taskService.GetTasksByList(ListID)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/Tasks/GetTasksByProject")]
        [HttpGet]
        public APIResponse GetTasksByProject(string ProjectID)
        {
            return new APIResponse
            {
                returnCode = 0,
                returnMessage = "Success",
                returnObject = _taskService.GetTasksByProject(ProjectID)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
       
        [Route("api/Tasks/CreateTask")]
        [HttpPost]
        public bool CreateTask(TaskDTO Task)
        {
            Task.CreatedDate = DateTime.UtcNow;
            return _taskService.CreateTask(Task);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        [Route("api/Tasks/UpdateTask")]
        [HttpPost]
        public bool UpdateTask(TaskDTO Task)
        {
            Task.UpdatedDate = DateTime.UtcNow;
            return _taskService.UpdateTask(Task);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Task"></param>
        /// <returns></returns>
        [Route("api/Tasks/DeleteTask")]
        [HttpGet]
        public bool DeleteTask(TaskDTO Task)
        {
            return _taskService.DeleteTask(Task);
        }
    }
}
