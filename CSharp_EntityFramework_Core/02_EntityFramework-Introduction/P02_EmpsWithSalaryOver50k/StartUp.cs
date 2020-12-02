using System;
using System.Text;
using System.Linq;

using P02_EmpsWithSalaryOver50k.Data;

namespace P02_EmpsWithSalaryOver50k
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetEmployeesWithSalaryOver50000(context);

            Console.WriteLine(output);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var emloyess = context
                                  .Employees
                                  .Where(e => e.Salary > 50000)
                                  .Select(e => new
                                  {
                                      e.FirstName,
                                      e.Salary
                                  })
                                  .OrderBy(e => e.FirstName)
                                  .ToList();

            foreach (var employee in emloyess)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
