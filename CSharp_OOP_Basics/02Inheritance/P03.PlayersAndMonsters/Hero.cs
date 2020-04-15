using System;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string username;
        private int level;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username 
        {
            get 
            {
                return this.username; 
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException("The username cannot be null.");
                }
                else 
                {
                    this.username = value;
                }
            }
        }

        public int Level 
        { 
            get
            {
                return this.level;
            }
            private set 
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("The level cannot be a negative number.");
                }
                else
                {
                    this.level = value;
                }
            } 
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }

    }
}
