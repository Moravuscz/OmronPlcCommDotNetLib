using System.ComponentModel;

namespace Moravuscz.OmronPlcCommunications
{
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