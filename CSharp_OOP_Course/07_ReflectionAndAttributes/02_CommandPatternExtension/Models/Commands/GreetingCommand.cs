using CommandPattern.Core.Contracts;

namespace CommandPattern.Models.Commands
{
    public class GreetingCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return "It's a pleasure to meet you!";
        }
    }
}
