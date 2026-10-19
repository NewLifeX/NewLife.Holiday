using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
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

            Assert.NotEmpty(log.Lines);
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

            Assert.NotEmpty(log.Lines);
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

            Assert.NotEmpty(log.Lines);
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

    private sealed class ProbeLog : ILog
    {
        public List<String> Lines { get; } = [];

        public Boolean Enable { get; set; } = true;

        public LogLevel Level { get; set; } = LogLevel.Debug;

        public void Write(LogLevel level, String format, params Object[] args) => Lines.Add(args.Length > 0 ? String.Format(format, args) : format);

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
