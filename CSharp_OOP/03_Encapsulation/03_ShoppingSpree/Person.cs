using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
            
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<Product> BagOfProducts 
        {
            get { return this.bagOfProducts; }

            private set { this.bagOfProducts = value; }
        }

        public bool CanAffordProduct(decimal productCost)
        {
            return this.Money - productCost >= 0 ? true : false;
        }

        public void AddProduct(Product product)
        {
            this.BagOfProducts.Add(product);
            this.Money -= product.Cost;
        }

        public override string ToString()
        {
            return this.BagOfProducts.Count > 0 ?
                        $"{this.Name} - {string.Join(", ", this.BagOfProducts)}" :
                        $"{this.Name} - Nothing bought";
        }
    }
}
