using System;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
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
                    throw new ArgumentException("The animal name cannot be null or white space and should be at least 2 symbols long.");
                }

                this.name = value;
            }
        }

        public int Age 
        { 
            get
            {
                return this.age;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The age of an animal cannot be less or equal to 0.");
                }

                this.age = value;
            }
        }

        public Gender Gender
        { 
            get
            {
                return this.gender;
            }
            private set
            {
                this.gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb
              .AppendLine($"{this.GetType().Name}")
              .AppendLine($"{this.Name} {this.Age} {this.Gender}")
              .AppendLine($"{this.ProduceSound()}");

            return sb.ToString().TrimEnd();
        }
    }
}
