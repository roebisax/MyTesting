using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new HostApplicationBuilder();
            app.Configuration.AddJsonFile("appsettings.json");

            string connectionSTring = app.Configuration.GetConnectionString("sql") ??"";

            app.Services.AddDbContext<ProjectContext>(options =>
            {
                options.UseSqlServer(app.Configuration.GetConnectionString("sql"));
            });

            var host = app.Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ProjectContext>();
                {
                    var list =
                        db.Employees
                        .Where(e => e.State.Equals("WA"))
                        .ToList();
                    list.ForEach(l => Console.Write($"{l.Name} "));
                    Console.WriteLine("");

                    list =
                        (from e in db.Employees
                         where e.State.Equals("WA")
                         select e)
                        .ToList();
                    list.ForEach(l => Console.Write($"{l.Name} "));
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------------------");
                }

                {
                    Console.WriteLine("Liste der Departments mit dem Salär des bestverdienenden Mitarbeiters");

                    var listQuery =
                        (from d in db.Departments
                         join e in db.Employees on d.Id equals e.DepId into g
                         let maxSal = g.Max(g => g.Salary)
                         orderby maxSal descending
                         select new
                         {
                             DepName = d.Name,
                             MaxSalaer = maxSal
                         }

                         );

                    var listQuery2 =
                        db.Departments
                        .GroupJoin(
                            db.Employees,
                            d => d.Id,
                            e => e.DepId,
                            (d, e) => new
                            {
                                DepName = d.Name,
                                MaxSalaer = e.Max(e => e.Salary)
                            }).OrderByDescending(l => l.MaxSalaer);


                    var listQuery3 =
                        (from d in db.Departments
                         from e in db.Employees
                         where d.Id == e.DepId
                         select new
                         {
                             DepName = d.Name,
                             Salaer = e.Salary
                         } into g
                         group g by g.DepName into h
                         select new
                         {
                             DepName = h.Key,
                             MaxSalaer = h.Max(s => s.Salaer)
                         } into sorted
                         orderby sorted.MaxSalaer descending
                         select sorted
                         );

                    var list = listQuery.ToList();
                    list = listQuery2.ToList();
                    list = listQuery3.ToList();
                    list = listQuery3.ToList();
                    list = listQuery3.ToList();
                    list = listQuery3.ToList();
                }
                

            }

        }
    }
}
