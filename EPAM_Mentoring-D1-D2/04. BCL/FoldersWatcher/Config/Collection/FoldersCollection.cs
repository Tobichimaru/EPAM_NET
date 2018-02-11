using System.Configuration;
using FoldersWatcher.Config.Elements;

namespace FoldersWatcher.Config.Collection
{
    [ConfigurationCollection(typeof(FolderElement))]
    public class FoldersCollection : ConfigurationElementCollection
    {
        private FoldersCollection()
        {
        }
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

        protected override string ElementName => "Folder";

        protected override ConfigurationElement CreateNewElement()
        {
           return new FolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FolderElement) element).Path;
        }
    }
}
