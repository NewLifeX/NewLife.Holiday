# NewLife.Holiday - Biblioteca de días festivos de China

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

Biblioteca de identificación de días festivos chinos con una base de datos integrada de festivos y jornadas de ajuste, mantenida y actualizada cada año.

> Esta traducción sigue el README en inglés; si hay discrepancias, prevalece la versión inglesa.

## Uso
Referencie `NewLife.Holiday` desde NuGet e importe el espacio de nombres `NewLife.Holiday` para usar el método de extensión de DateTime `IsChinaHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```


## Nombres de festivos localizados

`HolidayInfo.DisplayName` devuelve el nombre del festivo en el idioma de interfaz actual, mientras que `Name` conserva el texto original en chino. La tabla incluye 11 idiomas; los no compatibles vuelven al chino.

``` csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

## Festival del 3 de marzo en Guangxi
Referencie `NewLife.Holiday` desde NuGet e importe el espacio de nombres `NewLife.Holiday` para usar el método de extensión de DateTime `IsGuangxiHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## Documentación del proyecto

- [Documento de requisitos](Doc/需求文档.md)
- [Lista de funcionalidades](Doc/功能清单.md)
- [Diseño de arquitectura](Doc/架构设计.md)

## Matriz de proyectos NewLife
Todos los proyectos admiten net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5 de forma predeterminada; las versiones anteriores (2024.0801) admiten net4.0/net2.0.  

| Proyecto | Año | Descripción |
| :-----: | :--: | :---------- |
| Fundamentos | | Sostienen otros proyectos de middleware y productos |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | Biblioteca principal: registro, configuración, caché, red, serialización, seguimiento de rendimiento APM |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | Middleware de big data, tabla única con decenas de miles de millones de filas, MySql/SQLite/SqlServer/Oracle/PostgreSql/DaMeng, particionamiento automático, separación de lectura/escritura |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | Biblioteca de red, decenas de millones de TPS en una sola máquina (22,66 millones de tps), millones de conexiones en una sola máquina (4 millones de conexiones TCP de larga duración) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | Biblioteca de comunicación por protocolo que proporciona un marco de aplicación C/S, compatible con comunicación Http/RPC, alto rendimiento, bajo coste y fácil acceso para dispositivos IoT |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Plataforma de desarrollo rápido Cube, que integra permisos de usuario, inicio de sesión SSO, servidor OAuth, etc., validada por proyectos con 10 mil millones de filas por tabla |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | Componente de gestión de servicios que instala aplicaciones como demonios del sistema operativo: servicios de Windows y systemd de Linux |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | Andamiaje de nueva generación: plantillas de proyecto NewLife.Templates basadas en el ecosistema de componentes NewLife, Web, WebApi, Service |
| Middleware | | Se integran con plataformas de middleware conocidas |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Cliente Redis, latencia de microsegundos, millones de TPS, colas de mensajes completas, validado por proyectos con decenas de miles de millones de registros |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | Cliente RocketMQ totalmente administrado, compatible con Apache RocketMQ y Alibaba Cloud Message Queue, validado por proyectos de escala de miles de millones |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | Protocolo de mensajería IoT, MqttClient/MqttServer, el cliente es compatible con Alibaba Cloud IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | Biblioteca estándar de IoT, que define diversos estándares de protocolos de comunicación para el ámbito IoT |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII, implementado sobre la biblioteca estándar de IoT, compatible con la plataforma ZeroIoT y la pasarela IoTEdge |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | Protocolo Siemens PLC, implementado sobre la biblioteca estándar de IoT, compatible con la plataforma IoT e IoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | Biblioteca de componentes de mapas que envuelve Baidu Maps, Amap, Tencent Maps y Tianditu |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | Biblioteca de códecs de audio, PCM/ADPCMA/G711A/G722U/WAV/AAC |
| Plataformas de producto | | Nivel de plataforma de producto, listas para compilar y desplegar, personalizables |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust, una plataforma de servicios distribuidos: gestión de nodos, centro de monitorización APM, centro de configuración, registro, centro de publicación |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob, una plataforma distribuida de computación de big data (tiempo real/fuera de línea), con el concepto de particionamiento «ant-moving», validada por proyectos de datos a escala de billones |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | ERP empresarial: gestión de productos, gestión de clientes, gestión de ventas, gestión de proveedores |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | Herramientas CrazyCoder: numerosas herramientas para desarrolladores que cubren red, puertos serie, cifrado/descifrado, expresiones regulares, Modbus, MQTT |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | Almacenamiento de archivos simple, compatible con el almacenamiento centralizado de archivos en sistemas distribuidos. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | Proxy inverso de calidad de producción: proxy NAT, proxy Http |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Herramienta de pruebas de carga Http |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Sistema de gestión de código fuente Git |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | Sistema operativo embebido, totalmente independiente, compatible con la arquitectura de chips ARM Cortex-M |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | Ordenador industrial embebido, pasarela edge IoT, host .NET8 de alto rendimiento, aplicado en industria, agricultura, transporte y sanidad |
| Plataforma IoT FIoT | 2020 | Solución integral de IoT que integra hardware, software y análisis de big data para construcción, protección ambiental y agricultura; validada por proyectos con 100.000 puntos por máquina |
| Posicionamiento indoor de alta precisión UWB | 2020 | Posicionamiento indoor de alta precisión a nivel centimétrico (10–20 cm), hardware y software integrados, interoperable con otros sistemas, validado en grandes salas de exposiciones |

## Equipo de desarrollo NewLife
![XCode](https://newlifex.com/logo.png)  

El equipo NewLife se fundó en 2002 y es un proveedor de soluciones industriales de IoT para la nueva era, dedicado a la consultoría de aplicaciones de hardware y software, la planificación de arquitecturas de sistemas y los servicios de desarrollo.  
Más de 80 proyectos de código abierto liderados por el equipo se utilizan ampliamente en todos los sectores, con más de 4 millones de descargas acumuladas en NuGet.  
El middleware de big data NewLife.XCode, la plataforma distribuida de planificación y computación AntJob, la plataforma distribuida Stardust, el componente de caché y colas NewLife.Redis y la plataforma IoT FIoT del equipo se han aplicado con éxito en energía, educación, Internet, telecomunicaciones, transporte, logística, control industrial, sanidad, museos y otros sectores, ofreciendo a los clientes numerosos productos y servicios de integración de sistemas avanzados, fiables, seguros, de alta calidad y fácilmente ampliables.  
Seguiremos mejorando nuestros servicios para convertirnos en un socio de confianza a largo plazo para nuestros clientes y, mediante la innovación y el desarrollo continuos, en un proveedor nacional de IoT excelente.  

`El equipo NewLife comenzó en 2002. Algunos proyectos de código abierto tienen más de 20 años de historia y el repositorio de código conserva cada modificación desde 2010`  
Sitio web: https://newlifex.com  
Código abierto: https://github.com/newlifex  
Grupos de QQ: 1600800 / 1600838  
Cuenta oficial de WeChat:
![智能大石头](https://www.newlifex.com/stone.jpg)
