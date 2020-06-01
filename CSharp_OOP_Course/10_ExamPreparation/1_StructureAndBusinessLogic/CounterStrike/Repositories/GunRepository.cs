﻿namespace CounterStrike.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using CounterStrike.Utilities.Messages;
    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Repositories.Contracts;
    
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }

            this.guns.Add(model);
        }

        public bool Remove(IGun model) => this.guns.Remove(model);

        public IGun FindByName(string name) => this.guns.FirstOrDefault(g => g.Name == name);
    }
}
