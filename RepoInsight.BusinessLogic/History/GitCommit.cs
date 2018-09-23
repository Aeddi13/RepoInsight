using System;
using System.Collections.Generic;
using System.Text;

namespace RepoInsight.BusinessLogic.History
{
    /// <summary>
    /// Represents a commit in a Git-Reporitory
    /// </summary>
    public class GitCommit : ICommit
    {
        /// <inheritdoc />
        public string Message { get; set; }

        /// <inheritdoc />
        public string Author { get; set; }

        /// <inheritdoc />
        public DateTime Date { get; set; }

        /// <inheritdoc />
        public IList<string> CommitedFiles { get; set; }
    }
}
