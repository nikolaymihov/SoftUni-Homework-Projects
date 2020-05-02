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
            Dictionary<string,Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < inputLines; i++)
            {
                string[] carArgs = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = carArgs[0];
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumption = double.Parse(carArgs[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(currentCar.Model, currentCar);
            }

            string command = Console.ReadLine();

            while (command.ToUpper() != "END" )
            {
                string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string modelToDrive = commandArgs[1];
                double ammountOfKm = double.Parse(commandArgs[2]);

                Car carForTheTrip = cars[modelToDrive];
                double amountOfFuel = carForTheTrip.FuelAmount;
                double carConsumption = carForTheTrip.FuelConsumptionPerKilometer;

                if (carForTheTrip.canMakeTheTrip(ammountOfKm, amountOfFuel, carConsumption))
                {
                    carForTheTrip.Drive(ammountOfKm, amountOfFuel, carConsumption);
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive.");
                }

                command = Console.ReadLine();
            }

            foreach (string model in cars.Keys)
            {
                Car car = cars[model];

                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
