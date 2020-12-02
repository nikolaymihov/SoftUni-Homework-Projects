using System;
using System.Text;
using System.Linq;

using P04_InsertAndUpdate.Data;
using P04_InsertAndUpdate.Models;

namespace P04_InsertAndUpdate
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = AddNewAddressToEmployee(context);

            Console.WriteLine(output);
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder output = new StringBuilder();

            Address vitoshaAddress = new Address
                                    { 
                                        AddressText = "Vitoshka 15",
                                        TownId = 4
                                    };

            context.Addresses.Add(vitoshaAddress);

            Employee nakovEmployee = context.Employees
                                            .Where(e => e.LastName == "Nakov")
                                            .FirstOrDefault();

            nakovEmployee.Address = vitoshaAddress;

            context.SaveChanges();

            var employeesAddresses = context.Employees
                                    .OrderByDescending(e => e.AddressId)
                                    .Take(10)
                                    .Select(e => new
                                    {
                                        e.Address.AddressText
                                    })
                                    .ToList();

            foreach (var employeeAddress in employeesAddresses)
            {
                output.AppendLine(employeeAddress.AddressText);
            }


            return output.ToString().TrimEnd();
        }
    }
}
