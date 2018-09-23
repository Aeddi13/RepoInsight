using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace RepoInsight.BusinessLogic.History
{
    public class GitCommitFactory
    {
        public static List<ICommit> GetCommitsForRepository(string repositoryPath)
        {
            Repository repository = new Repository(repositoryPath);
            List<ICommit> commitList = new List<ICommit>();


            foreach (Commit commit in repository.Commits)
            {
                foreach (var parent in commit.Parents)
                {
                    GitCommit gitCommit = new GitCommit();
                    gitCommit.Message = commit.Message;
                    gitCommit.Author = commit.Author.Name;
                    gitCommit.Date = commit.Committer.When.DateTime;
                    gitCommit.CommitedFiles = new List<string>();
                    foreach (TreeEntryChanges change in repository.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree))
                    {
                        gitCommit.CommitedFiles.Add(change.Path);
                    }
                    commitList.Add(gitCommit);
                }
            }

            return commitList;
        }
    }
}
