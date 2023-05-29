namespace Moravuscz.OmronPlcCommunications
{
    public interface IPlcCommunication
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

        #endregion Public Methods
    }
}
