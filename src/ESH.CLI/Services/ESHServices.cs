using System;
using Microsoft.Extensions.CommandLineUtils;

namespace ESH.CLI.Services
{
    public class EshServices : IEshServices
    {
        private readonly IFileServices _fileServices;
        private readonly IGitServices _gitServices;

        public EshServices()
        {
            _fileServices = new FileServices();
            _gitServices = new GitServices();
        }

        public void AddCommand(CommandLineApplication cmd)
        {
            cmd.Description = "Add git repository to dependencies";
            cmd.HelpOption("-h|--help");

            var url = cmd.Argument("[gitRepository]", "Git repository url");

            cmd.OnExecute(() =>
            {
                var repository = _gitServices.Clone(url.Value);
                if (!string.IsNullOrWhiteSpace(repository.Message))
                {
                    Console.WriteLine(repository.Message);
                }
                return 0;
            });
        }

        public void UpdateCommand(CommandLineApplication cmd)
        {
            cmd.Description = "Update git repository to dependencies";
            cmd.HelpOption("-h|--help");

            var packageName = cmd.Argument("[packageName]", "Git repository package name");
            cmd.OnExecute(() =>
            {
                if (Uri.TryCreate(packageName.Value, UriKind.RelativeOrAbsolute, out var gitRepoUrl))
                {
                    _gitServices.Update(_fileServices.GetGitRepositoryName(gitRepoUrl));
                    return 0;
                }

                if (string.IsNullOrWhiteSpace(packageName.Value))
                {
                    _gitServices.UpdateAll();
                }
                else
                {
                    _gitServices.Update(packageName.Value);
                }

                return 0;
            });
        }

        public void InstallCommand(CommandLineApplication cmd)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCommand(CommandLineApplication cmd)
        {
            throw new System.NotImplementedException();
        }

        public void ListCommand(CommandLineApplication cmd)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IEshServices
    {
        void AddCommand(CommandLineApplication cmd);
        void UpdateCommand(CommandLineApplication cmd);
        void InstallCommand(CommandLineApplication cmd);
        void RemoveCommand(CommandLineApplication cmd);
        void ListCommand(CommandLineApplication cmd);
    }
}