using System;
using System.Net;
using System.Net.Sockets;

namespace Moravuscz.OmronPLCComm.Ethernet
{
    public class FinsTcp : ITransport, IPlcDataTransfer
    {
        #region Fields

        private readonly Socket _socket = null;
        private string _lastError;

        #endregion Fields

        #region Properties

        public Fins.Config Config { get; private set; }
        public bool Connected => _socket.Connected;
        public IPAddress ConnectionIP { get; private set; }

        public string LastError
        {
            get => _lastError;
            private set => _lastError = value;
        }

        public Port Port { get; private set; }

        #endregion Properties

        #region Methods

        #region ITransport Implementation

        public bool CloseConnection()
        {
            _socket.Close();
            return Connected;
        }

        public bool OpenConnection()
        {
            _socket.Connect(ConnectionIP, Port);
            return Connected;
        }

        public int ReceiveData(byte[] receiveDataBuffer)
        {
            return _socket.Receive(receiveDataBuffer);
        }

        public int SendData(byte[] sendDataBuffer)
        {
            return _socket.Send(sendDataBuffer);
        }

        #endregion ITransport Implementation

        #region IPlcDataTransfer

        public bool PlcReadBit(string address) => throw new NotImplementedException();

        public short PlcReadWord(string word) => throw new NotImplementedException();

        public short[] PlcReadWord(string[] area) => throw new NotImplementedException();

        public bool PlcWriteBit(string address, bool value) => throw new NotImplementedException();

        public bool PlcWriteWord(string address, short value) => throw new NotImplementedException();

        public bool PlcWriteWord(string startAddress, short[] values) => throw new NotImplementedException();

        #endregion IPlcDataTransfer

        public FinsTcp(Fins.Config config, IPAddress iPAddress, Port port)
        {
            Config = config;
            ConnectionIP = iPAddress;
            Port = port;
        }

        #endregion Methods
    }
}