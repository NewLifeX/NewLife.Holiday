using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using NewLife;
using NewLife.Holiday;
using NewLife.Log;
using Xunit;

namespace XUnitTest;

/// <summary>运行时多语言与带前缀日志测试。本地化设置为进程级全局状态，串行执行</summary>
[Collection("Localization")]
public class LocalizationTests
{
    [Fact]
    [DisplayName("带前缀日志_先翻译消息再拼接前缀")]
    public void PrefixLog_TranslatesBeforePrefix()
    {
        var saved = Localization.LogCulture;
        try
        {
            Localization.LogCulture = CultureInfo.GetCultureInfo("zh-Hans");
            var log = new ProbeLog();

            _ = new ChinaHoliday(log);

            Assert.Single(log.Lines);
            var line = log.Lines[log.Lines.Count - 1];
            Assert.StartsWith("[ChinaHoliday]", line);
            Assert.Contains("已从", line);
            Assert.Contains("条假期记录", line);
        }
        finally
        {
            Localization.LogCulture = saved;
        }
    }

    [Fact]
    [DisplayName("带前缀日志_未提供译文时回退英文")]
    public void PrefixLog_FallsBackToEnglish()
    {
        var saved = Localization.LogCulture;
        try
        {
            Localization.LogCulture = CultureInfo.GetCultureInfo("sw-KE");
            var log = new ProbeLog();

            _ = new ChinaHoliday(log);

            Assert.Single(log.Lines);
            var line = log.Lines[log.Lines.Count - 1];
            Assert.StartsWith("[ChinaHoliday]", line);
            Assert.Contains("Loaded", line);
            Assert.Contains("holiday records", line);
        }
        finally
        {
            Localization.LogCulture = saved;
        }
    }

    [Fact]
    [DisplayName("带前缀日志_派生类使用派生类型前缀")]
    public void PrefixLog_UsesDerivedPrefix()
    {
        var saved = Localization.LogCulture;
        try
        {
            Localization.LogCulture = CultureInfo.GetCultureInfo("zh-Hans");
            var log = new ProbeLog();

            _ = new GuangxiHoliday(log);

            Assert.Equal(2, log.Lines.Count);
            Assert.All(log.Lines, e => Assert.StartsWith("[GuangxiHoliday]", e));
            Assert.Contains(log.Lines, e => e.Contains("[Guangxi]"));
        }
        finally
        {
            Localization.LogCulture = saved;
        }
    }

    [Fact]
    [DisplayName("调试日志_跳过无效假期记录时按前缀输出")]
    public void DebugLog_SkippedInvalidRecords()
    {
        var saved = Localization.LogCulture;
        try
        {
            Localization.LogCulture = CultureInfo.GetCultureInfo("zh-Hans");
            var log = new ProbeLog();
            var holiday = new ChinaHoliday { Infos = [], Log = log };

            const String csv = "Name,Date,Days,Status\r\n有效,2026-05-20,1,1\r\n无效,0999-01-01,1,1\r\n";
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));
            holiday.Load(stream, "Test");

            var line = Assert.Single(log.Lines);
            Assert.StartsWith("[ChinaHoliday]", line);
            Assert.Contains("已跳过", line);
            Assert.Contains("1 条无效假期记录", line);
        }
        finally
        {
            Localization.LogCulture = saved;
        }
    }

    [Fact]
    [DisplayName("节气结果_按界面语言翻译天数单位")]
    public void SolarTermResult_TranslatesDaysUnit()
    {
        var saved = Localization.Culture;
        try
        {
            var from = new DateTime(2025, 3, 20, 12, 0, 0);
            var time = new DateTime(2025, 3, 20, 17, 1, 0);
            var r = new SolarTermResult(SolarTerm.春分, time, from);

            Localization.Culture = CultureInfo.GetCultureInfo("zh-Hans");
            Assert.Equal("春分 2025-03-20 17:01:00 +0.2天", r.ToString());

            Localization.Culture = CultureInfo.GetCultureInfo("en");
            Assert.Equal("春分 2025-03-20 17:01:00 +0.2 days", r.ToString());
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Fact]
    [DisplayName("异常消息_按界面语言翻译")]
    public void Exception_TranslatesWithCulture()
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo("zh-Hans");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Lunar.FromDateTime(new DateTime(1800, 1, 1)));

            Assert.Contains("日期超出农历支持范围", ex.Message);
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Fact]
    [DisplayName("运行时注册词表_覆盖译文并可注销")]
    public void RuntimeRegistration_OverridesTranslation()
    {
        var saved = Localization.Culture;
        var culture = CultureInfo.GetCultureInfo("sw-KE");
        try
        {
            Localization.Register(culture, new Dictionary<String, String>
            {
                ["{0} {1} {2} days"] = "{0} {1} {2} siku",
            });
            Localization.Culture = culture;

            var r = new SolarTermResult(SolarTerm.春分, new DateTime(2025, 3, 20, 17, 1, 0), new DateTime(2025, 3, 20, 12, 0, 0));
            Assert.EndsWith(" siku", r.ToString());

            Assert.True(Localization.Unregister(culture));
            Assert.EndsWith(" days", r.ToString());
        }
        finally
        {
            Localization.Unregister(culture);
            Localization.Culture = saved;
        }
    }

    [Fact]
    [DisplayName("无效节气_异常消息按界面语言翻译")]
    public void InvalidSolarTerm_TranslatesMessage()
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo("zh-Hans");

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => SolarTerms.GetTermTime(2025, (SolarTerm)(-1)));

            Assert.Contains("无效节气[-1]", ex.Message);
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Theory]
    [DisplayName("翻译表覆盖全部运行时语言")]
    [InlineData("zh-Hans", "天")]
    [InlineData("zh-Hant", "天")]
    [InlineData("de", "Tage")]
    [InlineData("es", "días")]
    [InlineData("fr", "jours")]
    [InlineData("ja", "日")]
    [InlineData("ko", "일")]
    [InlineData("pt", "dias")]
    [InlineData("ru", "дн.")]
    [InlineData("ar", "أيام")]
    public void RuntimeLocales_AreSupported(String name, String expected)
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo(name);

            var text = Localization.Translate("{0} {1} {2} days", "春分", "2025-03-20", "+1");

            Assert.EndsWith(expected, text);
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Fact]
    [DisplayName("程序集元数据_英文源文且全部语言有译文")]
    public void AssemblyMetadata_IsLocalized()
    {
        var asm = typeof(ChinaHoliday).Assembly;
        var title = asm.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
        var description = asm.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;
        Assert.Equal("NewLife.Holiday - Chinese Holiday Library", title);
        Assert.False(description.IsNullOrEmpty());

        var saved = Localization.Culture;
        try
        {
            foreach (var name in new[] { "zh-Hans", "zh-Hant", "de", "es", "fr", "ja", "ko", "pt", "ru", "ar" })
            {
                Localization.Culture = CultureInfo.GetCultureInfo(name);
                Assert.NotEqual(title, Localization.Translate(title!));
                Assert.NotEqual(description, Localization.Translate(description!));
            }

            Localization.Culture = CultureInfo.GetCultureInfo("zh-Hans");
            Assert.Equal("NewLife.Holiday - 中国节假日识别库", Localization.Translate(title!));
            Assert.Contains("农历节日判定", Localization.Translate(description!));
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Theory]
    [DisplayName("假期状态元数据_按界面语言翻译")]
    [InlineData("zh-Hans", "常规", "放假", "调休")]
    [InlineData("zh-Hant", "常規", "放假", "調休")]
    [InlineData("de", "Regulär", "Feiertag", "Ausgleichsarbeitstag")]
    [InlineData("es", "Normal", "Día festivo", "Jornada de ajuste")]
    [InlineData("fr", "Normal", "Jour férié", "Journée de rattrapage")]
    [InlineData("ja", "通常", "休日", "振替出勤")]
    [InlineData("ko", "일반", "휴일", "대체 근무")]
    [InlineData("pt", "Normal", "Feriado", "Dia de trabalho compensatório")]
    [InlineData("ru", "Обычный", "Праздник", "Перенос рабочего дня")]
    [InlineData("ar", "عادي", "عطلة", "يوم عمل تعويضي")]
    public void HolidayStatusMetadata_IsLocalized(String name, String normal, String holiday, String off)
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo(name);

            Assert.Equal(normal, Localization.Translate(HolidayStatus.Normal.GetDescription()));
            Assert.Equal(holiday, Localization.Translate(HolidayStatus.On.GetDescription()));
            Assert.Equal(off, Localization.Translate(HolidayStatus.Off.GetDescription()));
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Theory]
    [DisplayName("假期名称_按界面语言翻译")]
    [InlineData("zh-Hans", "春节")]
    [InlineData("zh-Hant", "春節")]
    [InlineData("en", "Spring Festival")]
    [InlineData("de", "Frühlingsfest")]
    [InlineData("es", "Fiesta de la Primavera")]
    [InlineData("fr", "Fête du Printemps")]
    [InlineData("ja", "春節")]
    [InlineData("ko", "춘절")]
    [InlineData("pt", "Festival da Primavera")]
    [InlineData("ru", "Праздник весны")]
    [InlineData("ar", "عيد الربيع")]
    public void HolidayName_IsLocalized(String name, String expected)
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo(name);

            var info = new HolidayInfo { Name = "春节" };

            Assert.Equal(expected, info.DisplayName);
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Theory]
    [DisplayName("假期名称_英文词表覆盖全部内置名称")]
    [InlineData("元旦", "New Year's Day")]
    [InlineData("春节", "Spring Festival")]
    [InlineData("清明节", "Qingming Festival")]
    [InlineData("劳动节", "Labour Day")]
    [InlineData("端午节", "Dragon Boat Festival")]
    [InlineData("中秋节", "Mid-Autumn Festival")]
    [InlineData("国庆节", "National Day")]
    [InlineData("三月三", "Double Third Festival")]
    public void HolidayNames_English(String source, String expected)
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo("en");

            Assert.Equal(expected, new HolidayInfo { Name = source }.DisplayName);
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Fact]
    [DisplayName("假期名称_未知语言回退中文原名")]
    public void HolidayName_FallsBackToSource()
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo("sw-KE");

            Assert.Equal("春节", new HolidayInfo { Name = "春节" }.DisplayName);
            Assert.Null(new HolidayInfo().DisplayName);
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Fact]
    [DisplayName("简体中文词表_覆盖全部运行时消息")]
    public void Translate_AllKeys_zhHans()
    {
        var saved = Localization.Culture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo("zh-Hans");

            Assert.Equal("日期超出农历支持范围", Localization.Translate("The date is outside the supported lunar calendar range."));
            Assert.Equal("已从 7 个嵌入资源加载 91 条假期记录，分类[China]", Localization.Translate("Loaded {0} holiday records from {1} embedded resources for [{2}].", 91, 7, "China"));
            Assert.Equal("加载嵌入资源[x]失败：y", Localization.Translate("Failed to load embedded resource [{0}]: {1}", "x", "y"));
            Assert.Equal("已跳过[Test]中 2 条无效假期记录", Localization.Translate("Skipped {0} invalid holiday records from [{1}].", 2, "Test"));
            Assert.Equal("未找到[Test]的嵌入资源", Localization.Translate("No embedded resources found for [{0}].", "Test"));
            Assert.Equal("无效节气[24]", Localization.Translate("Invalid solar term [{0}].", 24));
            Assert.Equal("春分 2025-03-20 +1天", Localization.Translate("{0} {1} {2} days", "春分", "2025-03-20", "+1"));
        }
        finally
        {
            Localization.Culture = saved;
        }
    }

    [Fact]
    [DisplayName("日志语言_优先于界面语言")]
    public void LogCulture_TakesPriority()
    {
        var savedCulture = Localization.Culture;
        var savedLogCulture = Localization.LogCulture;
        try
        {
            Localization.Culture = CultureInfo.GetCultureInfo("zh-Hans");
            Localization.LogCulture = CultureInfo.GetCultureInfo("en");
            var log = new ProbeLog();

            _ = new ChinaHoliday(log);

            Assert.Single(log.Lines);
            Assert.Contains("Loaded", log.Lines[log.Lines.Count - 1]);
        }
        finally
        {
            Localization.Culture = savedCulture;
            Localization.LogCulture = savedLogCulture;
        }
    }

    [Fact]
    [DisplayName("默认日志_未注入时使用空日志保持静默")]
    public void DefaultLog_IsNullLogger()
    {
        var holiday = new ChinaHoliday();

        Assert.Same(Logger.Null, holiday.Log);
    }

    [Fact]
    [DisplayName("加载不存在的分类_按警告输出并带前缀")]
    public void MissingCategory_Warns()
    {
        var saved = Localization.LogCulture;
        try
        {
            Localization.LogCulture = CultureInfo.GetCultureInfo("zh-Hans");
            var log = new ProbeLog();
            var holiday = new ProbeHoliday(log);

            holiday.LoadCategory("NoSuch");

            Assert.Equal(2, log.Lines.Count);
            Assert.Equal(LogLevel.Info, log.Levels[0]);
            Assert.Equal(LogLevel.Warn, log.Levels[1]);
            Assert.StartsWith("[ProbeHoliday]", log.Lines[1]);
            Assert.Contains("未找到[NoSuch]的嵌入资源", log.Lines[1]);
        }
        finally
        {
            Localization.LogCulture = saved;
        }
    }

    /// <summary>暴露受保护 Load 的探针类型</summary>
    private sealed class ProbeHoliday : ChinaHoliday
    {
        public ProbeHoliday(ILog log) : base(log) { }

        public void LoadCategory(String category) => Load(category);
    }

    private sealed class ProbeLog : ILog
    {
        public List<String> Lines { get; } = [];

        public List<LogLevel> Levels { get; } = [];

        public Boolean Enable { get; set; } = true;

        public LogLevel Level { get; set; } = LogLevel.Debug;

        public void Write(LogLevel level, String format, params Object[] args)
        {
            Lines.Add(args.Length > 0 ? String.Format(format, args) : format);
            Levels.Add(level);
        }

        public void Debug(String format, params Object[] args) => Write(LogLevel.Debug, format, args);

        public void Info(String format, params Object[] args) => Write(LogLevel.Info, format, args);

        public void Warn(String format, params Object[] args) => Write(LogLevel.Warn, format, args);

        public void Error(String format, params Object[] args) => Write(LogLevel.Error, format, args);

        public void Fatal(String format, params Object[] args) => Write(LogLevel.Fatal, format, args);
    }
}

/// <summary>本地化测试集合。本地化状态为进程级全局，禁止与其他集合并行</summary>
[CollectionDefinition("Localization", DisableParallelization = true)]
public class LocalizationCollection { }
