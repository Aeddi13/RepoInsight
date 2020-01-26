using System;
using System.Collections.Generic;
using System.Text;

namespace RepoInsight.BusinessLogic.Repository
{
    /// <summary>
    /// Contains methods to create <see cref="IRepoObjectInfo"/> objects for an repository.
    /// </summary>
    public interface IRepoObjectInfoFactory
    {
        /// <summary>
        /// Creates a list of <see cref="IRepoObjectInfo"/> for the given repository.
        /// </summary>
        /// <param name="repositoryPath">
        /// The path to the repository.
        /// This can be a path on the file system, an url or even a single file depending on the implementation of the factory.
        /// </param>
        /// <returns>A list of <see cref="IRepoObjectInfo"/>.</returns>
        List<IRepoObjectInfo> CreateObjectInfos(string repositoryPath);
    }
}
