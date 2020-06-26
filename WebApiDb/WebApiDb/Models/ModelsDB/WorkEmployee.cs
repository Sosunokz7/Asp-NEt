using System;
using System.Collections.Generic;

namespace WebApiDb.Models
{
    public partial class WorkEmployee
    {
        public uint IdEmploye { get; set; }
        public ushort? Yeаr { get; set; }
        public byte Month { get; set; }
        public string PlanFact { get; set; }

        public virtual Employee IdEmployeNavigation { get; set; }
    }
}
