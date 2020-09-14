using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblList
    {
        public TblList()
        {
            TblTasks = new HashSet<TblTasks>();
            TblTasksHistory = new HashSet<TblTasksHistory>();
        }

        public int Lid { get; set; }
        public string ListId { get; set; }
        public string ProjectId { get; set; }
        public string ModuleId { get; set; }
        public string ListName { get; set; }
        public int? ListOwnerId { get; set; }
        public string ListStatus { get; set; }
        public string Active { get; set; }
        public int? ListSeq { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TblProjects Project { get; set; }
        public virtual ICollection<TblTasks> TblTasks { get; set; }
        public virtual ICollection<TblTasksHistory> TblTasksHistory { get; set; }
    }
}
