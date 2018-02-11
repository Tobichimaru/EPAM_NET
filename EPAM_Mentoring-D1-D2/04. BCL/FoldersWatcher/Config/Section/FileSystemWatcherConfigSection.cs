using System.Configuration;
using FoldersWatcher.Config.Collection;
using FoldersWatcher.Config.Elements;

namespace FoldersWatcher.Config.Section
{
    public class FileSystemWatcherConfigSection : ConfigurationSection
    {
        private FileSystemWatcherConfigSection() { }

        [ConfigurationProperty("Folders")]
        public FoldersCollection Folders => (FoldersCollection) base["Folders"];

        [ConfigurationProperty("Rules")]
        public RulesCollection Rules => (RulesCollection) base["Rules"];

        [ConfigurationProperty("Culture")]
        public CultureElement Culture => (CultureElement)base["Culture"];
    }
}
