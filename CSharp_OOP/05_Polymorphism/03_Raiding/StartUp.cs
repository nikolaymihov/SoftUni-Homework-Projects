using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        public static void Main()
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            HeroFactory factory = null;

            int neededHeroes = int.Parse(Console.ReadLine());
            int countOfValidHeroes = 0;

            while (neededHeroes != countOfValidHeroes)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = GetHero(heroName, heroType, factory);
                    raidGroup.Add(hero);

                    countOfValidHeroes++;
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
            
            int bossPower = int.Parse(Console.ReadLine());

            PrintAbilities(raidGroup);

            int totalDamageOfAllHeroes = SumTotalDamage(raidGroup);
            
            if (totalDamageOfAllHeroes >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }

        private static BaseHero GetHero(string heroName, string heroType, HeroFactory factory)
        {
            switch (heroType.ToLower())
            {
                case "druid":
                    factory = new DruidFactory(heroName);
                    break;
                case "paladin":
                    factory = new PaladinFactory(heroName);
                    break;
                case "rogue":
                    factory = new RogueFactory(heroName);
                    break;
                case "warrior":
                    factory = new WarriorFactory(heroName);
                    break;
                default:
                    throw new InvalidOperationException("Invalid hero!");
            }

            return factory.CreateHero();
        }

        private static void PrintAbilities(List<BaseHero> raidGroup)
        {
            foreach (BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }
        }

        private static int SumTotalDamage(List<BaseHero> raidGroup)
        {
            int totalDamageOfAllHeroes = 0;

            foreach (BaseHero hero in raidGroup)
            {
                totalDamageOfAllHeroes += hero.Power;
            }

            return totalDamageOfAllHeroes;
        }
    }
}