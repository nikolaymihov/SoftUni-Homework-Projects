namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DEFAULT_PRICE = 5m;
        private const double DEFAULT_GRAMS = 250;
        private const double DEFAULT_CALORIES = 1000;

        public Cake(string name)
            : this(name, DEFAULT_PRICE, DEFAULT_GRAMS, DEFAULT_CALORIES)
        {
        }

        public Cake(string name, decimal price)
            : this(name, price, DEFAULT_GRAMS, DEFAULT_CALORIES)
        {
        }

        public Cake(string name, double grams)
            : this(name, DEFAULT_PRICE, grams, DEFAULT_CALORIES)
        {
        }

        public Cake(string name, double grams, double calories)
            : this(name, DEFAULT_PRICE, grams, calories) 
        {
        }

        public Cake(string name, decimal price, double grams)
            :this(name, price, grams, DEFAULT_CALORIES)
        {
        }

        public Cake(string name, decimal price, double grams, double calories) 
            : base(name, price, grams, calories)
        {
        }
    }
}
