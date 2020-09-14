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

        public bool CreateList(TblList List)
        {
            _projectContext.TblList.Add(List);
            _projectContext.SaveChanges();
            return true;
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
            List<TblList> lists = new List<TblList>();
            try
            {
                lists = _projectContext.TblList.Where(m => m.ProjectId == ProjectID ).ToList();
            }
            catch (Exception ex)
            {
                //log
            }
            return lists;

           
        }

        public TblList GetListByID(string ListID,string ProjectID)
        {
            return _projectContext.TblList.Where(m => m.ListId == ListID && m.ProjectId == ProjectID).FirstOrDefault();
        }

        public bool UpdateList(TblList Lists)
        {
            var _Projectobj = _projectContext.TblList.Where(m => m.ListId == Lists.ListId && m.ProjectId ==Lists.ProjectId).FirstOrDefault();

            if (_Projectobj != null)
            {
                _Projectobj.ListName = Lists.ListName;
                _Projectobj.ListId = Lists.ListId;
                _Projectobj.ProjectId = Lists.ProjectId;
                _Projectobj.ModuleId = Lists.ModuleId;

                _Projectobj.ListOwnerId = Lists.ListOwnerId;
                _Projectobj.ListStatus = Lists.ListStatus;
                _Projectobj.Active = Lists.Active;
                _Projectobj.UpdatedBy = Lists.UpdatedBy;
                _Projectobj.UpdatedDate = Lists.UpdatedDate;


                _projectContext.Update(_Projectobj).Property(x => x.Lid).IsModified = false;
                _projectContext.SaveChanges();
            }
            return true;
        }
    }
}
