# NewLife.Holiday - Библиотека китайских праздников

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [한국어](README.ko.md) | [العربية](README.ar.md)
<!-- lang:end -->

Библиотека определения китайских праздников со встроенной базой праздников и переносов рабочих дней, которая ежегодно поддерживается и обновляется.

> Этот перевод соответствует английскому README; при расхождениях приоритет имеет английская версия.

## Использование
Подключите `NewLife.Holiday` из NuGet и импортируйте пространство имён `NewLife.Holiday`, чтобы использовать метод расширения DateTime `IsChinaHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```


## Локализация названий праздников

`HolidayInfo.DisplayName` возвращает название праздника на текущем языке интерфейса, а `Name` сохраняет исходный китайский текст. Словарь содержит 11 языков; для неподдерживаемых языков используется китайский оригинал.

``` csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

## Праздник 3 марта в Гуанси
Подключите `NewLife.Holiday` из NuGet и импортируйте пространство имён `NewLife.Holiday`, чтобы использовать метод расширения DateTime `IsGuangxiHoliday`.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## Документация проекта

- [Документ требований](Doc/需求文档.md)
- [Список функций](Doc/功能清单.md)
- [Проектирование архитектуры](Doc/架构设计.md)

## Матрица проектов NewLife
Все проекты по умолчанию поддерживают net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5; старые версии (2024.0801) поддерживают net4.0/net2.0.  

| Проект | Год | Описание |
| :-----: | :--: | :---------- |
| Базовые компоненты | | Поддерживают другие middleware- и продуктовые проекты |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | Базовая библиотека: журналирование, конфигурация, кэширование, сеть, сериализация, трассировка производительности APM |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | Middleware для больших данных, одна таблица с десятками миллиардов строк, MySql/SQLite/SqlServer/Oracle/PostgreSql/DaMeng, автоматическое секционирование, разделение чтения и записи |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | Сетевая библиотека, десятки миллионов TPS на одной машине (22,66 млн tps), миллионы подключений на одной машине (4 млн длительных TCP-соединений) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | Библиотека протокольной связи, предоставляющая фреймворк C/S-приложений, поддерживает Http/RPC-связь, высокую пропускную способность, низкие накладные расходы и простой доступ для IoT-устройств |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | Платформа быстрой разработки Cube, объединяющая права пользователей, SSO-вход, OAuth-сервер и т. д.; проверена проектами с 10 млрд строк на таблицу |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | Компонент управления службами, устанавливающий приложения как демоны операционной системы: службы Windows и Linux systemd |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | Каркас нового поколения: шаблоны проектов NewLife.Templates на основе экосистемы компонентов NewLife, Web, WebApi, Service |
| Middleware | | Интеграция с известными middleware-платформами |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | Клиент Redis, микросекундная задержка, миллионы TPS, богатые очереди сообщений, проверен проектами с десятками миллиардов записей |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | Полностью управляемый клиент RocketMQ, поддерживает Apache RocketMQ и Alibaba Cloud Message Queue, проверен проектами масштаба миллиардов |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | Протокол обмена сообщениями IoT, MqttClient/MqttServer, клиент поддерживает Alibaba Cloud IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | Стандартная библиотека IoT, определяющая различные стандарты протоколов связи для области IoT |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII, реализованные на стандартной библиотеке IoT, поддерживают платформу ZeroIoT и шлюз IoTEdge |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | Протокол Siemens PLC, реализованный на стандартной библиотеке IoT, поддерживает платформу IoT и IoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | Библиотека картографических компонентов, обёртывающая Baidu Maps, Amap, Tencent Maps и Tianditu |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | Библиотека аудиокодеков, PCM/ADPCMA/G711A/G722U/WAV/AAC |
| Продуктовые платформы | | Уровень продуктовой платформы, готовы к компиляции и развёртыванию, настраиваемые |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust, распределённая сервисная платформа: управление узлами, центр мониторинга APM, центр конфигурации, реестр, центр релизов |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob, распределённая платформа вычислений для больших данных (реального времени/офлайн) с концепцией «ant-moving» секционирования, проверена проектами с триллионами данных |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | Корпоративная ERP: управление продуктами, клиентами, продажами и поставщиками |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | Инструменты CrazyCoder: множество инструментов разработчика для сети, последовательных портов, шифрования/дешифрования, регулярных выражений, Modbus, MQTT |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | Простое файловое хранилище с поддержкой централизованного хранения файлов в распределённых системах. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | Обратный прокси промышленного уровня: NAT-прокси, Http-прокси |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | Инструмент нагрузочного тестирования Http |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | Система управления исходным кодом Git |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | Встраиваемая операционная система, полностью независимая, поддерживает архитектуру чипов ARM Cortex-M |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | Встраиваемый промышленный компьютер, IoT-шлюз, высокопроизводительный хост .NET8, применяется в промышленности, сельском хозяйстве, транспорте и здравоохранении |
| IoT-платформа FIoT | 2020 | Комплексное IoT-решение, объединяющее аппаратное и программное обеспечение и анализ больших данных для строительства, охраны окружающей среды и сельского хозяйства; проверено проектами с 100 000 точек на машину |
| Высокоточное позиционирование UWB в помещении | 2020 | Высокоточное позиционирование в помещении с сантиметровой точностью (10–20 см), интеграция аппаратного и программного обеспечения, совместимость с другими системами, проверено в больших выставочных залах |

## Команда разработчиков NewLife
![XCode](https://newlifex.com/logo.png)  

Команда NewLife основана в 2002 году и является поставщиком отраслевых IoT-решений нового времени, специализирующимся на консалтинге по аппаратным и программным приложениям, планировании системной архитектуры и разработке.  
Более 80 открытых проектов под руководством команды широко используются в различных отраслях, а совокупное число загрузок NuGet превышает 4 миллиона.  
Middleware для больших данных NewLife.XCode, распределённая платформа планирования и вычислений AntJob, распределённая платформа Stardust, компонент кэширования и очередей NewLife.Redis, а также IoT-платформа FIoT команды успешно применяются в энергетике, образовании, интернете, телекоммуникациях, транспорте, логистике, промышленной автоматизации, здравоохранении, музеях и других отраслях, предоставляя клиентам множество передовых, надёжных, безопасных, качественных и легко расширяемых продуктов и услуг системной интеграции.  
Мы будем постоянно совершенствовать наши услуги, чтобы стать долгосрочным доверенным партнёром клиентов, и благодаря непрерывным инновациям и развитию — выдающимся отечественным поставщиком IoT-услуг.  

`Команда NewLife начала работу в 2002 году. Некоторые открытые проекты имеют более чем 20-летнюю историю, а репозиторий исходного кода хранит все изменения с 2010 года`  
Сайт: https://newlifex.com  
Открытый исходный код: https://github.com/newlifex  
Группы QQ: 1600800 / 1600838  
Официальный аккаунт WeChat:
![智能大石头](https://www.newlifex.com/stone.jpg)
