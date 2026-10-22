# NewLife.Holiday - Bibliothèque des jours fériés chinois

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

Bibliothèque d'identification des jours fériés chinois avec une base de données intégrée des jours fériés et des journées de rattrapage, maintenue et mise à jour chaque année.

> Cette traduction suit la README anglaise ; en cas de divergence, la version anglaise fait foi.

## Utilisation
Référencez `NewLife.Holiday` depuis NuGet et importez l'espace de noms `NewLife.Holiday` pour utiliser la méthode d'extension DateTime `IsChinaHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```


## Noms de jours fériés localisés

`HolidayInfo.DisplayName` renvoie le nom du jour férié dans la langue d'interface courante, tandis que `Name` conserve le texte chinois d'origine. La table couvre 11 langues ; les langues non prises en charge retombent sur le chinois.

``` csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

## Fête du 3 mars au Guangxi
Référencez `NewLife.Holiday` depuis NuGet et importez l'espace de noms `NewLife.Holiday` pour utiliser la méthode d'extension DateTime `IsGuangxiHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## Documentation du projet

- [Document d'exigences](Doc/需求文档.md)
- [Liste des fonctionnalités](Doc/功能清单.md)
- [Conception de l'architecture](Doc/架构设计.md)

## Matrice des projets NewLife
Tous les projets prennent en charge net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5 par défaut ; les anciennes versions (2024.0801) prennent en charge net4.0/net2.0.  

| Projet | Année | Description |
| :-----: | :--: | :---------- |
| Fondations | | Prennent en charge les autres projets d'intergiciels et de produits |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | Bibliothèque de base : journalisation, configuration, mise en cache, réseau, sérialisation, traçage des performances APM |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | Intergiciel big data, table unique de dizaines de milliards de lignes, MySql/SQLite/SqlServer/Oracle/PostgreSql/DaMeng, partitionnement automatique, séparation lecture/écriture |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | Bibliothèque réseau, des dizaines de millions de TPS sur une seule machine (22,66 millions tps), des millions de connexions sur une seule machine (4 millions de connexions TCP longue durée) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | Bibliothèque de communication par protocole fournissant un framework d'application C/S, prenant en charge la communication Http/RPC, à haut débit, faible surcoût et accès facile pour les appareils IoT |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Plateforme de développement rapide Cube, intégrant les permissions utilisateur, la connexion SSO, le serveur OAuth, etc., validée par des projets de 10 milliards de lignes par table |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | Composant de gestion de services qui installe les applications en tant que démons du système d'exploitation : services Windows et systemd Linux |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | Échafaudage de nouvelle génération : modèles de projet NewLife.Templates basés sur l'écosystème de composants NewLife, Web, WebApi, Service |
| Intergiciels | | S'intègrent aux plateformes d'intergiciels connues |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Client Redis, latence de l'ordre de la microseconde, millions de TPS, files de messages riches, validé par des projets de dizaines de milliards d'enregistrements |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | Client RocketMQ entièrement managé, prenant en charge Apache RocketMQ et Alibaba Cloud Message Queue, validé par des projets à l'échelle du milliard |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | Protocole de messagerie IoT, MqttClient/MqttServer, le client prend en charge Alibaba Cloud IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | Bibliothèque standard IoT, définissant diverses normes de protocoles de communication pour le domaine IoT |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII, implémenté sur la bibliothèque standard IoT, prenant en charge la plateforme ZeroIoT et la passerelle IoTEdge |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | Protocole Siemens PLC, implémenté sur la bibliothèque standard IoT, prenant en charge la plateforme IoT et IoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | Bibliothèque de composants cartographiques encapsulant Baidu Maps, Amap, Tencent Maps et Tianditu |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | Bibliothèque de codecs audio, PCM/ADPCMA/G711A/G722U/WAV/AAC |
| Plateformes produits | | Niveau plateforme produit, prêtes à compiler et à déployer, personnalisables |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust, une plateforme de services distribués : gestion des nœuds, centre de surveillance APM, centre de configuration, registre, centre de publication |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob, une plateforme de calcul big data distribuée (temps réel/hors ligne), avec le concept de partitionnement « ant-moving », validée par des projets de données à l'échelle du billion |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | ERP d'entreprise : gestion des produits, gestion des clients, gestion des ventes, gestion des fournisseurs |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | Outils CrazyCoder : nombreux outils de développeur couvrant le réseau, les ports série, le chiffrement/déchiffrement, les expressions régulières, Modbus, MQTT |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | Stockage de fichiers simple, prenant en charge le stockage centralisé de fichiers dans les systèmes distribués. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | Proxy inverse de qualité production : proxy NAT, proxy Http |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Outil de test de charge Http |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Système de gestion de code source Git |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | Système d'exploitation embarqué, entièrement indépendant, prenant en charge l'architecture de puces ARM Cortex-M |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | Ordinateur industriel embarqué, passerelle edge IoT, hôte .NET8 hautes performances, appliqué dans l'industrie, l'agriculture, les transports et la santé |
| Plateforme IoT FIoT | 2020 | Solution IoT globale intégrant matériel, logiciel et analyse big data pour la construction, la protection de l'environnement et l'agriculture ; validée par des projets à 100 000 points par machine |
| Localisation intérieure haute précision UWB | 2020 | Localisation intérieure haute précision au niveau centimétrique (10–20 cm), matériel et logiciel intégrés, interopérable avec d'autres systèmes, validée dans de grands halls d'exposition |

## Équipe de développement NewLife
![XCode](https://newlifex.com/logo.png)  

L'équipe NewLife a été fondée en 2002 et est un fournisseur de solutions industrielles IoT pour la nouvelle ère, spécialisé dans le conseil en applications matérielles et logicielles, la planification d'architecture système et les services de développement.  
Plus de 80 projets open source dirigés par l'équipe sont largement utilisés dans tous les secteurs, avec plus de 4 millions de téléchargements NuGet cumulés.  
L'intergiciel big data NewLife.XCode, la plateforme de planification et de calcul distribuée AntJob, la plateforme distribuée Stardust, le composant de cache et de file d'attente NewLife.Redis ainsi que la plateforme IoT FIoT de l'équipe ont été appliqués avec succès dans l'énergie, l'éducation, l'Internet, les télécommunications, les transports, la logistique, le contrôle industriel, la santé, les musées et d'autres secteurs, fournissant aux clients de nombreux produits et services d'intégration système avancés, fiables, sûrs, de haute qualité et facilement extensibles.  
Nous améliorons continuellement nos services pour devenir un partenaire de confiance à long terme pour nos clients et, par l'innovation et le développement continus, devenir un fournisseur IoT national d'excellence.  

`L'équipe NewLife a démarré en 2002. Certains projets open source ont plus de 20 ans d'histoire, et le dépôt source conserve chaque modification depuis 2010`  
Site web: https://newlifex.com  
Open source: https://github.com/newlifex  
Groupes QQ: 1600800 / 1600838  
Compte officiel WeChat:
![智能大石头](https://www.newlifex.com/stone.jpg)
