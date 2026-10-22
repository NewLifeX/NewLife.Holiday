# NewLife.Holiday - 中國節假日識別庫

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

中國節假日識別庫，內建假期調休資料庫，每年維護更新。

> 本繁體中文版與 [English README](README.md) 同批維護；若兩者內容不一致，以英文版為對外口徑。

## 使用方法
專案從 NuGet 引用 `NewLife.Holiday`，程式碼中引入命名空間 `NewLife.Holiday`，即可使用 DateTime 擴充方法 IsChinaHoliday。  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```


## 假期名稱本地化

`HolidayInfo.DisplayName` 依目前介面語言傳回假期名稱，`Name` 保留中文原文。詞表內建 11 種語言，未提供譯文時回退中文。

``` csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

## 廣西三月三
專案從 NuGet 引用 `NewLife.Holiday`，程式碼中引入命名空間 `NewLife.Holiday`，即可使用 DateTime 擴充方法 IsGuangxiHoliday。  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## 專案文件

- [需求文件](Doc/需求文档.md)
- [功能清單](Doc/功能清单.md)
- [架構設計](Doc/架构设计.md)

## 新生命專案矩陣
各專案預設支援 net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5，舊版（2024.0801）支援 net4.0/net2.0  

| 專案 | 年份 | 說明 |
| :-----: | :--: | :---------- |
| 基礎組件 | | 支撐其它中介軟體以及產品專案 |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | 核心庫，日誌、組態、快取、網路、序列化、APM 效能追蹤 |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | 大數據中介軟體，單表百億級，MySql/SQLite/SqlServer/Oracle/PostgreSql/達夢，自動分表，讀寫分離 |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | 網路庫，單機千萬級輸送量（2266 萬 tps），單機百萬級連線（400 萬 Tcp 長連線） |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | 協定通訊庫，提供 CS 應用通訊框架，支援 Http/RPC 通訊框架，高輸送量，物聯網裝置低開銷易接入 |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Cube 快速開發平台，整合了使用者權限、SSO 登入、OAuth 伺服器等，單表 100 億級專案驗證 |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | 服務管理組件，將應用程式安裝為作業系統常駐服務：Windows 服務與 Linux systemd |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | 零代腳手架：基於 NewLife 組件生態的 NewLife.Templates 專案範本，Web、WebApi、Service |
| 中介軟體 | | 與知名中介軟體平台整合 |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Redis 用戶端，微秒級延遲，百萬級 TPS，豐富的訊息佇列，百億級資料專案驗證 |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | 純託管 RocketMQ 用戶端，支援 Apache RocketMQ 與阿里雲訊息佇列，十億級專案驗證 |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | 物聯網訊息協定，MqttClient/MqttServer，用戶端支援阿里雲 IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | 物聯網標準庫，定義物聯網領域的各種通訊協定標準 |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII，基於物聯網標準庫實現，支撐 ZeroIoT 平台與 IoTEdge 閘道 |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | 西門子 PLC 協定，基於物聯網標準庫實現，支撐物聯網平台與 IoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | 地圖組件庫，封裝百度地圖、高德地圖、騰訊地圖、天地圖 |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | 音訊編解碼庫，PCM/ADPCMA/G711A/G722U/WAV/AAC |
| 產品平台 | | 產品平台級，可直接編譯部署，可客製化 |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | 星塵分散式服務平台：節點管理、APM 監控中心、組態中心、註冊中心、發布中心 |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | 螞蟻調度分散式大數據計算平台（即時/離線），螞蟻搬家式分片理念，兆級資料專案驗證 |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | 企業 ERP：產品管理、客戶管理、銷售管理、供應商管理 |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | 碼神工具：網路、序列埠、加解密、正則表達式、Modbus、MQTT 等眾多開發者工具 |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | 簡單檔案儲存，支援分散式系統中的集中式檔案儲存。 |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | 產品級反向代理：NAT 代理、Http 代理 |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Http 壓力測試工具 |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Git 原始碼管理系統 |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | 嵌入式作業系統，完全獨立自主，支援 ARM Cortex-M 晶片架構 |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | 嵌入式工業電腦，物聯網邊緣閘道，高效能 .NET8 主機，應用於工業、農業、交通、醫療 |
| FIoT 物聯網平台 | 2020 | 物聯網整體解決方案，建築、環保、農業，軟硬體及大數據分析一體化，單機十萬級點位專案驗證 |
| UWB 高精度室內定位 | 2020 | 公分級（10~20cm）高精度室內定位，軟硬體一體化，與其它系統聯動，大型展廳專案驗證 |

## 新生命開發團隊
![XCode](https://newlifex.com/logo.png)  

新生命團隊（NewLife）成立於 2002 年，是新時代物聯網行業解決方案提供者，致力於提供軟硬體應用方案諮詢、系統架構規劃與開發服務。  
團隊主導的 80 多個開源專案已被廣泛應用於各行業，NuGet 累計下載量高達 400 餘萬次。  
團隊開發的大數據中介軟體 NewLife.XCode、螞蟻調度計算平台 AntJob、星塵分散式平台 Stardust、快取佇列組件 NewLife.Redis 以及物聯網平台 FIoT，均成功應用於電力、高校、網際網路、電信、交通、物流、工控、醫療、文博等行業，為客戶提供了大量先進、可靠、安全、高品質、易擴充的產品和系統整合服務。  
我們將不斷透過服務的持續改進，成為客戶長期信賴的合作夥伴，透過不斷的創新和發展，成為國內優秀的 IoT 服務供應商。  

`新生命團隊始於 2002 年，部分開源專案具有 20 年以上漫長歷史，原始碼庫保留有 2010 年以來所有修改記錄`  
網站：https://newlifex.com  
開源: https://github.com/newlifex  
QQ 群: 1600800 / 1600838  
微信公眾號:
![智能大石头](https://www.newlifex.com/stone.jpg)
