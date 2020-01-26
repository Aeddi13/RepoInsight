using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RepoInsight.BusinessLogic.Repository.FileSystemImpl
{
    public class FileSystemRepoObjectInfoFactory : IRepoObjectInfoFactory
    {
        /// <summary>
        /// Creates a list of <see cref="IRepoObjectInfo"/> for the given repository.
        /// </summary>
        /// <param name="repositoryPath">
        /// The path of the repository on the file system.
        /// </param>
        /// <returns>A list of <see cref="IRepoObjectInfo"/>.</returns>
        public List<IRepoObjectInfo> CreateObjectInfos(string repositoryPath)
        {
            List<IRepoObjectInfo> objectInfos = new List<IRepoObjectInfo>();

            // add the fileInfos from the subdirectories
            string[] subdirectories = Directory.GetDirectories(repositoryPath);
            foreach (string directory in subdirectories)
            {
                FolderInfo folderInfo = CreateFolderInfo(directory);
                objectInfos.Add(folderInfo);
            }

            // Put all file names in the current directory into an array.
            string[] fileNames = Directory.GetFiles(repositoryPath);
            foreach (string fileName in fileNames)
            {
                FileInfo fileInfo = CreateFileInfo(fileName);

                objectInfos.Add(fileInfo);
            }

            return objectInfos;
        }

        private FileInfo CreateFileInfo(string fileName)
        {
            string fileContent = File.ReadAllText(fileName);

            string[] lines = fileContent.Split('\n');

            int lineCount = lines.Length;
            int leadingWhitespaceCount = 0;

            FileInfo fileInfo = new FileInfo()
            {
                LinesOfCode = lineCount,
                Name = fileName,
            };

            return fileInfo;
        }

        private FolderInfo CreateFolderInfo(string folderName)
        {
            FolderInfo folderInfo = new FolderInfo();
            folderInfo.Name = folderName;

            folderInfo.SubObjects = CreateObjectInfos(folderName);
            folderInfo.UpdateProperties();

            return folderInfo;
        }
    }
}
