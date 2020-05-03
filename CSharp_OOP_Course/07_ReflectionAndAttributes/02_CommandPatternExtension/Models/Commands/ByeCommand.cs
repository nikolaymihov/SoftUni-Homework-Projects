using CommandPattern.Core.Contracts;

namespace CommandPattern.Models.Commands
{
    public class ByeCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Bye-bye {args[0]}";
        }
    }
}
