using System;

namespace Moravuscz.OmronPlcCommunications.Serial
{
    public class HostLink //: IDataTransport, IPlcDataTransfer
    {
        #region Public Properties

        public bool Connected => throw new NotImplementedException();

        public string LastError => throw new NotImplementedException();

        #endregion Public Properties

        #region Public Methods

        public bool CloseConnection() => throw new NotImplementedException();

        public bool OpenConnection() => throw new NotImplementedException();

        public bool ReadBit(string address) => throw new NotImplementedException();

        public short ReadWord(string word) => throw new NotImplementedException();

        public short[] PlcReadWord(string[] area) => throw new NotImplementedException();

        public bool WriteBit(string address, bool value) => throw new NotImplementedException();

        public bool WriteWord(string address, short value) => throw new NotImplementedException();

        public bool WriteWords(string startAddress, short[] values) => throw new NotImplementedException();

        public int ReceiveData(byte[] receiveDataBuffer) => throw new NotImplementedException();

        public int SendData(byte[] sendDataBuffer) => throw new NotImplementedException();

        #endregion Public Methods
    }
}