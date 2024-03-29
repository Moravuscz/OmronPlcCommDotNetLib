﻿using System;

namespace Moravuscz.OmronPlcCommunication
{
    /// <summary>
    /// Communication protocol for OMRON PLCs
    /// </summary>
    /// <remarks>FINS = Factory Interface Network Service</remarks>
    public abstract class Fins
    {
        #region Public Fields

        /// <summary>
        /// Default FINS <see cref="Port" />
        /// </summary>
        /// <value>9600</value>
        public static readonly Port DefaultPort = 9600;

        #endregion Public Fields

        #region Public Structs

        /// <summary>
        /// Encapsulates FINS Communication Settings
        /// </summary>
        /// <remarks>Consists of <see cref="SourceAddress.SourceAddress(Net, Node, Unit)" />, <see cref="DestinationAddress.DestinationAddress(Net, Node, Unit)" />, <see cref="FrameLength.FrameLength(int)" /> and <see cref="ResponseTimeout.ResponseTimeout(int)" /></remarks>
        public struct Config
        {
            #region Public Constructors + Destructors

            /// <summary>
            /// <inheritdoc cref="Config" path="/summary" />
            /// </summary>
            /// <remarks>
            /// <inheritdoc cref="Config" path="/remarks" />
            /// <list type="number">
            /// <item><paramref name="sourceAddress" /> = <see cref="Fins.SourceAddress" />(<inheritdoc cref="Config(SourceAddress, DestinationAddress, FrameLength, ResponseTimeout)" path="/param[@name='sourceAddress']" />)</item>
            /// <item><paramref name="destinationAddress" /> = <see cref="Fins.DestinationAddress" />(<inheritdoc cref="Config(SourceAddress, DestinationAddress, FrameLength, ResponseTimeout)" path="/param[@name='destinationAddress']" />)</item>
            /// <item><paramref name="frameLength" /> = <inheritdoc cref="Config(SourceAddress, DestinationAddress, FrameLength, ResponseTimeout)" path="/param[@name='frameLength']" /></item>
            /// <item><paramref name="responseTimeout" /> = <inheritdoc cref="Config(SourceAddress, DestinationAddress, FrameLength, ResponseTimeout)" path="/param[@name='responseTimeout']" /></item>
            /// </list>
            /// </remarks>
            /// <param name="sourceAddress"><see cref="Net" />(<inheritdoc cref="Net(int)" />), <see cref="Node" />(<inheritdoc cref="Node(int)" />), <see cref="Unit" />(<inheritdoc cref="Unit(int)" />)</param>
            /// <param name="destinationAddress"><see cref="Net" />(<inheritdoc cref="Net(int)" />), <see cref="Node" />(<inheritdoc cref="Node(int)" />), <see cref="Unit" />(<inheritdoc cref="Unit(int)" />)</param>
            /// <param name="frameLength"><see cref="Fins.FrameLength" />(<inheritdoc cref="FrameLength.FrameLength(int)" />)</param>
            /// <param name="responseTimeout"><see cref="Fins.ResponseTimeout" />(<inheritdoc cref="ResponseTimeout.ResponseTimeout(int)" />)</param>
            public Config(SourceAddress sourceAddress, DestinationAddress destinationAddress, FrameLength frameLength, ResponseTimeout responseTimeout)
            {
                DestinationAddress = destinationAddress;
                SourceAddress = sourceAddress;
                FrameLength = frameLength;
                ResponseTimeout = responseTimeout;
            }

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <inheritdoc cref="DestinationAddress.DestinationAddress(Net, Node, Unit)" />
            public DestinationAddress DestinationAddress { get; }

            /// <inheritdoc cref="FrameLength.FrameLength(int)" />
            public FrameLength FrameLength { get; }

            /// <inheritdoc cref="ResponseTimeout.ResponseTimeout(int)" />
            public ResponseTimeout ResponseTimeout { get; }

            /// <inheritdoc cref="SourceAddress.SourceAddress(Net, Node, Unit)" />
            public SourceAddress SourceAddress { get; }

            #endregion Public Properties
        }

        /// <summary>
        /// Destination address in FINS communication
        /// </summary>
        /// <remarks>Consists of <see cref="Fins.Net" />, <see cref="Fins.Node" /> and <see cref="Fins.Unit"/></remarks>
        public struct DestinationAddress
        {
            #region Public Constructors + Destructors

            /// <summary>
            /// <inheritdoc cref="DestinationAddress" path="/summary" />
            /// </summary>
            /// <remarks>
            /// <inheritdoc cref="DestinationAddress" path="/remarks" />
            /// <list type="number">
            /// <item><paramref name="destinationNet" /> = <see cref="Fins.Net" />(<inheritdoc cref="DestinationAddress(Net, Node, Unit)" path="/param[@name='destinationNet']" />)</item>
            /// <item><paramref name="destinationNode" /> = <see cref="Fins.Node" />(<inheritdoc cref="DestinationAddress(Net, Node, Unit)" path="/param[@name='destinationNode']" />)</item>
            /// <item><paramref name="destinationUnit" /> = <see cref="Fins.Unit" />(<inheritdoc cref="DestinationAddress(Net, Node, Unit)" path="/param[@name='destinationUnit']" />)</item>
            /// </list>
            /// </remarks>
            /// <param name="destinationNet"><inheritdoc cref="Net.Net(int)" path="/param[@name='netNumber']" /></param>
            /// <param name="destinationNode"><inheritdoc cref="Node.Node(int)" path="/param[@name='nodeNumber']" /></param>
            /// <param name="destinationUnit"><inheritdoc cref="Unit.Unit(int)" path="/param[@name='unitNumber']" /></param>
            public DestinationAddress(Net destinationNet, Node destinationNode, Unit destinationUnit)
            {
                Net = destinationNet;
                Node = destinationNode;
                Unit = destinationUnit;
            }

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <inheritdoc cref="Fins.Net" />
            public Net Net { get; }

            /// <inheritdoc cref="Fins.Node" />
            public Node Node { get; }

            /// <inheritdoc cref="Fins.Unit" />
            /// <value>0</value>
            public Unit Unit { get; }

            #endregion Public Properties
        }

        /// <summary>
        /// Length of a FINS frame
        /// </summary>
        public struct FrameLength : IConvertible
        {
            #region Public Fields

            /// <summary>
            /// Default value
            /// </summary>
            /// <value>2000</value>
            public const int Default = 2000;

            /// <summary>
            /// Maximum permissible value
            /// </summary>
            /// <value>2000</value>
            public const int MaxValue = 2000;

            /// <summary>
            /// Minimum permissible value
            /// </summary>
            /// <value>0</value>
            public const int MinValue = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <summary>
            /// <inheritdoc cref="FrameLength" path="/summary" />
            /// </summary>
            /// <remarks>
            /// <inheritdoc cref="FrameLength" path="/remarks" />
            /// <list type="number">
            /// <item><paramref name="length" /> = <inheritdoc cref="FrameLength(int)" path="/param[@name='length']" /></item>
            /// </list>
            /// </remarks>
            /// <param name="length">Any <see cref="int" /> from <see cref="MinValue"><inheritdoc cref="MinValue" path="/value" /></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue" path="/value" /></see></param>
            public FrameLength(int length) => Value = length <= MaxValue && length >= MinValue ? length : throw new ArgumentOutOfRangeException(nameof(length), $"Value \"{length}\" is out of range! Valid range is {MinValue} to {MaxValue}");

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            /// <inheritdoc cref="FrameLength(int)" path="/param[@name='length']" />
            /// </summary>
            public int Value { get; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// Treat <see cref="FrameLength" /> as <see cref="int" /> when assigning <see langword="value" />
            /// </summary>
            /// <param name="length"><inheritdoc cref="FrameLength(int)" /></param>
            #if NET46_OR_GREATER
            public static implicit operator FrameLength(int length) => new FrameLength(length);
            #endif
            #if NET5_0_OR_GREATER
            public static implicit operator FrameLength(int length) => new(length);
            #endif

            /// <summary>
            /// Treat <see cref="FrameLength" /> as <see cref="int" /> when retrieving <see langword="value" />
            /// </summary>
            /// <param name="length"><inheritdoc cref="FrameLength(int)" /></param>
            public static implicit operator int(FrameLength length) => length.Value;

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

        /// <summary>
        /// FINS Network Number
        /// </summary>
        public struct Net : IConvertible
        {
            #region Public Fields

            /// <summary>
            /// Maximum permissible value
            /// </summary>
            /// <value>127</value>
            public const int MaxValue = 127;

            /// <summary>
            /// Minimum permissible value
            /// </summary>
            /// <value>0</value>
            public const int MinValue = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <summary>
            /// <inheritdoc cref="Net" path="/summary" />
            /// </summary>
            /// <remarks>
            /// <inheritdoc cref="Net" path="/remarks" />
            /// <list type="number">
            /// <item><paramref name="netNumber" /> = <inheritdoc cref="Net(int)" path="/param[@name='netNumber']" /></item>
            /// </list>
            /// </remarks>
            /// <param name="netNumber">Any <see cref="int" /> from <see cref="MinValue"><inheritdoc cref="MinValue" path="/value" /></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue" path="/value" /></see></param>
            public Net(int netNumber) => Value = netNumber <= MaxValue && netNumber >= MinValue ? netNumber : throw new ArgumentOutOfRangeException(nameof(netNumber), $"Value \"{netNumber}\" is out of range! Valid range is {MinValue} to {MaxValue}");

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            /// <inheritdoc cref="Net(int)" path="/param[@name='netNumber']" />
            /// </summary>
            public int Value { get; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// Treat <see cref="Net" /> as <see cref="int" /> when retrieving <see langword="value" />
            /// </summary>
            /// <param name="net"><inheritdoc cref="Net(int)" /></param>
            public static implicit operator int(Net net) => net.Value;

            /// <summary>
            /// Treat <see cref="Net" /> as <see cref="int" /> when assigning <see langword="value" />
            /// </summary>
            /// <param name="netNum"><inheritdoc cref="Net(int)" /></param>
            #if NET46_OR_GREATER
            public static implicit operator Net(int netNum) => new Net(netNum);
            #endif
            #if NET5_0_OR_GREATER
            public static implicit operator Net(int netNum) => new(netNum);
            #endif

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

        /// <summary>
        /// FINS Node Number
        /// </summary>
        public struct Node : IConvertible
        {
            #region Public Fields

            /// <summary>
            /// Maximum permissible value
            /// </summary>
            /// <value>255</value>
            public const int MaxValue = 255;

            /// <summary>
            /// Minimum permissible value
            /// </summary>
            /// <value>0</value>
            public const int MinValue = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <summary>
            /// <inheritdoc cref="Node" path="/summary" />
            /// </summary>
            /// <remarks>
            /// <inheritdoc cref="Node" path="/remarks" />
            /// <list type="number">
            /// <item><paramref name="nodeNumber" /> = <inheritdoc cref="Node(int)" path="/param[@name='nodeNumber']" /></item>
            /// </list>
            /// </remarks>
            /// <param name="nodeNumber">Any <see cref="int" /> from <see cref="MinValue"><inheritdoc cref="MinValue" path="/value" /></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue" path="/value" /></see></param>
            public Node(int nodeNumber) => Value = nodeNumber <= MaxValue && nodeNumber >= MinValue ? nodeNumber : throw new ArgumentOutOfRangeException(nameof(nodeNumber), $"Value \"{nodeNumber}\" is out of range! Valid range is {MinValue} to {MaxValue}");

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            /// <inheritdoc cref="Node(int)" path="/param[@name='nodeNumber']" />
            /// </summary>
            public int Value { get; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// Treat <see cref="Node" /> as <see cref="int" /> when retrieving <see langword="value" />
            /// </summary>
            /// <param name="node"><inheritdoc cref="Node(int)" /></param>
            public static implicit operator int(Node node) => node.Value;

            /// <summary>
            /// Treat <see cref="Node" /> as <see cref="int" /> when assigning <see langword="value" />
            /// </summary>
            /// <param name="nodeNum"><inheritdoc cref="Node(int)" /></param>
            #if NET46_OR_GREATER
            public static implicit operator Node(int nodeNum) => new Node(nodeNum);
            #endif
            #if NET5_0_OR_GREATER
            public static implicit operator Node(int nodeNum) => new(nodeNum);
            #endif

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

        /// <summary>
        /// Time to fail FINS communication
        /// </summary>
        public struct ResponseTimeout : IConvertible
        {
            #region Public Fields

            /// <summary>
            /// Default value
            /// </summary>
            /// <value>2000</value>
            public const int Default = 2;

            /// <summary>
            /// Maximum permissible value
            /// </summary>
            /// <value>600</value>
            /// <remarks>Inclusive</remarks>
            public const int MaxValue = 600;

            /// <summary>
            /// Minimum permissible value
            /// </summary>
            /// <value>0</value>
            /// <remarks>Inclusive</remarks>
            public const int MinValue = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors
            
            /// <summary>
            /// <inheritdoc cref="ResponseTimeout" path="/summary" />
            /// </summary>
            /// <remarks>
            /// <inheritdoc cref="ResponseTimeout" path="/remarks" />
            /// <list type="number">
            /// <item><paramref name="time" /> = <inheritdoc cref="ResponseTimeout(int)" path="/param[@name='time']" /></item>
            /// </list>
            /// </remarks>
            /// <param name="time"><see cref="int" /> Time in seconds; from <see cref="MinValue"><inheritdoc cref="MinValue" path="/value" /></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue" path="/value" /></see></param>
            public ResponseTimeout(int time) => Value = time <= MaxValue && time >= MinValue ? time : throw new ArgumentOutOfRangeException(nameof(time), $"Value \"{time}\" is out of range! Valid range is {MinValue} to {MaxValue}");

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            /// <inheritdoc cref="ResponseTimeout(int)" path="/param[@name='time']" />
            /// </summary>
            public int Value { get; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// Treat <see cref="ResponseTimeout" /> as <see cref="int" /> when retrieving <see langword="value" />
            /// </summary>
            /// <param name="responseTimeout"><inheritdoc cref="ResponseTimeout(int)" /></param>
            public static implicit operator int(ResponseTimeout responseTimeout) => responseTimeout.Value;

            /// <summary>
            /// Treat <see cref="ResponseTimeout" /> as <see cref="int" /> when assigning <see langword="value" />
            /// </summary>
            /// <param name="time"><inheritdoc cref="ResponseTimeout(int)" /></param>
            #if NET46_OR_GREATER
            public static implicit operator ResponseTimeout(int time) => new ResponseTimeout(time);
            #endif
            #if NET5_0_OR_GREATER
            public static implicit operator ResponseTimeout(int time) => new(time);
            #endif

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

        /// <summary>
        /// Source address in FINS communication
        /// </summary>
        /// <remarks><inheritdoc cref="DestinationAddress" path="/remarks" /></remarks>
        public struct SourceAddress
        {
            #region Public Constructors + Destructors

            /// <summary>
            /// <inheritdoc cref="SourceAddress" path="/summary" />
            /// </summary>
            /// <remarks>
            /// <list type="number">
            /// <item><paramref name="sourceNet" /> = <see cref="Fins.Net" />(<inheritdoc cref="SourceAddress(Net, Node, Unit)" path="/param[@name='sourceNet']" />)</item>
            /// <item><paramref name="sourceNode" /> = <see cref="Fins.Node" />(<inheritdoc cref="SourceAddress(Net, Node, Unit)" path="/param[@name='sourceNode']" />)</item>
            /// <item><paramref name="sourceUnit" /> = <see cref="Fins.Unit" />(<inheritdoc cref="SourceAddress(Net, Node, Unit)" path="/param[@name='sourceUnit']" />)</item>
            /// </list>
            /// </remarks>
            /// <param name="sourceNet"><inheritdoc cref="Net.Net(int)" /></param>
            /// <param name="sourceNode"><inheritdoc cref="Node.Node(int)" /></param>
            /// <param name="sourceUnit"><inheritdoc cref="Unit.Unit(int)" /></param>
            public SourceAddress(Net sourceNet, Node sourceNode, Unit sourceUnit)
            {
                Net = sourceNet;
                Node = sourceNode;
                Unit = sourceUnit;
            }

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            /// <see cref="Fins.Node" /> in <see cref="SourceAddress" /> is always <inheritdoc cref="Node" path="/value" />
            /// </summary>
            /// <value>0</value>
            public Node Node { get; }

            /// <summary>
            /// <see cref="Fins.Unit" /> in <see cref="SourceAddress" /> is always <inheritdoc cref="Unit" path="/value" />
            /// </summary>
            /// <value>0</value>
            public Unit Unit { get; }

            /// <summary>
            /// <see cref="Fins.Net" /> in <see cref="SourceAddress" />
            /// </summary>
            public Net Net { get; }

            #endregion Public Properties
        }

        /// <summary>
        /// FINS CPU Bus Unit Number
        /// </summary>
        public struct Unit : IConvertible
        {
            #region Public Fields

            /// <summary>
            /// Maximum permissible value
            /// </summary>
            /// <value>15</value>
            /// <remarks>Inclusive</remarks>
            public const int MaxValue = 15;

            /// <summary>
            /// Minimum permissible value
            /// </summary>
            /// <value>0</value>
            /// <remarks>Inclusive</remarks>
            public const int MinValue = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <inheritdoc cref="Unit" />
            /// <remarks>
            /// <list type="number">
            /// <item><paramref name="unitNumber" /> = <inheritdoc cref="Unit(int)" path="/param[@name='unitNumber']" /></item>
            /// </list>
            /// </remarks>
            /// <param name="unitNumber">Any <see cref="int" /> from <see cref="MinValue"><inheritdoc cref="MinValue" path="/value" /></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue" path="/value" /></see></param>
            public Unit(int unitNumber) => Value = unitNumber <= MaxValue && unitNumber >= MinValue ? unitNumber : throw new ArgumentOutOfRangeException(nameof(unitNumber), $"Value \"{unitNumber}\" is out of range! Valid range is {MinValue} to {MaxValue}");

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            /// <inheritdoc cref="Unit(int)" path="/param[@name='unitNumber']" />
            /// </summary>
            public int Value { get; }

            #endregion Public Properties

            #region Public Methods

            /// <summary>
            /// Treat <see cref="Unit" /> as <see cref="int" /> when retrieving <see langword="value" />
            /// </summary>
            /// <param name="unit"><inheritdoc cref="Unit(int)" /></param>
            public static implicit operator int(Unit unit) => unit.Value;

            /// <summary>
            /// Treat <see cref="Unit" /> as <see cref="int" /> when assigning <see langword="value" />
            /// </summary>
            /// <param name="unitNumber"><inheritdoc cref="Unit(int)" /></param>
            #if NET46_OR_GREATER
            public static implicit operator Unit(int unitNumber) => new Unit(unitNumber);
            #endif
            #if NET5_0_OR_GREATER
            public static implicit operator Unit(int unitNumber) => new(unitNumber);
            #endif

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

        #endregion Public Structs
    }
}
