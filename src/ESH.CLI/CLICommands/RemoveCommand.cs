using ESH.CLI.Common;
using ESH.CLI.Services;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI.CLICommands
{
    [Command(Name = "remove", Description = "Remove esh packages from package list")]
    [HelpOption("-h|--help")]
    public class RemoveCommand
    {
        private readonly IGitServices _gitServices;
        public RemoveCommand(IGitServices gitServices)
        {
            _gitServices = gitServices;
        }

        public int OnExecute(CommandLineApplication cmd)
        {
            return (int)StatusCodes.Success;
        }
    }
}