using System.ComponentModel;

namespace Moravuscz.OmronPlcCommunication
{
    /// <summary>
    /// Communication type
    /// </summary>
    /// <remarks>
    /// <list type="number">
    /// <item><see cref="FinsTCP">FINS/TCP</see></item>
    /// <item><see cref="FinsUDP">FINS/UDP</see></item>
    /// <item><see cref="EthernetIP">Ethernet/IP</see></item>
    /// <item><see cref="HostLink">Serial Host Link</see></item>
    /// </list>
    /// </remarks>
    public enum CommType
    {
        /// <summary><inheritdoc cref="Ethernet.FinsTcp" path="/summary"/></summary>
        [Description("FINS/TCP")]
        FinsTCP,

        /// <summary><inheritdoc cref="Ethernet.FinsUdp" path="/summary"/></summary>
        [Description("FINS/UDP")]
        FinsUDP,

        /// <summary><inheritdoc cref="Ethernet.EthernetIP" path="/summary"/></summary>
        [Description("Ethernet/IP")]
        EthernetIP,

        /// <summary><inheritdoc cref="Serial.HostLink" path="/summary"/></summary>
        [Description("Host Link")]
        HostLink
    }

    
}