using System;
using System.ComponentModel;
using System.Linq;
using NewLife.Holiday;
using Xunit;

namespace XUnitTest;

/// <summary>24节气与最近节气（SolarTerms/Lunar.GetNearestSolarTerm）单元测试</summary>
/// <remarks>
/// 对照值取自公开发布的天文年历节气时刻（北京时间，即 UTC+8）。
/// 本库采用简化太阳黄经模型，时刻误差通常在 ±15 分钟内，断言给 ±45 分钟窗口。
/// 时刻断言基于 UTC 绝对时刻，任意运行环境均有效；
/// 中国本地日期断言仅在本机时区为 UTC+8 时执行（CI 工作流已固定中国时区）。
/// </remarks>
public class SolarTermsTests
{
    [Theory]
    [DisplayName("已知节气时刻接近天文年历发布时刻")]
    // 北京时间: 2021-12-21 23:59:09（特殊修正年份）
    [InlineData(2021, SolarTerm.冬至, "2021-12-21 15:59:09", "2021-12-21")]
    // 北京时间: 2023-12-22 11:27:09
    [InlineData(2023, SolarTerm.冬至, "2023-12-22 03:27:09", "2023-12-22")]
    // 北京时间: 2024-02-04 16:26:53
    [InlineData(2024, SolarTerm.立春, "2024-02-04 08:26:53", "2024-02-04")]
    // 北京时间: 2024-12-21 17:20:20
    [InlineData(2024, SolarTerm.冬至, "2024-12-21 09:20:20", "2024-12-21")]
    // 北京时间: 2025-02-03 22:10:13
    [InlineData(2025, SolarTerm.立春, "2025-02-03 14:10:13", "2025-02-03")]
    // 北京时间: 2025-03-20 17:01:24
    [InlineData(2025, SolarTerm.春分, "2025-03-20 09:01:24", "2025-03-20")]
    // 北京时间: 2025-12-21 23:03:03
    [InlineData(2025, SolarTerm.冬至, "2025-12-21 15:03:03", "2025-12-21")]
    // 北京时间: 2026-02-04 04:02:03
    [InlineData(2026, SolarTerm.立春, "2026-02-03 20:02:03", "2026-02-04")]
    // 北京时间: 2026-03-20 22:45:44
    [InlineData(2026, SolarTerm.春分, "2026-03-20 14:45:44", "2026-03-20")]
    public void MatchPublishedTime(Int32 year, SolarTerm term, String publishedUtc, String publishedLocalDate)
    {
        var time = SolarTerms.GetTermTime(year, term);

        // 时刻断言：与发布时刻的 UTC 绝对时刻对照
        var expected = DateTime.SpecifyKind(TestDate.Parse(publishedUtc), DateTimeKind.Utc);
        var diff = Math.Abs((time.ToUniversalTime() - expected).TotalMinutes);
        Assert.True(diff <= 45, $"{year} {term} 实际 {time:yyyy-MM-dd HH:mm}，与发布时刻相差 {diff:n0} 分钟");

        // 本地日期断言：仅在中国时区（UTC+8）下验证与历书一致的本地日期
        if (TimeZoneInfo.Local.BaseUtcOffset == TimeSpan.FromHours(8))
        {
            var date = TestDate.Parse(publishedLocalDate).Date;
            Assert.Equal(date, time.Date);
            Assert.Equal(date, SolarTerms.GetTermDate(year, term));
        }
    }

    [Fact]
    [DisplayName("全年24节气按序返回且精确到分钟")]
    public void AllTermsAreOrdered()
    {
        var all = SolarTerms.GetAll(2025);
        Assert.Equal(24, all.Count);
        Assert.Equal(SolarTerm.小寒, all[0].Term);
        Assert.Equal(SolarTerm.冬至, all[23].Term);

        var times = SolarTerms.GetAllTimes(2025);
        Assert.Equal(24, times.Count);

        // 按公历月份递增（小寒起于1月，冬至止于12月），且时刻精确到分钟
        var month = 0;
        foreach (var (term, time) in times)
        {
            Assert.True(time.Month >= month, $"{term} 月份顺序异常");
            month = time.Month;
            Assert.Equal(0, time.Second);
        }
    }

    [Fact]
    [DisplayName("GetTermDate 与 GetTermTime 的本地日期一致")]
    public void TermDateConsistentWithTime()
    {
        foreach (var (term, time) in SolarTerms.GetAllTimes(2025))
        {
            Assert.Equal(time.Date, SolarTerms.GetTermDate(2025, term));
        }
    }

    [Fact]
    [DisplayName("最近节气：冬至到小寒可跨年")]
    public void NearestSolarTerm_CrossesYear()
    {
        var r = Lunar.FromDateTime(new DateTime(2024, 12, 31)).GetNearestSolarTerm();

        Assert.Equal(SolarTerm.小寒, r.Term);
        // 用同一本地时区下的节气日期做一致性断言，避免硬编码日期在非中国时区失效
        Assert.Equal(SolarTerms.GetTermDate(2025, SolarTerm.小寒), r.TermTime.Date);
        Assert.True(r.DaysTo > 0);
        Assert.False(r.IsTermDay);
        Assert.False(r.IsWithinOneDay);
    }

    [Fact]
    [DisplayName("最近节气：节气当天命中且结果格式化包含节气名")]
    public void NearestSolarTerm_OnTermDay()
    {
        // 取本时区下立春的本地日期，保证任意时区都能测试“节气当天”语义
        var termDate = SolarTerms.GetTermDate(2024, SolarTerm.立春);
        var r = Lunar.FromDateTime(termDate).GetNearestSolarTerm();

        Assert.Equal(SolarTerm.立春, r.Term);
        Assert.True(r.IsTermDay);
        Assert.True(r.IsWithinOneDay);
        Assert.Contains("立春", r.ToString());
    }

    [Fact]
    [DisplayName("最近节气结果_属性与格式化正确")]
    public void SolarTermResult_Properties()
    {
        var from = new DateTime(2025, 3, 20, 12, 0, 0);
        var time = new DateTime(2025, 3, 20, 17, 1, 0);
        var r = new SolarTermResult(SolarTerm.春分, time, from);

        Assert.Equal(SolarTerm.春分, r.Term);
        Assert.Equal(time, r.TermTime);
        Assert.Equal((time - from).TotalDays, r.DaysTo, 6);
        Assert.True(r.IsTermDay);
        Assert.True(r.IsWithinOneDay);
        Assert.Contains("春分", r.ToString());
        Assert.Contains("+", r.ToString());
    }

    [Fact]
    [DisplayName("节气时刻重复查询_结果一致")]
    public void RepeatedQuery_ReturnsSameResult()
    {
        var first = SolarTerms.GetTermTime(2025, SolarTerm.冬至);
        var second = SolarTerms.GetTermTime(2025, SolarTerm.冬至);

        Assert.Equal(first, second);
        Assert.Equal(SolarTerms.GetTermDate(2025, SolarTerm.冬至), first.Date);
    }

    [Theory]
    [DisplayName("无效节气值_抛出参数越界异常")]
    [InlineData(-1)]
    [InlineData(24)]
    public void InvalidTerm_Throws(Int32 term)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => SolarTerms.GetTermTime(2025, (SolarTerm)term));
    }
}

