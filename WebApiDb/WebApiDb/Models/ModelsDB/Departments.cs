using System;
using System.Collections.Generic;

namespace WebApiDb.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employee = new HashSet<Employee>();
        }

        public uint IdDepartment { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
