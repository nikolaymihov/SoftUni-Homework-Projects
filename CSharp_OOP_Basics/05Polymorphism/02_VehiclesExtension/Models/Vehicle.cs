using System;
using Vehicles.Common;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
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

        public double TankCapacity { get; private set; }
        
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
            if (fuelAmmount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_AMOUNT_OF_FUEL_MSG);
            }

            if (this.TankCapacity < fuelAmmount)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MORE_FUEL_THAN_THE_TANK_CAPACITY_MSG, fuelAmmount));
            }

            this.FuelQuantity += fuelAmmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
