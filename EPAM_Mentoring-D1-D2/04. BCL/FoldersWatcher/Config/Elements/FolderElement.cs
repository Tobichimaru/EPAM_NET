using System.Configuration;

namespace FoldersWatcher.Config.Elements
{
    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("path", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Path
        {
            get { return (string)base["path"]; }
            set { base["path"] = value; }
        }
    }
}
