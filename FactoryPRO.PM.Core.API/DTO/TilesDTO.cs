using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class TilesDTO
    {
        public int TotalProjectsCount { get; set; }
        public int ActiveTasksCount { get; set; }
        public int OverDueTasksCount { get; set; }
    }
}
