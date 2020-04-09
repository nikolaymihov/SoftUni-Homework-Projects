using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Car car = CarCreator(carArgs);
                cars.Add(car);
            }

            string command = Console.ReadLine().ToLower();
            List<Car> selection = new List<Car>();

            if (command == "fragile")
            {
                selection = cars.Where(c => c.Cargo.CargoType == command && c.Tires.Any(t => t.TirePressure < 1)).ToList();
            }
            else if (command == "flamable")
            {
                selection = cars.Where(c => c.Cargo.CargoType == command && c.Engine.EnginePower > 250).ToList();
            }

            foreach (Car car in selection)
            {
                Console.WriteLine(car);
            }
        }

        public static Car CarCreator(string[] carArgs)
        {
            string model = carArgs[0];
            
            int engineSpeed = int.Parse(carArgs[1]);
            int enginePower = int.Parse(carArgs[2]);
            Engine engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(carArgs[3]);
            string cargoType = carArgs[4];
            Cargo cargo = new Cargo(cargoWeight, cargoType);

            List<Tire> tires = new List<Tire>();

            for (int i = 5; i < carArgs.Length; i+= 2)
            {
                double tirePressure = double.Parse(carArgs[i]);
                int tireAge = int.Parse(carArgs[i + 1]);
                
                Tire tire = new Tire(tirePressure, tireAge);
                tires.Add(tire);
            }

            return new Car(model, engine, cargo, tires);
        }
    }
}
