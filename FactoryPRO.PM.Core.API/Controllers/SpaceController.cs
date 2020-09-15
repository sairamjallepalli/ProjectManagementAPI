using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.API.Services;
using FactoryPRO.PM.Core.Common;

namespace FactoryPRO.PM.Core.API.Controllers
{
   
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
   // [ApiExplorerSettings(IgnoreApi = true)]
  
    public class SpaceController : ControllerBase
    {
        private ISpaceService _spaceService;
        private ILogger _logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spaceService"></param>
        /// <param name="logger"></param>
        public SpaceController(ISpaceService spaceService)
        {
            _spaceService = spaceService;
        }


      /// <summary>
      /// 
      /// </summary>
      /// <returns></returns>
       [Route("api/Spaces/GetSpaces")]
        [HttpGet]
        public APIResponse GetSpaces(string ModuleID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _spaceService.GetSpaces(ModuleID)
                };
            }
            catch(Exception ex)
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
        [Route("api/Spaces/GetSpaceTree")]
        [HttpGet]
        public APIResponse GetSpaceTree(string ModuleID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _spaceService.GetSpaceTree(ModuleID)
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
        /// <param name="SpaceID"></param>
        /// <returns></returns>
        [Route("api/Spaces/GetSpaceByID")]
        [HttpGet]
        public APIResponse GetSpaceByID(string SpaceID)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _spaceService.GetSpaceByID(SpaceID)
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
        /// <param name="space"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Spaces/CreateSpace")]
        public APIResponse CreateSpace(SpaceDTO space)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _spaceService.CreateSpace(space)
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
        /// <param name="space"></param>
        /// <returns></returns>
        [Route("api/Spaces/UpdateSpace")]
        [HttpPost]
        public APIResponse UpdateSpace(SpaceDTO space)
        {
            try
            {
                return new APIResponse
                {
                    returnCode = 0,
                    returnMessage = "Success",
                    returnObject = _spaceService.UpdateSpace(space)
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
        /// <param name="space"></param>
        /// <returns></returns>
        [Route("api/Spaces/DeleteSpace")]
        [HttpPost]
        public bool DeleteSpace(SpaceDTO space)
        {
            try
            {
                return _spaceService.DeleteSpace(space);
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

    }
}
