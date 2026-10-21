# NewLife.Holiday - 中国の祝日判定ライブラリ

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

中国の祝日と振替出勤のデータベースを内蔵し、毎年保守・更新される中国の祝日判定ライブラリです。

> この翻訳は英語版 README に追随しています。内容に相違がある場合は英語版を優先します。

## 使用方法
NuGet から `NewLife.Holiday` を参照し、名前空間 `NewLife.Holiday` をインポートすると、DateTime 拡張メソッド `IsChinaHoliday` を使用できます。  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```

## 広西チワン族自治区の三月三
NuGet から `NewLife.Holiday` を参照し、名前空間 `NewLife.Holiday` をインポートすると、DateTime 拡張メソッド `IsGuangxiHoliday` を使用できます。  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## プロジェクトドキュメント

- [要件ドキュメント](Doc/需求文档.md)
- [機能一覧](Doc/功能清单.md)
- [アーキテクチャ設計](Doc/架构设计.md)

## NewLife プロジェクトマトリクス
すべてのプロジェクトは既定で net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5 をサポートします。旧版（2024.0801）は net4.0/net2.0 をサポートします。  

| プロジェクト | 年 | 説明 |
| :-----: | :--: | :---------- |
| 基盤コンポーネント | | 他のミドルウェアや製品プロジェクトを支える |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | コアライブラリ：ログ、構成、キャッシュ、ネットワーク、シリアル化、APM パフォーマンス追跡 |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | ビッグデータミドルウェア。単一テーブル数百億行、MySql/SQLite/SqlServer/Oracle/PostgreSql/達夢、自動分割、読み書き分離 |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | ネットワークライブラリ。単一マシンで数千万 TPS（2,266 万 tps）、単一マシンで数百万接続（400 万 TCP 長接続） |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | プロトコル通信ライブラリ。C/S アプリケーションフレームワークを提供し、Http/RPC 通信、高スループット、低オーバーヘッド、IoT デバイスの容易な接続を実現 |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Cube 高速開発プラットフォーム。ユーザー権限、SSO ログイン、OAuth サーバーなどを統合し、単一テーブル 100 億行のプロジェクトで検証済み |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | アプリケーションを OS デーモンとしてインストールするサービス管理コンポーネント：Windows サービスと Linux systemd |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | ゼロ世代スキャフォールド：NewLife コンポーネントエコシステムに基づく NewLife.Templates プロジェクトテンプレート、Web、WebApi、Service |
| ミドルウェア | | 著名なミドルウェアプラットフォームと統合 |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Redis クライアント。マイクロ秒レイテンシ、数百万 TPS、豊富なメッセージキュー、数百億レコードのプロジェクトで検証済み |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | 純マネージド RocketMQ クライアント。Apache RocketMQ と Alibaba Cloud Message Queue をサポートし、十億規模のプロジェクトで検証済み |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | IoT メッセージングプロトコル。MqttClient/MqttServer、クライアントは Alibaba Cloud IoT をサポート |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | IoT 標準ライブラリ。IoT 分野の各種通信プロトコル標準を定義 |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII。IoT 標準ライブラリ上に実装され、ZeroIoT プラットフォームと IoTEdge ゲートウェイをサポート |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | シーメンス PLC プロトコル。IoT 標準ライブラリ上に実装され、IoT プラットフォームと IoTEdge をサポート |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | 地図コンポーネントライブラリ。百度地図、高徳地図、騰訊地図、天地図をラップ |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | オーディオコーデックライブラリ。PCM/ADPCMA/G711A/G722U/WAV/AAC |
| 製品プラットフォーム | | 製品プラットフォームレベル。すぐにコンパイル・デプロイでき、カスタマイズ可能 |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust 分散型サービスプラットフォーム：ノード管理、APM 監視センター、構成センター、レジストリセンター、リリースセンター |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob 分散型ビッグデータ計算プラットフォーム（リアルタイム/オフライン）。蟻移動型シャーディングの理念を持ち、兆規模のデータプロジェクトで検証済み |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | 企業向け ERP：製品管理、顧客管理、販売管理、サプライヤー管理 |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | コードの神ツール：ネットワーク、シリアルポート、暗号化/復号、正規表現、Modbus、MQTT を網羅する多数の開発者ツール |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | シンプルなファイルストレージ。分散システムでの集中ファイルストレージをサポート。 |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | 製品グレードのリバースプロキシ：NAT プロキシ、Http プロキシ |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Http 負荷テストツール |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Git ソースコード管理システム |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | 組み込みオペレーティングシステム。完全に独立し、ARM Cortex-M チップアーキテクチャをサポート |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | 組み込み産業用コンピュータ、IoT エッジゲートウェイ、高性能 .NET8 ホスト。産業、農業、交通、医療で採用 |
| FIoT IoT プラットフォーム | 2020 | IoT 総合ソリューション。建築、環境保護、農業向けにハードウェア、ソフトウェア、ビッグデータ分析を一体化し、単一マシン 10 万点規模のプロジェクトで検証済み |
| UWB 高精度屋内測位 | 2020 | センチメートル級（10〜20 cm）の高精度屋内測位。ハードウェアとソフトウェアを一体化し、他システムと連携、大型展示ホールで検証済み |

## NewLife 開発チーム
![XCode](https://newlifex.com/logo.png)  

NewLife チームは 2002 年に設立され、新しい時代の IoT 業界ソリューションプロバイダーとして、ハードウェアとソフトウェアのアプリケーションコンサルティング、システムアーキテクチャ計画、開発サービスを提供しています。  
チームが主導する 80 以上のオープンソースプロジェクトが各業界で広く利用され、NuGet の累計ダウンロード数は 400 万回を超えています。  
チームのビッグデータミドルウェア NewLife.XCode、AntJob 分散スケジューリング・計算プラットフォーム、Stardust 分散プラットフォーム、キャッシュ・キューコンポーネント NewLife.Redis、IoT プラットフォーム FIoT は、電力、教育、インターネット、通信、交通、物流、産業制御、医療、博物館などの業界で成功裏に採用され、お客様に多数の先進的で信頼性が高く、安全で高品質、拡張しやすい製品とシステム統合サービスを提供しています。  
私たちはサービスの継続的改善を通じてお客様から長期的に信頼されるパートナーとなり、絶え間ない革新と発展により、国内有数の IoT サービスプロバイダーとなることを目指します。  

`NewLife チームは 2002 年に始まりました。一部のオープンソースプロジェクトは 20 年以上の歴史があり、ソースリポジトリには 2010 年以降のすべての変更記録が保存されています`  
ウェブサイト: https://newlifex.com  
オープンソース: https://github.com/newlifex  
QQ グループ: 1600800 / 1600838  
WeChat 公式アカウント:
![智能大石头](https://www.newlifex.com/stone.jpg)
