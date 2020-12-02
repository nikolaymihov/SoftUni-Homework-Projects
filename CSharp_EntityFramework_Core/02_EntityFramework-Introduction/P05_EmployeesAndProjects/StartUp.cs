using System;
using System.Text;
using System.Linq;
using System.Globalization;

using P05_EmployeesAndProjects.Data;

namespace P05_EmployeesAndProjects
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetEmployeesInPeriod(context);

            Console.WriteLine(output);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();


            var employeesInPeriod = context.Employees
                                    .Where(e => e.EmployeesProjects
                                        .Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                            ep.Project.StartDate.Year <= 2003))
                                    .Take(10)
                                    .Select(e => new
                                    {
                                        e.FirstName,
                                        e.LastName,
                                        ManagerFirstName = e.Manager.FirstName,
                                        ManagerLastname = e.Manager.LastName,
                                        Projects = e.EmployeesProjects
                                                    .Select(ep => new
                                                    {
                                                        ProjectName = ep.Project.Name,
                                                        StartDate = ep.Project.StartDate
                                                                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                                        EndDate = ep.Project.EndDate.HasValue ?
                                                                    ep.Project.EndDate.Value
                                                                        .ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                                                    :
                                                                        "not finished"
                                                    }).ToList()
                                    }).ToList();

            foreach (var employee in employeesInPeriod)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} – Manager: {employee.ManagerFirstName} {employee.ManagerLastname}");

                foreach (var project in employee.Projects)
                {
                    output.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }


            return output.ToString().TrimEnd();
        }
    }
}
