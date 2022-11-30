using System;

namespace Moravuscz.OmronPLCComm.Fins
{
    /// <summary>
    /// FINS Destination Address
    /// </summary>
    public struct DestinationAddress
    {
        #region Fields

        /// <summary>
        ///
        /// </summary>
        public const int Unit = 0;

        /// <summary>
        ///
        /// </summary>
        public FinsNet Net;

        /// <summary>
        ///
        /// </summary>
        public FinsNode Node;

        #endregion Fields

        #region Constructors

        private DestinationAddress(FinsNet sourceNet, FinsNode sourceNode)
        {
            Net = sourceNet;
            Node = sourceNode;
        }

        #endregion Constructors
    }

    /// <summary>
    /// Encapsulates FINS Communication Settings
    /// </summary>
    public struct FinsConfig
    {
        #region Properties

        public DestinationAddress DestinationAddress { get; }
        public FrameLength FrameLength { get; }
        public ReponseTimeout ReponseTimeout { get; }
        public SourceAddress SourceAddress { get; }

        #endregion Properties
    }

    /// <summary>
    /// FINS Network
    /// </summary>
    public struct FinsNet
    {
        #region Fields

        /// <summary>
        /// Maximum permissible value
        /// </summary>
        /// <example>127</example>
        /// <remarks>Inclusive</remarks>
        public const int MaxValue = 127;

        /// <summary>
        /// Minimum permissible value
        /// </summary>
        /// <example>0</example>
        /// <remarks>Inclusive</remarks>
        public const int MinValue = 0;

        private readonly int _netNum;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Network Port
        /// </summary>
        /// <param name="netNumber">Any <see cref="int"/> from <see cref="MinValue"><inheritdoc cref="MinValue"  path="//example"/></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue"  path="//example"/></see>.</param>
        private FinsNet(int netNumber)
        {
            if (netNumber > MaxValue || netNumber < MinValue) { throw new ArgumentOutOfRangeException(); }
            _netNum = netNumber;
        }

        #endregion Constructors

        #region Methods

        public static implicit operator FinsNet(int netNum) => new FinsNet(netNum);

        public static implicit operator int(FinsNet net) => net._netNum;

        #endregion Methods
    }

    /// <summary>
    /// FINS Node
    /// </summary>
    public struct FinsNode
    {
        #region Fields

        public const int MaxValue = 255;
        public const int MinValue = 0;
        private readonly int _nodeNum;

        #endregion Fields

        #region Constructors

        private FinsNode(int nodeNumber)
        {
            if (nodeNumber > MaxValue || nodeNumber < MinValue) { throw new ArgumentOutOfRangeException(); }
            _nodeNum = nodeNumber;
        }

        #endregion Constructors

        #region Methods

        public static implicit operator FinsNode(int nodeNum) => new FinsNode(nodeNum);

        public static implicit operator int(FinsNode node) => node._nodeNum;

        #endregion Methods
    }

    /// <summary>
    /// Length of a FINS frame
    /// </summary>
    public struct FrameLength
    {
        #region Fields

        /// <summary>
        /// Maximum permissible value
        /// </summary>
        /// <example>2000</example>
        /// <remarks>Inclusive</remarks>
        public const int MaxValue = 2000;

        /// <summary>
        /// Minimum permissible value
        /// </summary>
        /// <example>0</example>
        /// <remarks>Inclusive</remarks>
        public const int MinValue = 0;

        public readonly int _frameLength;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Length of a FINS frame
        /// </summary>
        /// <param name="frameLength">Any <see cref="int"/> from <see cref="MinValue"><inheritdoc cref="MinValue"  path="//example"/></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue"  path="//example"/></see>.</param>
        private FrameLength(int frameLength) => _frameLength = frameLength;

        #endregion Constructors
    }

    /// <summary>
    /// Time to fail communicatoini
    /// </summary>
    public struct ReponseTimeout
    {
        #region Fields

        /// <summary>
        /// Maximum permissible value
        /// </summary>
        /// <example>600</example>
        /// <remarks>Inclusive</remarks>
        public const int MaxValue = 600;

        /// <summary>
        /// Minimum permissible value
        /// </summary>
        /// <example>0</example>
        /// <remarks>Inclusive</remarks>
        public const int MinValue = 0;

        public readonly int _time;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Time to fail communication
        /// </summary>
        /// <remarks>Values in seconds</remarks>
        /// <param name="time">Number of <see cref="int">seconds</see> from <see cref="MinValue"><inheritdoc cref="MinValue"  path="//example"/></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue"  path="//example"/></see>.</param>
        private ReponseTimeout(int time) => _time = time;

        #endregion Constructors
    }

    /// <summary>
    /// FINS Source Address
    /// </summary>
    public struct SourceAddress
    {
        #region Fields

        /// <summary>
        ///
        /// </summary>
        public const int Node = 0;

        /// <summary>
        ///
        /// </summary>
        public const int Unit = 0;

        /// <summary>
        ///
        /// </summary>
        public FinsNet Net;

        #endregion Fields

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="sourceNet"></param>
        private SourceAddress(FinsNet sourceNet) => Net = sourceNet;

        #endregion Constructors
    }
}