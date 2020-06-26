using System;
using System.Collections.Generic;

namespace WebApiDb.Models
{
    public partial class Work
    {
        public Work()
        {
            Employee = new HashSet<Employee>();
        }

        public uint IdWork { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
