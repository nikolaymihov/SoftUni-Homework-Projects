namespace CounterStrike.Core
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    
    using CounterStrike.Models.Maps;
    using CounterStrike.Models.Guns;
    using CounterStrike.Repositories;
    using CounterStrike.Models.Players;
    using CounterStrike.Core.Contracts;
    using CounterStrike.Utilities.Messages;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Repositories.Contracts;
    using CounterStrike.Models.Players.Contracts;

    public class Controller : IController
    {
        private IRepository<IGun> guns;
        private IRepository<IPlayer> players;
        private IMap map;


        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;

            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);

            string outputMessage = string.Format(OutputMessages.SuccessfullyAddedGun, name);
            
            return outputMessage;

        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player;

            IGun gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);

            string outputMessage = string.Format(OutputMessages.SuccessfullyAddedPlayer, username);

            return outputMessage;
        }
        public string StartGame() => this.map.Start((ICollection<IPlayer>)this.players.Models);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            //this is done because I cannot order a ReadOnlyCollection
            IList<IPlayer> playersAsList = (IList<IPlayer>) this.players.Models;
            

            foreach (IPlayer player in playersAsList.OrderBy(p => p.GetType().Name)
                                                    .ThenByDescending(p => p.Health)
                                                    .ThenBy(p => p.Username))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
