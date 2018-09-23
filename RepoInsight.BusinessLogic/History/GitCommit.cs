using System;
using System.Collections.Generic;
using System.Text;

namespace RepoInsight.BusinessLogic.History
{
    public class GitCommit : ICommit
    {
        public string Message { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }

        public IList<string> CommitedFiles { get; set; }
    }
}
