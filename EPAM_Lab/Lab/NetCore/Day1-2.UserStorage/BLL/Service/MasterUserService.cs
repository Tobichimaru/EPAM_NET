using System;
using BLL.Mappers;
using BLL.Models;
using DAL;
using DAL.Interface;

namespace BLL.Service
{
    /// <summary>
    /// Master user service: allows add- and delete operations
    /// </summary>
    public class MasterUserService : BaseUserService
    {
        #region Constructors

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="repository"></param>
        public MasterUserService(IUserRepository repository) : base(repository)
        {
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MasterUserService() : this(new UserRepository())
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Saves users to repository
        /// </summary>
        public override void Save()
        {
            Repository.Save();
        }

        /// <summary>
        /// Loads users from repository
        /// </summary>
        public override void Load()
        {
            Repository.Load();
        }

        /// <summary>
        /// Sends notifiication about deleting operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected virtual void OnUserDeleted(object sender, UserEventArgs args)
        {
            Communicator?.SendDelete(args);
        }

        /// <summary>
        /// Sends notifiication about adding operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected virtual void OnUserAdded(object sender, UserEventArgs args)
        {
            Communicator?.SendAdd(args);
        }

        /// <summary>
        /// Adds with notification
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected override int NotifyAdd(BllUser user)
        {
            if (ReferenceEquals(user, null))
            {
                throw new ArgumentNullException();
            }

            try
            {
                Repository.Add(user.ToDalUser());
            }
            catch (ArgumentException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }

            OnUserAdded(this, new UserEventArgs(user));
            return user.Id;
        }

        /// <summary>
        /// Deletes with notification
        /// </summary>
        /// <param name="user"></param>
        protected override void NotifyDelete(BllUser user)
        {
            if (ReferenceEquals(user, null))
            {
                throw new ArgumentNullException();
            }

            try
            {
                Repository.Delete(user.ToDalUser());
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }

            OnUserDeleted(this, new UserEventArgs(user));
        }

        #endregion
    }
}
