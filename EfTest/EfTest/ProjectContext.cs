using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() { }
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            
        }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Project;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");
        //}
    }
}
