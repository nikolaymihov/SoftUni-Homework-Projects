using WildFarm.Models.Food.Contracts;

namespace WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
