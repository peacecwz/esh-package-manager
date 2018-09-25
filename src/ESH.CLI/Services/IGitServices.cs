using ESH.CLI.Models;
using LibGit2Sharp;

namespace ESH.CLI.Services
{
    public interface IGitServices
    {
        void Update(string repositoryName);
        void UpdateAll();
        ResponseBase<Repository> Clone(string gitRepositoryUrl);
    }
}