using System.Collections.Generic;

namespace ESH.CLI.Common
{
    public class EshConfig
    {
        public string Name { get; set; }
        public List<EshDependency> Dependencies { get; set; }
    }
}