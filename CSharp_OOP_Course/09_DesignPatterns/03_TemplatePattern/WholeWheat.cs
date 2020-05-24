using System;

namespace P03_TemplatePattern
{
    public class WholeWheat : Bread
    {
        public override void MixIngrediants()
        {
            Console.WriteLine("Gathering ingredients for Whole Wheat bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat bread. (15 minutes)");
        }

        public override void Slice()
        {
            Console.WriteLine($"Slicing the Whole Wheat bread on 8mm slices!");
        }
    }
}
