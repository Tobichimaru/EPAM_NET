using System.Configuration;

namespace DomainConfig.CustomSections.ServiceConfig
{
    /// <summary>
    ///     Class for user service config section
    /// </summary>
    public class ServiceConfigSection : ConfigurationSection
    {
        /// <summary>
        ///     Returns collection of MasterService
        /// </summary>
        [ConfigurationProperty("MasterService")]
        public MasterServiceCollection MasterServices => (MasterServiceCollection)base["MasterService"];

        /// <summary>
        ///     Gets ServiceConfigSection
        /// </summary>
        /// <returns></returns>
        public static ServiceConfigSection GetSection()
        {
            return (ServiceConfigSection)ConfigurationManager.GetSection("ServiceConfigSection");
        }
    }
}
