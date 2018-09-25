using ESH.CLI.CLICommands;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI
{
    [Command(Name = "esh", Description = "ESH Package Manager for .NET and .NET Core Projects")]
    [HelpOption("-h|--help")]
    [Subcommand("add", typeof(AddCommand))]
    [Subcommand("remove", typeof(RemoveCommand))]
    [Subcommand("list", typeof(ListCommand))]
    [Subcommand("install", typeof(InstallCommand))]
    [Subcommand("update", typeof(UpdateCommand))]
    public class App
    {
        public void OnExecute(CommandLineApplication app)
        {
            
        }
    }
}