using FactoryPRO.PM.Core.Common;
using FactoryPRO.PM.Core.DAL.Models;
//using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
   public interface IListRepository
    {
        List<TblList> GetList(string ProjectID);

        TblList GetListByID(string ListID,string ProjectID);

        bool CreateList(TblList Lists);

        bool UpdateList(TblList Lists);

        bool DeleteList(TblList Lists);
    }
}
