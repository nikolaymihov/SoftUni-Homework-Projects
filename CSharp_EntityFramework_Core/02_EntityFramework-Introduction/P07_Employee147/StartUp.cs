using System;
using System.Text;
using System.Linq;

using P07_Employee147.Data;

namespace P07_Employee147
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetEmployee147(context);

            Console.WriteLine(output);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var employee147 = context.Employees
                             .Where(e => e.EmployeeId == 147)
                             .Select(e => new
                             {
                                 e.FirstName,
                                 e.LastName,
                                 e.JobTitle,
                                 Projects = e.EmployeesProjects
                                    .Select(ep => ep.Project.Name)
                                    .OrderBy(pn => pn)
                                    .ToList()
                             })
                             .Single();

            output.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            foreach (var projectName in employee147.Projects)
            {
                output.AppendLine($"{projectName}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
