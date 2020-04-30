using WildFarm.IO;
using WildFarm.Core;
using WildFarm.Core.Contracts;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
