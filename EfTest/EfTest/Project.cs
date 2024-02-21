using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public Employee ProjectManager { get; set; }
    }
}
