using System;

namespace Restaurant
{
    public abstract class Beverage : Product
    {
        private double milliliters;

        public Beverage(string name, decimal price, double milliliters) 
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        public double Milliliters 
        { 
            get
            {
                return this.milliliters;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The quantity of milliliters of a beverage should be higher than 0.");
                }

                this.milliliters = value;
            }
        }
    }
}
