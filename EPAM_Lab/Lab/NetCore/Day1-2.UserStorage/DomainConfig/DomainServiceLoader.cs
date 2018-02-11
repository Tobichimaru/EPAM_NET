using DomainConfig.Models;

namespace DomainConfig
{
    using System;
    using BLL;
    using BLL.Models;
    using BLL.Service;
    using DAL;
    using DAL.Interface;
    using NetworkConfig;

    /// <summary>
    /// Helper class for creating services
    /// </summary>
    public class DomainServiceLoader : MarshalByRefObject
    {
        /// <summary>
        /// Creates service according to config info
        /// </summary>
        /// <param name="configInfo"></param>
        /// <returns></returns>
        public BaseUserService LoadService(ServiceConfigInfo configInfo)
        {
            BaseUserService service;
            UserServiceCommunicator communicator;
            IUserRepository repository = new UserRepository();
            switch (configInfo.Type)
            {
                case ServiceType.Master:
                    {
                        Sender<BllUser> sender = new Sender<BllUser>();
                        communicator = new UserServiceCommunicator(sender);
                        service = new MasterUserService(repository);
                    }

                    break;
                case ServiceType.Slave:
                    {
                        Receiver<BllUser> receiver = new Receiver<BllUser>(configInfo.IpEndPoint.Address, configInfo.IpEndPoint.Port);
                        communicator = new UserServiceCommunicator(receiver);
                        service = new SlaveUserService(repository);
                    }

                    break;
                default:
                    throw new ArgumentException("Wrong service type!");
            }

            service.Communicator = communicator;
            service.Name = AppDomain.CurrentDomain.FriendlyName;

            return service;
        }
    }
}