namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Person
    {
        private string name;
        private int age;

        public Person() : this("No name", 1)
        {
        }

        public Person(int age) : this("No name", age)
        {
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
                
            set
            {
                if (value.Length < 2)
                {
                    throw new InvalidOperationException("Every person should have a name that is at least 2 symbols long!");
                }
                else
                {
                    this.name = value;
                }
            }

        }
        
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 1)
                {
                    throw new InvalidOperationException("Every person should be at least 1 year old!");
                }
                else
                { 
                    this.age = value;
                }
            }
        }
    }
}
