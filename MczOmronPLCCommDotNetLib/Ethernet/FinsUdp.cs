using System;

namespace Moravuscz.OmronPLCComm.Ethernet
{
    public class FinsUdp : ITransport, IPlcDataTransfer
    {
        #region Properties

        public bool Connected => throw new NotImplementedException();

        public string LastError => throw new NotImplementedException();

        #endregion Properties

        #region ITransport Implementation

        public bool CloseConnection() => throw new NotImplementedException();

        public bool OpenConnection() => throw new NotImplementedException();

        public int ReceiveData(byte[] receiveDataBuffer) => throw new NotImplementedException();

        public int SendData(byte[] sendDataBuffer) => throw new NotImplementedException();

        #endregion ITransport Implementation

        #region IPlcDataTransfer Implementation

        public bool PlcReadBit(string address) => throw new NotImplementedException();

        public short PlcReadWord(string word) => throw new NotImplementedException();

        public short[] PlcReadWord(string[] area) => throw new NotImplementedException();

        public bool PlcWriteBit(string address, bool value) => throw new NotImplementedException();

        public bool PlcWriteWord(string address, short value) => throw new NotImplementedException();

        public bool PlcWriteWord(string startAddress, short[] values) => throw new NotImplementedException();

        #endregion IPlcDataTransfer Implementation
    }
}