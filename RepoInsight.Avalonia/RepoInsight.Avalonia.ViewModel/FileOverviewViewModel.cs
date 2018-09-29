using RepoInsight.BusinessLogic;
using RepoInsight.BusinessLogic.History;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RepoInsight.Avalonia.ViewModel
{
    public class FileOverviewViewModel : INotifyPropertyChanged
    {
        public FileOverviewViewModel()
        {
            _loadFileInfosCommand = new RelayCommand(param => 
            {
                this.LoadFileInfos();
            }, param => true);

            this.DirectoryPath = "E:\\Aeddimedia\\Development\\Gource";
            this.LoadFileInfos();
        }
        
        private List<FileInfo> _fileInfos;

        public List<FileInfo> FileInfos
        {
            get { return _fileInfos; }
            set
            {
                _fileInfos = value;
                RaisePropertyChanged();
            }
        }

        private string _directoryPath;

        public string DirectoryPath
        {
            get { return _directoryPath; }
            set
            {
                _directoryPath = value;
                RaisePropertyChanged();
            }
        }

        private ICommand _loadFileInfosCommand;
        
        public ICommand LoadFileInfosCommand
        {
            get { return _loadFileInfosCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void LoadFileInfos()
        {
            if (string.IsNullOrEmpty(DirectoryPath))
            {
                return;
            }

            FileInfos = new List<FileInfo>();
            
            FileInfo[] fileInfos = FileInfoFactory.CreateFilesForDirectory(DirectoryPath);

            List<ICommit> GitLog = GitCommitFactory.GetCommitsForRepositoryPath(DirectoryPath);

            FileInfoFactory.AddCommitsToFileInfos(fileInfos, GitLog.ToArray());

            Console.Write(GitLog);
            FileInfos.AddRange(fileInfos);
            RaisePropertyChanged(nameof(FileInfos));
        }
    }
}
