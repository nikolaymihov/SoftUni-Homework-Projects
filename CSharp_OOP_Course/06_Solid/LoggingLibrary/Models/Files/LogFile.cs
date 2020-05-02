using System;
using System.IO;
using System.Linq;
using System.Globalization;

using LoggingLibrary.Common;
using LoggingLibrary.Models.Contracts;
using LoggingLibrary.Models.IOManagement;
using LoggingLibrary.Models.Enumerations;

namespace LoggingLibrary.Models.Files
{
    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }

        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();

        /// <summary>
        /// Returns formatted message in provided layout with provided error's data
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="error"></param>
        /// <returns>string formatted message</returns>
        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMessage = string.Format(format,
                    dateTime.ToString(GlobalConstants.DATE_FORMAT,
                    CultureInfo.InvariantCulture),
                    message, level.ToString()) + Environment.NewLine;

            return formattedMessage;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long size = text.Where(char.IsLetter).Sum(ch => ch);

            return size;
        }
    }
}
