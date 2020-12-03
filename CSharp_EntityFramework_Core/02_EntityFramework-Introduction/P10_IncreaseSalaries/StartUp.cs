using System;
using System.Text;
using System.Linq;

using P10_IncreaseSalaries.Data;
using P10_IncreaseSalaries.Models;

namespace P10_IncreaseSalaries
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = IncreaseSalaries(context);

            Console.WriteLine(output);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            decimal increasePercentage = 0.12m; 

            IQueryable<Employee> employeesToPromote = context.Employees
                                                             .Where(e => e.Department.Name == "Engineering" ||
                                                                 e.Department.Name == "Tool Design" ||
                                                                 e.Department.Name == "Marketing" ||
                                                                 e.Department.Name == "Information Services"
                                                             );

            foreach (var employee in employeesToPromote)
            {
                employee.Salary += employee.Salary * increasePercentage;
            }

           context.SaveChanges();

            var promotedEmployeesInfo = employeesToPromote
                                                    .Select(e => new
                                                    {
                                                        e.FirstName,
                                                        e.LastName,
                                                        e.Salary
                                                    })
                                                    .OrderBy(e => e.FirstName)
                                                    .ThenBy(e => e.LastName)
                                                    .ToList();
                                        

            foreach (var employee in promotedEmployeesInfo)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return output.ToString().TrimEnd();
        }
    }
}
