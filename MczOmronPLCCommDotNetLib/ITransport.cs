using System;

namespace Moravuscz.OmronPLCComm
{
    internal interface ITransport
    {
        #region Properties

        /// <summary>
        /// Connection status
        /// </summary>
        bool Connected { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Closes connection to PLC
        /// </summary>
        void CloseConnection();

        /// <summary>
        /// Opens connection to PLC
        /// </summary>
        /// <returns></returns>
        bool OpenConnection();

        /// <summary>
        /// Receive response data from PLC
        /// </summary>
        /// <returns>number of <see cref="byte"/>s received</returns>
        int ReceiveData();

        /// <summary>
        /// Send command data to PLC
        /// </summary>
        /// <returns>Number of <see cref="byte"/>s sent</returns>
        int SendData();

        #endregion Methods
    }
}