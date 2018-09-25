using ESH.CLI.Common;
using ESH.CLI.Services;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI.CLICommands
{
    [Command(Name = "list", Description = "Add package from Git repository")]
    [HelpOption("-h|--help")]
    public class ListCommand
    {
        private readonly IGitServices _gitServices;
        public ListCommand(IGitServices gitServices)
        {
            _gitServices = gitServices;
        }

        public int OnExecute(CommandLineApplication cmd)
        {
            return (int)StatusCodes.Success;
        }
    }
}