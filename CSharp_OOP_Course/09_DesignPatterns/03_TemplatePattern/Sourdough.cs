using System;

namespace P03_TemplatePattern
{
    public class Sourdough : Bread
    {
        public override void MixIngrediants()
        {
            Console.WriteLine("Gathering ingredients for Sourdough bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough bread. (20 minutes)");
        }
    }
}
