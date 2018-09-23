using System;
using System.Collections.Generic;
using System.Text;

namespace RepoInsight.BusinessLogic.History
{
    /// <summary>
    /// Represents a commit in a version control system.
    /// </summary>
    public interface ICommit
    {
        /// <summary>
        /// The message of the commit.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// The author of the commit.
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// The date and time on which the commit has been made.
        /// </summary>
        DateTime Date { get; set; }

        /// <summary>
        /// An enumeration of all files that have been commited in this commit.
        /// </summary>
        IList<string> CommitedFiles { get; set; }
    }
}
