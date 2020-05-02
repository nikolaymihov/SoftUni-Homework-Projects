using System.Text;

using LoggingLibrary.Models.Contracts;
using LoggingLibrary.Models.Enumerations;

namespace LoggingLibrary.Models.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, Level level, IFile file)
        {
            this.Layout = layout;
            this.Level = level;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }

        public IFile File { get; private set; }

        public long MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);

            this.MessagesAppended++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Appender type: {this.GetType().Name}, ")
              .Append($"Layout type: {this.Layout.GetType().Name}, ")
              .Append($"Report level: {this.Level.ToString().ToUpper()}, ")
              .Append($"Messages appended: {this.MessagesAppended}, ")
              .Append($"File size {this.File.Size}");

            return sb.ToString().TrimEnd();
        }
    }
}
