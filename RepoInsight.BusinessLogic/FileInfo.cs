namespace RepoInsight.BusinessLogic
{
    /// <summary>
    /// Represents a file that has been read from the file system.
    /// </summary>
    public class FileInfo
    {
        /// <summary>
        /// The name of the file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// The lines of code of this file.
        /// </summary>
        public int LinesOfCode { get; set; }

        /// <summary>
        /// The total number of leading whitespaces and tabs in this file.
        /// 1 Tab counts as 4 whitespaces;
        /// </summary>
        public int NumberOfLeadingSpaces { get; set; }

        /// <summary>
        /// Gets the <see cref="NumberOfLeadingSpaces"/> divided by the <see cref="LinesOfCode"/>.
        /// </summary>
        /// <returns>The Leading spaces per Line of code.</returns>
        public double GetLeadingSpacesPerLine()
        {
            return ((double)NumberOfLeadingSpaces) / ((double)LinesOfCode);
        }
    }
}
