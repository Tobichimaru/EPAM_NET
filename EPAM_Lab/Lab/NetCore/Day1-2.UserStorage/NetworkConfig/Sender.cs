using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetworkConfig
{
    /// <summary>
    ///     Sender class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Sender<T> : IDisposable
    {
        #region Private Fields
        private IList<Socket> sockets;
        #endregion

        #region Constructor
        /// <summary>
        ///     Default constructor
        /// </summary>
        public Sender()
        {
            this.sockets = new List<Socket>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///     Connects to collection of listeners
        /// </summary>
        /// <param name="ipEndPoints"></param>
        public void Connect(IEnumerable<IPEndPoint> ipEndPoints)
        {
            foreach (var ipEndPoint in ipEndPoints)
            {
                var socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipEndPoint);
                this.sockets.Add(socket);
            }
        }

        /// <summary>
        ///     Sends message
        /// </summary>
        /// <param name="message"></param>
        public void Send(NetworkMessage<T> message)
        {
            foreach (var socket in this.sockets)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (NetworkStream networkStream = new NetworkStream(socket, false))
                {
                    formatter.Serialize(networkStream, message);
                }
            }
            ////Console.WriteLine("Message is sent!");
        }

        /// <summary>
        ///     Releases sockets
        /// </summary>
        public void Dispose()
        {
            foreach (var socket in this.sockets)
            {
                socket?.Shutdown(SocketShutdown.Both);
                socket?.Close();
            }
        }
        #endregion
    }
}
