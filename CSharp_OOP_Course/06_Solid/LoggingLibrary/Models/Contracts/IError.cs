using System;

using LoggingLibrary.Models.Enumerations;

namespace LoggingLibrary.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
