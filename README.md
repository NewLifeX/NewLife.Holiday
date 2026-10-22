# NewLife.Holiday - Chinese holiday library

![GitHub top language](https://img.shields.io/github/languages/top/newlifex/newlife.holiday?logo=github)


![GitHub License](https://img.shields.io/github/license/NewLifeX/NewLife.Holiday?logo=github)
![NuGet Downloads](https://img.shields.io/nuget/dt/NewLife.Holiday?logo=nuget)
![NuGet](https://img.shields.io/nuget/v/NewLife.Holiday?logo=nuget)
![NuGet prerelease](https://img.shields.io/nuget/vpre/NewLife.Holiday?label=dev%20nuget&logo=nuget)
[![test](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml/badge.svg?branch=master)](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml)
[![locales](https://img.shields.io/badge/locales-11-2ea44f?logo=dotnet)](Doc/多语言本地化.md)
![platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS%20%7C%20Android%20%7C%20iOS-blue)
![arch](https://img.shields.io/badge/arch-x64%20%7C%20arm64%20%7C%20loongarch64-orange)
[![contributors](https://img.shields.io/github/contributors/NewLifeX/NewLife.Holiday?logo=github)](https://github.com/NewLifeX/NewLife.Holiday/graphs/contributors)

<!-- lang:start -->
🌐 [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

Chinese holiday identification library with a built-in holiday and adjusted-workday database, maintained and updated every year.   

## Usage
Reference `NewLife.Holiday` from NuGet and import the `NewLife.Holiday` namespace to use the `IsChinaHoliday` DateTime extension method.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```


## Localized holiday names

`HolidayInfo.DisplayName` returns the holiday name in the current UI language, while `Name` keeps the original Chinese source. The word list ships 11 languages; unsupported languages fall back to Chinese.

``` csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

## Guangxi March 3rd Festival
Reference `NewLife.Holiday` from NuGet and import the `NewLife.Holiday` namespace to use the `IsGuangxiHoliday` DateTime extension method.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## Project documentation

- [Requirements document](Doc/需求文档.md)
- [Feature list](Doc/功能清单.md)
- [Architecture design](Doc/架构设计.md)

## NewLife Project Matrix
All projects support net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5 by default; older releases (2024.0801) support net4.0/net2.0.  

| Project | Year | Description |
| :-----: | :--: | :---------- |
| Foundations | | Supports other middleware and product projects |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | Core library: logging, configuration, caching, networking, serialization, APM performance tracing |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | Big-data middleware, single table with tens of billions of rows, MySql/SQLite/SqlServer/Oracle/PostgreSql/DaMeng, automatic sharding, read/write splitting |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | Network library, tens of millions of TPS on a single machine (22.66 million tps), millions of connections on a single machine (4 million TCP long connections) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | Protocol communication library, providing a C/S application communication framework, supporting Http/RPC communication, high throughput, low overhead and easy access for IoT devices |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Cube rapid development platform, integrating user permissions, SSO login, OAuth server, etc., validated by projects with 10 billion rows per table |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | Service management component that installs applications as operating-system daemons: Windows services and Linux systemd |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | Zero-generation scaffold: NewLife.Templates project templates based on the NewLife component ecosystem, Web, WebApi, Service |
| Middleware | | Integrates with well-known middleware platforms |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Redis client, microsecond latency, millions of TPS, rich message queues, validated by projects with tens of billions of data records |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | Pure managed RocketMQ client, supporting Apache RocketMQ and Alibaba Cloud Message Queue, validated by billion-scale projects |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | IoT messaging protocol, MqttClient/MqttServer, client supports Alibaba Cloud IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | IoT standard library, defining various communication protocol standards for the IoT domain |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII, implemented on the IoT standard library, supporting the ZeroIoT platform and IoTEdge gateway |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | Siemens PLC protocol, implemented on the IoT standard library, supporting the IoT platform and IoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | Map component library wrapping Baidu Maps, Amap, Tencent Maps, and Tianditu |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | Audio codec library, PCM/ADPCMA/G711A/G722U/WAV/AAC |
| Product Platforms | | Product-platform level, ready to compile and deploy, customizable |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust, a distributed service platform: node management, APM monitoring center, configuration center, registry center, release center |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob, a distributed big-data computing platform (real-time/offline), with the ant-moving sharding concept, validated by trillion-level data projects |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | Enterprise ERP: product management, customer management, sales management, supplier management |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | Code-god tools: numerous developer tools covering networking, serial ports, encryption/decryption, regular expressions, Modbus, MQTT |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | Simple file storage, supporting centralized file storage in distributed systems. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | Product-grade reverse proxy: NAT proxy, Http proxy |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Http stress testing tool |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Git source code management system |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | Embedded operating system, fully independent, supporting ARM Cortex-M chip architecture |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | Embedded industrial computer, IoT edge gateway, high-performance .NET8 host, applied in industry, agriculture, transportation, and healthcare |
| FIoT IoT Platform | 2020 | Overall IoT solution integrating hardware, software, and big-data analysis for construction, environmental protection, and agriculture; validated by projects with 100,000-level points per machine |
| UWB High-Precision Indoor Positioning | 2020 | Centimeter-level (10–20 cm) high-precision indoor positioning, integrated hardware and software, interoperating with other systems, validated in large exhibition halls |

## NewLife Development Team
![XCode](https://newlifex.com/logo.png)  

The NewLife team was founded in 2002 and is an IoT industry solution provider for the new era, dedicated to software and hardware application consulting, system architecture planning, and development services.  
More than 80 open-source projects led by the team have been widely used across industries, with cumulative NuGet downloads exceeding 4 million.  
The team's big-data middleware NewLife.XCode, the AntJob distributed scheduling and computing platform, the Stardust distributed platform, the cache and queue component NewLife.Redis, and the IoT platform FIoT have all been successfully applied in power, education, Internet, telecommunications, transportation, logistics, industrial control, healthcare, museums, and other industries, providing customers with a large number of advanced, reliable, secure, high-quality, and easily extensible products and system integration services.  

We will keep improving our services to become a long-term trusted partner for our customers, and through continuous innovation and development, become an outstanding domestic IoT service provider.  

`The NewLife team started in 2002. Some open-source projects have a history of more than 20 years, and the source repository retains every modification record since 2010`  
Website: https://newlifex.com  
Open source: https://github.com/newlifex  
QQ groups: 1600800 / 1600838  
WeChat official account:  
![智能大石头](https://www.newlifex.com/stone.jpg)  