using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main()
        {
            List<IPerson> people = new List<IPerson>();

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                string[] personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                AddPerson(personArgs, people);
            }


            HashSet<IBuyer> buyers = new HashSet<IBuyer>();
            string personName = Console.ReadLine();

            while (personName.ToLower() != "end")
            {
                if (IsAnExistingName(personName, people))
                {
                    IBuyer buyer = (IBuyer)people.Where(p => p.Name == personName).FirstOrDefault();
                    buyer.BuyFood();
                    buyers.Add(buyer);
                }

                personName = Console.ReadLine();
            }

            int sum = GetSumOfAllFood(buyers);
            Console.WriteLine(sum);
        }

        private static void AddPerson(string[] personArgs, List<IPerson> people)
        {
            if (personArgs.Length == 4)
            {
                Citizen citizen = CreateCitizen(personArgs);
                people.Add(citizen);
            }
            else
            {
                Rebel rebel = CreateRebel(personArgs);
                people.Add(rebel);
            }
        }

        private static Citizen CreateCitizen(string[] citizenArgs)
        {
            string name = citizenArgs[0];
            int age = int.Parse(citizenArgs[1]);
            string id = citizenArgs[2];
            string birthdate = citizenArgs[3];

            Citizen citizen = new Citizen(name, age, id, birthdate);

            return citizen;
        }

        private static Rebel CreateRebel(string[] rebelArgs)
        {
            string name = rebelArgs[0];
            int age = int.Parse(rebelArgs[1]);
            string group = rebelArgs[2];

            Rebel rebel = new Rebel(name, age, group);

            return rebel;
        }

        private static bool IsAnExistingName(string name, List<IPerson> people)
        {
            return people.Any(p => p.Name == name);
        }

        private static int GetSumOfAllFood(HashSet<IBuyer> buyers)
        {
            int sum = 0;

            foreach (IBuyer buyer in buyers)
            {
                sum += buyer.Food;
            }

            return sum;
        }
    }
}
