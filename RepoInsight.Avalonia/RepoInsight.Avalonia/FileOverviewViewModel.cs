using RepoInsight.BusinessLogic;
using RepoInsight.BusinessLogic.History;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoInsight.Avalonia.View
{
    public class FileOverviewViewModel
    {
        public FileOverviewViewModel()
        {
            FileInfos = new List<FileInfo>();

            string directoryPath = "E:\\Aeddimedia\\Development\\MealPlanner\\Server\\src";
            string repositoryPath = "E:\\Aeddimedia\\Development\\MealPlanner";
            FileInfo[] fileInfos = FileInfoFactory.CreateFilesForDirectory(directoryPath);

            var GitLog = GitCommitFactory.GetCommitsForRepository(repositoryPath);

            FileInfoFactory.AddCommitsToFileInfos(fileInfos, GitLog.ToArray());

            Console.Write(GitLog);
            FileInfos.AddRange(fileInfos);
        }


        public List<FileInfo> FileInfos { get; set; }
        
    }
}
