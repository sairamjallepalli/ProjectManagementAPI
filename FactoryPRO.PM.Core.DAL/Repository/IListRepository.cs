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
        List<TblList> GetLists(string ProjectID);

        TblList GetListByID(string ListID,string ProjectID);

        TblList CreateList(TblList Lists);

        TblList UpdateList(TblList Lists);

        bool DeleteList(TblList Lists);

        bool UpdateListStatusByID(string ListID);
    }
}
