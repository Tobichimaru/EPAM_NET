using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using BLL.Service;
using DomainConfig.CustomSections.ServiceConfig;
using DomainConfig.Models;

namespace DomainConfig
{
    /// <summary>
    ///     Helper class for creating user services in AppDomains
    /// </summary>
    public static class UserServiceInitializer
    {
        /// <summary>
        ///     Initializes services in different app domains
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<BaseUserService> InitializeServices()
        {
            var configurations = ParseServiceConfigSection();
            var services = CreateServices(configurations.MasterConfiguration, configurations.SlaveConfigurations).ToList();
            var master = services.OfType<MasterUserService>().SingleOrDefault();
            var slaves = services.OfType<SlaveUserService>().ToList();

            if (!ReferenceEquals(master, null) && configurations.SlaveConfigurations.Count != 0)
            {
                master.Communicator.Connect(configurations.SlaveConfigurations.Select(c => c.IpEndPoint).ToList());
            }

            foreach (var slave in slaves)
            {
                slave.Communicator.RunReceiver();
            }

            foreach (var service in services)
            {
                service.Load();
                CreateWcfService(service);
            }

            return services;
        }

        private static DependencyConfigInfo ParseServiceConfigSection()
        {
            var section = ServiceConfigSection.GetSection();
            var configInfo = new DependencyConfigInfo();
            var isMasterSet = !string.IsNullOrWhiteSpace(section.MasterServices.MasterServiceName)
                && !string.IsNullOrWhiteSpace(section.MasterServices.MasterServiceType);
            if (isMasterSet)
            {
                configInfo.MasterConfiguration = new ServiceConfigInfo
                {
                    Name = section.MasterServices.MasterServiceName,
                    Type = (ServiceType)Enum.Parse(typeof(ServiceType), section.MasterServices.MasterServiceType)
                };
            }

            configInfo.SlaveConfigurations = new List<ServiceConfigInfo>();
            for (int i = 0; i < section.MasterServices.Count; ++i)
            {
                var slaveInfo = section.MasterServices[i];
                var endPoint = new IPEndPoint(IPAddress.Parse(slaveInfo.IpAddress), slaveInfo.Port);
                var slaveConfig = new ServiceConfigInfo
                {
                    IpEndPoint = endPoint,
                    Type = (ServiceType)Enum.Parse(typeof(ServiceType), slaveInfo.ServiceType),
                    Name = slaveInfo.ServiceName,
                    IsCreated = slaveInfo.IsCreated
                };
                configInfo.SlaveConfigurations.Add(slaveConfig);
            }

            return configInfo;
        }

        private static IEnumerable<BaseUserService> CreateServices(ServiceConfigInfo masterConfig, IEnumerable<ServiceConfigInfo> slaveConfigs)
        {
            var services = new List<BaseUserService>();
            if (!object.ReferenceEquals(masterConfig, null))
            {
                services.Add(CreateService(masterConfig));
            }

            services.AddRange(from configuration in slaveConfigs where !configuration.IsCreated select CreateService(configuration));

            return services;
        }

        private static BaseUserService CreateService(ServiceConfigInfo config)
        {
            var domain = AppDomain.CreateDomain(config.Name, null, null);
            var type = typeof(DomainServiceLoader);
            var loader = (DomainServiceLoader)domain.CreateInstanceAndUnwrap(Assembly.GetAssembly(type).FullName, type.FullName);

            return loader.LoadService(config);
        }

        private static void CreateWcfService(BaseUserService service)
        {
            var serviceUri = new Uri($"http://127.0.0.1:8080/BaseUserService/" + service.Name);
            var host = new ServiceHost(service, serviceUri);
            host.Open();
        }
    }
}
