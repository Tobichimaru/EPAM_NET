using System.Configuration;

namespace DomainConfig.CustomSections.ServiceConfig
{
    /// <summary>
    ///     Custom section for master user service management
    /// </summary>
    public class MasterServiceCollection : ConfigurationElementCollection
    {
        /// <summary>
        ///     Property for master user service name
        /// </summary>
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string MasterServiceName
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        /// <summary>
        ///     Property for master user service type
        /// </summary>
        [ConfigurationProperty("type", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string MasterServiceType
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        /// <summary>
        ///     Indexer for slave user services
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public SlaveServiceElement this[int idx] => (SlaveServiceElement)BaseGet(idx);

        /// <summary>
        ///     Creates new SlaveServiceElement
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new SlaveServiceElement();
        }

        /// <summary>
        ///     Gets SlaveServiceElement name
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SlaveServiceElement)element).ServiceName;
        }
    }
}