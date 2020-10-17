using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string name { get; set; }
        public int? TaskStatus { get; set; }
        public string? Assignee { get; set; }
        public string TaskParent { get; set; }
        public string IsRequired { get; set; }
        public string? StartDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? EstimatedEfforts { get; set; }
        public decimal? CompletedEfforts { get; set; }
        public int? Priority { get; set; }
        public string CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public string ProductTaskId { get; set; }
        public bool? criticalpart { get; set; }
        public string? notes { get; set; }
        public int? predecessor { get; set; }
        public virtual List<TaskFilesDTO> TaskFiles { get; set; }

        //public virtual TblList List { get; set; }
        //public virtual TblTaskStatus TaskStatusNavigation { get; set; }
        //public virtual ICollection<TblTasksHistory> TblTasksHistory { get; set; }
    }

    public class TaskFilesDTO
    {
        public int ProductID { get; set; }
        public System.Guid FileGuid { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public string ProjectName { get; set; }
        public string IsExists { get; set; }
        public int ModuleID { get; set; }
        public int DepartmentID { get; set; }
        public IFormFile NewFileStream { get; set; }

        public System.Guid ActionBy { get; set; }
        [DisplayFormat(DataFormatString = Constants.DateOnlyFormat)]
        public DateTime ActionDate { get; set; }
    }

    public static class Constants
    {
        public const string DateOnlyFormat = "{0:MM/dd/yyyy}";
    }
}
