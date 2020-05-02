using System;

namespace Restaurant
{
    public abstract class Dessert : Food
    {
        private double calories;

        public Dessert(string name, decimal price, double grams, double calories) 
            : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public double Calories 
        { 
            get
            {
                return this.calories;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The amount of calories in a dessert cannot be a negative number.");
                }

                this.calories = value;
            }
        }
    }
}
