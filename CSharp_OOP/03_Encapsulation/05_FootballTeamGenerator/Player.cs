using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private const int MIN_STAT_VALUE = 0;
        private const int MAX_STAT_VALUE = 100; 

        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name 
        {
            get { return this.name; }
            
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Endurance 
        {
            get { return this.endurance; } 
            
            private set
            {
                if (MIN_STAT_VALUE > value || value > MAX_STAT_VALUE)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.endurance = value;
            }
        }

        public double Sprint
        {
            get { return this.sprint; }

            private set
            {
                if (MIN_STAT_VALUE > value || value > MAX_STAT_VALUE)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.sprint = value;
            }
        }

        public double Dribble
        {
            get { return this.dribble; }

            private set
            {
                if (MIN_STAT_VALUE > value || value > MAX_STAT_VALUE)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.dribble = value;
            }
        }

        public double Passing
        {
            get { return this.passing; }

            private set
            {
                if (MIN_STAT_VALUE > value || value > MAX_STAT_VALUE)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.passing = value;
            }
        }

        public double Shooting
        {
            get { return this.shooting; }

            private set
            {
                if (MIN_STAT_VALUE > value || value > MAX_STAT_VALUE)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between {MIN_STAT_VALUE} and {MAX_STAT_VALUE}.");
                }

                this.shooting = value;
            }
        }
    }
}
