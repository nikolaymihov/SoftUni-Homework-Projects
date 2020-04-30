namespace Raiding
{
    public class RogueFactory : HeroFactory
    {
        private readonly string _name;

        public RogueFactory(string name)
        {
            this._name = name;
        }

        public override BaseHero CreateHero()
        {
            return new Rogue(this._name);
        }
    }
}
