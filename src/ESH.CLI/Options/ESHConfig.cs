using System.Collections.Generic;

namespace ESH.CLI.Options
{
    public class ESHConfig
    {
        public string Name { get; set; }
        public List<ESHDependency> Dependencies { get; set; }
    }

    public class ESHDependency
    {
        public string Name { get; set; }
        public string GitRepository { get; set; }
        public string LastModifiedOn { get; set; }
    }
}