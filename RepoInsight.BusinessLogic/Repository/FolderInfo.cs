using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoInsight.BusinessLogic.Repository
{
    /// <summary>
    /// Contains repository information for one folder in the repository
    /// </summary>
    public class FolderInfo : IRepoObjectInfo
    {
        private string _name;
        private int _linesOfCode;
        private int _numberOfRevisions;

        /// <summary>
        /// The name of the file.
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// The lines of code of this file.
        /// </summary>
        public int LinesOfCode
        {
            get => _linesOfCode;

            set
            {
                _linesOfCode = value;
            }
        }

        /// <summary>
        /// The number of changes that have been made to this folder.
        /// </summary>
        public int NumberOfRevisions
        {
            get => _numberOfRevisions;

            set
            {
                _numberOfRevisions = value;
            }
        }

        /// <summary>
        /// Contains a list of sub folders and files inside this folder.
        /// </summary>
        public List<IRepoObjectInfo> SubObjects
        {
            get;
            set;
        }

        public void UpdateProperties()
        {
            foreach(IRepoObjectInfo subObject in SubObjects)
            {
                subObject.UpdateProperties();
            }

            LinesOfCode = SubObjects.Sum(sub => sub.LinesOfCode);
        }
    }
}
