namespace Person
{
    using System;

    public class Child : Person
    {
        private const int CHILD_MAX_AGE = 15;
        public Child(string name, int age) 
            : base(name, age)
        {

        }

        public override int Age
        {
            get 
            { 
                return base.Age; 
            } 
            protected set
            {
                if (value > CHILD_MAX_AGE)
                {
                    throw new InvalidOperationException("A child cannot be older than 15.");
                }
                else
                {
                    base.Age = value;
                }
            }
        }
    }
}
