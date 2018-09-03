using System.Collections.Generic;
using System.IO;

namespace ComplexCity.BusinessLogic
{
    /// <summary>
    /// Creates instances of the <see cref="FileInfo"/> class.
    /// </summary>
    public class FileFactory
    {
        public static FileInfo[] CreateFilesForDirectory(string directoryPath, bool includeSubdirectories = true)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();

            // Put all file names in the current directory into an array.
            string[] fileNames = Directory.GetFiles(directoryPath);
            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = FileFactory.CreateFileInfo(fileName);

                fileInfos.Add(fileInfo);
            }

            // add the fielInfos from the subdirectories
            if (includeSubdirectories)
            {
                string[] subdirectories = Directory.GetDirectories(directoryPath);
                foreach (string directory in subdirectories)
                {
                    fileInfos.AddRange(FileFactory.CreateFilesForDirectory(directory, includeSubdirectories));
                }
            }

            return fileInfos.ToArray();
        }

        private static FileInfo CreateFileInfo(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);

            string[] lines = fileContent.Split('\n');

            int lineCount = lines.Length;
            int leadingWhitespaceCount = 0;

            FileInfo fileInfo = new FileInfo()
            {
                LinesOfCode = lineCount,
                FileName = fileName,
                NumberOfLeadingSpaces = leadingWhitespaceCount
            };

            return fileInfo;
        }
    }
}
