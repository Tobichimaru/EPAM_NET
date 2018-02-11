using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DAL.DTO;
using DAL.Interface;
using NLog;

namespace DAL
{
    /// <summary>
    ///     User repository class
    /// </summary>
    [Serializable]
    public class UserRepository : MarshalByRefObject, IUserRepository
    {
        #region Private Fields
        private static readonly Logger Logger;
        private static readonly BooleanSwitch LoggerSwitch;

        private readonly IUserValidator validator;
        private readonly List<DalUser> users;

        private IEnumerator<int> iterator;     
        #endregion

        #region Constructors
        static UserRepository()
        {
            LoggerSwitch = new BooleanSwitch("Data", "DataAccess module");
            Logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public UserRepository() : this(new UserIdIterator(), new SimpleUserValidator())
        {
        }

        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="validator"></param>
        public UserRepository(IEnumerator<int> iterator, IUserValidator validator)
        {
            if (object.ReferenceEquals(iterator, null))
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(nameof(iterator) + " is null!");
                }

                throw new ArgumentNullException();
            }

            if (object.ReferenceEquals(validator, null))
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(nameof(validator) + " is null!");
                }

                throw new ArgumentNullException();
            }

            this.iterator = iterator;
            this.validator = validator;
            this.users = new List<DalUser>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///     Adds user to repository
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(DalUser user)
        {
            try
            {
                var isValid = this.validator.Validate(user);
                if (!isValid)
                {
                    throw new ArgumentException(nameof(user) + " is invalid!");
                }

                this.iterator.MoveNext();
                user.Id = this.iterator.Current;
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw;
            }
            catch (InvalidOperationException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw;
            }

            this.users.Add(user);
            if (LoggerSwitch.Enabled)
            {
                Logger.Info($"User {user} Added!");
            }

            return user.Id;
        }

        /// <summary>
        ///     Removes user from repository
        /// </summary>
        /// <param name="user"></param>
        public void Delete(DalUser user)
        {
            if (object.ReferenceEquals(user, null))
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(nameof(user) + " is null!");
                }

                throw new ArgumentNullException();
            }

            this.users.Remove(user);
            if (LoggerSwitch.Enabled)
            {
                Logger.Info($"User {user} Removed!");
            }
        }

        /// <summary>
        ///     Searches user according to predicates
        /// </summary>
        /// <param name="predicates"></param>
        /// <returns></returns>
        public int[] GetByPredicate(Func<DalUser, bool>[] predicates)
        {
            try
            {
                return this.users.AsParallel().Where(p => predicates.All(pr => pr(p))).Select(u => u.Id).ToArray();
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }
        }

        /// <summary>
        ///     Searches user according to criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public int[] SearchForUsers(IDalCriterion<DalUser>[] criteria)
        {
            try
            {
                return this.users.AsParallel().Where(u => criteria.All(cr => cr.ApplyCriterion(u))).Select(u => u.Id).ToArray();
            }
            catch (ArgumentNullException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error(exception.Message);
                }

                throw exception;
            }
        }

        /// <summary>
        ///     Saves user to xml
        /// </summary>
        public void Save()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<DalUser>));
            string path;
            try
            {
                path = ConfigurationManager.AppSettings["Path"];
            }
            catch (ConfigurationErrorsException exception)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error($"App.Config exception! " + exception.Message);
                }

                throw;
            }

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, this.users);
            }

            if (LoggerSwitch.Enabled)
            {
                Logger.Info($"User storage saved to XML!");
            }
        }

        /// <summary>
        ///     Loads user from xml
        /// </summary>
        public void Load()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<DalUser>));
            string path;
            try
            {
                path = ConfigurationManager.AppSettings["Path"];
            }
            catch (ConfigurationErrorsException ex)
            {
                if (LoggerSwitch.Enabled)
                {
                    Logger.Error($"App.Config exception! " + ex.Message);
                }

                throw;
            }

            using (StreamReader sr = new StreamReader(path))
            {
                List<DalUser> users = (List<DalUser>)formatter.Deserialize(sr);
                foreach (var user in users)
                {
                    this.users.Add(user);
                }

                if (users.Count != 0)
                {
                    this.iterator = new UserIdIterator(users.Last().Id);
                }
            }

            if (LoggerSwitch.Enabled)
            {
                Logger.Info($"User storage loaded from XML!");
            }
        }
        #endregion
    }
}
