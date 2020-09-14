using FactoryPRO.PM.Core.DAL.Models;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
  public  interface ISpaceRepository
    {
        List<TblSpace> GetSpaces(string ModuleID);

        TblSpace GetSpaceByID(string SpaceID);

        bool CreateSpace(TblSpace Space);

        bool UpdateSpace(TblSpace Space);

        bool DeleteSpace(TblSpace Space);
    }
}
