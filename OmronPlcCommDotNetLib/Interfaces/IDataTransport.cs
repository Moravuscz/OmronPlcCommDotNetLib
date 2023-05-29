namespace Moravuscz.OmronPlcCommunication
{
    /// <summary>
    /// Provides network communication methods and status
    /// </summary>
    internal interface IDataTransport
    {
        #region Public Methods

        /// <summary>
        /// Receive response data from PLC
        /// </summary>
        /// <returns>number of <see cref="byte"/>s received</returns>
        int ReceiveData(byte[] receiveDataBuffer);

        /// <summary>
        /// Send command data to PLC
        /// </summary>
        /// <returns>Number of <see cref="byte"/>s sent</returns>
        int SendData(byte[] sendDataBuffer);

        #endregion Public Methods
    }
}
