using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace RepoInsight.BusinessLogic.History
{
    /// <summary>
    /// This class is responsible for generating <see cref="GitCommit"/>s of a given <see cref="Repository"/> or repository path.
    /// </summary>
    public class GitCommitFactory
    {
        /// <summary>
        /// Creates all <see cref="ICommit"/>s in a given repository path.
        /// </summary>
        /// <param name="repositoryPath">The path f the repository.</param>
        /// <returns>A <see cref="List{ICommit}"/> with all commits in the repository.</returns>
        public static List<ICommit> GetCommitsForRepositoryPath(string repositoryPath)
        {
            Repository repository = new Repository(repositoryPath);

            return GetCommitsForRepository(repository);
        }

        /// <summary>
        /// Creates all <see cref="ICommit"/>s in a given <see cref="Repository"/>.
        /// </summary>
        /// <param name="repositoryPath">The <see cref="Repository"/>.</param>
        /// <returns>A <see cref="List{ICommit}"/> with all commits in the repository.</returns>
        public static List<ICommit> GetCommitsForRepository(Repository repository)
        {
            List<ICommit> commitList = new List<ICommit>();

            foreach (Commit commit in repository.Commits)
            {
                foreach (var parent in commit.Parents)
                {
                    GitCommit gitCommit = new GitCommit(commit);
                    gitCommit.GenerateCommitedFiles(commit, parent, repository);
                    commitList.Add(gitCommit);
                }
            }

            return commitList;
        }
    }
}
