namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double BUS_FUEL_CONSUMPTION_INCREMENT = 1.4;

        private bool isContainingPeople;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.isContainingPeople = false;
        }

        public bool IsContainingPeople 
        {
            get { return this.isContainingPeople; }

            set 
            { 
                if (value)
                {
                    this.FuelConsumption += BUS_FUEL_CONSUMPTION_INCREMENT;
                }

                this.isContainingPeople = value;
            } 
        }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }

            protected set
            {
                base.FuelConsumption = value;
            }
        }
    }
}
