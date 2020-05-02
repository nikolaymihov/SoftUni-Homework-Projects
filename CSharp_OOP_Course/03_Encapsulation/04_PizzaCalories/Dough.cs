using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double DOUGH_CALORIES_PER_GRAM = 2;
        private const double WHITE_FLOUR_CALORIES_PER_GRAM = 1.5;
        private const double WHOLEGRAIN_FLOUR_CALORIES_PER_GRAM = 1;
        private const double CRISPY_BAKED_CALORIES_PER_GRAM = 0.9;
        private const double CHEWY_BAKED_CALORIES_PER_GRAM = 1.1;
        private const double HOMEMADE_BAKED_CALORIES_PER_GRAM = 1;

        private string flourType;
        private string bakingTechnique;
        private double weightInGrams;
        private double caloriesPerGram;

        public Dough(string flourType, string bakingTechnique, double weightInGrams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.WeightInGrams = weightInGrams;
            this.CaloriesPerGram = GetCaloriesPerGram();
        }

        private string FlourType 
        {
            get { return this.flourType; }
            
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }

        }

        private string BakingTechnique
        {
            get { return this.bakingTechnique; }

            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }

        }

        private double WeightInGrams
        {
            get { return this.weightInGrams; }

            set
            {
                if (1 > value || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
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
            double flourCalories = GetFlourCalories();
            double bakingTechniqueCalories = GetBakingCalories();
           
            return DOUGH_CALORIES_PER_GRAM  * flourCalories * bakingTechniqueCalories;
        }

        private double GetFlourCalories()
        {
            double flourCalories = 0;

            if (this.FlourType.ToLower() == "white")
            {
                flourCalories = WHITE_FLOUR_CALORIES_PER_GRAM;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                flourCalories = WHOLEGRAIN_FLOUR_CALORIES_PER_GRAM;
            }

            return flourCalories;
        }

        private double GetBakingCalories()
        {
            double bakingTechniqueCalories = 0;

            if (this.BakingTechnique.ToLower() == "crispy")
            {
                bakingTechniqueCalories = CRISPY_BAKED_CALORIES_PER_GRAM;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                bakingTechniqueCalories = CHEWY_BAKED_CALORIES_PER_GRAM;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                bakingTechniqueCalories = HOMEMADE_BAKED_CALORIES_PER_GRAM;
            }

            return bakingTechniqueCalories;
        }
    }
}
