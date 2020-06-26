using System;
using System.Collections.Generic;

namespace WebApiDb.Models
{
    public partial class Employee
    {
        public uint IdEmployee { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MidleName { get; set; }
        public uint Deportamen { get; set; }
        public uint Work { get; set; }
        public byte? Experience { get; set; }

        public virtual Departments DeportamenNavigation { get; set; }
        public virtual Work WorkNavigation { get; set; }
        public virtual WorkEmployee WorkEmployee { get; set; }
    }
}
