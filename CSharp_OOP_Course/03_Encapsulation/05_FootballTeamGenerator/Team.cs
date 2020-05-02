using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        private int rating;

        public Team(string teamName)
        {
            this.Name = teamName;
            this.Players = new List<Player>();
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

        public List<Player> Players
        {
            get { return this.players; }

            private set
            {
                this.players = value;
            }
        }

        public int Rating
        {
            get { return this.rating; }

            private set
            {
                this.rating = value;
            }
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
            CalculateTeamRating();
        }

        public void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }

        private void CalculateTeamRating()
        {
            double rating = 0;

            foreach (Player player in this.Players)
            {
                double playerRating = (player.Endurance + player.Sprint + player.Dribble + player.Passing + player.Shooting) / 5;
                rating += playerRating;
            }
            
            this.Rating = (int) Math.Round(rating / this.Players.Count);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }

    }
}
