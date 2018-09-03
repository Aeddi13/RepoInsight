using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Complexity.BusinessLogic
{
    /// <summary>
    /// Creates instances of the <see cref="File"/> class.
    /// </summary>
    public class FileFactory
    {
        public static File[] CreateFilesForDirectory(string directoryPath)
        {
            List<File> files = new List<File>();

            // Put all file names in the directory into array.
            string[] fileNames = Directory.GetFiles(@directoryPath);
            foreach (string fileName in fileNames)
            {
                string fileContent = System.IO.File.ReadAllText(fileName);

                int lineCount = fileContent.Split('\n').Length;
                int leadingWhitespaceCount = 0;

                File file = new File()
                {
                    LinesOfCode = lineCount,
                    FileName = fileName,
                    NumberOfLeadingSpaces = leadingWhitespaceCount
                };

                files.Add(file);
            }

            return files.ToArray();
        }
    }
}
