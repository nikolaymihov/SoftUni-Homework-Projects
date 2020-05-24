using System;

namespace P03_TemplatePattern
{
    public class TwelveGrain : Bread
    {
        public override void MixIngrediants()
        {
            Console.WriteLine("Gathering ingredients for 12-Grain bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain bread. (25 minutes)");
        }
    }
}
