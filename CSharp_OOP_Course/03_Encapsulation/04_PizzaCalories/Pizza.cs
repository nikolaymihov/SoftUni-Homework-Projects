using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private int numberOfToppings;

        public Pizza(string name)
        {
            this.Name = name;
            toppings = new List<Topping>();
        }

        public string Name 
        {
            get { return this.name; }
            
            private set
            {
                if (string.IsNullOrEmpty(value) || 1 > value.Length || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough 
        { 
            private get { return this.dough; }
            
            set { this.dough = value; }
        }

        private List<Topping> Toppings 
        {
            get { return this.toppings; }

            set { this.toppings = value; }

        }

        public int NumberOfToppings 
        { 
            get 
            { 
                return this.numberOfToppings; 
            }
            
            private set
            {
                this.numberOfToppings = value;

                if (0 > this.NumberOfToppings || this.NumberOfToppings > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
            }
        }


        public void AddTopping(Topping topping)
        {
            this.Toppings.Add(topping);
            this.NumberOfToppings++;
        }

        public double GetTotalCalories()
        {
            double doughCalories = this.Dough.GetAllCalories();
            
            double toppingsCalories = 0;

            foreach (Topping topping in this.Toppings)
            {
                toppingsCalories += topping.GetAllCalories();
            }

            return doughCalories + toppingsCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.GetTotalCalories():F2} Calories.";
        }
    }
}
