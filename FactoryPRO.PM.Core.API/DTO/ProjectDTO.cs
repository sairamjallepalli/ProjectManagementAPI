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
        public string? name { get; set; }
        public string SpaceId { get; set; }
        public string ModuleId { get; set; }
        public int? ProjectStatus { get; set; }
        public string ProjectPhases { get; set; }
        public int? ProjectManager { get; set; }
        public string? ProjectStartDate { get; set; }
        public string? TargetDate { get; set; }
        public int? Resources { get; set; }
        public string? ActualDate { get; set; }
        public string? CurrentDate { get; set; }
        public string? OriginalPlanDate { get; set; }
        public string? OverridePlanDate { get; set; }
        public string Revision { get; set; }
        public string CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }

        public virtual SpaceDTO Space { get; set; }

        public virtual CustomFieldsDTO customFieldsDTO { get; set; }
        public string type { get; set; }
        //public virtual List<ListDTO> listDTO { get; set; }
        public virtual List<ListDTO> children { get; set; }

    }
}
