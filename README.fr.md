# NewLife.Holiday - Bibliothèque de jours fériés chinois

![GitHub License](https://img.shields.io/github/license/NewLifeX/NewLife.Holiday?logo=github)
![NuGet Downloads](https://img.shields.io/nuget/dt/NewLife.Holiday?logo=nuget)
![NuGet](https://img.shields.io/nuget/v/NewLife.Holiday?logo=nuget)
![NuGet prerelease](https://img.shields.io/nuget/vpre/NewLife.Holiday?label=dev%20nuget&logo=nuget)
[![test](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml/badge.svg?branch=master)](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml)
![platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-blue)
[![contributors](https://img.shields.io/github/contributors/NewLifeX/NewLife.Holiday?logo=github)](https://github.com/NewLifeX/NewLife.Holiday/graphs/contributors)

<!-- lang:start -->
🌐 [中文](README.md) | [繁體中文](README.zh-TW.md) | [English](README.en.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

> Cette traduction peut être en retard sur la version chinoise.

NewLife.Holiday intègre des données annuelles de jours fériés pour la Chine continentale et le Guangxi, avec fêtes lunaires, termes solaires et jours ouvrés, hors ligne.

## Installation

```bash
dotnet add package NewLife.Holiday
```

## Démarrage rapide

```csharp
var holiday = new ChinaHoliday();
var isHoliday = holiday.Check(DateTime.Today);
```

## Fonctionnalités

- Fonctionnalités et données intégrées ; fonctionne sans service externe
- Cibles net45 à net10.0 pour une adoption progressive
- Licence MIT ; usage commercial et privé libre

## Documentation

> 📖 Documentation complète (chinois) : [documents du dépôt](Doc)

## Licence

MIT License © 2002-2026 Équipe NewLife

[GitHub](https://github.com/NewLifeX/NewLife.Holiday) | [Website](https://newlifex.com)
