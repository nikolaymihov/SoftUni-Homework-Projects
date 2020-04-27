using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
        private const double FUEL_EFFICIENCY_PERCENTAGE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }

            protected set
            {
                base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT;
            }
        }

        public override void Refuel(double fuelAmmount)
        {
            base.Refuel(fuelAmmount * FUEL_EFFICIENCY_PERCENTAGE);
        }
    }
}
