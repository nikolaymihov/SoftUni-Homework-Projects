using System;
using System.Diagnostics;
using System.Collections.Generic;

using P01_Chronometer.Contracts;

namespace P01_Chronometer
{
    public class Chronometer : IChronometer
    {
        private readonly Stopwatch stopwatch;
        private readonly List<String> laps;
        
        public Chronometer()
        {
            this.stopwatch = new Stopwatch();
            this.laps = new List<string>();
        }

        public string GetTime => this.stopwatch.Elapsed.ToString().Substring(3);
        
        public void Start()
        {
            this.stopwatch.Start();
        }

        public void Stop()
        {
            this.stopwatch.Stop();
        }
        
        public void Reset()
        {
            this.stopwatch.Reset();
            this.laps.Clear();
        }

        public string Lap()
        {
            TimeSpan time = this.stopwatch.Elapsed;
            var lap = time.ToString();

            this.laps.Add(lap);

            return lap;
        }

        public string GetLaps()
        {
            var lapsText = "";

            for (int i = 0; i < this.laps.Count; i++)
            {
                lapsText += $"{i}. {this.laps[i]}{Environment.NewLine}";
            }

            if (this.laps.Count == 0)
            {
                lapsText = "Laps: no laps";
            }

            return lapsText.TrimEnd();
        }
    }
}