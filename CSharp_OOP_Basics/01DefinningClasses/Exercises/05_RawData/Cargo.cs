namespace DefiningClasses
{
    using System;
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }
        public int CargoWeight 
        { 
            get { return this.cargoWeight; } 
            
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The weight of the cargo cannot be a negative number.");
                }
                else
                {
                    this.cargoWeight = value;
                }
            }
        }

        public string CargoType 
        { 
            get { return this.cargoType; } 

            set { this.cargoType = value; }
        }
    }
}
