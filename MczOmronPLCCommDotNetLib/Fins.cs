using System;

namespace Moravuscz.OmronPLCComm
{
    public class Fins
    {
        #region Public Structs

        /// <summary>
        /// Encapsulates FINS Communication Settings
        /// </summary>
        public struct Config
        {
            #region Public Constructors + Destructors

            public Config(SourceAddress sourceAddress, DestinationAddress destinationAddress, FrameLength frameLength, ResponseTimeout responseTimeout)
            {
                DestinationAddress = destinationAddress;
                SourceAddress = sourceAddress;
                FrameLength = frameLength;
                ResponseTimeout = responseTimeout;
            }

            #endregion Public Constructors + Destructors

            #region Public Properties

            public DestinationAddress DestinationAddress { get; set; }
            public FrameLength FrameLength { get; set; }
            public ResponseTimeout ResponseTimeout { get; set; }
            public SourceAddress SourceAddress { get; set; }

            #endregion Public Properties
        }

        /// <summary>
        /// FINS Destination Address
        /// </summary>
        public struct DestinationAddress
        {
            #region Public Fields

            public const int Unit = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors

            public DestinationAddress(Net destinationNet, Node destinationNode
                )
            {
                Net = destinationNet;
                Node = destinationNode;
            }

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            ///
            /// </summary>
            public Net Net { get; set; }

            /// <summary>
            ///
            /// </summary>
            public Node Node { get; set; }

            #endregion Public Properties
        }

        /// <summary>
        /// Length of a FINS frame
        /// </summary>
        public struct FrameLength
        {
            #region Private Fields

            private readonly int _frameLength;

            #endregion Private Fields

            #region Public Fields

            /// <summary>
            /// Default value (<inheritdoc cref="Default" path="//example"/>)
            /// </summary>
            /// <example>2000</example>
            public const int Default = 2000;

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

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <summary>
            /// Length of a FINS frame
            /// </summary>
            /// <param name="frameLength">Any <see cref="int"/> from <see cref="MinValue"><inheritdoc cref="MinValue"  path="//example"/></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue"  path="//example"/></see>.</param>
            public FrameLength(int frameLength) => _frameLength = frameLength;

            #endregion Public Constructors + Destructors
        }

        /// <summary>
        /// FINS Network
        /// </summary>
        public struct Net
        {
            #region Private Fields

            private readonly int _netNum;

            #endregion Private Fields

            #region Public Fields

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

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <summary>
            /// Network Port
            /// </summary>
            /// <param name="netNumber">Any <see cref="int"/> from <see cref="MinValue"><inheritdoc cref="MinValue"  path="//example"/></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue"  path="//example"/></see>.</param>
            public Net(int netNumber)
            {
                if (netNumber > MaxValue || netNumber < MinValue) { throw new ArgumentOutOfRangeException(); }
                _netNum = netNumber;
            }

            #endregion Public Constructors + Destructors

            #region Public Methods

            public static implicit operator int(Net net) => net._netNum;

            public static implicit operator Net(int netNum) => new Net(netNum);

            #endregion Public Methods
        }

        /// <summary>
        /// FINS Node
        /// </summary>
        public struct Node
        {
            #region Private Fields

            private readonly int _nodeNum;

            #endregion Private Fields

            #region Public Fields

            public const int MaxValue = 255;
            public const int MinValue = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors

            public Node(int nodeNumber)
            {
                if (nodeNumber > MaxValue || nodeNumber < MinValue) { throw new ArgumentOutOfRangeException(); }
                _nodeNum = nodeNumber;
            }

            #endregion Public Constructors + Destructors

            #region Public Methods

            public static implicit operator int(Node node) => node._nodeNum;

            public static implicit operator Node(int nodeNum) => new Node(nodeNum);

            #endregion Public Methods
        }

        /// <summary>
        /// Time to fail communicatoini
        /// </summary>
        public struct ResponseTimeout
        {
            #region Private Fields

            private readonly int _time;

            #endregion Private Fields

            #region Public Fields

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

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <summary>
            /// Time to fail communication
            /// </summary>
            /// <remarks>Values in seconds</remarks>
            /// <param name="time">Number of <see cref="int">seconds</see> from <see cref="MinValue"><inheritdoc cref="MinValue"  path="//example"/></see> to <see cref="MaxValue"><inheritdoc cref="MaxValue"  path="//example"/></see>.</param>
            public ResponseTimeout(int time) => _time = time;

            #endregion Public Constructors + Destructors
        }

        /// <summary>
        /// FINS Source Address
        /// </summary>
        public struct SourceAddress
        {
            #region Public Fields

            /// <summary>
            ///
            /// </summary>
            public const int Node = 0;

            /// <summary>
            ///
            /// </summary>
            public const int Unit = 0;

            #endregion Public Fields

            #region Public Constructors + Destructors

            /// <summary>
            ///
            /// </summary>
            /// <param name="sourceNet"></param>
            public SourceAddress(Net sourceNet) => Net = sourceNet;

            #endregion Public Constructors + Destructors

            #region Public Properties

            /// <summary>
            ///
            /// </summary>
            public Net Net { get; set; }

            #endregion Public Properties
        }

        #endregion Public Structs
    }
}