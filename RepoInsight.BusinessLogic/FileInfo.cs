﻿namespace RepoInsight.BusinessLogic
{
    /// <summary>
    /// Represents a file that has been read from the file system.
    /// </summary>
    public class FileInfo
    {
        private double _leadingSpacesPerLine;
        private string _fileName;
        private int _linesOfCode;

        /// <summary>
        /// The name of the file.
        /// </summary>
        public string FileName
        {
            get => _fileName;

            set  {
                _fileName = value;
                RefreshLeadingSpacesPerLine();
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
        public int NumberOfLeadingSpaces { get; set; }

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
    }
}
