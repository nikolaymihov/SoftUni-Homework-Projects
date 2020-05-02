namespace DefiningClasses
{
    using DefiningClasses;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            int inputLines = int.Parse(Console.ReadLine());
            OpinionPoll poll = new OpinionPoll();

            for (int i = 0; i < inputLines; i++)
            {
                string[] personArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = personArgs[0];
                int personAge = int.Parse(personArgs[1]);

                Person currentPerson = new Person(personName, personAge);
                poll.AddMember(currentPerson);
            }

            List<Person> adultMembers = poll.GetAdultMembers();

            if (adultMembers.Count > 0)
            {
                Console.WriteLine("The adult members ordered in alphabetical order are:");

                foreach (Person adultMember in adultMembers.OrderBy(am => am.Name))
                {
                    Console.WriteLine($"{adultMember.Name} - {adultMember.Age}");
                }
            }
            else
            {
                Console.WriteLine("Unfortunately there aren't any adult members in the provided input.");
            }
        }
    }
}
