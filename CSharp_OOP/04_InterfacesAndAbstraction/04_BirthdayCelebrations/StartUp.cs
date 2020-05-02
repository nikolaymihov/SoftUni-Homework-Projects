using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main()
        {
            List<IIdentifiable> identifiableObjects = new List<IIdentifiable>();
            List<ICreature> creatures = new List<ICreature>();

            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                string[] identifiableObjectAgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type = identifiableObjectAgs[0].ToLower();

                if (type == "citizen")
                {
                    Citizen citizen = CreateCitizen(identifiableObjectAgs);
                    identifiableObjects.Add(citizen);
                    creatures.Add(citizen);
                }
                else if (type == "robot")
                {
                    Robot robot = CreateRobot(identifiableObjectAgs);
                    identifiableObjects.Add(robot);
                }
                else if (type == "pet")
                {
                    Pet pet = CreatePet(identifiableObjectAgs);
                    creatures.Add(pet);
                }

                input = Console.ReadLine();
            }

            string birthdayYear = Console.ReadLine();

            foreach (ICreature creature in creatures)
            {
                string creatureYear = creature.BirthDate.Split('/', StringSplitOptions.RemoveEmptyEntries)[2];

                if (IsABirthdateYear(creatureYear, birthdayYear))
                {
                    Console.WriteLine(creature.BirthDate);
                }
            }

        }

        private static Citizen CreateCitizen(string[] identifiableObjectAgs)
        {
            string name = identifiableObjectAgs[1];
            int age = int.Parse(identifiableObjectAgs[2]);
            string id = identifiableObjectAgs[3];
            string birthdate = identifiableObjectAgs[4];

            Citizen citizen = new Citizen(name, age, id, birthdate);

            return citizen;
        }

        private static Robot CreateRobot(string[] identifiableObjectAgs)
        {
            string model = identifiableObjectAgs[1];
            string id = identifiableObjectAgs[2];

            Robot robot = new Robot(model, id);

            return robot;
        }

        private static Pet CreatePet(string[] identifiableObjectAgs)
        {
            string name = identifiableObjectAgs[1];
            string birthdate = identifiableObjectAgs[2];

            Pet pet = new Pet(name, birthdate);

            return pet;
        }

        private static bool IsFake(string id, string fakeIdIdentifier)
        {
            return id.EndsWith(fakeIdIdentifier) ? true : false;
        }

        private static bool IsABirthdateYear(string year, string birthdayYear)
        {
            return year == birthdayYear;
        }
    }
}
