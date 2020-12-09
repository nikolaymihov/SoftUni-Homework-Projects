using System;
using System.Linq;
using P02_HospitalDatabase.Data;

namespace P02_HospitalDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new HospitalDbContext();

            var doctors = dbContext.Doctors
                                   .Select(d => new
                                   {
                                       d.Name,
                                       d.Specialty
                                   });

            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Hi, I am {doctor.Name} and my specialty is {doctor.Specialty}.");
            }
        }
    }
}
