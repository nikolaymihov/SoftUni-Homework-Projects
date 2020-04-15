﻿namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private const int PERSON_MIN_AGE = 0;

        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public virtual int Age 
        {
            get 
            { 
                return this.age; 
            }
            protected set 
            {
                if (value < PERSON_MIN_AGE)
                {
                    throw new InvalidOperationException("A person cannot have a negative age!");
                }
                else 
                {
                    this.age = value;
                }
                 
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.Name}, Age: {this.Age}");
            
            return sb.ToString().TrimEnd();
        }

    }
}