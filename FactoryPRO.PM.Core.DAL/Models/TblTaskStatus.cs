using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblTaskStatus
    {
        public TblTaskStatus()
        {
            TblList = new HashSet<TblList>();
            TblProjects = new HashSet<TblProjects>();
            TblTasks = new HashSet<TblTasks>();
            TblTasksHistory = new HashSet<TblTasksHistory>();
        }

        public int Tsid { get; set; }
        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }

        public virtual ICollection<TblList> TblList { get; set; }
        public virtual ICollection<TblProjects> TblProjects { get; set; }
        public virtual ICollection<TblTasks> TblTasks { get; set; }
        public virtual ICollection<TblTasksHistory> TblTasksHistory { get; set; }
    }
}
