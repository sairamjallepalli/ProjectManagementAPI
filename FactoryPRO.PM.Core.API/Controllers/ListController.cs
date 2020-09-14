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
            return new APIResponse
            {
                returnCode = 0,
                returnMessage = "Success",
                returnObject = _listtService.GetList(ProjectID)
            };
        }

     /// <summary>
     /// 
     /// </summary>
     /// <param name="ListID"></param>
     /// <param name="ProjectID"></param>
     /// <returns></returns>
        [Route("api/Lists/GetListByID")]
        [HttpGet]
        public ListDTO GetListByID(string ListID,string ProjectID)
        {
            return _listtService.GetListByID(ListID, ProjectID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
      
        [Route("api/Lists/CreateList")]
        [HttpPost]
        public bool CreateList(ListDTO lists)
        {
            lists.CreatedDate = DateTime.UtcNow;
            return _listtService.CreateList(lists);
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="lists"></param>
       /// <returns></returns>
        [Route("api/Lists/UpdateList")]
        [HttpPost]
        public bool UpdateList(ListDTO lists)
        {
            lists.UpdatedDate  = DateTime.UtcNow;
            return _listtService.UpdateList(lists);
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
    }
}
