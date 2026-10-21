# NewLife.Holiday - 중국 공휴일 판별 라이브러리

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [العربية](README.ar.md)
<!-- lang:end -->

중국의 공휴일과 대체 근무일 데이터베이스를 내장하고 매년 유지·갱신되는 중국 공휴일 판별 라이브러리입니다.

> 이 번역은 영어 README를 따릅니다. 내용이 다를 경우 영어 버전을 기준으로 합니다.

## 사용 방법
NuGet에서 `NewLife.Holiday`를 참조하고 `NewLife.Holiday` 네임스페이스를 가져오면 DateTime 확장 메서드 `IsChinaHoliday`를 사용할 수 있습니다.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```

## 광시 좡족 자치구의 싼웨싼
NuGet에서 `NewLife.Holiday`를 참조하고 `NewLife.Holiday` 네임스페이스를 가져오면 DateTime 확장 메서드 `IsGuangxiHoliday`를 사용할 수 있습니다.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## 프로젝트 문서

- [요구 사항 문서](Doc/需求文档.md)
- [기능 목록](Doc/功能清单.md)
- [아키텍처 설계](Doc/架构设计.md)

## NewLife 프로젝트 매트릭스
모든 프로젝트는 기본적으로 net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5를 지원합니다. 이전 버전(2024.0801)은 net4.0/net2.0을 지원합니다.  

| 프로젝트 | 연도 | 설명 |
| :-----: | :--: | :---------- |
| 기반 구성 요소 | | 다른 미들웨어 및 제품 프로젝트를 지원 |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | 핵심 라이브러리: 로깅, 구성, 캐싱, 네트워크, 직렬화, APM 성능 추적 |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | 빅데이터 미들웨어, 단일 테이블 수백억 행, MySql/SQLite/SqlServer/Oracle/PostgreSql/다멩, 자동 분할, 읽기/쓰기 분리 |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | 네트워크 라이브러리, 단일 머신 수천만 TPS(2,266만 tps), 단일 머신 수백만 연결(400만 TCP 장기 연결) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | 프로토콜 통신 라이브러리로 C/S 애플리케이션 프레임워크를 제공하며 Http/RPC 통신, 높은 처리량, 낮은 오버헤드, IoT 장치의 손쉬운 접속을 지원 |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Cube 고속 개발 플랫폼으로 사용자 권한, SSO 로그인, OAuth 서버 등을 통합하며 단일 테이블 100억 행 프로젝트로 검증됨 |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | 애플리케이션을 운영 체제 데몬으로 설치하는 서비스 관리 구성 요소: Windows 서비스 및 Linux systemd |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | 제로 세대 스캐폴드: NewLife 구성 요소 생태계 기반의 NewLife.Templates 프로젝트 템플릿, Web, WebApi, Service |
| 미들웨어 | | 잘 알려진 미들웨어 플랫폼과 통합 |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Redis 클라이언트, 마이크로초 지연, 수백만 TPS, 풍부한 메시지 큐, 수백억 데이터 레코드 프로젝트로 검증됨 |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | 순수 관리형 RocketMQ 클라이언트로 Apache RocketMQ와 Alibaba Cloud Message Queue를 지원하며 수십억 규모 프로젝트로 검증됨 |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | IoT 메시징 프로토콜, MqttClient/MqttServer, 클라이언트는 Alibaba Cloud IoT 지원 |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | IoT 표준 라이브러리로 IoT 분야의 다양한 통신 프로토콜 표준을 정의 |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII, IoT 표준 라이브러리 위에 구현되어 ZeroIoT 플랫폼과 IoTEdge 게이트웨이 지원 |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | 지멘스 PLC 프로토콜, IoT 표준 라이브러리 위에 구현되어 IoT 플랫폼과 IoTEdge 지원 |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | 지도 구성 요소 라이브러리로 바이두 지도, 가오더 지도, 텐센트 지도, 티안디투를 래핑 |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | 오디오 코덱 라이브러리, PCM/ADPCMA/G711A/G722U/WAV/AAC |
| 제품 플랫폼 | | 제품 플랫폼 수준으로 즉시 컴파일·배포 가능하며 사용자 정의 가능 |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust 분산 서비스 플랫폼: 노드 관리, APM 모니터링 센터, 구성 센터, 레지스트리 센터, 릴리스 센터 |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob 분산 빅데이터 컴퓨팅 플랫폼(실시간/오프라인), 개미 이동식 샤딩 개념을 갖추며 조 단위 데이터 프로젝트로 검증됨 |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | 기업 ERP: 제품 관리, 고객 관리, 판매 관리, 공급업체 관리 |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | 코드의 신 도구: 네트워크, 시리얼 포트, 암호화/복호화, 정규식, Modbus, MQTT를 아우르는 다양한 개발자 도구 |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | 간단한 파일 저장소로 분산 시스템의 중앙 집중식 파일 저장 지원. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | 제품급 리버스 프록시: NAT 프록시, Http 프록시 |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Http 부하 테스트 도구 |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Git 소스 코드 관리 시스템 |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | 임베디드 운영 체제로 완전히 독립적이며 ARM Cortex-M 칩 아키텍처 지원 |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | 임베디드 산업용 컴퓨터, IoT 엣지 게이트웨이, 고성능 .NET8 호스트로 산업, 농업, 교통, 의료 분야에 적용 |
| FIoT IoT 플랫폼 | 2020 | 건축, 환경 보호, 농업을 위한 하드웨어, 소프트웨어, 빅데이터 분석을 통합한 IoT 종합 솔루션으로 단일 머신 10만 포인트 규모 프로젝트로 검증됨 |
| UWB 고정밀 실내 측위 | 2020 | 센티미터급(10–20cm) 고정밀 실내 측위로 하드웨어와 소프트웨어를 통합하고 다른 시스템과 연동하며 대형 전시장에서 검증됨 |

## NewLife 개발 팀
![XCode](https://newlifex.com/logo.png)  

NewLife 팀은 2002년에 설립되었으며 새로운 시대의 IoT 산업 솔루션 제공업체로서 하드웨어·소프트웨어 애플리케이션 컨설팅, 시스템 아키텍처 기획 및 개발 서비스를 제공합니다.  
팀이 주도하는 80여 개의 오픈 소스 프로젝트가 각 산업에서 널리 사용되고 있으며 NuGet 누적 다운로드 수는 400만 회를 넘습니다.  
팀의 빅데이터 미들웨어 NewLife.XCode, AntJob 분산 스케줄링·컴퓨팅 플랫폼, Stardust 분산 플랫폼, 캐시·큐 구성 요소 NewLife.Redis, IoT 플랫폼 FIoT는 전력, 교육, 인터넷, 통신, 교통, 물류, 산업 제어, 의료, 박물관 등 다양한 산업에 성공적으로 적용되어 고객에게 다수의 첨단·신뢰·안전·고품질·확장 용이한 제품과 시스템 통합 서비스를 제공하고 있습니다.  
우리는 지속적인 서비스 개선을 통해 고객이 오랫동안 신뢰하는 파트너가 되고, 끊임없는 혁신과 발전을 통해 국내 우수 IoT 서비스 제공업체가 되고자 합니다.  

`NewLife 팀은 2002년에 시작되었습니다. 일부 오픈 소스 프로젝트는 20년 이상의 역사를 가지며 소스 저장소에는 2010년 이후 모든 수정 기록이 보관되어 있습니다`  
웹사이트: https://newlifex.com  
오픈 소스: https://github.com/newlifex  
QQ 그룹: 1600800 / 1600838  
WeChat 공식 계정:
![智能大石头](https://www.newlifex.com/stone.jpg)
