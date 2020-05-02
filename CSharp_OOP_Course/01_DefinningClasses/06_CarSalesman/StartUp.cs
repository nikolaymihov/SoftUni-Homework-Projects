namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfEngines = int.Parse(Console.ReadLine());
            HashSet<Engine> engines = new HashSet<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Engine engine = CreateAnEngine(engineArgs, engineArgs.Length);
                engines.Add(engine);
            }

            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                Car car = CreateACar(carArgs, carArgs.Length, engines);
                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car CreateACar(string[] carArgs, int numberOfParameters, HashSet<Engine> availableEngines)
        {
            Car car = null;
            string model = carArgs[0];
            string engineModel = carArgs[1];
            Engine engine = availableEngines.Where(e => e.Model == engineModel).FirstOrDefault();

            if (numberOfParameters == 4)
            {
                int weight = int.Parse(carArgs[2]);
                string color = carArgs[3];
                 car = new Car(model, engine, weight, color);
            }
            else if (numberOfParameters == 3)
            {
                string thirdParameter = carArgs[2];
                int weight;

                bool isWeight = int.TryParse(thirdParameter, out weight);

                if (isWeight)
                {
                    car = new Car(model, engine, weight);
                }
                else
                {
                    string color = thirdParameter;
                    car = new Car(model, engine, color);
                }
            }
            else if (numberOfParameters == 2)
            {
                car = new Car(model, engine);
            }

            return car;
        }

        public static Engine CreateAnEngine(string[] engineArgs, int numberOfParameters)
        {
            Engine engine = null;
            string model = engineArgs[0];
            int power = int.Parse(engineArgs[1]);

            if (numberOfParameters == 4)
            {
                int displacement = int.Parse(engineArgs[2]);
                string efficiency = engineArgs[3];
                engine = new Engine(model, power, displacement, efficiency);
            }
            else if (numberOfParameters == 3)
            {
                string thirdParameter = engineArgs[2];
                int displacement;

                bool isDisplacement = int.TryParse(thirdParameter, out displacement);

                if (isDisplacement)
                {
                    engine = new Engine(model, power, displacement);
                }
                else
                {
                    string efficiency = thirdParameter;
                    engine = new Engine(model, power, efficiency);
                }
            }
            else if (numberOfParameters == 2)
            {
                engine = new Engine(model, power);
            }

            return engine;
        }
    }
}
