using System;
using ESH.CLI.Common;
using ESH.CLI.Services;
using McMaster.Extensions.CommandLineUtils;

namespace ESH.CLI.CLICommands
{
    [Command(Name = "add", Description = "Add package from Git repository")]
    [HelpOption("-h|--help")]
    public class AddCommand
    {
        [Argument(0, "gitRepository", "Git repository url")]
        public string Url { get; set; }

        private readonly IGitServices _gitServices;
        public AddCommand(IGitServices gitServices)
        {
            _gitServices = gitServices;
        }

        public int OnExecute(CommandLineApplication cmd)
        {
            var repository = _gitServices.Clone(Url);
            if (!string.IsNullOrWhiteSpace(repository.Message))
            {
                Console.WriteLine(repository.Message);
            }

            return (int)StatusCodes.Success;
        }
    }
}