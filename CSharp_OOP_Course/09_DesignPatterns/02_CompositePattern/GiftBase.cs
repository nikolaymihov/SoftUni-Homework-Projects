namespace P02_CompositePattern
{
    public abstract class GiftBase
    {
        protected GiftBase(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public abstract decimal CalculateTotalPrice();
    }
}
