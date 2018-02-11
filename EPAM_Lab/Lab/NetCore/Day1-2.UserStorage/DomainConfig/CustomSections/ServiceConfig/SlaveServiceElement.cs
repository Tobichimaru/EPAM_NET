using System.Configuration;

namespace DomainConfig.CustomSections.ServiceConfig
{
    /// <summary>
    ///     Class for slave user service config section
    /// </summary>
    public class SlaveServiceElement : ConfigurationElement
    {
        /// <summary>
        ///     Property for slave service type
        /// </summary>
        [ConfigurationProperty("type", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string ServiceType
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        /// <summary>
        /// P   roperty for slave service name
        /// </summary>
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string ServiceName
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }

        /// <summary>
        ///     Property for slave service ip address
        /// </summary>
        [ConfigurationProperty("ip", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string IpAddress
        {
            get { return (string)base["ip"]; }
            set { base["ip"] = value; }
        }

        /// <summary>
        ///     Property for slave service port
        /// </summary>
        [ConfigurationProperty("port", DefaultValue = 0, IsKey = false, IsRequired = false)]
        public int Port
        {
            get { return (int)base["port"]; }
            set { base["port"] = value; }
        }

        /// <summary>
        ///     Property for slave service creation flag: if flag is true, service is already created
        /// </summary>
        [ConfigurationProperty("created", DefaultValue = false, IsKey = false, IsRequired = false)]
        public bool IsCreated
        {
            get { return (bool)base["created"]; }
            set { base["created"] = value; }
        }
    }
}