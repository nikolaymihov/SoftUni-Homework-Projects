using System;

namespace P03_TemplatePattern
{
    public class StartUp
    {
        public static void Main()
        {
            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            Sourdough sourdough = new Sourdough();
            sourdough.Make();

            WholeWheat wholeWeat = new WholeWheat();
            wholeWeat.Make();

        }
    }
}
