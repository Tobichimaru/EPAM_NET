using System.Configuration;

namespace FoldersWatcher.Config.Elements
{
    public class RuleElement : ConfigurationElement
    {
        [ConfigurationProperty("targetFolder", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string TargetFolder
        {
            get { return (string) base["targetFolder"]; }
            set { base["targetFolder"] = value; }
        }

        [ConfigurationProperty("regex", DefaultValue = "*", IsKey = false, IsRequired = true)]
        public string Filter
        {
            get { return (string) base["regex"]; }
            set { base["regex"] = value; }
        }

        [ConfigurationProperty("includeDate", DefaultValue = "false", IsKey = false, IsRequired = false)]
        public bool IncludeDate
        {
            get { return (bool)base["includeDate"]; }
            set { base["includeDate"] = value; }
        }

        [ConfigurationProperty("includeIndex", DefaultValue = "false", IsKey = false, IsRequired = false)]
        public bool IncludeIndex
        {
            get { return (bool)base["includeIndex"]; }
            set { base["includeIndex"] = value; }
        }
    }
}
