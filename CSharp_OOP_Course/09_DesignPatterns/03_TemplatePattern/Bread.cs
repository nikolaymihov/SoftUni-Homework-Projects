using System;

namespace P03_TemplatePattern
{
    public abstract class Bread
    {
        public abstract void MixIngrediants();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }

        //The template method
        public void Make()
        {
            this.MixIngrediants();
            this.Bake();
            this.Slice();
        }
    }
}
