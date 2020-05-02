using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            List<IIdentifiable> identifiableObjects = new List<IIdentifiable>();

            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                string[] identifiableObjectAgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (identifiableObjectAgs.Length == 3)
                {
                    Citizen citizen = CreateCitizen(identifiableObjectAgs);
                    identifiableObjects.Add(citizen);
                }
                else
                {
                    Robot robot = CreateRobot(identifiableObjectAgs);
                    identifiableObjects.Add(robot);
                }

                input = Console.ReadLine();
            }

            string fakeIdIdentifier = Console.ReadLine();

            foreach (IIdentifiable identifiableObject in identifiableObjects)
            {
                string currentObjectId = identifiableObject.Id;

                if (IsFake(currentObjectId, fakeIdIdentifier))
                {
                    Console.WriteLine(currentObjectId);
                }
            }
        }

        private static Citizen CreateCitizen(string[] identifiableObjectAgs)
        {
            string name = identifiableObjectAgs[0];
            int age = int.Parse(identifiableObjectAgs[1]);
            string id = identifiableObjectAgs[2];

            Citizen citizen = new Citizen(name, age, id);

            return citizen;
        }

        private static Robot CreateRobot(string[] identifiableObjectAgs)
        {
            string model = identifiableObjectAgs[0];
            string id = identifiableObjectAgs[1];

            Robot robot = new Robot(model, id);

            return robot;
        }

        private static bool IsFake(string id, string fakeIdIdentifier)
        {
            return id.EndsWith(fakeIdIdentifier) ? true : false;
        }
    }
}
