# NewLife.Holiday - مكتبة الأعياد الصينية

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
🌐 [English](README.md) | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [Español](README.es.md) | [Deutsch](README.de.md) | [日本語](README.ja.md) | [Français](README.fr.md) | [Português](README.pt.md) | [Русский](README.ru.md) | [한국어](README.ko.md)
<!-- lang:end -->

مكتبة للتعرف على الأعياد الصينية مع قاعدة بيانات مدمجة للأعياد وأيام العمل التعويضية، تتم صيانتها وتحديثها سنويًا.

> تتبع هذه الترجمة ملف README الإنجليزي؛ وعند الاختلاف تكون النسخة الإنجليزية هي المرجع.

## الاستخدام
أضف مرجع `NewLife.Holiday` من NuGet واستورد مساحة الأسماء `NewLife.Holiday` لاستخدام طريقة التوسعة `IsChinaHoliday` على DateTime.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-09-10".ToDateTime();
var rs = dt.IsChinaHoliday();
```


## تعريب أسماء الأعياد

تُرجع `HolidayInfo.DisplayName` اسم العيد باللغة الحالية للواجهة، بينما يحتفظ `Name` بالنص الصيني الأصلي. تتضمن الجدول 11 لغة، وتعود اللغات غير المدعومة إلى الصينية.

``` csharp
var info = HolidayExtensions.China.Query("2026-02-15".ToDateTime()).FirstOrDefault();
Console.WriteLine(info?.DisplayName); // Spring Festival
```

## مهرجان الثالث من مارس في قوانغشي
أضف مرجع `NewLife.Holiday` من NuGet واستورد مساحة الأسماء `NewLife.Holiday` لاستخدام طريقة التوسعة `IsGuangxiHoliday` على DateTime.  
``` csharp
using NewLife.Holiday;

// var dt = DateTime.Now;
var dt = "2022-04-02".ToDateTime();
var rs = dt.IsGuangxiHoliday();
```

## وثائق المشروع

- [وثيقة المتطلبات](Doc/需求文档.md)
- [قائمة الميزات](Doc/功能清单.md)
- [تصميم البنية](Doc/架构设计.md)

## مصفوفة مشاريع NewLife
تدعم جميع المشاريع افتراضيًا net9.0/netstandard2.1/netstandard2.0/net4.62/net4.5؛ وتدعم الإصدارات القديمة (2024.0801) net4.0/net2.0.  

| المشروع | السنة | الوصف |
| :-----: | :--: | :---------- |
| المكونات الأساسية | | تدعم مشاريع الوسائط البرمجية والمنتجات الأخرى |
| [NewLife.Core](https://github.com/NewLifeX/X) | 2002 | مكتبة أساسية: التسجيل والتكوين والتخزين المؤقت والشبكات والتسلسل وتتبع أداء APM |
| [NewLife.XCode](https://github.com/NewLifeX/NewLife.XCode) | 2005 | وسيط بيانات ضخمة، جدول واحد بعشرات المليارات من الصفوف، MySql/SQLite/SqlServer/Oracle/PostgreSql/DaMeng، تقسيم تلقائي، فصل القراءة والكتابة |
| [NewLife.Net](https://github.com/NewLifeX/NewLife.Net) | 2005 | مكتبة شبكات، عشرات الملايين من TPS على جهاز واحد (22.66 مليون tps)، ملايين الاتصالات على جهاز واحد (4 ملايين اتصال TCP طويل الأمد) |
| [NewLife.Remoting](https://github.com/NewLifeX/NewLife.Remoting) | 2011 | مكتبة اتصال بروتوكولي توفر إطار تطبيقات C/S، وتدعم اتصال Http/RPC وإنتاجية عالية وتكلفة منخفضة وسهولة وصول أجهزة IoT |
| [NewLife.Cube](https://github.com/NewLifeX/NewLife.Cube) | 2010 | منصة التطوير السريع Cube، تدمج أذونات المستخدمين وتسجيل الدخول SSO وخادم OAuth وغيرها، ومُتحقَّق منها في مشاريع بجدول واحد يحتوي 10 مليارات صف |
| [NewLife.Agent](https://github.com/NewLifeX/NewLife.Agent) | 2008 | مكوّن إدارة الخدمات الذي يثبّت التطبيقات كخدمات خلفية لنظام التشغيل: خدمات Windows وLinux systemd |
| [NewLife.Zero](https://github.com/NewLifeX/NewLife.Zero) | 2020 | هيكل الجيل الجديد: قوالب مشاريع NewLife.Templates المبنية على منظومة مكونات NewLife، Web وWebApi وService |
| الوسائط البرمجية | | تتكامل مع منصات الوسائط البرمجية المعروفة |
| [NewLife.Redis](https://github.com/NewLifeX/NewLife.Redis) | 2017 | عميل Redis بزمن استجابة ميكروثاني، وملايين TPS، وقوائم رسائل غنية، ومُتحقَّق منه في مشاريع بعشرات المليارات من السجلات |
| [NewLife.RocketMQ](https://github.com/NewLifeX/NewLife.RocketMQ) | 2018 | عميل RocketMQ مُدار بالكامل، يدعم Apache RocketMQ وAlibaba Cloud Message Queue، ومُتحقَّق منه في مشاريع بمقياس المليارات |
| [NewLife.MQTT](https://github.com/NewLifeX/NewLife.MQTT) | 2019 | بروتوكول مراسلة IoT، MqttClient/MqttServer، ويدعم العميل Alibaba Cloud IoT |
| [NewLife.IoT](https://github.com/NewLifeX/NewLife.IoT) | 2022 | مكتبة معايير IoT، تحدد معايير بروتوكولات اتصال متنوعة لمجال إنترنت الأشياء |
| [NewLife.Modbus](https://github.com/NewLifeX/NewLife.Modbus) | 2022 | ModbusTcp/ModbusRTU/ModbusASCII، مبنية على مكتبة معايير IoT، وتدعم منصة ZeroIoT وبوابة IoTEdge |
| [NewLife.Siemens](https://github.com/NewLifeX/NewLife.Siemens) | 2022 | بروتوكول Siemens PLC، مبني على مكتبة معايير IoT، ويدعم منصة IoT وIoTEdge |
| [NewLife.Map](https://github.com/NewLifeX/NewLife.Map) | 2022 | مكتبة مكونات خرائط تغلّف Baidu Maps وAmap وTencent Maps وTianditu |
| [NewLife.Audio](https://github.com/NewLifeX/NewLife.Audio) | 2023 | مكتبة ترميز صوتي، PCM/ADPCMA/G711A/G722U/WAV/AAC |
| منصات المنتجات | | بمستوى منصة منتج، جاهزة للترجمة والنشر وقابلة للتخصيص |
| [Stardust](https://github.com/NewLifeX/Stardust) | 2018 | Stardust، منصة خدمات موزعة: إدارة العقد، مركز مراقبة APM، مركز التكوين، مركز التسجيل، مركز الإصدارات |
| [AntJob](https://github.com/NewLifeX/AntJob) | 2019 | AntJob، منصة حوسبة بيانات ضخمة موزعة (فورية/دون اتصال) بمفهوم التجزئة ant-moving، ومُتحقَّق منها في مشاريع بمقياس التريليونات |
| [NewLife.ERP](https://github.com/NewLifeX/NewLife.ERP) | 2021 | نظام ERP للمؤسسات: إدارة المنتجات والعملاء والمبيعات والموردين |
| [CrazyCoder](https://github.com/NewLifeX/XCoder) | 2006 | أدوات CrazyCoder: أدوات مطورين متعددة تغطي الشبكات والمنافذ التسلسلية والتشفير/فك التشفير والتعبيرات النمطية وModbus وMQTT |
| [EasyIO](https://github.com/NewLifeX/EasyIO) | 2023 | تخزين ملفات بسيط، يدعم التخزين المركزي للملفات في الأنظمة الموزعة. |
| [XProxy](https://github.com/NewLifeX/XProxy) | 2005 | وكيل عكسي بمستوى تجاري: وكيل NAT ووكيل Http |
| [HttpMeter](https://github.com/NewLifeX/HttpMeter) | 2022 | أداة اختبار ضغط Http |
| [GitCandy](https://github.com/NewLifeX/GitCandy) | 2015 | نظام إدارة شيفرة المصدر Git |
| [SmartOS](https://github.com/NewLifeX/SmartOS) | 2014 | نظام تشغيل مدمج مستقل تمامًا، يدعم معمارية شرائح ARM Cortex-M |
| [SmartA2](https://github.com/NewLifeX/SmartA2) | 2019 | حاسوب صناعي مدمج، بوابة حافة IoT، مضيف .NET8 عالي الأداء، يُستخدم في الصناعة والزراعة والنقل والرعاية الصحية |
| منصة FIoT لإنترنت الأشياء | 2020 | حل IoT متكامل يجمع العتاد والبرمجيات وتحليل البيانات الضخمة للبناء وحماية البيئة والزراعة؛ ومُتحقَّق منه في مشاريع بـ100000 نقطة لكل جهاز |
| تحديد الموقع الداخلي عالي الدقة UWB | 2020 | تحديد موقع داخلي عالي الدقة بمستوى السنتيمتر (10–20 سم)، عتاد وبرمجيات متكاملة، يتفاعل مع أنظمة أخرى، ومُتحقَّق منه في قاعات عرض كبيرة |

## فريق تطوير NewLife
![XCode](https://newlifex.com/logo.png)  

تأسس فريق NewLife في عام 2002، وهو مزوّد حلول صناعة إنترنت الأشياء للعصر الجديد، يقدم استشارات تطبيقات العتاد والبرمجيات وتخطيط بنية الأنظمة وخدمات التطوير.  
يُستخدم أكثر من 80 مشروعًا مفتوح المصدر بقيادة الفريق على نطاق واسع في مختلف الصناعات، وتجاوز إجمالي التنزيلات من NuGet 4 ملايين.  
طُبّقت وسيطة البيانات الضخمة NewLife.XCode، ومنصة AntJob الموزعة للجدولة والحوسبة، ومنصة Stardust الموزعة، ومكوّن التخزين المؤقت والطوابير NewLife.Redis، ومنصة FIoT لإنترنت الأشياء التابعة للفريق بنجاح في قطاعات الطاقة والتعليم والإنترنت والاتصالات والنقل والخدمات اللوجستية والتحكم الصناعي والرعاية الصحية والمتاحف وغيرها، مقدمة للعملاء العديد من المنتجات وخدمات تكامل الأنظمة المتقدمة والموثوقة والآمنة وعالية الجودة وسهلة التوسع.  
سنواصل تحسين خدماتنا لنصبح شريكًا موثوقًا طويل الأمد لعملائنا، ومن خلال الابتكار والتطوير المستمرين، نصبح مزوّد خدمات إنترنت أشياء محليًا متميزًا.  

`بدأ فريق NewLife في عام 2002. بعض المشاريع مفتوحة المصدر لها تاريخ يتجاوز 20 عامًا، ويحتفظ مستودع الشيفرة بكل تعديل منذ عام 2010`  
الموقع: https://newlifex.com  
المصدر المفتوح: https://github.com/newlifex  
مجموعات QQ: 1600800 / 1600838  
حساب WeChat الرسمي:
![智能大石头](https://www.newlifex.com/stone.jpg)
