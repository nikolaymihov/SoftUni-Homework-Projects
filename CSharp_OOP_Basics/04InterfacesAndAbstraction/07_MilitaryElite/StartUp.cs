using System;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();

            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
