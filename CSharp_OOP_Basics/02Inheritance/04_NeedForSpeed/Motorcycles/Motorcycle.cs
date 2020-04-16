namespace NeedForSpeed
{
    public abstract class Motorcycle : Vehicle
    {
        public Motorcycle(int horsePower, double fuel) 
            : base(horsePower, fuel)
        {
        }

        protected Motorcycle(int horsePower, double fuel, double fuelConsumption) 
            : base(horsePower, fuel, fuelConsumption)
        {
        }
    }
}
