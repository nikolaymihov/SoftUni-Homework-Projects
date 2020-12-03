using System;
using System.Text;
using System.Linq;

using P12_DeleteProjectById.Data;

namespace P12_DeleteProjectById
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = DeleteProjectById(context);

            Console.WriteLine(output);
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var projectToDelete = context.Projects.First(p => p.ProjectId == 2);

            var employeeProjectsRecords = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);

            context.RemoveRange(employeeProjectsRecords);

            context.SaveChanges();

            context.Remove(projectToDelete);

            context.SaveChanges();

            var projectsNames = context.Projects.Take(10).Select(p => p.Name).ToList();

            foreach (var projectName in projectsNames)
            {
                output.AppendLine(projectName);
            }

            return output.ToString().TrimEnd();
        }
    }
}
