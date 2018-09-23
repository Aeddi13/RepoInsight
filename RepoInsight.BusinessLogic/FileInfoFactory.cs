using RepoInsight.BusinessLogic.History;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RepoInsight.BusinessLogic
{
    /// <summary>
    /// Creates instances of the <see cref="FileInfo"/> class.
    /// </summary>
    public class FileInfoFactory
    {
        public static FileInfo[] CreateFilesForDirectory(string directoryPath, bool includeSubdirectories = true)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();

            // Put all file names in the current directory into an array.
            string[] fileNames = Directory.GetFiles(directoryPath);
            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = FileInfoFactory.CreateFileInfo(fileName);

                fileInfos.Add(fileInfo);
            }

            // add the fileInfos from the subdirectories
            if (includeSubdirectories)
            {
                string[] subdirectories = Directory.GetDirectories(directoryPath);
                foreach (string directory in subdirectories)
                {
                    fileInfos.AddRange(FileInfoFactory.CreateFilesForDirectory(directory, true));
                }
            }

            fileInfos.Sort(FileInfoSortHelper.CompareFileInfosByLinesOfCode);
            return fileInfos.ToArray();
        }
        
        public static void AddCommitsToFileInfos(FileInfo[] fileInfos, ICommit[] commits)
        {
            foreach (FileInfo fileInfo in fileInfos)
            {
                foreach (ICommit commit in commits)
                {
                    if (commit.CommitedFiles.Contains(fileInfo.FileName))
                    {
                        fileInfo.NumberOfRevisions++;
                    }
                }
            }
        }

        private static FileInfo CreateFileInfo(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);

            string[] lines = fileContent.Split('\n');

            int lineCount = lines.Length;
            int leadingWhitespaceCount = 0;

            foreach (string line in lines)
            {
                // skip if line is a comment
                if (StringHelper.IsLineAComment(line))
                {
                    continue;
                }

                // replace tabs with 4 whitespaces
                string lineValue = StringHelper.ReplaceTabsWithWhitespaces(line);

                int leadingSpaces = lineValue.TakeWhile(Char.IsWhiteSpace).Count();
                leadingWhitespaceCount += leadingSpaces;
            }

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
