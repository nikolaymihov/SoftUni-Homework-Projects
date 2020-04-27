using System;
using Vehicles.Common;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public virtual double FuelConsumption 
        { 
            get { return this.fuelConsumption; }

            protected set
            {
                this.fuelConsumption = value;
            }
        }

        private bool IsThereEnoughFuel(double distanceToDestination, double FuelQuantity, double fuelConsumption)
        {
            return FuelQuantity - (distanceToDestination * fuelConsumption) > 0;
        }

        public void Drive(double kilometers)
        {
            if (IsThereEnoughFuel(kilometers, this.FuelQuantity, this.FuelConsumption))
            {
                this.FuelQuantity -= this.FuelConsumption * kilometers;
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NOT_ENOUGH_FUEL_MSG, this.GetType().Name));
            }
        }

        public virtual void Refuel(double fuelAmmount)
        {
            this.FuelQuantity += fuelAmmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
