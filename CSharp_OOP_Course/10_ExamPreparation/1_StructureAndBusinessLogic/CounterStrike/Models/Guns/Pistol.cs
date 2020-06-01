namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLETS_FIRED_AT_ONCE = 1;

        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount > 0)
            {
                this.BulletsCount -= BULLETS_FIRED_AT_ONCE;
                return BULLETS_FIRED_AT_ONCE;
            }
            else
            {
                return 0;
            }
        }
    }
}
