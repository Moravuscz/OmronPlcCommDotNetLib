using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Moravuscz.OmronPlcCommunications.Ethernet
{
    /// <summary>
    /// Communication over <see cref="Ethernet" /> using the <inheritdoc cref="FinsTcp" path="/DisplayName" /> protocol
    /// </summary>
    /// <DisplayName>FINS/TCP</DisplayName>
    public class FinsTcp : IPlcCommunication, IPlcDataTransfer
    {
        #region Public Constructors + Destructors

        public FinsTcp(Fins.Config config, IPAddress remoteIpAddress, Port port)
        {
            Config = config;
            RemoteIP = remoteIpAddress;
            RemotePort = port;
            RemoteIpEndPoint = new IPEndPoint(RemoteIP, RemotePort);
            Transport = new DataTransport(new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
        }

        public FinsTcp(Fins.Config config, IPAddress remoteIpAddress, Port port, IPAddress localIpAddress, Port localPort)
            : this(config, remoteIpAddress, port)
        {
            LocalIP = localIpAddress;
            LocalPort = localPort;
        }

        #endregion Public Constructors + Destructors

        #region Public Properties

        public Fins.Config Config { get; private set; }
        public bool Connected => Transport.Socket.Connected;
        public IPAddress RemoteIP { get; private set; }
        public IPAddress LocalIP { get; private set; }
        public Port LocalPort { get; private set; }
        public string LastError { get; private set; }
        public Port RemotePort { get; private set; }

        #endregion Public Properties

        #region Private Properties

        private DataTransport Transport { get; }
        private IPEndPoint RemoteIpEndPoint { get; }

        #endregion Private Properties

        #region Public Methods

        public bool CloseConnection()
        {
            try
            {
                Transport.Socket.Disconnect(true);
            }
            catch (PlatformNotSupportedException e)
            {
                Debug.WriteLine($"ArgumentNullException : {e}");
            }
            catch (ObjectDisposedException e)
            {
                Debug.WriteLine($"ObjectDispoedException : {e}");
            }
            catch (SocketException e)
            {
                Debug.WriteLine($"SocketException : {e}");
            }

            catch (Exception e)
            {
                Debug.WriteLine($"Unexpected exception : {e}");
            }

            return Connected;
        }

        public bool OpenConnection()
        {
            try
            {
                Transport.Socket.Connect(new IPEndPoint(RemoteIP, RemotePort));
            }
            catch (ArgumentNullException e)
            {
                Debug.WriteLine($"ArgumentNullException : {e}");
            }
            catch (SocketException e)
            {
                Debug.WriteLine($"SocketException : {e}");
            }
            catch (ObjectDisposedException e)
            {
                Debug.WriteLine($"ObjectDispoedException : {e}");
            }
            catch (System.Security.SecurityException e)
            {
                Debug.WriteLine($"SecurityException : {e}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unexpected exception : {e}");
            }
            return Connected;
        }

        public bool ReadBit(string address) => throw new NotImplementedException();

        public ushort ReadWord(string word)
        {
            byte[] command = new byte[]
            {
                (byte)'@',
            };

            return Convert.ToUInt16(Transport.SendData(command));
        }

        public ushort[] ReadWords(string[] area) => throw new NotImplementedException();

        public bool WriteBit(string address, bool value) => throw new NotImplementedException();

        public bool WriteWord(string address, ushort value) => throw new NotImplementedException();

        public bool WriteWords(string startAddress, ushort[] values) => throw new NotImplementedException();

        #endregion Public Methods

        #region Private Classes

        private class DataTransport : IDataTransport
        {
            #region Private Fields

            private Socket _socket = null;

            #endregion Private Fields

            #region Internal Constructors + Destructors

            internal DataTransport(Socket socket)
            {
                Socket = socket;
            }

            #endregion Internal Constructors + Destructors

            #region Public Properties

            internal Socket Socket
            {
                get => _socket;
                private set => _socket = value;
            }

            internal SocketException SocketException { get; private set; } 

            #endregion Public Properties

            #region Public Methods

            public int ReceiveData(byte[] receiveDataBuffer)
            {
                try
                {
                    return _socket.Receive(receiveDataBuffer);
                }
                catch
                {

                }
                return -1;
            }

            public int SendData(byte[] sendDataBuffer)
            {
                return _socket.Send(sendDataBuffer);
            }

            #endregion Public Methods
        }

        #endregion Private Classes
    }
}
