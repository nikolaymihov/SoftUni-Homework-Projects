namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CAR_FUEL_CONSUMPTION_INCREMENT = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption 
        {
            get { return base.FuelConsumption; }
            
            protected set
            {
                base.FuelConsumption = value + CAR_FUEL_CONSUMPTION_INCREMENT;
            }
        }
    }
}
