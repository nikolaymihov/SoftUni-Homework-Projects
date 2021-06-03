using System.Collections.Generic;

namespace P01_Chronometer.Contracts
{
    public interface IChronometer
    {
        string GetTime { get; }
        
        void Start();

        void Stop();

        string Lap();

        void Reset();
    }
}