using ESH.CLI.Common;
using ESH.CLI.Services;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI.CLICommands
{
    [Command(Name = "install", Description = "Install package from Git repository")]
    [HelpOption("-h|--help")]
    public class InstallCommand
    {
        private readonly IGitServices _gitServices;
        public InstallCommand(IGitServices gitServices)
        {
            _gitServices = gitServices;
        }

        public int OnExecute(CommandLineApplication cmd)
        {
            return (int) StatusCodes.Success;
        }
    }
}