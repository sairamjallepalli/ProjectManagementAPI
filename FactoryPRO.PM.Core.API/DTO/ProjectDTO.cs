using FactoryPRO.PM.Core.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjectDTO
    {
        /// <summary>
        /// 
        /// </summary>
        //public ProjectDTO()
        //{
        //    listDTO = new HashSet<ListDTO>();
        //}
        public int Pid { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string name { get; set; }
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
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual SpaceDTO Space { get; set; }

        public virtual CustomFieldsDTO customFieldsDTO { get; set; }
        public string type { get; set; }
        //public virtual List<ListDTO> listDTO { get; set; }
        public virtual List<ListDTO> children { get; set; }

    }
}
