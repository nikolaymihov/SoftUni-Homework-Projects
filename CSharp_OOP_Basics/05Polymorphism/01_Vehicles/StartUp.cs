using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main()
        {
            string[] carArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] truckArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            
            Vehicle car = ProduceVehicle(carArgs);
            Vehicle truck = ProduceVehicle(truckArgs);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    ParseCommand(car, truck);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static Vehicle ProduceVehicle(string[] vehicleArgs)
        {
            Vehicle vehicle = null;

            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);

            if (vehicleType == "Car")
            {
                vehicle = new Car(vehicleFuelQuantity, vehicleFuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(vehicleFuelQuantity, vehicleFuelConsumption);
            }

            return vehicle;
        }

        private static void ParseCommand(Vehicle car, Vehicle truck)
        {
            string[] commandArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commandArgs[0];
            string vehicleType = commandArgs[1];
            double thirdParameter = double.Parse(commandArgs[2]);

            if (command == "Drive")
            {
                if (vehicleType == "Car")
                {
                    car.Drive(thirdParameter);
                    Console.WriteLine($"Car travelled {thirdParameter} km");
                }
                else if (vehicleType == "Truck")
                {
                    truck.Drive(thirdParameter);
                    Console.WriteLine($"Truck travelled {thirdParameter} km");
                }
            }
            else if (command == "Refuel")
            {
                if (vehicleType == "Car")
                {
                    car.Refuel(thirdParameter);
                }
                else if (vehicleType == "Truck")
                {
                    truck.Refuel(thirdParameter);
                }
            }
        }
    }
}
