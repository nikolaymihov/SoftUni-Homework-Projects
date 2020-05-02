namespace DefiningClasses
{
    using DefiningClasses;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier modifier = new DateModifier(firstDate, secondDate);
            double daysBetween = modifier.getDifferenceInDays(modifier.FirstDate, modifier.SecondDate);
            
            Console.WriteLine(Math.Abs(daysBetween));
        }
    }
}
