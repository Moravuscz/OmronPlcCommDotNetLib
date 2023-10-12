using System;

namespace Moravuscz.OmronPlcCommunication
{
    /// <summary>
    /// Network Port
    /// </summary>
    /// <remarks>Can be used as <see cref="int" /></remarks>
    public struct Port : IConvertible
    {
        #region Public Fields

        /// <summary>
        /// Maximum permissible value
        /// </summary>
        /// <value>65535</value>
        /// <remarks>Inclusive</remarks>
        public const int MaxValue = 65535;

        /// <summary>
        /// Minimum permissible value
        /// </summary>
        /// <value>0</value>
        /// <remarks>Inclusive</remarks>
        public const int MinValue = 0;

        #endregion Public Fields

        #region Private Fields

        /// <summary>
        /// <inheritdoc cref="Port(int)" path="/param[@name='portNumber']" />
        /// </summary>
        public int Value { get; }

        #endregion Private Fields
        #region Public Constructors + Destructors

        /// <summary>
        /// Network Port
        /// </summary>
        /// <param name="portNumber">Any <see cref="int" /> from <see cref="MinValue"><inheritdoc cref="MinValue" path="/value" /></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue" path="/value" /></see>.</param>
        public Port(int portNumber)
        {
            if (portNumber > MaxValue || portNumber < MinValue) { throw new ArgumentOutOfRangeException(nameof(portNumber), $"Value \"{portNumber}\" is out of range! Valid range is {MinValue} to {MaxValue}"); }
            Value = portNumber;
        }

        #endregion Public Constructors + Destructors

        #region Public Methods

        /// <summary>
        /// Allow <see cref="Port" /> to be used same as <see cref="int" />
        /// </summary>
        /// <param name="port"></param>
        public static implicit operator int(Port port) => port.Value;

        /// <summary>
        /// Define <see cref="Port" /> with <see cref="int" /> as parameter for its value
        /// </summary>
        /// <param name="portNumber"></param>
        public static implicit operator Port(int portNumber) => new Port(portNumber);

        #region IConvertible
        #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public TypeCode GetTypeCode() => Convert.GetTypeCode(Value);
        public bool ToBoolean(IFormatProvider provider) => Convert.ToBoolean(Value, provider);
        public byte ToByte(IFormatProvider provider) => Convert.ToByte(Value, provider);
        public char ToChar(IFormatProvider provider) => Convert.ToChar(Value, provider);
        public DateTime ToDateTime(IFormatProvider provider) => Convert.ToDateTime(Value, provider);
        public decimal ToDecimal(IFormatProvider provider) => Convert.ToDecimal(Value, provider);
        public double ToDouble(IFormatProvider provider) => Convert.ToDouble(Value, provider);
        public short ToInt16(IFormatProvider provider) => Convert.ToInt16(Value, provider);
        public int ToInt32(IFormatProvider provider) => Convert.ToInt32(Value, provider);
        public long ToInt64(IFormatProvider provider) => Convert.ToInt64(Value, provider);
        public sbyte ToSByte(IFormatProvider provider) => Convert.ToSByte(Value, provider);
        public float ToSingle(IFormatProvider provider) => Convert.ToSingle(Value, provider);
        public string ToString(IFormatProvider provider) => Convert.ToString(Value, provider);
        public object ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(Value, conversionType);
        public ushort ToUInt16(IFormatProvider provider) => Convert.ToUInt16(Value, provider);
        public uint ToUInt32(IFormatProvider provider) => Convert.ToUInt32(Value, provider);
        public ulong ToUInt64(IFormatProvider provider) => Convert.ToUInt64(Value, provider);
        #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        #endregion IConvertible

        #endregion Public Methods
    }
}
