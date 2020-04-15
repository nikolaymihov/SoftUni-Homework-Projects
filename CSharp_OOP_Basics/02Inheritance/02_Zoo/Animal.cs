using System;

namespace Zoo
{
    public class Animal
    {
        private string name;

        public Animal(string name)
        {
            this.Name = name;
        }

        public string Name 
        {
            get
            { 
                return this.name; 
            }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("The name of an animal cannot be null.");
                }
                else 
                {
                    this.name = value;
                }
            }
        }

        public override string ToString()
        {
            return $"I am an animal and my name is {this.Name}.";
        }
    }
}
