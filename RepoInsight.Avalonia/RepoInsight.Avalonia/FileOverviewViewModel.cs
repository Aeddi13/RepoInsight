using RepoInsight.BusinessLogic;
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
            FileInfo[] fileInfos = FileInfoFactory.CreateFilesForDirectory(directoryPath);
            FileInfos.AddRange(fileInfos);
        }


        public List<FileInfo> FileInfos { get; set; }
    }
}
