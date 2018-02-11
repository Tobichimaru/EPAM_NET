using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace NetworkConfig
{
    /// <summary>
    ///     Reciever class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Receiver<T> : IDisposable
    {
        #region Private Fields
        private Socket listener;
        private Socket reciever;
        #endregion

        #region Constructors
        /// <summary>
        ///     Parametrized constructor
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        public Receiver(IPAddress ipAddress, int port)
        {
            this.IpEndPoint = new IPEndPoint(ipAddress, port);
            this.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.listener.Bind(this.IpEndPoint);
            this.listener.Listen(1);
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Gets the ip address of the port
        /// </summary>
        public IPEndPoint IpEndPoint { get; }
        #endregion

        #region Public Methods
        /// <summary>
        ///     Accepts connection
        /// </summary>
        /// <returns></returns>
        public Task AcceptConnection()
        {
            return Task.Run(() =>
            {
                this.reciever = this.listener.Accept();
            });
        }

        /// <summary>
        ///     Recieves message
        /// </summary>
        /// <returns></returns>
        public NetworkMessage<T> Receive()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            NetworkMessage<T> message;

            using (var networkStream = new NetworkStream(this.reciever, false))
            {
                message = (NetworkMessage<T>)formatter.Deserialize(networkStream);
            }

            Console.WriteLine($"User {message.Entity} {message.MessageType}!");

            return message;
        }

        /// <summary>
        ///     Releases sockets
        /// </summary>
        public void Dispose()
        {
            this.Close(this.reciever);
            this.Close(this.listener);
        }
        #endregion

        #region Private Methods
        private void Close(Socket socket)
        {
            socket?.Shutdown(SocketShutdown.Both);
            socket?.Close();
        }
        #endregion
    }
}
