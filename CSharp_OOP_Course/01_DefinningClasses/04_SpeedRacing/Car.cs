namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car() : this(null, 0, 1, 0)
        {
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) 
            : this(model, fuelAmount, fuelConsumptionPerKilometer, 0)
        {
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = travelledDistance;
        }
        
        public string Model { get; private set; }

        public double FuelAmount
        {
            get {return this.fuelAmount; }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The amount of fuel cannot be a negative number.");
                }
                else
                {
                    this.fuelAmount = value;
                }
            }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException("The fuel consumption should be higher than 0.");
                }
                else
                {
                    this.fuelConsumptionPerKilometer = value;
                }
            }
        }
        
        public double TravelledDistance
        {
            get { return this.travelledDistance; }

            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The travelled distance cannot be a negative number.");
                }
                else
                {
                    this.travelledDistance = value;
                }
            }
        }

        public bool canMakeTheTrip(double distanceToDestination, double fuelAmount, double fuelConsumption)
        {
            return fuelAmount - (distanceToDestination * fuelConsumption) > 0;
        }

        public void Drive(double distance, double fuelAmount, double fuelConsumption)
        {
            this.FuelAmount -= (distance * fuelConsumption);
            this.TravelledDistance += distance;
        }
    }
}
