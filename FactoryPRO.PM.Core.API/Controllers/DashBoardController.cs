using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FactoryPRO.PM.Core.API.Services;
using FactoryPRO.PM.Core.Common;
using Microsoft.AspNetCore.Mvc;


namespace FactoryPRO.PM.Core.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private ITilesService _tilesService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tilesService"></param>
        public DashBoardController(ITilesService tilesService)
        {
            _tilesService = tilesService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        [Route("api/Tiles/GetTilesCount")]
        [HttpGet]
        public APIResponse GetTilesCount(int UserID, string ModuleID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _tilesService.GetTilesCount(UserID, ModuleID)
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
    }

}

