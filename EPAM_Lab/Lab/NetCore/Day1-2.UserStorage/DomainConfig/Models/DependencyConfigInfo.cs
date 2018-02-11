using System.Collections.Generic;

namespace DomainConfig.Models
{
    /// <summary>
    ///     Helper class for user service config information
    /// </summary>
    public class DependencyConfigInfo
    {
        /// <summary>
        ///     Property for Master config
        /// </summary>
        public ServiceConfigInfo MasterConfiguration { get; set; }

        /// <summary>
        ///     Property for slaves config
        /// </summary>
        public IList<ServiceConfigInfo> SlaveConfigurations { get; set; }
    }
}
