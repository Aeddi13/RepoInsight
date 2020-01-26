using RepoInsight.BusinessLogic.Repository;

namespace RepoInsight.BusinessLogic
{
    /// <summary>
    /// Represents a file that has been read from the file system.
    /// </summary>
    public class FileInfo : IRepoObjectInfo
    {
        private double _leadingSpacesPerLine;
        private string _fileName;
        private int _linesOfCode;
        private int _numberOfLeadingSpaces;
        private int _numberOfRevisions;

        /// <summary>
        /// The name of the file.
        /// </summary>
        public string Name
        {
            get => _fileName;

            set
            {
                _fileName = value;
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
                RefreshLeadingSpacesPerLine();
            }
        }

        /// <summary>
        /// The total number of leading whitespaces and tabs in this file.
        /// 1 Tab counts as 4 whitespaces;
        /// </summary>
        public int NumberOfLeadingSpaces
        {
            get => _numberOfLeadingSpaces;

            set
            {
                _numberOfLeadingSpaces = value;
                RefreshLeadingSpacesPerLine();
            }
        }

        /// <summary>
        /// Gets the <see cref="NumberOfLeadingSpaces"/> divided by the <see cref="LinesOfCode"/>.
        /// </summary>
        public double LeadingSpacesPerLine
        {
            get;
            private set;
        }

        /// <summary>
        /// Updates the <see cref="LeadingSpacesPerLine"/>.
        /// </summary>
        private void RefreshLeadingSpacesPerLine()
        {
            LeadingSpacesPerLine = ((double)NumberOfLeadingSpaces) / ((double)LinesOfCode);
        }


        /// <summary>
        /// The name of the file.
        /// </summary>
        public int NumberOfRevisions
        {
            get => _numberOfRevisions;

            set
            {
                _numberOfRevisions = value;
            }
        }
    }
}
