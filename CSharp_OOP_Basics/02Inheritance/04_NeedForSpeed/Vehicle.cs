using System;
using System.Text;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        public Vehicle(int horsePower, double fuel)
            : this(horsePower, fuel, DEFAULT_FUEL_CONSUMPTION)
        {
        }

        public Vehicle(int horsePower, double fuel, double fuelConsumption)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The fuel consumption cannot be a negative number.");
                }

                this.fuelConsumption = value;
            }
        }

        public double Fuel 
        {
            get
            {
                return this.fuel; 
            } 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The ammount of fuel in a vehicle cannot be a negative number.");
                }

                this.fuel = value;
            }
        }

        public int HorsePower 
        {
            get
            {
                return this.horsePower;
            } 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The horse power in a vehicle cannot be a negative number.");
                }

                this.horsePower = value;
            }
        }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hi! I am coming from class: \"{this.GetType().Name}\".");
            sb.AppendLine($"My fuel consumption is: {this.FuelConsumption} and I have {this.Fuel} leters remaining fuel.");

            return sb.ToString().TrimEnd();
        }
    }
}
