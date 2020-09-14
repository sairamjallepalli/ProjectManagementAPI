using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class TaskDTO
    {
        public TaskDTO()
        {
            //TblTasksHistory = new HashSet<TblTasksHistory>();
        }

        public int Tid { get; set; }
        public string TaskId { get; set; }
        public string ListId { get; set; }
        public string ProjectId { get; set; }
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
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //public virtual TblList List { get; set; }
        //public virtual TblTaskStatus TaskStatusNavigation { get; set; }
        //public virtual ICollection<TblTasksHistory> TblTasksHistory { get; set; }
    }
}
