namespace CounterStrike.Models.Maps
{
    using System.Linq;
    using System.Collections.Generic;

    using CounterStrike.Models.Players;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players.Contracts;

    public class Map : IMap
    {
        private const string WIN_MESSAGE = "{0} wins!";

        public Map()
        {
        }

        public string Start(ICollection<IPlayer> players)
        {
            ICollection<IPlayer> terrorists = players.Where(p => p.GetType().Name == nameof(Terrorist)).ToList();
            ICollection<IPlayer> counterTerrorists = players.Where(p => p.GetType().Name == nameof(CounterTerrorist)).ToList();

            bool haveAWinners = false;

            while (!haveAWinners)
            {
                if (terrorists.Count > 0)
                {
                    foreach (IPlayer terrorist in terrorists)
                    {
                        int currentTerroristDamage = terrorist.Gun.Fire();

                        if (currentTerroristDamage > 0 && terrorist.IsAlive)
                        {
                            foreach (IPlayer counterTerrorist in counterTerrorists)
                            {
                                counterTerrorist.TakeDamage(currentTerroristDamage);

                                if (!counterTerrorist.IsAlive)
                                {
                                    counterTerrorists.Remove(counterTerrorist);
                                    break;
                                };
                            }
                        }
                    }
                }

                if (counterTerrorists.Count > 0)
                {
                    foreach (IPlayer counterTerrorist in counterTerrorists)
                    {
                        int currentCounterTerroristDamage = counterTerrorist.Gun.Fire();

                        if (currentCounterTerroristDamage > 0 && counterTerrorist.IsAlive)
                        {
                            foreach (IPlayer terrorist in terrorists)
                            {
                                terrorist.TakeDamage(currentCounterTerroristDamage);

                                if (!terrorist.IsAlive)
                                {
                                    terrorists.Remove(terrorist);
                                    break;
                                };
                            }
                        }
                    }
                }

                if (terrorists.Count == 0 || counterTerrorists.Count == 0)
                {
                    haveAWinners = true;
                }
            }

            string winners = terrorists.Count > 0 ? "Terrorist" : "Counter Terrorist";

            return string.Format(WIN_MESSAGE, winners);
        }
    }
}
