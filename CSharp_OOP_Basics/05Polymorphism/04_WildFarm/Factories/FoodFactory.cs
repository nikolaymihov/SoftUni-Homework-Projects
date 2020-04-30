using WildFarm.Models.Food;
using WildFarm.Models.Food.Contracts;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            IFood food = null;

            switch (type.ToLower())
            {
                case "vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "fruit":
                    food = new Fruit(quantity);
                    break;
                case "meat":
                    food = new Meat(quantity);
                    break;
                case "seeds":
                    food = new Seeds(quantity);
                    break;
            }

            return food;
        }
    }
}
