using System;
using System.Linq;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                string[] citizenArgs = input.Split(' ').ToArray();

                Citizen citizen = CreateCitizen(citizenArgs);

                IPerson citizenAsPerson = citizen;
                IResident citizenAsResident = citizen;

                Console.WriteLine(citizenAsPerson.GetName());
                Console.WriteLine(citizenAsResident.GetName());

                input = Console.ReadLine();
            }
        }

        private static Citizen CreateCitizen(string[] citizenArgs)
        {
            string name = citizenArgs[0];
            string country = citizenArgs[1];
            int age = int.Parse(citizenArgs[2]);

            Citizen citizen = new Citizen(name, country, age);

            return citizen;
        }
    }
}
