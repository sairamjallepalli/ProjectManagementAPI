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
        public int? ListStatus { get; set; }
        public string Active { get; set; }
        public int? ListSeq { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ListParent { get; set; }

        public virtual TblTaskStatus ListStatusNavigation { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual ICollection<TblTasks> TblTasks { get; set; }
        public virtual ICollection<TblTasksHistory> TblTasksHistory { get; set; }
    }
}
