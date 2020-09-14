using System;

namespace FactoryPRO.PM.Core.Common
{
    public class APIResponse
    {
        public int returnCode { get; set; }
        public string  returnMessage { get; set; }
        public object returnObject { get; set; }

    }
}
