using System;
using System.Collections.Generic;
using System.Text;

namespace RepoInsight.BusinessLogic.Repository
{
    /// <summary>
    /// Contains information for an object inside a repository.
    /// This can either be information about a folder or a file.
    /// </summary>
    public interface IRepoObjectInfo
    {
        string Name
        {
            get;
        }

        int LinesOfCode
        {
            get;
        }

        int NumberOfRevisions
        {
            get;
        }
    }
}
