using ESH.CLI.Common;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI.CLICommands
{
    [Command(Name = "restore", Description = "Restore packages in the project")]
    [HelpOption("-h|--help")]
    public class RestoreCommand
    {
        public int OnExecute(CommandLineApplication cmd)
        {
            return (int) StatusCodes.Success;
        }
    }

}