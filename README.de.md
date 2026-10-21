# NewLife.Holiday - Bibliothek für chinesische Feiertage

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

Bibliothek zur Erkennung chinesischer Feiertage mit integrierter Datenbank für Feiertage und Ausgleichsarbeitstage, die jährlich gepflegt und aktualisiert wird.

> Diese Übersetzung folgt der englischen README; bei Abweichungen ist die englische Fassung maßgeblich.

## Verwendung
Referenzieren Sie `NewLife.Holiday` aus NuGet und importieren Sie den Namespace `NewLife.Holiday`, um die DateTime-Erweiterungsmethode `IsChinaHoliday` zu verwenden.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```

## Feiertag des 3. März in Guangxi
Referenzieren Sie `NewLife.Holiday` aus NuGet und importieren Sie den Namespace `NewLife.Holiday`, um die DateTime-Erweiterungsmethode `IsGuangxiHoliday` zu verwenden.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## Projektdokumentation

- [Anforderungsdokument](Doc/需求文档.md)
- [Funktionsliste](Doc/功能清单.md)
- [Architekturentwurf](Doc/架构设计.md)

## NewLife-Projektmatrix
Alle Projekte unterstützen standardmäßig net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5; ältere Versionen (2024.0801) unterstützen net4.0/net2.0.  

| Projekt | Jahr | Beschreibung |
| :-----: | :--: | :---------- |
| Grundlagen | | Unterstützen andere Middleware- und Produktprojekte |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | Kernbibliothek: Protokollierung, Konfiguration, Zwischenspeicherung, Netzwerk, Serialisierung, APM-Leistungsverfolgung |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | Big-Data-Middleware, einzelne Tabelle mit Dutzenden Milliarden Zeilen, MySql/SQLite/SqlServer/Oracle/PostgreSql/DaMeng, automatisches Sharding, Lese-/Schreibaufteilung |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | Netzwerkbibliothek, Dutzende Millionen TPS auf einem Rechner (22,66 Millionen tps), Millionen Verbindungen auf einem Rechner (4 Millionen TCP-Langzeitverbindungen) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | Protokollkommunikationsbibliothek mit C/S-Anwendungsframework, unterstützt Http/RPC-Kommunikation, hohen Durchsatz, geringen Overhead und einfachen Zugang für IoT-Geräte |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Cube-Schnellentwicklungsplattform mit Benutzerberechtigungen, SSO-Anmeldung, OAuth-Server usw., validiert durch Projekte mit 10 Milliarden Zeilen pro Tabelle |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | Dienstverwaltungskomponente, die Anwendungen als Betriebssystemdienste installiert: Windows-Dienste und Linux systemd |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | Zero-Generation-Gerüst: NewLife.Templates-Projektvorlagen auf Basis des NewLife-Komponentenökosystems, Web, WebApi, Service |
| Middleware | | Integration mit bekannten Middleware-Plattformen |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Redis-Client, Mikrosekunden-Latenz, Millionen TPS, umfangreiche Nachrichtenwarteschlangen, validiert durch Projekte mit Dutzenden Milliarden Datensätzen |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | Rein verwalteter RocketMQ-Client, unterstützt Apache RocketMQ und Alibaba Cloud Message Queue, validiert durch Projekte im Milliardenmaßstab |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | IoT-Nachrichtenprotokoll, MqttClient/MqttServer, Client unterstützt Alibaba Cloud IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | IoT-Standardbibliothek, definiert verschiedene Kommunikationsprotokollstandards für den IoT-Bereich |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII, implementiert auf der IoT-Standardbibliothek, unterstützt die ZeroIoT-Plattform und das IoTEdge-Gateway |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | Siemens-PLC-Protokoll, implementiert auf der IoT-Standardbibliothek, unterstützt die IoT-Plattform und IoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | Kartenkomponentenbibliothek als Wrapper für Baidu Maps, Amap, Tencent Maps und Tianditu |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | Audio-Codec-Bibliothek, PCM/ADPCMA/G711A/G722U/WAV/AAC |
| Produktplattformen | | Produktplattform-Ebene, direkt kompilier- und bereitstellbar, anpassbar |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust, eine verteilte Dienstplattform: Knotenverwaltung, APM-Überwachungszentrum, Konfigurationszentrum, Registrierungszentrum, Release-Zentrum |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob, eine verteilte Big-Data-Computing-Plattform (Echtzeit/Offline) mit dem Ant-Moving-Sharding-Konzept, validiert durch Datenprojekte im Billionenmaßstab |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | Unternehmens-ERP: Produktverwaltung, Kundenverwaltung, Vertriebsverwaltung, Lieferantenverwaltung |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | Code-Gott-Werkzeuge: zahlreiche Entwicklerwerkzeuge für Netzwerk, serielle Schnittstellen, Ver- und Entschlüsselung, reguläre Ausdrücke, Modbus, MQTT |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | Einfache Dateispeicherung, unterstützt zentrale Dateispeicherung in verteilten Systemen. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | Produktreifer Reverse-Proxy: NAT-Proxy, Http-Proxy |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Http-Lasttestwerkzeug |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Git-Quellcodeverwaltungssystem |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | Eingebettetes Betriebssystem, vollständig eigenständig, unterstützt ARM-Cortex-M-Chiparchitektur |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | Eingebetteter Industriecomputer, IoT-Edge-Gateway, leistungsstarker .NET8-Host, eingesetzt in Industrie, Landwirtschaft, Verkehr und Gesundheitswesen |
| FIoT IoT-Plattform | 2020 | Gesamt-IoT-Lösung, die Hard- und Software sowie Big-Data-Analyse für Bauwesen, Umweltschutz und Landwirtschaft integriert; validiert durch Projekte mit 100.000 Punkten pro Rechner |
| UWB-Hochpräzisions-Innenraumpositionierung | 2020 | Zentimetergenaue (10–20 cm) Hochpräzisions-Innenraumpositionierung, Hard- und Software integriert, interoperabel mit anderen Systemen, validiert in großen Ausstellungshallen |

## NewLife-Entwicklungsteam
![XCode](https://newlifex.com/logo.png)  

Das NewLife-Team wurde 2002 gegründet und ist ein IoT-Industrielösungsanbieter für die neue Ära, der sich auf Beratung für Hard- und Softwareanwendungen, Systemarchitekturplanung und Entwicklungsdienstleistungen spezialisiert hat.  
Mehr als 80 vom Team geführte Open-Source-Projekte werden branchenübergreifend eingesetzt, mit kumulierten NuGet-Downloads von über 4 Millionen.  
Die Big-Data-Middleware NewLife.XCode, die verteilte Planungs- und Rechenplattform AntJob, die verteilte Plattform Stardust, die Cache- und Warteschlangenkomponente NewLife.Redis sowie die IoT-Plattform FIoT des Teams wurden erfolgreich in den Bereichen Energie, Bildung, Internet, Telekommunikation, Verkehr, Logistik, Industrieautomatisierung, Gesundheitswesen und Museen eingesetzt und bieten Kunden zahlreiche fortschrittliche, zuverlässige, sichere, hochwertige und leicht erweiterbare Produkte und Systemintegrationsdienste.  
Wir verbessern unsere Dienstleistungen kontinuierlich, um ein langfristig vertrauenswürdiger Partner für unsere Kunden zu werden, und streben durch kontinuierliche Innovation und Entwicklung danach, ein herausragender inländischer IoT-Dienstleister zu sein.  

`Das NewLife-Team startete 2002. Einige Open-Source-Projekte haben eine über 20-jährige Geschichte, und das Quellcode-Repository bewahrt jede Änderung seit 2010 auf`  
Website: https://newlifex.com  
Open Source: https://github.com/newlifex  
QQ-Gruppen: 1600800 / 1600838  
WeChat-Offizieller Account:
![智能大石头](https://www.newlifex.com/stone.jpg)
