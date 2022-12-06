using System;
using CommunicationsExample.Commands;
using Moravuscz.OmronPLCComm;

namespace CommunicationsExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Fields

        private string _bitAddress = "0.00";
        private string _finsPort = new Port(9600).ToString();
        private string _ipAddress = "192.168.250.1";
        private string _wordAddress = "100";
        private string _writeData = "0000";

        #endregion Private Fields

        #region Public Constructors + Destructors

        public MainWindowViewModel()
        {
            SaveSetupCommand = new DelegateCommand(SaveSetup);
            FinsTCPReadCommand = new DelegateCommand(FinsTcpRead);
            FinsUdpReadCommand = new DelegateCommand(FinsUdpRead);
            FinsTcpWriteCommand = new DelegateCommand(FinsTcpWrite);
            FinsUdpWriteCommand = new DelegateCommand(FinsUdpWrite);
            EthernetIPReadCommand = new DelegateCommand(EthernetIPRead);
            EthernetIPWriteCommand = new DelegateCommand(EthernetIPWrite);
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

        public CommandBase FinsTCPReadCommand { get; }

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

        private void EthernetIPRead(object commandParameter) => throw new NotImplementedException();

        private void EthernetIPWrite(object commandParameter) => throw new NotImplementedException();

        private void FinsTcpRead(object commandParameter) => throw new NotImplementedException();

        private void FinsTcpWrite(object commandParameter) => throw new NotImplementedException();

        private void FinsUdpRead(object commandParameter) => throw new NotImplementedException();

        private void FinsUdpWrite(object commandParameter) => throw new NotImplementedException();

        private void SaveSetup(object commandParameter)
        {
            /*
             * Fins.Config config = new Fins.Config()
            {
                DestinationAddress = new Fins.DestinationAddress();
            }
            */
        }

        #endregion Private Methods
    }
}