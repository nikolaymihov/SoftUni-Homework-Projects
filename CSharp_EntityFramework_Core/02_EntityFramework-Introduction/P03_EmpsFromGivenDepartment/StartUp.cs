using System;
using System.Text;
using System.Linq;

using P03_EmpsFromGivenDepartment.Data;

namespace P03_EmpsFromGivenDepartment
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetEmployeesFromResearchAndDevelopment(context);

            Console.WriteLine(output);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var emloyess = context
                                  .Employees
                                  .Where(e => e.Department.Name == "Research and Development")
                                  .Select(e => new
                                  {
                                      e.FirstName,
                                      e.LastName,
                                      DepartmentName = e.Department.Name,
                                      e.Salary
                                  })
                                  .OrderBy(e => e.Salary)
                                  .ThenByDescending(e => e.FirstName)
                                  .ToList();

            foreach (var employee in emloyess)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - {employee.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
