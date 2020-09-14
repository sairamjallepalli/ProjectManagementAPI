using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblProjects
    {
        public TblProjects()
        {
            TblCustomFields = new HashSet<TblCustomFields>();
            TblList = new HashSet<TblList>();
            TblTasks = new HashSet<TblTasks>();
        }

        public int Pid { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string SpaceId { get; set; }
        public string ModuleId { get; set; }
        public int? ProjectStatus { get; set; }
        public string ProjectPhases { get; set; }
        public int? ProjectManager { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public int? Resources { get; set; }
        public DateTime? ActualDate { get; set; }
        public DateTime? CurrentDate { get; set; }
        public DateTime? OriginalPlanDate { get; set; }
        public DateTime? OverridePlanDate { get; set; }
        public string Revision { get; set; }
        public string ParentProjectId { get; set; }
        public string IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual TblSpace Space { get; set; }
        public virtual ICollection<TblCustomFields> TblCustomFields { get; set; }
        public virtual ICollection<TblList> TblList { get; set; }
        public virtual ICollection<TblTasks> TblTasks { get; set; }
    }
}
