namespace DefiningClasses
{
    using System;
    
    public class Tire
    {
        private double tirePressure;
        private int tireAge;

        public Tire(double tirePressure, int tireAge)
        {
            this.TirePressure = tirePressure;
            this.TireAge = tireAge;
        }

        public double TirePressure
        {
            get { return this.tirePressure; }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The tire pressure cannot be lower than 0.");
                }
                else
                {
                    this.tirePressure = value;
                }
            }
        }

        public int TireAge 
        {
            get { return this.tireAge; }
            
            set
            {
                if (value > 20)
                {
                    throw new InvalidOperationException("The released date of the tire cannot be before 2000y.");
                }
            }
        }
    }
}
