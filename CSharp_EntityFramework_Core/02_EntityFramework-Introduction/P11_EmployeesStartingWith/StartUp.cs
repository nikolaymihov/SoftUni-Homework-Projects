using System;
using System.Text;
using System.Linq;

using P11_EmployeesStartingWith.Data;

namespace P11_EmployeesStartingWith
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetEmployeesByFirstNameStartingWithSa(context);

            Console.WriteLine(output);
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var matchedEmployees = context.Employees
                                   .Where(e => e.FirstName.StartsWith("Sa"))
                                   .Select(e => new
                                   {
                                       e.FirstName,
                                       e.LastName,
                                       e.JobTitle,
                                       e.Salary
                                   })
                                   .OrderBy(e => e.FirstName)
                                   .ThenBy(e => e.LastName)
                                   .ToList();

            foreach (var employee in matchedEmployees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return output.ToString().TrimEnd();
        }
    }
}
