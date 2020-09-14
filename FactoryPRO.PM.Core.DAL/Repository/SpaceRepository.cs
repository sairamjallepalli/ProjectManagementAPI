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
   public class SpaceRepository : ISpaceRepository 
    {
        private ProjectContext _projectContext;
        public SpaceRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public bool CreateSpace(TblSpace Space)
        {
            try
            {
                _projectContext.TblSpace.Add(Space);
                _projectContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //log
            }
            return true;
        }

        public bool DeleteSpace(TblSpace Space)
        {
            var _spaceobj = _projectContext.TblSpace.Where(m => m.SpaceId == Space.SpaceId).FirstOrDefault();

            if (_spaceobj != null)
            {
                _projectContext.Entry<TblSpace>(_spaceobj).State = EntityState.Deleted;
                _projectContext.SaveChanges();
            }
            return true;
        }

        public TblSpace GetSpaceByID(string SpaceID)
        {
            TblSpace tblspace = new TblSpace();
            try
            {
                tblspace =  _projectContext.TblSpace.Where(m => m.SpaceId == SpaceID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log
            }
            return tblspace;
        }

        public List<TblSpace> GetSpaces(string ModuleID)
        {
            List<TblSpace> spaces = new List<TblSpace>();
            try
            {
                spaces =  _projectContext.TblSpace.Where(m=>m.ModuleId==ModuleID).ToList();
            }
            catch(Exception ex)
            {
                //logging_response.returnCode = -1;
            }
            return spaces;
        }

        public bool UpdateSpace(TblSpace Space)
        {
            var _spaceobj = _projectContext.TblSpace.Where(m => m.SpaceId == Space.SpaceId).FirstOrDefault();
            try
            {
                if (_spaceobj != null)
                {
                    _spaceobj.SpaceName = Space.SpaceName;
                    _projectContext.Update(_spaceobj).Property(x => x.Sid).IsModified = false;
                    //_projectContext.Entry(_spaceobj).State = EntityState.Modified;
                    _projectContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //log
            }
            return true;

        }
    }
}
