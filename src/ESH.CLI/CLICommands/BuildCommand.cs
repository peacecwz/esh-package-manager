using ESH.CLI.Common;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI.CLICommands
{
    [Command(Name = "build", Description = "Build packages in the project")]
    [HelpOption("-h|--help")]
    public class BuildCommand
    {
        public int OnExecute(CommandLineApplication cmd)
        {
            return (int) StatusCodes.Success;
        }
    }
}