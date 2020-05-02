namespace NeedForSpeed
{
    public abstract class Car : Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 3;

        public Car(int horsePower, double fuel) 
            : this(horsePower, fuel, DEFAULT_FUEL_CONSUMPTION)
        {
        }

        public Car(int horsePower, double fuel, double fuelConsumption) 
            : base(horsePower, fuel, fuelConsumption)
        {
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
