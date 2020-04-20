using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double TOPPING_CALORIES_PER_GRAM = 2;
        private const double MEAT_CALORIES_PER_GRAM = 1.2;
        private const double VEGGIES_CALORIES_PER_GRAM = 0.8;
        private const double CHEESE_CALORIES_PER_GRAM = 1.1;
        private const double SAUCE_CALORIES_PER_GRAM = 0.9;

        private string type;
        private double weightInGrams;
        private double caloriesPerGram;

        public Topping(string type, double weightInGrams)
        {
            this.Type = type;
            this.WeightInGrams = weightInGrams;
            this.CaloriesPerGram = GetCaloriesPerGram();
        }

        private string Type 
        {
            get { return this.type; }
            
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value;
            }
        }

        private double WeightInGrams
        {
            get { return this.weightInGrams; }

            set
            {
                if (1 > value || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range[1..50].");
                }

                this.weightInGrams = value;
            }

        }

        public double CaloriesPerGram 
        {
            get { return this.caloriesPerGram; } 
            
            private set
            {
                this.caloriesPerGram = value;
            }
        }

        public double GetAllCalories()
        {
            return this.CaloriesPerGram * this.WeightInGrams;
        }

        private double GetCaloriesPerGram()
        {
            double toppingCalories = GetToppingCalories();

            return TOPPING_CALORIES_PER_GRAM * toppingCalories;
        }

        private double GetToppingCalories()
        {
            double toppingCalories = 0;

            if (this.Type.ToLower() == "meat")
            {
                toppingCalories = MEAT_CALORIES_PER_GRAM;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                toppingCalories = VEGGIES_CALORIES_PER_GRAM;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                toppingCalories = CHEESE_CALORIES_PER_GRAM;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                toppingCalories = SAUCE_CALORIES_PER_GRAM;
            }

            return toppingCalories;
        }

    }
}
