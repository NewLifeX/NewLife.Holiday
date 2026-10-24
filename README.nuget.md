# NewLife.Holiday - Chinese Holiday Library

![GitHub License](https://img.shields.io/github/license/NewLifeX/NewLife.Holiday?logo=github)
![NuGet Downloads](https://img.shields.io/nuget/dt/NewLife.Holiday?logo=nuget)
![NuGet](https://img.shields.io/nuget/v/NewLife.Holiday?logo=nuget)
[![test](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml/badge.svg?branch=master)](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml)
[![locales](https://img.shields.io/badge/locales-11-2ea44f?logo=dotnet)](https://github.com/NewLifeX/NewLife.Holiday/blob/master/Doc/%E5%A4%9A%E8%AF%AD%E8%A8%80%E6%9C%AC%E5%9C%B0%E5%8C%96.md)

Chinese holiday and adjusted-workday identification library with a built-in annual holiday database, lunar festival support and fully offline operation.

## Installation

```bash
dotnet add package NewLife.Holiday
```

## Quick start

```csharp
using NewLife.Holiday;

var isHoliday = "2026-10-01".ToDateTime().IsChinaHoliday();
```

Guangxi March 3rd Festival:

```csharp
using NewLife.Holiday;

var isHoliday = "2026-04-18".ToDateTime().IsGuangxiHoliday();
```

## Localized holiday names

`HolidayInfo.DisplayName` returns the holiday name in the current UI language, while `Name` keeps the original Chinese source:

```csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

The word list ships 11 languages (English, Simplified Chinese, Traditional Chinese, Spanish, German, Japanese, French, Portuguese, Russian, Korean and Arabic); unsupported languages fall back to Chinese.

## Logging

`ChinaHoliday` and `GuangxiHoliday` accept an `ILog` in the constructor. The default is a null logger, so the library stays silent unless you opt in:

```csharp
using NewLife.Log;
using NewLife.Holiday;

XTrace.UseConsole();
var holiday = new ChinaHoliday(XTrace.Log);
// [ChinaHoliday]Loaded 91 holiday records from 7 embedded resources for [China].
```

Log messages are translated with the current log language (`Localization.LogCulture`, falling back to `Localization.Culture`).

## Documentation

- [Requirements document](https://github.com/NewLifeX/NewLife.Holiday/blob/master/Doc/%E9%9C%80%E6%B1%82%E6%96%87%E6%A1%A3.md)
- [Feature list](https://github.com/NewLifeX/NewLife.Holiday/blob/master/Doc/%E5%8A%9F%E8%83%BD%E6%B8%85%E5%8D%95.md)
- [Architecture design](https://github.com/NewLifeX/NewLife.Holiday/blob/master/Doc/%E6%9E%B6%E6%9E%84%E8%AE%BE%E8%AE%A1.md)
- [Localization guide](https://github.com/NewLifeX/NewLife.Holiday/blob/master/Doc/%E5%A4%9A%E8%AF%AD%E8%A8%80%E6%9C%AC%E5%9C%B0%E5%8C%96.md)
- [All languages](https://github.com/NewLifeX/NewLife.Holiday#readme)

## License

MIT License © 2002-2026 NewLife Team

[GitHub](https://github.com/NewLifeX/NewLife.Holiday) | [Website](https://newlifex.com)
