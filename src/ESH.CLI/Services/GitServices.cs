using ESH.CLI.Models;
using LibGit2Sharp;
using System;
using System.IO;

namespace ESH.CLI.Services
{
    public class GitServices : IGitServices
    {
        private readonly IFileServices _fileServices;

        public GitServices()
        {
            _fileServices = new FileServices();
        }

        public ResponseBase<Repository> Clone(string gitRepositoryUrl)
        {
            if (!Uri.TryCreate(gitRepositoryUrl, UriKind.RelativeOrAbsolute, out var gitRepo))
            {
                throw new Exception("Invalid Repository Url");
            }

            bool isProjectExists = Directory.Exists(_fileServices.GetPackageFolder(gitRepo));

            string projectPath = !isProjectExists
                ? Repository.Clone(gitRepo.ToString(), _fileServices.GetPackageFolder(gitRepo))
                : _fileServices.GetPackageFolder(gitRepo);

            if (isProjectExists)
            {
                Update(_fileServices.GetGitRepositoryName(gitRepo));
            }

            return new ResponseBase<Repository>()
            {
                IsSucess = true,
                Message = (isProjectExists) ? "Project is already installed" : "Your project is installed successfully",
                Data = new Repository(projectPath)
            };
        }

        public void UpdateAll()
        {
            var directories = Directory.GetDirectories("esh_packages");
            foreach (var directoryPath in directories)
            {
                var directory = new DirectoryInfo(directoryPath);
                Update(directory.Name);
            }
        }

        public void Update(string repositoryName)
        {
            using (var repository = new Repository(_fileServices.GetPackageFolderByRepositoryName(repositoryName)))
            {
                var signature = new LibGit2Sharp.Signature(
                    new Identity("MERGE_USER_NAME", "MERGE_USER_EMAIL"), DateTimeOffset.Now);

                var result = Commands.Pull(repository, signature, new PullOptions());
                if (result.Status == MergeStatus.UpToDate)
                {
                    Console.WriteLine($"{repositoryName}: Already up-to-date");
                }
            }
        }
    }

    public interface IGitServices
    {
        void Update(string repositoryName);
        void UpdateAll();
        ResponseBase<Repository> Clone(string gitRepositoryUrl);
    }
}