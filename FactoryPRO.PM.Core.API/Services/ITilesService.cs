using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    public interface ITilesService
    {
        TilesDTO GetTilesCount(int UserID, string ModuleID);
    }
}
