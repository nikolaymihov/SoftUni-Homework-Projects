using System;
using System.Linq;
using System.Collections.Generic;

using LoggingLibrary.Core;
using LoggingLibrary.Models;
using LoggingLibrary.Factories;
using LoggingLibrary.Core.Contracts;
using LoggingLibrary.Models.Contracts;

namespace LoggingLibrary
{
    public class StartUp
    {
        public static void Main()
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppendersInput(appendersCount, appenders);

            ILogger logger = new Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFacotry = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];
                string reportLevel = "INFO";

                if (appendersArgs.Length == 3)
                {
                    reportLevel = appendersArgs[2];
                }

                try
                {
                    IAppender appender = appenderFacotry.ProduceAppender(appenderType, layoutType, reportLevel);

                    appenders.Add((appender));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
