using System;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal DEFAULT_COFFEE_PRICE = 3.50m;
        private const double DEFAULT_COFFEE_MILLILITERS = 50;

        private double caffeine;

        public Coffee(string name, decimal price, double caffeine)
            : this(name, price, DEFAULT_COFFEE_MILLILITERS, caffeine)
        {
        }
        public Coffee(string name, double milliliters, double caffeine)
            : this(name, DEFAULT_COFFEE_PRICE, milliliters, caffeine)
        {
        }

        public Coffee(string name, double caffeine)
            : this(name, DEFAULT_COFFEE_PRICE, DEFAULT_COFFEE_MILLILITERS, caffeine)
        {
        }

        public Coffee(string name, decimal price, double milliliters, double caffeine)
            : base(name, price, milliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine 
        { 
            get
            {
                return this.caffeine;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The amount of caffeine in a coffee cannot be less or equal to 0.");
                }

                this.caffeine = value;
            }
        }
    }
}
