﻿namespace CounterStrike.Repositories
{
    using System;
    using System.Collections.Generic;

    using CounterStrike.Utilities.Messages;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Repositories.Contracts;
    using System.Linq;

    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.players.Add(model);
        }

        public bool Remove(IPlayer model) => this.players.Remove(model);

        public IPlayer FindByName(string name) => this.players.FirstOrDefault(p => p.Username == name);
    }
}
