using System;
using CommunicationsExample.Commands;
using Moravuscz.OmronPlcCommunications;
using Moravuscz.OmronPlcCommunications.Ethernet;

namespace CommunicationsExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Fields

        private string _bitAddress = "0.00";
        private string _finsPort = new Port(9600).ToString();
        private FinsTcp _finsTcp;
        private bool _finsTcpConnected;
        private string _ipAddress = "192.168.250.1";
        private string _resultText = "";
        private string _wordAddress = "100";
        private string _writeData = "0000";

        #endregion Private Fields

        #region Public Constructors + Destructors

        public MainWindowViewModel()
        {
            SaveSetupCommand = new DelegateCommand(SaveSetup);
            FinsTcpReadCommand = new DelegateCommand(FinsTcpRead);
            FinsUdpReadCommand = new DelegateCommand(FinsUdpRead);
            FinsTcpWriteCommand = new DelegateCommand(FinsTcpWrite);
            FinsUdpWriteCommand = new DelegateCommand(FinsUdpWrite);
            EthernetIPReadCommand = new DelegateCommand(EthernetIpRead);
            EthernetIPWriteCommand = new DelegateCommand(EthernetIpWrite);
            FinsTcpConnectCommand = new DelegateCommand(FinsTcpConnect);
            FinsTcpDisconnectCommand = new DelegateCommand(FinsTcpDisconnect);
        }

        #endregion Public Constructors + Destructors

        #region Public Properties

        public string BitAddress
        {
            get => _bitAddress;
            set
            {
                _bitAddress = value;
                RaisePropertyChanged();
            }
        }

        public CommandBase EthernetIPReadCommand { get; }
        public CommandBase EthernetIPWriteCommand { get; }

        public string FinsPort
        {
            get => _finsPort;
            set
            {
                _finsPort = value;
                RaisePropertyChanged();
            }
        }

        public CommandBase FinsTcpConnectCommand { get; }

        public bool FinsTcpConnected
        {
            get => _finsTcpConnected;
            private set
            {
                _finsTcpConnected = value;
                RaisePropertyChanged();
            }
        }

        public CommandBase FinsTcpDisconnectCommand { get; }
        public CommandBase FinsTcpReadCommand { get; }
        public CommandBase FinsTcpWriteCommand { get; }

        public CommandBase FinsUdpReadCommand { get; }

        public CommandBase FinsUdpWriteCommand { get; }

        public string IPAddress
        {
            get => _ipAddress;
            set
            {
                _ipAddress = value;
                RaisePropertyChanged();
            }
        }

        public string ResultText
        {
            get => _resultText;
            set
            {
                _resultText = value;
                RaisePropertyChanged();
            }
        }

        public CommandBase SaveSetupCommand { get; }

        public string WordAddress
        {
            get => _wordAddress;
            set
            {
                _wordAddress = value;
                RaisePropertyChanged();
            }
        }

        public string WriteData
        {
            get => _writeData;
            set
            {
                _writeData = value;
                RaisePropertyChanged();
            }
        }

        #endregion Public Properties

        #region Private Methods

        private void EthernetIpRead(object commandParameter) => throw new NotImplementedException();

        private void EthernetIpWrite(object commandParameter) => throw new NotImplementedException();

        private void FinsTcpConnect(object commandParameter)
        {
            FinsTcpConnected = _finsTcp.OpenConnection();
        }

        private void FinsTcpDisconnect(object commandParameter)
        {
            FinsTcpConnected = _finsTcp.CloseConnection();
        }

        private void FinsTcpRead(object commandParameter)
        {
            if (FinsTcpConnected)
            {
                ResultText += _finsTcp.ReadWord(WriteData) + Environment.NewLine;
            }
        }

        private void FinsTcpWrite(object commandParameter) => throw new NotImplementedException();

        private void FinsUdpRead(object commandParameter) => throw new NotImplementedException();

        private void FinsUdpWrite(object commandParameter) => throw new NotImplementedException();

        private void SaveSetup(object commandParameter)
        {
            _finsTcp = new FinsTcp
            (
                config: new Fins.Config
                (
                    sourceAddress: new Fins.SourceAddress
                    (
                        sourceNet: new Fins.Net(2)
                    ),
                    destinationAddress: new Fins.DestinationAddress
                    (
                        destinationNet: new Fins.Net(95),
                        destinationNode: new Fins.Node(80)
                    ),
                    frameLength: new Fins.FrameLength
                    (
                        length: Fins.FrameLength.Default
                    ),
                    responseTimeout: new Fins.ResponseTimeout(2)
                ),
                iPAddress: System.Net.IPAddress.Parse(IPAddress),
                port: new Port(int.Parse(FinsPort))
            );
        }

        #endregion Private Methods
    }
}