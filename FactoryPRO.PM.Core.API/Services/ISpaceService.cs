using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
  public interface ISpaceService 
    {
        List<SpaceDTO> GetSpaces(string ModuleID);
        List<SpaceTreeDTO> GetSpaceTree(string ModuleID);

        SpaceDTO GetSpaceByID(string SpaceID);

        SpaceDTO CreateSpace(SpaceDTO Space);

        SpaceDTO UpdateSpace(SpaceDTO Space);

        bool DeleteSpace(SpaceDTO Space);

    }
}
