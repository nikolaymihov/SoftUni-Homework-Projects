using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        void Feed(IFood food);

        string ProduceSound();

    }
}
