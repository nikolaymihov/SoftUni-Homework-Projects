namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double DEFAULT_GRAMS = 22;

        public Fish(string name, decimal price)
            : this(name, price, DEFAULT_GRAMS)
        {
        }

        public Fish(string name, decimal price, double grams) 
            : base(name, price, grams)
        {
        }
    }
}
