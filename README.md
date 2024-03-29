# Omron PLC Communication Library for .NET
![IDE = Visual Studio 2019](https://img.shields.io/badge/IDE-Visual%20Studio%202019-blue)
![Language = C#](https://img.shields.io/badge/Language-C%23-blue)
![dotNet Standard 2.0](https://img.shields.io/badge/.NET-Standard%202.0-blue)

###### A library providing an easy way to communicate with OMRON PLCs

Supports communication over:
- [ ] ![Medium-Ethernet](https://img.shields.io/badge/medium-Ethernet-brightgreen)
  - [ ] ![Protocol-FINS](https://img.shields.io/badge/protocol-FINS-brightgreen)
    - [ ] ![Protocol-FINS_TCP](https://img.shields.io/badge/protocol-FINS%2FTCP-brightgreen)
    - [ ] ![Protocol-FINS_UDP](https://img.shields.io/badge/protocol-FINS%2FUDP-brightgreen)  
  - [ ] ![Protocol-EIP](https://img.shields.io/badge/protocol-Ethernet%2FIP-brightgreen)
- [ ] ![Medium-Ethernet](https://img.shields.io/badge/medium-Serial_(RS232%2F422%2F485)-brightgreen)
  - [ ] ![Protocol-HostLink](https://img.shields.io/badge/protocol-Host%20Link-brightgreen)

## Installation


###### Binary release  

1. Download the latest release from GitHub   
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/Moravuscz/OmronPLCCommDotNetLib?logo=github)](https://github.com/Moravuscz/OmronPLCCommDotNetLib/releases/latest)  

2. Add a reference to *MczOmronPLCCommDotNetLib\bin\bin\release\MczOmronPLCCommDotNetLib.dll* in your project.

3. Add a XML Namespace reference to your XAML:  
```xml
<Window
xmlns:OmrPLCComm="https://github.com/Moravuscz/OmronPLCCommDotNetLib"
>
</Window>
```

---
###### NuGet

Install the package from NuGet  
[![Nuget](https://img.shields.io/nuget/v/Moravuscz.OmronPLCCommunications?logo=nuget)](https://www.nuget.org/packages/Moravuscz.OmronPLCCommunications)

---

###### Build

1. Clone the repository, 
2. Open *MczOmronPLCCommDotNetLib.sln* in Visual Studio 2019
3. Build the solution in *Release* mode  
4. Add a reference to *MczOmronPLCCommDotNetLib\bin\bin\release\MczOmronPLCCommDotNetLib.dll* in your project.
5. Add a XML Namespace reference to your XAML:  
```xml
<Window
xmlns:OmrPLCComm="https://github.com/Moravuscz/OmronPLCCommDotNetLib"
>
</Window>
```


## Usage

See [Wiki](https://github.com/Moravuscz/OmronPLCCommDotNetLib/wiki)

## License

![GitHub](https://img.shields.io/github/license/Moravuscz/OmronPLCCommDotNetLib)