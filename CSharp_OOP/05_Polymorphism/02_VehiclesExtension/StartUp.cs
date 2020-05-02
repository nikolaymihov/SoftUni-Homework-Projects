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
            string[] busArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Vehicle car = ProduceVehicle(carArgs);
            Vehicle truck = ProduceVehicle(truckArgs);
            Vehicle bus = ProduceVehicle(busArgs);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    ParseCommand(car, truck, bus);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Vehicle ProduceVehicle(string[] vehicleArgs)
        {
            Vehicle vehicle = null;

            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);
            double vehicleTankCapacity = double.Parse(vehicleArgs[3]);

            if (vehicleType == "Car")
            {
                vehicle = new Car(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(vehicleFuelQuantity, vehicleFuelConsumption, vehicleTankCapacity);
            }

            return vehicle;
        }

        private static void ParseCommand(Vehicle car, Vehicle truck, Vehicle bus)
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
                else if (vehicleType == "Bus")
                {
                    Bus busAsBus = (Bus) bus;
                    busAsBus.IsContainingPeople = true;
                    busAsBus.Drive(thirdParameter);
                    Console.WriteLine($"Bus travelled {thirdParameter} km");
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
                else if (vehicleType == "Bus")
                {
                    bus.Refuel(thirdParameter);
                }
            }
            else if (command == "DriveEmpty") 
            {
                bus.Drive(thirdParameter);
                Console.WriteLine($"Bus travelled {thirdParameter} km");
            }
        }
    }
}
