using RepoInsight.BusinessLogic.Repository;
using RepoInsight.BusinessLogic.Repository.FileSystemImpl;
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
        }

        private List<IRepoObjectInfo> _fileInfos;

        public List<IRepoObjectInfo> FileInfos
        {
            get { return _fileInfos; }
            set
            {
                _fileInfos = value;
                RaisePropertyChanged();
            }
        }

        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
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

            FileSystemRepoObjectInfoFactory factory = new FileSystemRepoObjectInfoFactory();
            IRepoObjectInfo repoInfo = factory.CreateObjectInfos(DirectoryPath);

            //FileInfo[] fileInfos = FileInfoFactory.CreateFilesForDirectory(DirectoryPath);

            //List<ICommit> GitLog = GitCommitFactory.GetCommitsForRepositoryPath(DirectoryPath);

            //FileInfoFactory.AddCommitsToFileInfos(fileInfos, GitLog.ToArray());

            this.FileInfos = repoInfo.SubObjects;
            this.FileName = repoInfo.Name;
        }
    }
}
