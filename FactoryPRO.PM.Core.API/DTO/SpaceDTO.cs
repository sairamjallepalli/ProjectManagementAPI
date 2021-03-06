﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class SpaceDTO
    {
        public string SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModuleID { get; set; }

        public string ProductSpaceId { get; set; }
    }
}
