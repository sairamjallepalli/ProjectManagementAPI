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
        public APIResponse GetTasksByUserID(string  UserGUID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _taskService.GetTasksByUserID(UserGUID)
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
        /// <returns></returns>
        [Route("api/Tasks/GetTasksByList")]
        [HttpGet]
        public APIResponse GetTasksByList(string ListID)
        {

            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _taskService.GetTasksByList(ListID)
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
        /// <returns></returns>
        [Route("api/Tasks/GetTasksByProject")]
        [HttpGet]
        public APIResponse GetTasksByProject(string ProjectID)
        {

            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _taskService.GetTasksByProject(ProjectID)
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
        /// <param name="Task"></param>
        /// <returns></returns>
       
        [Route("api/Tasks/CreateTask")]
        [HttpPost]
        public APIResponse CreateTask(TaskDTO Task)
        {
            Task.CreatedDate = DateTime.UtcNow;
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _taskService.CreateTask(Task)
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
        /// <param name="Task"></param>
        /// <returns></returns>
        [Route("api/Tasks/UpdateTask")]
        [HttpPost]
        public APIResponse UpdateTask(TaskDTO Task)
        {
            Task.UpdatedDate = DateTime.UtcNow;

            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _taskService.UpdateTask(Task)
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
        /// <param name="Task"></param>
        /// <returns></returns>
        [Route("api/Tasks/GetTaskByID")]
        [HttpGet]
        public APIResponse GetTasksByID(string TaskID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _taskService.GetTasksByID(TaskID)
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
