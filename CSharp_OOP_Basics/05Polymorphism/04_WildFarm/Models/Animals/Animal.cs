using System;
using System.Collections.Generic;

using WildFarm.Models.Food.Contracts;
using WildFarm.Models.Animals.Contracts;
using WildFarm.Exceptions;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string Uneatable_Food_Exception_Msg = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PrefferedFoods { get; }

        public void Feed(IFood food)
        {
            if (!this.PrefferedFoods.Contains(food.GetType()))
            {
                throw new UneatableFoodException(String.Format(Uneatable_Food_Exception_Msg, this.GetType().Name, food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
