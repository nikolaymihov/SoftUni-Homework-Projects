using System.IO;

using LoggingLibrary.Models.Contracts;

namespace LoggingLibrary.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;
        private string folderName;
        private string fileName;

        public IOManager()
        {
            this.currentPath = this.GetCurrentDirectory();
        }

        public IOManager(string folderName, string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath => this.currentPath + this.folderName;

        public string CurrentFilePath => this.CurrentDirectoryPath + this.fileName;

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.AppendAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            return currentDirectory;
        }
    }
}
