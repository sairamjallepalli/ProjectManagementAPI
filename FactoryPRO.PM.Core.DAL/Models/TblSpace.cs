using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblSpace
    {
        public TblSpace()
        {
            TblProjects = new HashSet<TblProjects>();
        }

        public int Sid { get; set; }
        public string SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModuleId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ProductSpaceId { get; set; }

        public virtual ICollection<TblProjects> TblProjects { get; set; }
    }
}
