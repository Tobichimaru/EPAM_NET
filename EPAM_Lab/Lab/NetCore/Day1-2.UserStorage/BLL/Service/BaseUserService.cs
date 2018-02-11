using System;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using BLL.Interface;
using BLL.Mappers;
using BLL.Models;
using BLL.SearchCriteria;
using DAL;
using DAL.DTO;
using DAL.Interface;
using NLog;

namespace BLL.Service
{
    /// <summary>
    ///     Abstract class for user service
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    [ServiceKnownType(typeof(IBllCriterion<BllUser>))]
    [ServiceKnownType(typeof(LastNameCriterion))]
    public abstract class BaseUserService : MarshalByRefObject, IUserServiceContract
    {
        #region Fields
        
        /// <summary>
        ///     NLog logger field
        /// </summary>
        protected static readonly Logger Logger;

        /// <summary>
        ///     Activates NLog if true
        /// </summary>
        protected static readonly BooleanSwitch LoggerSwitch;

        /// <summary>
        ///     Provides network communication between services
        /// </summary>
        private UserServiceCommunicator communicator;

        #endregion

        #region Constructors

        /// <summary>
        ///     Static constructor
        /// </summary>
        static BaseUserService()
        {
            Logger = LogManager.GetCurrentClassLogger();
            LoggerSwitch = new BooleanSwitch("Data", "DataAccess module");
        }

        /// <summary>
        ///     Default constructor
        /// </summary>
        protected BaseUserService() : this(new UserRepository())
        {
        }

        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="repository"></param>
        protected BaseUserService(IUserRepository repository)
        {
            if (ReferenceEquals(repository, null))
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(nameof(repository) + " is null!");
                }

                throw new ArgumentNullException();
            }

            StorageLock = new ReaderWriterLockSlim();
            Repository = repository;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Property to get/set communicator field
        /// </summary>
        public virtual UserServiceCommunicator Communicator
        {
            get
            {
                return communicator;
            }

            set
            {
                if (ReferenceEquals(value, null))
                {
                    throw new ArgumentNullException(nameof(value) + " is null!");
                }

                communicator = value;
            }
        }

        /// <summary>
        ///     Gets or sets a Name of service according to its AppDomain
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets a Serice's Repository
        /// </summary>
        protected IUserRepository Repository { get; set; }

        /// <summary>
        ///     Gets or sets a Used for syncronization 
        /// </summary>
        protected ReaderWriterLockSlim StorageLock { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Thread-safe add
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(BllUser user)
        {
            StorageLock.EnterWriteLock();
            try
            {
                return NotifyAdd(user);
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }
            finally
            {
                StorageLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Thread-safe delete
        /// </summary>
        /// <param name="user"></param>
        public void Delete(BllUser user)
        {
            StorageLock.EnterWriteLock();
            try
            {
                NotifyDelete(user);
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }
            finally
            {
                StorageLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Thread-safe search
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public virtual int[] SearchForUsers(IBllCriterion<BllUser>[] criteria)
        {
            StorageLock.EnterReadLock();
            try
            {
                var dalCriteria = criteria.Select(cr => cr.ToDalCriteria()).ToArray();
                return Repository.SearchForUsers(dalCriteria).ToArray();
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }
            finally
            {
                StorageLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Thread-safe search
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public virtual int[] SearchForUsers(Func<BllUser, bool>[] criteria)
        {
            StorageLock.EnterReadLock();
            try
            {
                var dalCriteria = new Func<DalUser, bool>[criteria.Length];
                for (var i = 0; i < dalCriteria.Length; i++)
                {
                    var k = i;
                    dalCriteria[k] = user => criteria[k].Invoke(user.ToBllUser());
                }

                return Repository.GetByPredicate(dalCriteria);
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }
            finally
            {
                StorageLock.ExitReadLock();
            }
        }

        /// <summary>
        ///     Abstract save method
        /// </summary>
        public abstract void Save();

        /// <summary>
        ///     Abstract load method
        /// </summary>
        public abstract void Load();

        /// <summary>
        ///     Add with notification
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected abstract int NotifyAdd(BllUser user);

        /// <summary>
        ///     Delete with notification
        /// </summary>
        /// <param name="user"></param>
        protected abstract void NotifyDelete(BllUser user);

        #endregion
    }
}
