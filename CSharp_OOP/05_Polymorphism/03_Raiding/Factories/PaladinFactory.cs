namespace Raiding
{
    public class PaladinFactory : HeroFactory
    {
        private readonly string _name;

        public PaladinFactory(string name)
        {
            this._name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Paladin(this._name);
        }
    }
}
