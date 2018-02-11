using System;
using BLL.Mappers;
using BLL.Models;
using DAL;
using DAL.Interface;

namespace BLL.Service
{
    /// <summary>
    /// Master user service: add- and delete operations are not allowed
    /// </summary>
    public class SlaveUserService : BaseUserService
    {
        #region Constructors

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="repository"></param>
        public SlaveUserService(IUserRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SlaveUserService() : this(new UserRepository())
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Overriden communicator property
        /// </summary>
        public override UserServiceCommunicator Communicator
        {
            get
            {
                return base.Communicator;
            }

            set
            {
                base.Communicator = value;
                Communicator.UserAdded += OnAdded;
                Communicator.UserDeleted += OnDeleted;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Not allowed
        /// </summary>
        public override void Save()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Loads users from repository
        /// </summary>
        public override void Load()
        {
            Repository.Load();
        }

        /// <summary>
        /// Not allowed
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected override int NotifyAdd(BllUser user)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Not allowed
        /// </summary>
        /// <param name="user"></param>
        protected override void NotifyDelete(BllUser user)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Adds user to repository if message from communicator recieved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnAdded(object sender, UserEventArgs args)
        {
            StorageLock.EnterWriteLock();
            try
            {
                Repository.Add(args.User.ToDalUser());
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
        /// Deletes user from repository if message from communicator recieved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnDeleted(object sender, UserEventArgs args)
        {
            StorageLock.EnterWriteLock();
            try
            {
                Repository.Delete(args.User.ToDalUser());
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

        #endregion
    }
}