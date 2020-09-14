using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblTasksHistory
    {
        public int Tid { get; set; }
        public string TaskId { get; set; }
        public string ListId { get; set; }
        public int? DepartmentId { get; set; }
        public string TaskName { get; set; }
        public int? TaskStatus { get; set; }
        public int? Assignee { get; set; }
        public int? TaskParent { get; set; }
        public string IsRequired { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? EstimatedEfforts { get; set; }
        public decimal? CompletedEfforts { get; set; }
        public int? Priority { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblList List { get; set; }
        public virtual TblTasks Task { get; set; }
        public virtual TblTaskStatus TaskStatusNavigation { get; set; }
    }
}
