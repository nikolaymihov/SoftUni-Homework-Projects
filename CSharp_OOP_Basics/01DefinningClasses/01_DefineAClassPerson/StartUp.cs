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
            Family family = new Family();

            for (int i = 0; i < inputLines; i++)
            {
                string[] personArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = personArgs[0];
                int personAge = int.Parse(personArgs[1]);

                Person currentPerson = new Person(personName, personAge);
                family.AddMember(currentPerson);
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

        }
    }
}
