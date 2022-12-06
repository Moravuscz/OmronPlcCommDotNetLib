namespace Moravuscz.OmronPLCComm
{
    /// <summary>
    /// Provides network communication methods and status
    /// </summary>
    public interface ITransport
    {
        #region Public Properties

        /// <summary>
        /// Connection status
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Last error occured during communication
        /// </summary>
        string LastError { get; }

        #endregion Public Properties



        #region Public Methods

        /// <summary>
        /// Closes connection to PLC
        /// </summary>
        bool CloseConnection();

        /// <summary>
        /// Opens connection to PLC
        /// </summary>
        /// <returns></returns>
        bool OpenConnection();

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