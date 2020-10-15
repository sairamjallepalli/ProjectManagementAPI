using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class TilesDTO
    {
        public int ActiveProjectsCount { get; set; }
        public int PendingProjectsCount { get; set; }

        
        public int TotalTasksCount { get; set; }
        public int CompletedTasksCount { get; set; }

        public int OverDueProjectsCount { get; set; }
        public int OverDueTasksCount { get; set; }   

        public int NewProjectsCount { get; set; }
        //ActiveProjectsCount
        public int HoldProjectsCount { get; set; }
        public int CompletedProjectsCount { get; set; }
        public int RejectedProjectsCount { get; set; }


    }
}
