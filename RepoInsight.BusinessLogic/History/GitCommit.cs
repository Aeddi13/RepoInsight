using LibGit2Sharp;
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
        /// <summary>
        /// Default constructor.
        /// </summary>
        public GitCommit()
        { }

        /// <summary>
        /// Creates a new <see cref="GitCommit"/> with the data of a given <see cref="Commit"/>.
        /// </summary>
        /// <param name="libGit2SharpCommit">The <see cref="Commit"/>.</param>
        public GitCommit(Commit libGit2SharpCommit)
        {
            this.Message = libGit2SharpCommit.Message;
            this.Author = libGit2SharpCommit.Author.Name;
            this.Date = libGit2SharpCommit.Committer.When.DateTime;
        }

        /// <summary>
        /// Generates the CommitedFiles where the files are the differences between the given <see cref="Commit"/>
        /// and the parent <see cref="Commit"/>.
        /// </summary>
        /// <param name="commit">The <see cref="Commit"/>.</param>
        /// <param name="parent">The parent of the <see cref="Commit"/>.</param>
        /// <param name="repository">The <see cref="LibGit2Sharp.Repository"/> of the commits.</param>
        public void GenerateCommitedFiles(Commit commit, Commit parent, LibGit2Sharp.Repository repository)
        {
            this.CommitedFiles = new List<string>();
            foreach (TreeEntryChanges change in repository.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree))
            {
                string fullFilePath = repository.Info.WorkingDirectory + change.Path.Replace("/", "\\");
                this.CommitedFiles.Add(fullFilePath);
            }
        }

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
