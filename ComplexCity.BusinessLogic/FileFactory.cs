using System.Collections.Generic;
using System.IO;

namespace Complexity.BusinessLogic
{
    /// <summary>
    /// Creates instances of the <see cref="FileInfo"/> class.
    /// </summary>
    public class FileFactory
    {
        public static FileInfo[] CreateFilesForDirectory(string directoryPath)
        {
            List<FileInfo> files = new List<FileInfo>();

            // Put all file names in the directory into array.
            string[] fileNames = Directory.GetFiles(@directoryPath);
            foreach (string fileName in fileNames)
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

                files.Add(fileInfo);
            }

            return files.ToArray();
        }
    }
}
