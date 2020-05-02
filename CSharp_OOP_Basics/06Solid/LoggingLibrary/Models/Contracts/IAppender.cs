using LoggingLibrary.Models.Enumerations;

namespace LoggingLibrary.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        long MessagesAppended { get; }

        void Append(IError error); 
    }
}
