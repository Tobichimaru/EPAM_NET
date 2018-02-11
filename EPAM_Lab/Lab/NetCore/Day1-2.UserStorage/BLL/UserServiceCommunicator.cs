using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BLL.Models;
using NetworkConfig;

namespace BLL
{
    /// <summary>
    ///     Class for network communication through sockets
    /// </summary>
    [Serializable]
    public class UserServiceCommunicator : MarshalByRefObject, IDisposable
    {
        #region Private Fields
        /// <summary>
        ///     Receiver of the messages
        /// </summary>
        private readonly Receiver<BllUser> receiver;

        /// <summary>
        ///     Sender of the messages
        /// </summary>
        private readonly Sender<BllUser> sender;

        /// <summary>
        ///     Task for the receiver
        /// </summary>
        private Task recieverTask;

        /// <summary>
        ///     Cancellation Token Source
        /// </summary>
        private CancellationTokenSource tokenSource;
        #endregion

        #region Constructors
        /// <summary> 
        ///      Initializes a new instance of the <see cref="UserServiceCommunicator" /> with sender and reciever objects
        /// </summary>
        /// <param name="sender">sender of the messages</param>
        /// <param name="receiver">receiver of the messages</param>
        public UserServiceCommunicator(Sender<BllUser> sender, Receiver<BllUser> receiver)
        {
            this.sender = sender;
            this.receiver = receiver;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserServiceCommunicator" /> with sender
        /// </summary>
        /// <param name="sender">sender of the messages</param>
        public UserServiceCommunicator(Sender<BllUser> sender) : this(sender, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserServiceCommunicator" /> with sender
        /// </summary>
        /// <param name="receiver">receiver of the messages</param>
        public UserServiceCommunicator(Receiver<BllUser> receiver) : this(null, receiver)
        {
        }
        #endregion

        #region Events
        /// <summary>
        ///     Event for user adding
        /// </summary>
        public event EventHandler<UserEventArgs> UserAdded;

        /// <summary>
        ///     Event for user deleting
        /// </summary>
        public event EventHandler<UserEventArgs> UserDeleted;
        #endregion

        #region Public Methods
        /// <summary>
        ///     Realease sockets
        /// </summary>
        public void Dispose()
        {
            receiver?.Dispose();
            sender?.Dispose();
        }
        
        /// <summary>
        ///     Asynchronously starts message recieving
        /// </summary>
        public async void RunReceiver()
        {
            await receiver.AcceptConnection();

            tokenSource = new CancellationTokenSource();
            recieverTask = Task.Run((Action)ReceiveMessages, tokenSource.Token);
        }

        /// <summary>
        ///     Connects to group of listeners
        /// </summary>
        /// <param name="endPoints">end points</param>
        public void Connect(IEnumerable<IPEndPoint> endPoints)
        {
            if (ReferenceEquals(sender, null))
            {
                return;
            }

            sender.Connect(endPoints);
        }

        /// <summary>
        ///     Stops recieving
        /// </summary>
        public void StopReceiver()
        {
            if (!ReferenceEquals(tokenSource, null) && tokenSource.Token.CanBeCanceled)
            {
                tokenSource.Cancel();
            }
        }

        /// <summary>
        ///     Sends add notification
        /// </summary>
        /// <param name="args">user event arguments</param>
        public void SendAdd(UserEventArgs args)
        {
            if (ReferenceEquals(sender, null))
            {
                return;
            }

            if (ReferenceEquals(args, null))
            {
                throw new ArgumentNullException();
            }

            Send(new NetworkMessage<BllUser>(args.User, MessageType.Added));
        }

        /// <summary>
        ///     Sends delete notification
        /// </summary>
        /// <param name="args">user event arguments</param>
        public void SendDelete(UserEventArgs args)
        {
            if (ReferenceEquals(sender, null))
            {
                return;
            }

            if (ReferenceEquals(args, null))
            {
                throw new ArgumentNullException();
            }

            Send(new NetworkMessage<BllUser>(args.User, MessageType.Deleted));
        }
        #endregion

        #region Protected Methods
        /// <summary>
        ///     Invokes UserDeleted event
        /// </summary>
        /// <param name="sender">sender of the message</param>
        /// <param name="args">user event arguments</param>
        protected virtual void OnUserDeleted(object sender, UserEventArgs args)
        {
            UserDeleted?.Invoke(sender, args);
        }

        /// <summary>
        ///     Invokes UserAdded event
        /// </summary>
        /// <param name="sender">sender of the message</param>
        /// <param name="args">user event arguments</param>
        protected virtual void OnUserAdded(object sender, UserEventArgs args)
        {
            UserAdded?.Invoke(sender, args);
        }
        #endregion

        #region Private Methods
        private void ReceiveMessages()
        {
            while (true)
            {
                if (tokenSource.IsCancellationRequested)
                {
                    return;
                }

                var message = receiver.Receive();
                var args = new UserEventArgs(message.Entity);
                switch (message.MessageType)
                {
                    case MessageType.Added:
                        OnUserAdded(this, args);
                        break;
                    case MessageType.Deleted:
                        OnUserDeleted(this, args);
                        break;
                }
            }
        }

        private void Send(NetworkMessage<BllUser> message)
        {
            sender.Send(message);
        }
        #endregion
    }
}
