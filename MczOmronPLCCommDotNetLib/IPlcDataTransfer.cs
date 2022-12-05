using System.Collections.Generic;
using System;

namespace Moravuscz.OmronPLCComm
{
    public interface IPlcDataTransfer
    {
        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        bool PlcReadBit(string address);

        /// <summary>
        ///
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        short PlcReadWord(string word);

        /// <summary>
        ///
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        short[] PlcReadWord(string[] area);

        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool PlcWriteBit(string address, bool value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool PlcWriteWord(string address, short value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="startAddress"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        bool PlcWriteWord(string startAddress, short[] values);

        #endregion Methods
    }
}