using System;
using ESH.CLI.Common;
using ESH.CLI.Services;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI.CLICommands
{
    [Command(Name = "update", Description = "Update package(s) from Git repository")]
    [HelpOption("-h|--help")]
    public class UpdateCommand
    {
        [Argument(0,"packageName","ESH Package name")] 
        public string PackageName { get; set; }

        private readonly IGitServices _gitServices;
        private readonly IFileServices _fileServices;

        public UpdateCommand(IGitServices gitServices, IFileServices fileServices)
        {
            _gitServices = gitServices;
            _fileServices = fileServices;
        }

        public int OnExecute(CommandLineApplication cmd)
        {
            if (Uri.TryCreate(PackageName, UriKind.RelativeOrAbsolute, out var gitRepoUrl))
            {
                _gitServices.Update(_fileServices.GetGitRepositoryName(gitRepoUrl));
                return (int)StatusCodes.Success;
            }

            if (string.IsNullOrWhiteSpace(PackageName))
            {
                _gitServices.UpdateAll();
            }
            else
            {
                _gitServices.Update(PackageName);
            }

            return (int)StatusCodes.Success;
        }
    }
}