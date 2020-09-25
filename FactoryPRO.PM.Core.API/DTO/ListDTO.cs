using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class ListDTO
    {
        public string ListId { get; set; }
        public string ProjectId { get; set; }
        public string ModuleId { get; set; }
        public string ListName { get; set; }
        public string name { get; set; }
        public int? ListOwnerId { get; set; }
        public int ListStatus { get; set; }
        public string Active { get; set; }
        public int? ListSeq { get; set; }
        public string ListParent { get; set; }
        public string CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public string type { get; set; }
        public List<TaskDTO> tasksDTO { get; set; }

    }
}
