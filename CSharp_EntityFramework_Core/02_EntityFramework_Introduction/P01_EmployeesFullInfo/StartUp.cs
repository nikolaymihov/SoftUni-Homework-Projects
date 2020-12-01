using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using P01_EmployeesFullInfo.Data;
using P01_EmployeesFullInfo.Models;

namespace P01_EmployeesFullInfo
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetEmployeesFullInformation(context);

            Console.WriteLine(output);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            List<Employee> employees = context.Employees.OrderBy(e => e.EmployeeId).ToList();

            foreach (Employee employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
