using System;
using System.Text;
using System.Linq;

using P08_BigDepartments.Data;

namespace P08_BigDepartments
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetDepartmentsWithMoreThan5Employees(context);

            Console.WriteLine(output);
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var departments = context.Departments
                                .Where(d => d.Employees.Count() > 5)
                                .OrderBy(d => d.Employees.Count())
                                .ThenBy(d => d.Name)
                                .Select(d => new
                                {
                                    d.Name,
                                    ManagerFirstname = d.Manager.FirstName,
                                    ManagerLastName = d.Manager.LastName,
                                    Employees = d.Employees
                                        .Select(e => new
                                        {
                                            e.FirstName,
                                            e.LastName,
                                            e.JobTitle
                                        })
                                        .OrderBy(e => e.FirstName)
                                        .ThenBy(e => e.LastName)
                                        .ToList()
                                })
                                .ToList();

            foreach (var department in departments)
            {
                output.AppendLine($"{department.Name} - {department.ManagerFirstname}  {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}
