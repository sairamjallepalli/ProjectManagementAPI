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
    public class FullProjectDTO
    {
        public ProjectDTO   projectDTO { get; set; }
        public List< CustomFieldsDTO> customFieldsDTO { get; set; }
    }
}
