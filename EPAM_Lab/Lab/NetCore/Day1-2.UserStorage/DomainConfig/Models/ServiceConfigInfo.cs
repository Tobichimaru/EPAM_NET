using System;
using System.Net;

namespace DomainConfig.Models
{
    /// <summary>
    /// Helper enumeration for ServiceType
    /// </summary>
    [Serializable]
    public enum ServiceType
    {
        /// <summary>
        /// Master
        /// </summary>
        Master,

        /// <summary>
        /// Slave
        /// </summary>
        Slave
    }

    /// <summary>
    /// Helper class for service config information
    /// </summary>
    [Serializable]
    public class ServiceConfigInfo
    {
        /// <summary>
        /// Service type
        /// </summary>
        public ServiceType Type { get; set; }

        /// <summary>
        /// Service name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Service IpEndPoint
        /// </summary>
        public IPEndPoint IpEndPoint { get; set; }

        /// <summary>
        /// Flag for notifying if service is already created or not
        /// </summary>
        public bool IsCreated { get; set; }
    }
}
