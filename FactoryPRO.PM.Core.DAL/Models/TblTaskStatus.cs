using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblTaskStatus
    {
        public TblTaskStatus()
        {
            TblTasks = new HashSet<TblTasks>();
            TblTasksHistory = new HashSet<TblTasksHistory>();
        }

        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }

        public virtual ICollection<TblTasks> TblTasks { get; set; }
        public virtual ICollection<TblTasksHistory> TblTasksHistory { get; set; }
    }
}
