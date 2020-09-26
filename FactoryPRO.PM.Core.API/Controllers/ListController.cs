using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ListController : ControllerBase
    {
        private IListService _listtService;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="listtService"></param>
        public ListController(IListService listtService)
        {
            _listtService = listtService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/Lists/GetLists")]
        [HttpGet]
        public APIResponse GetList(string ProjectID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _listtService.GetList(ProjectID)
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
     /// <param name="ListID"></param>
     /// <param name="ProjectID"></param>
     /// <returns></returns>
        [Route("api/Lists/GetListByID")]
        [HttpGet]
        public APIResponse GetListByID(string ListID,string ProjectID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _listtService.GetListByID(ListID, ProjectID)
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
        /// <param name="lists"></param>
        /// <returns></returns>
      
        [Route("api/Lists/CreateList")]
        [HttpPost]
        public APIResponse CreateList(ListDTO lists)
        {


            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _listtService.CreateList(lists)
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
       /// <param name="lists"></param>
       /// <returns></returns>
        [Route("api/Lists/UpdateList")]
        [HttpPost]
        public APIResponse UpdateList(ListDTO lists)
        {

            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _listtService.UpdateList(lists)
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
        /// <param name="lists"></param>
        /// <returns></returns>
        [Route("api/Lists/DeleteList")]
        [HttpGet]
        public bool DeleteList(ListDTO lists)
        {
            return _listtService.DeleteList(lists);
        }

        // To close the list if all tasks are closed.
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("api/Lists/UpdateListStatusByID")]
        [HttpGet]
        public bool UpdateListStatusByID(string ListID)
        {
            bool result = false;
            try
            {

                result = _listtService.UpdateListStatusByID(ListID);
               
            }
            catch (Exception ex)
            {
                return false;
            }
            return result;
        }

    }
}
