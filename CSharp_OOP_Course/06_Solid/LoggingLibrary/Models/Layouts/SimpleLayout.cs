using LoggingLibrary.Models.Contracts;

namespace LoggingLibrary.Models.Layouts
{
    class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
