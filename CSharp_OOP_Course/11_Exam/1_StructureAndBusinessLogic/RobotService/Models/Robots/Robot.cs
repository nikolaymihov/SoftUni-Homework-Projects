namespace RobotService.Models.Robots
{
    using System;

    using RobotService.Utilities.Messages;
    using RobotService.Models.Robots.Contracts;

    public abstract class Robot : IRobot
    {
        private const string DEFAULT_OWNER = "Service";

        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }

        public string Name { get; set; }


        public int Energy
        {
            get => this.energy;

            set
            {
                if (0 > value || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }

        public int Happiness 
        { 
            get => this.happiness; 

            set
            {
                if (0 > value || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; } = DEFAULT_OWNER;

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get;  set; }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
