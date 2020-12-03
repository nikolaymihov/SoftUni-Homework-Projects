using System;
using System.Text;
using System.Linq;
using System.Globalization;

using P09_GetLatestProjects.Data;

namespace P09_GetLatestProjects
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetLatestProjects(context);

            Console.WriteLine(output);
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var latestProjects = context.Projects
                                        .OrderByDescending(p => p.StartDate)
                                        .Take(10)
                                        .OrderBy(p => p.Name)
                                        .Select(p => new
                                        {
                                            p.Name,
                                            p.Description,
                                            StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                        })
                                        .ToList();

            foreach (var project in latestProjects)
            {
                output.AppendLine(project.Name);
                output.AppendLine(project.Description);
                output.AppendLine(project.StartDate);
            }

            return output.ToString().TrimEnd();
        }
    }
}
