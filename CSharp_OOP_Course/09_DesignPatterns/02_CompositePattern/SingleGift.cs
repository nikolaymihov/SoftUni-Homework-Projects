using System;

namespace P02_CompositePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, decimal price) 
            : base(name, price)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            Console.WriteLine($"{this.Name} with the price {this.Price}");

            return this.Price;
        }
    }
}
