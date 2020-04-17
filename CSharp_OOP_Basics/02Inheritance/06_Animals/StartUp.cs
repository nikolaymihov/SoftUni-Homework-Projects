namespace Animals
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string animalInput = Console.ReadLine();
            StringBuilder output = new StringBuilder();

            while (animalInput.ToLower() != "beast!")
            {
                string animalType = animalInput;
                string[] animalArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    Animal currentAnimal = GetAnimal(animalType, animalArgs);
                    output.AppendLine(currentAnimal.ToString());
                }
                catch (Exception)
                {
                    output.AppendLine("Invalid input!");
                }
                
                animalInput = Console.ReadLine();
            }

            Console.WriteLine(output.ToString().TrimEnd());
        }

        public static Animal GetAnimal(string animalType, string[] animalArgs)
        {
            Animal animal = null;

            string name = animalArgs[0];
            int age = int.Parse(animalArgs[1]);
            Gender gender =  animalArgs[2].ToLower() == "male" ? Gender.Male : Gender.Female;

            switch (animalType.ToLower())
            {
                case "dog":
                    animal = new Dog(name, age, gender);
                    break;
                case "frog":
                    animal = new Frog(name, age, gender);
                    break;
                case "cat":
                    animal = new Cat(name, age, gender);
                    break;
                case "tomcat":
                    animal = new Tomcat(name, age);
                    break;
                case "kitten":
                    animal = new Kitten(name, age);
                    break;
            }

            return animal;
        }
    }
}
