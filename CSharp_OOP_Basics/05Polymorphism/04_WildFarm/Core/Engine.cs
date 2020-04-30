using System;
using System.Linq;
using System.Collections.Generic;

using WildFarm.Factories;
using WildFarm.Exceptions;
using WildFarm.IO.Contracts;
using WildFarm.Core.Contracts;
using WildFarm.Models.Animals;
using WildFarm.Models.Food.Contracts;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Animals.Mammals.Felines;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IAnimal> animals;
        private readonly FoodFactory foodFactory;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.animals = new List<IAnimal>();
            this.foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] animalArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] foodArgs = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                IAnimal animal = CreateAnimal(animalArgs);
                IFood food = this.foodFactory.ProduceFood(foodArgs[0], int.Parse(foodArgs[1]));

                this.animals.Add(animal);

                this.writer.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Feed(food);
                }
                catch (UneatableFoodException ufe)
                {
                    this.writer.WriteLine(ufe.Message);
                }
            }

            foreach (IAnimal animal in this.animals)
            {
                this.writer.WriteLine(animal);
            }
        }

        private static IAnimal CreateAnimal(string[] animalArgs)
        {
            IAnimal animal = null;

            string animalType = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            if (animalType == "Owl")
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(animalArgs[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else
            {
                string livingRegion = animalArgs[3];

                if (animalType == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else if (animalType == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else
                {
                    string breed = animalArgs[4];

                    if (animalType == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (animalType == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                }
            }

            return animal;
        }
    }
}
