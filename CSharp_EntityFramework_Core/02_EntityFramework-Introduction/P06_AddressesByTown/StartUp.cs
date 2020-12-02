using System;
using System.Text;
using System.Linq;

using P06_AddressesByTown.Data;

namespace P06_AddressesByTown
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = GetAddressesByTown(context);

            Console.WriteLine(output);
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            var addresses = context.Addresses
                            .OrderByDescending(a => a.Employees.Count())
                            .ThenBy(a => a.Town.Name)
                            .ThenBy(a => a.AddressText)
                            .Select(a => new 
                            { 
                                a.AddressText,
                                TownName = a.Town.Name,
                                EmployeesCount = a.Employees.Count()
                            })
                            .Take(10)
                            .ToList();


            foreach (var address in addresses)
            {
                output.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return output.ToString().TrimEnd();
        }
    }
}
