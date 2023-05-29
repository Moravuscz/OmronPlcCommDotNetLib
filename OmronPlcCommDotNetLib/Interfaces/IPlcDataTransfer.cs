namespace Moravuscz.OmronPlcCommunication
{
    public interface IPlcDataTransfer
    {
        #region Public Methods

        /// <summary>
        /// Read the value of a single bit at specified <paramref name="address"/>
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        bool ReadBit(string address);

        /// <summary>
        ///
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        ushort ReadWord(string word);

        /// <summary>
        ///
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        ushort[] ReadWords(string[] area);

        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool WriteBit(string address, bool value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool WriteWord(string address, ushort value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        bool WriteWords(string startAddress, ushort[] values);

        #endregion Public Methods
    }
}