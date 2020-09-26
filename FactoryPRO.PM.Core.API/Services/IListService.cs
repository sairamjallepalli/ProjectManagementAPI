using FactoryPRO.PM.Core.API.DTO;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.Services
{
    /// <summary>
    /// 
    /// </summary>
   public interface IListService
    {
        List<ListDTO> GetLists(string ProjectID);
        ListDTO GetListByID(string ListID,string ProjectID);
        ListDTO CreateList(ListDTO Lists);
        ListDTO UpdateList(ListDTO Lists);
        bool DeleteList(ListDTO Lists);
        bool UpdateListStatusByID(string ListID);
    }
}
