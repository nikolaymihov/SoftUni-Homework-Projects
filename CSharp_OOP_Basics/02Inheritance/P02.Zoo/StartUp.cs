namespace Zoo
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string animalType = Console.ReadLine();
            string animalName = Console.ReadLine();

            object animal = GetAnimal(animalType, animalName);

            Console.WriteLine(animal);
            Console.WriteLine($"I am comming from class \"{animal.GetType().Name}\".");
        }

        public static object GetAnimal(string type, string name)
        {
            object animal;
            
            switch (type.ToLower())
            {
                case "mammal":
                    animal = new Mammal(name);
                    break;
                case "gorilla":
                    animal = new Gorilla(name);
                    break;
                case "bear":
                    animal = new Bear(name);
                    break;
                case "reptile":
                    animal = new Reptile(name);
                    break;
                case "lizard":
                    animal = new Lizard(name);
                    break;
                case "snake":
                    animal = new Snake(name);
                    break;
                default:
                    animal = new Animal(name);
                    break;
            }

            return animal;
        }
    }
}
