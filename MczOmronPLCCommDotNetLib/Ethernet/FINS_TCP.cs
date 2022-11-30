using System;
using System.Net;
using System.Net.Sockets;
using Moravuscz.OmronPLCComm.Fins;

namespace Moravuscz.OmronPLCComm.Ethernet
{
    public class FINS_TCP : ITransport
    {
        #region Fields

        private readonly Socket _socket = null;

        #endregion Fields

        #region Properties

        public bool Connected
        {
            get
            {
                return _socket.Connected;
            }
        }

        public IPAddress ConnectionIP { get; private set; }
        public FinsConfig FinsConfig { get; private set; }
        public Port Port { get; private set; }

        #endregion Properties

        #region Methods

        #region ITransport Implementation

        public void CloseConnection() => throw new NotImplementedException();

        public bool OpenConnection() => throw new NotImplementedException();

        public int ReceiveData() => throw new NotImplementedException();

        public int SendData() => throw new NotImplementedException();

        #endregion ITransport Implementation

        public void Setup(FinsConfig finsConfig, IPAddress iPAddress, Port port)
        {
            FinsConfig = finsConfig;
            ConnectionIP = iPAddress;
            Port = port;
        }

        #endregion Methods
    }
}