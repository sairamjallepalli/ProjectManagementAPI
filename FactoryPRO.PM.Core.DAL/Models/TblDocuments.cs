using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblDocuments
    {
        public int Did { get; set; }
        public string DocumentId { get; set; }
        public string TaskId { get; set; }
        public string Files { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblTasks Task { get; set; }
    }
}
