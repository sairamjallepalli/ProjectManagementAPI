using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblCheckList
    {
        public int Cid { get; set; }
        public string TaskId { get; set; }
        public string CheckListName { get; set; }

        public virtual TblTasks Task { get; set; }
    }
}
