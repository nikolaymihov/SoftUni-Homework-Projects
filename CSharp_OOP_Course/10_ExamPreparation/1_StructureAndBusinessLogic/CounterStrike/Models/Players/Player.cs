﻿namespace CounterStrike.Models.Players
{
    using System;
    using System.Text;

    using CounterStrike.Utilities.Messages;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Players.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username 
        {
            get => this.username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                this.gun = value;
            }
        }

        public bool IsAlive => this.Health > 0 ? true : false;

        public void TakeDamage(int points)
        {
            if (this.Armor >= points)
            {
                int remainingArmor = this.Armor - points;
                this.Armor = remainingArmor > 0 ? remainingArmor: 0;
            }
            else
            {
                int healthDamage = points - this.Armor;

                int remainingHealth = this.Health - healthDamage;
                this.Health = remainingHealth > 0 ? remainingHealth : 0;
            }
        }

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();
            
            sb
                .AppendLine($"{this.GetType().Name}: {this.Username}")
                .AppendLine($"--Health: {this.Health}")
                .AppendLine($"--Armor: {this.Armor}")
                .AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
