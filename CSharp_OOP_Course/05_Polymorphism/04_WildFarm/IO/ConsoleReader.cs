using System;

using WildFarm.IO.Contracts;

namespace WildFarm.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
