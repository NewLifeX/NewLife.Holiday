# NewLife.Holiday - مكتبة العطلات الصينية

![GitHub License](https://img.shields.io/github/license/NewLifeX/NewLife.Holiday?logo=github)
![NuGet Downloads](https://img.shields.io/nuget/dt/NewLife.Holiday?logo=nuget)
![NuGet](https://img.shields.io/nuget/v/NewLife.Holiday?logo=nuget)
![NuGet prerelease](https://img.shields.io/nuget/vpre/NewLife.Holiday?label=dev%20nuget&logo=nuget)
[![test](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml/badge.svg?branch=master)](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml)
![platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS%20%7C%20Android%20%7C%20iOS-blue)
![arch](https://img.shields.io/badge/arch-x64%20%7C%20arm64%20%7C%20loongarch64-orange)
[![contributors](https://img.shields.io/github/contributors/NewLifeX/NewLife.Holiday?logo=github)](https://github.com/NewLifeX/NewLife.Holiday/graphs/contributors)

<!-- lang:start -->
🌐 [中文](README.md) | [繁體中文](README.zh-TW.md) | [English](README.en.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md)
<!-- lang:end -->

> قد تتأخر هذه الترجمة عن النسخة الصينية.

تضمّن NewLife.Holiday بيانات سنوية للعطلات في البر الرئيسي الصيني وقوانغشي، مع الأعياد القمرية والمصطلحات الشمسية وأيام العمل دون اتصال.

## التثبيت

```bash
dotnet add package NewLife.Holiday
```

## البدء السريع

```csharp
var holiday = new ChinaHoliday();
var isHoliday = holiday.Check(DateTime.Today);
```

## الميزات الرئيسية

- إمكانات وبيانات مضمّنة تعمل دون خدمات خارجية
- يدعم net45 إلى net10.0 لسهولة التبني في الأنظمة القديمة
- رخصة MIT؛ استخدام تجاري وخاص بحرية

## التوثيق

> 📖 التوثيق الكامل (بالصينية): [مستندات المستودع](Doc)

## الترخيص

MIT License © 2002-2026 فريق NewLife

[GitHub](https://github.com/NewLifeX/NewLife.Holiday) | [Website](https://newlifex.com)
