using System;

namespace Moravuscz.OmronPLCComm
{
    /// <summary>
    /// Network Port
    /// </summary>
    public struct Port
    {
        #region Public Fields

        /// <summary>
        /// Maximum permissible value
        /// </summary>
        /// <example>65535</example>
        /// <remarks>Inclusive</remarks>
        public const int MaxValue = 65535;

        /// <summary>
        /// Minimum permissible value
        /// </summary>
        /// <example>0</example>
        /// <remarks>Inclusive</remarks>
        public const int MinValue = 0;

        #endregion Public Fields



        #region Private Fields

        private readonly int _portNum;

        #endregion Private Fields

        #region Public Constructors + Destructors

        /// <summary>
        /// Network Port
        /// </summary>
        /// <param name="portNumber">Any <see cref="int"/> from <see cref="MinValue"><inheritdoc cref="MinValue"  path="//example"/></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue"  path="//example"/></see>.</param>
        public Port(int portNumber)
        {
            if (portNumber > MaxValue || portNumber < MinValue) { throw new ArgumentOutOfRangeException(); }
            _portNum = portNumber;
        }

        #endregion Public Constructors + Destructors



        #region Public Methods

        /// <summary>
        /// Allow <see cref="Port"/> to be used same as <see cref="int"/>
        /// </summary>
        /// <param name="port"></param>
        public static implicit operator int(Port port) => port._portNum;

        /// <summary>
        /// Define <see cref="Port"/> with <see cref="int"/> as parameter for its value
        /// </summary>
        /// <param name="portNumber"></param>
        public static implicit operator Port(int portNumber) => new Port(portNumber);

        public override string ToString() => _portNum.ToString();

        #endregion Public Methods
    }
}