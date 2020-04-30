namespace Raiding
{
    public class WarriorFactory : HeroFactory
    {
        private readonly string _name;

        public WarriorFactory(string name)
        {
            this._name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Warrior(this._name);
        }
    }
}
