namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 8;

        public RaceMotorcycle(int horsePower, double fuel) 
            : this(horsePower, fuel, DEFAULT_FUEL_CONSUMPTION)
        {
        }

        public RaceMotorcycle(int horsePower, double fuel, double fuelConsumption) 
            : base(horsePower, fuel,  fuelConsumption)
        {
        }

        public override void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }
    }
}
