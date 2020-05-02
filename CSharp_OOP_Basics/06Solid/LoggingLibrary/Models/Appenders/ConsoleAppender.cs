using System;
using System.Text;
using System.Globalization;

using LoggingLibrary.Common;
using LoggingLibrary.Models.Contracts;
using LoggingLibrary.Models.Enumerations;

namespace LoggingLibrary.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, Level level)
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format,
                    dateTime.ToString(GlobalConstants.DATE_FORMAT,
                    CultureInfo.InvariantCulture),
                    message, level.ToString());

            Console.WriteLine(formattedMessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Appender type: {this.GetType().Name}, ")
              .Append($"Layout type: {this.Layout.GetType().Name}, ")
              .Append($"Report level: {this.Level.ToString().ToUpper()}, ")
              .Append($"Messages appended: {this.MessagesAppended}");

            return sb.ToString().TrimEnd();
        }
    }
}
