﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class SpaceTreeDTO
    {
        public string SpaceId { get; set; }
        public string SpaceName { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        //public List<ProjectDTO> ProjectDTO { get; set; }
        public List<ProjectDTO> children { get; set; }
    }
}
