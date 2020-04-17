using System;

namespace Restaurant
{
    public abstract class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("The product name cannot be null or white space and should be at least 2 symbols long.");
                }

                this.name = value;
            }
        }

        public decimal Price 
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The price of a product cannot be a negative number or 0.");
                }

                this.price = value;
            }
        }
    }
}
