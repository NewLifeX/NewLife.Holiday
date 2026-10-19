# NewLife.Holiday - 中国の祝日判定ライブラリ

![GitHub License](https://img.shields.io/github/license/NewLifeX/NewLife.Holiday?logo=github)
![NuGet Downloads](https://img.shields.io/nuget/dt/NewLife.Holiday?logo=nuget)
![NuGet](https://img.shields.io/nuget/v/NewLife.Holiday?logo=nuget)
![NuGet prerelease](https://img.shields.io/nuget/vpre/NewLife.Holiday?label=dev%20nuget&logo=nuget)
[![test](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml/badge.svg?branch=master)](https://github.com/NewLifeX/NewLife.Holiday/actions/workflows/test.yml)
![platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS%20%7C%20Android%20%7C%20iOS-blue)
![arch](https://img.shields.io/badge/arch-x64%20%7C%20arm64%20%7C%20loongarch64-orange)
[![contributors](https://img.shields.io/github/contributors/NewLifeX/NewLife.Holiday?logo=github)](https://github.com/NewLifeX/NewLife.Holiday/graphs/contributors)

<!-- lang:start -->
🌐 [中文](README.md) | [繁體中文](README.zh-TW.md) | [English](README.en.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

> この翻訳は中国語版より遅れている場合があります。

NewLife.Holiday は中国本土と広西の休暇・振替データを毎年更新して同梱し、旧暦の祝日、二十四節気、営業日判定をオフラインで提供します。

## インストール

```bash
dotnet add package NewLife.Holiday
```

## クイックスタート

```csharp
var holiday = new ChinaHoliday();
var isHoliday = holiday.Check(DateTime.Today);
```

## 主な機能

- 機能とデータを内蔵し、外部サービスなしで動作
- net45 〜 net10.0 のマルチターゲットで既存システムにも導入可能
- MIT ライセンス。商用・私的利用は自由

## ドキュメント

> 📖 詳細ドキュメント（中国語）： [リポジトリ内ドキュメント](Doc)

## ライセンス

MIT License © 2002-2026 NewLife チーム

[GitHub](https://github.com/NewLifeX/NewLife.Holiday) | [Website](https://newlifex.com)
