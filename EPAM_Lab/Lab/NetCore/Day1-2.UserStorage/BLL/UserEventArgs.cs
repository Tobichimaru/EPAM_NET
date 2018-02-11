using System;
using BLL.Models;

namespace BLL
{
    /// <summary>
    ///     Class for user service add/delete events
    /// </summary>
    [Serializable]
    public class UserEventArgs : EventArgs
    {
        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="user"></param>
        public UserEventArgs(BllUser user)
        {
            if (ReferenceEquals(user, null))
            {
                throw new ArgumentNullException(nameof(user) + " is null!");
            }

            User = user;
        }

        /// <summary>
        ///     Gets the user
        /// </summary>
        public BllUser User { get; }
    }
}
