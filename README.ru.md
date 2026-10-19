# NewLife.Holiday - Библиотека китайских праздников

![GitHub License](https://img.shields.io/github/license/NewLifeX/NewLife.Holiday?logo=github)
![NuGet Downloads](https://img.shields.io/nuget/dt/NewLife.Holiday?logo=nuget)
![NuGet](https://img.shields.io/nuget/v/NewLife.Holiday?logo=nuget)
![NuGet prerelease](https://img.shields.io/nuget/vpre/NewLife.Holiday?label=dev%20nuget&logo=nuget)
[![test](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml/badge.svg?branch=master)](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml)
![platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-blue)
![arch](https://img.shields.io/badge/arch-x64%20%7C%20arm64%20%7C%20loongarch64-orange)
[![contributors](https://img.shields.io/github/contributors/NewLifeX/NewLife.Holiday?logo=github)](https://github.com/NewLifeX/NewLife.Holiday/graphs/contributors)

<!-- lang:start -->
🌐 [中文](README.md) | [繁體中文](README.zh-TW.md) | [English](README.en.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

> Перевод может отставать от китайской версии.

NewLife.Holiday содержит ежегодно обновляемые данные о праздниках материкового Китая и Гуанси, включая лунные праздники, солнечные термины и рабочие дни, полностью офлайн.

## Установка

```bash
dotnet add package NewLife.Holiday
```

## Быстрый старт

```csharp
var holiday = new ChinaHoliday();
var isHoliday = holiday.Check(DateTime.Today);
```

## Возможности

- Встроенные возможности и данные; работает без внешних сервисов
- Цели net45–net10.0 для плавного внедрения в унаследованные системы
- Лицензия MIT; свободное коммерческое и частное использование

## Документация

> 📖 Полная документация (на китайском): [документы репозитория](Doc)

## Лицензия

MIT License © 2002-2026 Команда NewLife

[GitHub](https://github.com/NewLifeX/NewLife.Holiday) | [Website](https://newlifex.com)
