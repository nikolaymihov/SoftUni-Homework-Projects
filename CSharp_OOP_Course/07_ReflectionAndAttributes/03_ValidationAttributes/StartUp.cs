using System;

using ValidationAttributes.Models;
using ValidationAttributes.Utilities;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main()
        {
            Person person = new Person("Pesho", 12);

            bool IsValidEntity = Validator.IsValid(person);
            
            Console.WriteLine(IsValidEntity);
           
        }
    }
}
