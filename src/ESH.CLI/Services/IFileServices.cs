using System;
using ESH.CLI.Common;

namespace ESH.CLI.Services
{
    public interface IFileServices
    {
        string GetPackageFolder(Uri gitRepo);
        string GetPackageFolderByRepositoryName(string repositoryName);
        string GetGitRepositoryName(Uri gitRepo);
        void CreatePackagesFolder();
        EshConfig GetConfig();
    }
}