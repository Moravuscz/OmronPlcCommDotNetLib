using System;

namespace Moravuscz.OmronPlcCommunication.Ethernet
{
    /// <summary>
    /// Communication over <see cref="Ethernet"/> using the <inheritdoc cref="FinsUdp" path="/DisplayName"/> protocol
    /// </summary>
    /// <DisplayName>FINS/UDP</DisplayName>
    public class FinsUdp : IPlcCommunication, IPlcDataTransfer
    {
        #region Public Properties

        public bool Connected => throw new NotImplementedException();

        public string LastError => throw new NotImplementedException();

        #endregion Public Properties

        #region Public Methods

        public bool CloseConnection() => throw new NotImplementedException();

        public bool OpenConnection() => throw new NotImplementedException();

        public bool ReadBit(string address) => throw new NotImplementedException();

        public ushort ReadWord(string word) => throw new NotImplementedException();

        public ushort[] ReadWords(string[] area) => throw new NotImplementedException();

        public bool WriteBit(string address, bool value) => throw new NotImplementedException();

        public bool WriteWord(string address, ushort value) => throw new NotImplementedException();

        public bool WriteWords(string startAddress, ushort[] values) => throw new NotImplementedException();

        #endregion Public Methods

        internal class Transport : IDataTransport
        {
            #region Public Methods

            public int ReceiveData(byte[] receiveDataBuffer) => throw new NotImplementedException();

            public int SendData(byte[] sendDataBuffer) => throw new NotImplementedException();

            #endregion Public Methods
        }

    }
}