using System;
using System.IO;
using System.Linq;
using System.Text;
using ESH.CLI.Common;
using Newtonsoft.Json;

namespace ESH.CLI.Services.Implementations
{
    public class FileServices : IFileServices
    {
        public void CreatePackagesFolder()
        {
            if (!Directory.Exists("esh_packages"))
            {
                Directory.CreateDirectory("esh_packages");
            }
        }

        public string GetPackageFolder(Uri gitRepo)
        {
            return $"esh_packages/{GetGitRepositoryName(gitRepo)}";
        }

        public string GetPackageFolderByRepositoryName(string repositoryName)
        {
            return $"esh_packages/{repositoryName}";
        }

        public string GetGitRepositoryName(Uri gitRepo)
        {
            return gitRepo.LocalPath.Split('/')?.LastOrDefault()?.Replace(".git", "");
        }

        public EshConfig GetConfig()
        {
            if (!File.Exists("esh.json"))
            {
                File.WriteAllText("esh.json", "{}", Encoding.UTF8);
            }

            string json = File.ReadAllText("esh.json");

            return JsonConvert.DeserializeObject<EshConfig>(json);
        }
    }
}