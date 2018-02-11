using System.Configuration;
using FoldersWatcher.Config.Elements;

namespace FoldersWatcher.Config.Collection
{
    [ConfigurationCollection(typeof(RuleElement))]
    public class RulesCollection : ConfigurationElementCollection
    {
        private RulesCollection()
        {
        }
        public override ConfigurationElementCollectionType CollectionType => ConfigurationElementCollectionType.BasicMap;

        protected override string ElementName => "Rule";

        protected override ConfigurationElement CreateNewElement()
        {
            return new RuleElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((RuleElement) element).TargetFolder;
        }
    }
}
