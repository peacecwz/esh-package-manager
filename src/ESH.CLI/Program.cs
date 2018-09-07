using ESH.CLI.Services;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace ESH.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication()
            {
                Name = "esh",
                Description =
                    "ESH Package Manager is managing your packages with git repository and working without nuget"
            };
            var services = new EshServices();
            app.HelpOption("-h|--help");
            app.Command("install", services.InstallCommand);
            app.Command("add", services.AddCommand);
            app.Command("update", services.UpdateCommand);
            app.Command("remove", services.RemoveCommand);
            app.Command("list", services.ListCommand);

            app.OnExecute(() => 0);

            app.Execute(args);
            Console.ReadKey();
        }
    }
}
