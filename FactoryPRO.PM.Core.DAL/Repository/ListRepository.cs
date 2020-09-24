using FactoryPRO.PM.Core.DAL.Models;
using Microsoft.EntityFrameworkCore;
using FactoryPRO.PM.Core.Common;
//using FactoryPRO.PM.Core.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryPRO.PM.Core.DAL.Repository
{
    public class ListRepository : IListRepository   
    {
        private ProjectContext _projectContext;

        public ListRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public TblList CreateList(TblList List)
        {
            _projectContext.TblList.Add(List);
            _projectContext.SaveChanges();
            return List;
        }

        public bool DeleteList(TblList Lists)
        {
            var _projectObj = _projectContext.TblList.Where(m => m.ListId == Lists.ListId && m.ProjectId == Lists.ProjectId).FirstOrDefault();

            if (_projectObj != null)
            {
                _projectContext.Entry<TblList>(_projectObj).State = EntityState.Deleted;
                _projectContext.SaveChanges();
            }
            return true;
        }

        public List<TblList> GetList(string ProjectID)
        {
            return _projectContext.TblList.Where(m => m.ProjectId == ProjectID ).ToList();
        }

        public TblList GetListByID(string ListID,string ProjectID)
        {
            return _projectContext.TblList.Where(m => m.ListId == ListID && m.ProjectId == ProjectID).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ListID"></param>
        /// <returns></returns>
        public bool UpdateListStatusByID(string ListID)
        {
            var _listobj = _projectContext.TblList.Where(m => m.ListId == ListID ).FirstOrDefault();

            if (_listobj != null)
            {
                _listobj.ListStatus  = 4;
               // _projectContext.Update(_listobj).Property(x => x.Lid).IsModified = false;
                _projectContext.SaveChanges();
            }
            return true;
        }

        public TblList UpdateList(TblList list)
        {
            var _Projectobj = _projectContext.TblList.Where(m => m.ListId == list.ListId && m.ProjectId ==list.ProjectId).FirstOrDefault();

            if (_Projectobj != null)
            {
                _Projectobj.ListName = list.ListName;
                _Projectobj.ListId = list.ListId;
                _Projectobj.ProjectId = list.ProjectId;
                _Projectobj.ModuleId = list.ModuleId;

                _Projectobj.ListOwnerId = list.ListOwnerId;
                _Projectobj.ListStatus = list.ListStatus;
                _Projectobj.Active = list.Active;
                _Projectobj.UpdatedBy = list.UpdatedBy;
                _Projectobj.UpdatedDate = list.UpdatedDate;


                _projectContext.Update(_Projectobj).Property(x => x.Lid).IsModified = false;
                _projectContext.SaveChanges();
            }
            return list;
        }
    }
}
