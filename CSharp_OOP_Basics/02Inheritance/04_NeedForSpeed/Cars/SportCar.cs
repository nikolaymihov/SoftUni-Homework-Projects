namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 10;
        
        public SportCar(int horsePower, double fuel) 
            : this(horsePower, fuel, DEFAULT_FUEL_CONSUMPTION)
        {
        }

        public SportCar(int horsePower, double fuel, double fuelConsumption) 
            : base(horsePower, fuel, fuelConsumption)
        {
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
