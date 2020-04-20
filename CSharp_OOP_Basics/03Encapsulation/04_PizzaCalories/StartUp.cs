using System;

namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine();

            try
            {
                engine.Run();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
