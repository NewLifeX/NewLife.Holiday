# NewLife.Holiday - Biblioteca de feriados chineses

![GitHub License](https://img.shields.io/github/license/NewLifeX/NewLife.Holiday?logo=github)
![NuGet Downloads](https://img.shields.io/nuget/dt/NewLife.Holiday?logo=nuget)
![NuGet](https://img.shields.io/nuget/v/NewLife.Holiday?logo=nuget)
![NuGet prerelease](https://img.shields.io/nuget/vpre/NewLife.Holiday?label=dev%20nuget&logo=nuget)
[![test](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml/badge.svg?branch=master)](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml)
![platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-blue)
[![contributors](https://img.shields.io/github/contributors/NewLifeX/NewLife.Holiday?logo=github)](https://github.com/NewLifeX/NewLife.Holiday/graphs/contributors)

<!-- lang:start -->
🌐 [中文](README.md) | [繁體中文](README.zh-TW.md) | [English](README.en.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

> Esta tradução pode estar desatualizada em relação à versão em chinês.

NewLife.Holiday inclui dados anuais de feriados da China continental e Guangxi, com festivais lunares, termos solares e dias úteis, totalmente offline.

## Instalação

```bash
dotnet add package NewLife.Holiday
```

## Início rápido

```csharp
var holiday = new ChinaHoliday();
var isHoliday = holiday.Check(DateTime.Today);
```

## Recursos

- Recursos e dados integrados; funciona sem serviços externos
- Alvos net45 a net10.0 para adoção em sistemas legados
- Licença MIT; uso comercial e privado livre

## Documentação

> 📖 Documentação completa (em chinês): [documentos do repositório](Doc)

## Licença

MIT License © 2002-2026 Equipe NewLife

[GitHub](https://github.com/NewLifeX/NewLife.Holiday) | [Website](https://newlifex.com)
