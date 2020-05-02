namespace Raiding
{
    public class DruidFactory : HeroFactory
    {
        private readonly string _name;

        public DruidFactory(string name)
        {
            this._name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Druid(this._name);
        }
    }
}
