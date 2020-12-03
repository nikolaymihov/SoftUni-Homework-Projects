using System;
using System.Linq;

using P13_RemoveTown.Data;

namespace P13_RemoveTown
{
    class StartUp
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            string output = RemoveTown(context);

            Console.WriteLine(output);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townToRemove = context.Towns.First(t => t.Name == "Seattle");

            var addressesToRemove = context.Addresses.Where(a => a.TownId == townToRemove.TownId);

            int addressesCount = addressesToRemove.Count();

            var employeesOnDeletedAddresses = context.Employees.Where(e => addressesToRemove.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employeesOnDeletedAddresses)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToRemove);

            context.Towns.Remove(townToRemove);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted.";
        }
    }
}
