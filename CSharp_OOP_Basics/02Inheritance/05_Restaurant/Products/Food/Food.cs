using System;

namespace Restaurant
{
    public abstract class Food : Product
    {
        private double grams;

        public Food(string name, decimal price, double grams) 
            : base(name, price)
        {
            this.Grams = grams;
        }

        public double Grams 
        { 
            get
            {
                return this.grams;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The grams of any food cannot be less or equal to 0.");
                }

                this.grams = value;
            }
        }
    }
}
