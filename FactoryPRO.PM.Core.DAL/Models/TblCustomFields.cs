using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblCustomFields
    {
        public int Cid { get; set; }
        public string ProjectId { get; set; }
        public string ModuleId { get; set; }
        public string Revision { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblProjects Project { get; set; }
    }
}
