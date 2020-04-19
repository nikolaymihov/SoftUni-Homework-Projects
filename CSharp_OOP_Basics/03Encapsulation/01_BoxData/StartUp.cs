using System;

namespace BoxData
{
    public class StartUp
    {
        public static void Main()
        {
            double boxLength = double.Parse(Console.ReadLine());
            double boxWidth = double.Parse(Console.ReadLine());
            double boxHeight = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(boxLength, boxWidth, boxHeight);
                Console.WriteLine(box.Details());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
