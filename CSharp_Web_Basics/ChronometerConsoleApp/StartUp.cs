using System;

namespace P01_Chronometer
{
    public class StartUp
    {
        public static void Main()
        {
            var chronometer = new Chronometer();
            var appIsRunning = true;

            while (appIsRunning)
            {
                var command = Console.ReadLine();

                switch(command)
                {
                    case "start":
                        chronometer.Start();
                        break;
                    case "stop":
                        chronometer.Stop();
                        break;
                    case "lap":
                        Console.WriteLine(chronometer.Lap());
                        break;
                    case "laps":
                        Console.WriteLine(chronometer.GetLaps());
                        break;
                    case "time":
                        Console.WriteLine(chronometer.GetTime);
                        break;
                    case "reset":
                        chronometer.Reset();
                        break;
                    case "exit":
                        appIsRunning = false;
                        break;
                }
            }
        }
    }
}
