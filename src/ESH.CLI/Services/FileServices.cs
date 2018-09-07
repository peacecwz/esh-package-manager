using ESH.CLI.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace ESH.CLI.Services
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

        public ESHConfig GetConfig()
        {
            if (!File.Exists("esh.json"))
            {
                File.WriteAllText("esh.json", "{}", Encoding.UTF8);
            }

            string json = File.ReadAllText("esh.json");

            return JsonConvert.DeserializeObject<ESHConfig>(json);
        }
    }

    public interface IFileServices
    {
        string GetPackageFolder(Uri gitRepo);
        string GetPackageFolderByRepositoryName(string repositoryName);
        string GetGitRepositoryName(Uri gitRepo);
        void CreatePackagesFolder();
        ESHConfig GetConfig();
    }
}