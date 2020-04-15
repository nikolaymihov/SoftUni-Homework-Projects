namespace PlayersAndMonsters
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string heroType = Console.ReadLine();
            string heroUsername = Console.ReadLine();
            int heroLevel = int.Parse(Console.ReadLine());

            object hero = CreateAHero(heroType, heroUsername, heroLevel);

            Console.WriteLine(hero);
        }

        public static object CreateAHero(string type, string username, int level)
        {
            object hero;

            switch (type.ToLower())
            {
                case "elf":
                    hero = new Elf(username, level);
                    break;
                case "museelf":
                    hero = new MuseElf(username, level);
                    break;
                case "wizard":
                    hero = new Wizard(username, level);
                    break;
                case "darkwizard":
                    hero = new DarkWizard(username, level);
                    break;
                case "soulmaster":
                    hero = new SoulMaster(username, level);
                    break;
                case "knight":
                    hero = new Knight(username, level);
                    break;
                case "darkknight":
                    hero = new DarkKnight(username, level);
                    break;
                case "bladeknight":
                    hero = new BladeKnight(username, level);
                    break;
                default:
                    hero = new Hero(username, level);
                    break;
            }

            return hero;
        }
    }
}
