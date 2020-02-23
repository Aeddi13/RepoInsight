using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RepoInsight.BusinessLogic.Repository.FileSystemImpl
{
    public class FileSystemRepoObjectInfoFactory : IRepoObjectInfoFactory
    {
        List<string> excludedFileEndings = new List<string>
        {
            ".gitignore",
            ".dll",
        };

        List<string> excludedFolders = new List<string>
        {
            "\\bin",
            "\\obj",
            "\\Debug",
            "\\debug",
            "\\build",
            "\\.git",
            "\\.vs",
        };

        /// <summary>
        /// Creates an <see cref="IRepoObjectInfo"/> for the given repository.
        /// </summary>
        /// <param name="repositoryPath">
        /// The path of the repository on the file system.
        /// </param>
        /// <returns>An <see cref="IRepoObjectInfo"/>.</returns>
        public IRepoObjectInfo CreateObjectInfos(string repositoryPath)
        {
            FolderInfo repoInfo = new FolderInfo();
            repoInfo.Name = repositoryPath;

            List<IRepoObjectInfo> objectInfos = new List<IRepoObjectInfo>();

            // add the fileInfos from the subdirectories
            string[] subdirectories = Directory.GetDirectories(repositoryPath);
            foreach (string directory in subdirectories)
            {
                if (ExcludeThisFolder(directory))
                {
                    continue;
                }

                FolderInfo folderInfo = CreateFolderInfo(directory);
                objectInfos.Add(folderInfo);
            }

            // Put all file names in the current directory into an array.
            string[] fileNames = Directory.GetFiles(repositoryPath);
            foreach (string fileName in fileNames)
            {
                if (ExcludeThisFile(fileName))
                {
                    continue;
                }

                FileInfo fileInfo = CreateFileInfo(fileName);
                objectInfos.Add(fileInfo);
            }

            repoInfo.SubObjects = objectInfos;
            repoInfo.UpdateProperties();

            return repoInfo;
        }

        private bool ExcludeThisFolder(string folderName)
        {
            foreach (string excludedFolder in excludedFolders)
            {
                if (folderName.Contains(excludedFolder))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ExcludeThisFile(string folderName)
        {
            foreach (string excludedFileEnding in excludedFileEndings)
            {
                if (folderName.EndsWith(excludedFileEnding))
                {
                    return true;
                }
            }

            return false;
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
