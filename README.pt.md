# NewLife.Holiday - Biblioteca de feriados chineses

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Русский](README.ru.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

Biblioteca de identificação de feriados chineses com banco de dados integrado de feriados e dias de trabalho compensatório, mantido e atualizado anualmente.

> Esta tradução acompanha o README em inglês; em caso de divergência, prevalece a versão em inglês.

## Uso
Referencie `NewLife.Holiday` a partir do NuGet e importe o namespace `NewLife.Holiday` para usar o método de extensão DateTime `IsChinaHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```


## Nomes de feriados localizados

`HolidayInfo.DisplayName` retorna o nome do feriado no idioma da interface atual, enquanto `Name` mantém o texto original em chinês. A tabela cobre 11 idiomas; idiomas não suportados retornam ao chinês.

``` csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

## Festival do 3 de março em Guangxi
Referencie `NewLife.Holiday` a partir do NuGet e importe o namespace `NewLife.Holiday` para usar o método de extensão DateTime `IsGuangxiHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## Documentação do projeto

- [Documento de requisitos](Doc/需求文档.md)
- [Lista de funcionalidades](Doc/功能清单.md)
- [Projeto de arquitetura](Doc/架构设计.md)

## Matriz de projetos NewLife
Todos os projetos suportam net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5 por padrão; versões anteriores (2024.0801) suportam net4.0/net2.0.  

| Projeto | Ano | Descrição |
| :-----: | :--: | :---------- |
| Fundações | | Dão suporte a outros projetos de middleware e produtos |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | Biblioteca principal: registro, configuração, cache, rede, serialização, rastreamento de desempenho APM |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | Middleware de big data, tabela única com dezenas de bilhões de linhas, MySql/SQLite/SqlServer/Oracle/PostgreSql/DaMeng, fragmentação automática, separação de leitura/escrita |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | Biblioteca de rede, dezenas de milhões de TPS em uma única máquina (22,66 milhões de tps), milhões de conexões em uma única máquina (4 milhões de conexões TCP de longa duração) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | Biblioteca de comunicação por protocolo que fornece uma estrutura de aplicação C/S, com suporte a comunicação Http/RPC, alta vazão, baixo custo e acesso fácil para dispositivos IoT |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Plataforma de desenvolvimento rápido Cube, integrando permissões de usuário, login SSO, servidor OAuth etc., validada por projetos com 10 bilhões de linhas por tabela |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | Componente de gerenciamento de serviços que instala aplicações como daemons do sistema operacional: serviços do Windows e systemd do Linux |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | Andaime de nova geração: modelos de projeto NewLife.Templates baseados no ecossistema de componentes NewLife, Web, WebApi, Service |
| Middleware | | Integram-se a plataformas de middleware conhecidas |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Cliente Redis, latência de microssegundos, milhões de TPS, filas de mensagens ricas, validado por projetos com dezenas de bilhões de registros |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | Cliente RocketMQ totalmente gerenciado, com suporte a Apache RocketMQ e Alibaba Cloud Message Queue, validado por projetos em escala de bilhões |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | Protocolo de mensagens IoT, MqttClient/MqttServer, o cliente suporta Alibaba Cloud IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | Biblioteca padrão de IoT, definindo diversos padrões de protocolos de comunicação para o domínio IoT |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII, implementado sobre a biblioteca padrão de IoT, com suporte à plataforma ZeroIoT e ao gateway IoTEdge |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | Protocolo Siemens PLC, implementado sobre a biblioteca padrão de IoT, com suporte à plataforma IoT e ao IoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | Biblioteca de componentes de mapas que encapsula Baidu Maps, Amap, Tencent Maps e Tianditu |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | Biblioteca de codecs de áudio, PCM/ADPCMA/G711A/G722U/WAV/AAC |
| Plataformas de produto | | Nível de plataforma de produto, prontas para compilar e implantar, personalizáveis |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust, uma plataforma de serviços distribuídos: gerenciamento de nós, central de monitoramento APM, central de configuração, registro, central de releases |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob, uma plataforma distribuída de computação de big data (tempo real/offline), com o conceito de fragmentação «ant-moving», validada por projetos de dados em escala de trilhões |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | ERP corporativo: gestão de produtos, gestão de clientes, gestão de vendas, gestão de fornecedores |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | Ferramentas CrazyCoder: inúmeras ferramentas para desenvolvedores cobrindo rede, portas seriais, criptografia/descriptografia, expressões regulares, Modbus, MQTT |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | Armazenamento de arquivos simples, com suporte a armazenamento centralizado de arquivos em sistemas distribuídos. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | Proxy reverso de qualidade de produção: proxy NAT, proxy Http |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Ferramenta de teste de carga Http |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Sistema de gerenciamento de código-fonte Git |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | Sistema operacional embarcado, totalmente independente, com suporte à arquitetura de chips ARM Cortex-M |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | Computador industrial embarcado, gateway de borda IoT, host .NET8 de alto desempenho, aplicado em indústria, agricultura, transporte e saúde |
| Plataforma IoT FIoT | 2020 | Solução completa de IoT que integra hardware, software e análise de big data para construção, proteção ambiental e agricultura; validada por projetos com 100 mil pontos por máquina |
| Posicionamento indoor de alta precisão UWB | 2020 | Posicionamento indoor de alta precisão em nível centimétrico (10–20 cm), hardware e software integrados, interoperável com outros sistemas, validado em grandes salões de exposições |

## Equipe de desenvolvimento NewLife
![XCode](https://newlifex.com/logo.png)  

A equipe NewLife foi fundada em 2002 e é uma fornecedora de soluções industriais de IoT para a nova era, dedicada a consultoria de aplicações de hardware e software, planejamento de arquitetura de sistemas e serviços de desenvolvimento.  
Mais de 80 projetos de código aberto liderados pela equipe são amplamente utilizados em diversos setores, com mais de 4 milhões de downloads acumulados no NuGet.  
O middleware de big data NewLife.XCode, a plataforma distribuída de agendamento e computação AntJob, a plataforma distribuída Stardust, o componente de cache e filas NewLife.Redis e a plataforma IoT FIoT da equipe foram aplicados com sucesso em energia, educação, Internet, telecomunicações, transporte, logística, controle industrial, saúde, museus e outros setores, oferecendo aos clientes muitos produtos e serviços de integração de sistemas avançados, confiáveis, seguros, de alta qualidade e facilmente extensíveis.  
Continuaremos aprimorando nossos serviços para nos tornarmos um parceiro de confiança de longo prazo para nossos clientes e, por meio de inovação e desenvolvimento contínuos, um excelente fornecedor nacional de IoT.  

`A equipe NewLife começou em 2002. Alguns projetos de código aberto têm mais de 20 anos de história, e o repositório de código preserva cada modificação desde 2010`  
Site: https://newlifex.com  
Código aberto: https://github.com/newlifex  
Grupos QQ: 1600800 / 1600838  
Conta oficial do WeChat:
![智能大石头](https://www.newlifex.com/stone.jpg)
