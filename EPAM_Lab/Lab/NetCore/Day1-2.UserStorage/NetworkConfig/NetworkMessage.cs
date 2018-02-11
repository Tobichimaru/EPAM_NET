using System;

namespace NetworkConfig
{
    /// <summary>
    ///     Enumeration for message type
    /// </summary>
    [Serializable]
    public enum MessageType
    {
        /// <summary>
        ///     Added
        /// </summary>
        Added = 0,

        /// <summary>
        ///     Deleted
        /// </summary>
        Deleted = 1
    }

    /// <summary>
    ///     Helper class for network message
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class NetworkMessage<T>
    {
        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="messageType"></param>
        public NetworkMessage(T entity, MessageType messageType)
        {
            if (object.ReferenceEquals(entity, null))
            {
                throw new ArgumentNullException(nameof(entity) + " is null!");
            }

            this.Entity = entity;
            this.MessageType = messageType;
        }

        /// <summary>
        ///     Property for message info
        /// </summary>
        public T Entity { get; }

        /// <summary>
        ///     Property for message type
        /// </summary>
        public MessageType MessageType { get; }
    }
}
