using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Xunit;

namespace XUnitTest;

public class LunarTests
{
    [Theory]
    [DisplayName("基础属性_与ChineseLunisolarCalendar一致")]
    [InlineData("2024-02-10")] // 甲辰年正月初一（春节）
    [InlineData("2023-01-22")] // 癸卯年正月初一
    [InlineData("2020-05-23")] // 庚子年闰四月初一
    public void BasicProperties_ShouldMatchChineseLunisolarCalendar(String gregorian)
    {
        var date = TestDate.Parse(gregorian);
        var lunar = NewLife.Holiday.Lunar.FromDateTime(date);

        var cal = new ChineseLunisolarCalendar();
        var year = cal.GetYear(date);
        var monthWithLeap = cal.GetMonth(date);
        var day = cal.GetDayOfMonth(date);
        var leapMonth = cal.GetLeapMonth(year);

        var isLeap = false;
        var normalizedMonth = monthWithLeap;
        if (leapMonth > 0)
        {
            if (monthWithLeap == leapMonth)
            {
                isLeap = true;
                normalizedMonth = monthWithLeap - 1;
            }
            else if (monthWithLeap > leapMonth)
            {
                normalizedMonth = monthWithLeap - 1;
            }
        }

        // 覆盖 Date/Year/Month/Day/IsLeapMonth
        Assert.Equal(date, lunar.Date);
        Assert.Equal(year, lunar.Year);
        Assert.Equal(normalizedMonth, lunar.Month);
        Assert.Equal(day, lunar.Day);
        Assert.Equal(isLeap, lunar.IsLeapMonth);

        // 覆盖 ToString 的基本格式（不含固定前缀“农历”，当前实现不带该前缀）
        var str = lunar.ToString();
        Assert.Contains("年", str);
        Assert.Contains("月", str);
    }

    [Theory]
    [DisplayName("干支生肖与中文文本_正确")]
    [InlineData("2024-02-10", "甲辰", "龙", "正", "初一")]
    [InlineData("2023-01-22", "癸卯", "兔", "正", "初一")]
    [InlineData("2020-01-25", "庚子", "鼠", "正", "初一")]
    public void TextualMembers_ShouldBeCorrect(String gregorian, String ganzhi, String zodiac, String monthText, String dayText)
    {
        var date = TestDate.Parse(gregorian);
        var lunar = NewLife.Holiday.Lunar.FromDateTime(date);

        // YearGanzhi + Zodiac + MonthText + DayText
        Assert.Equal(ganzhi, lunar.YearGanzhi);
        Assert.Equal(zodiac, lunar.Zodiac);
        Assert.Equal(monthText, lunar.MonthText);
        Assert.Equal(dayText, lunar.DayText);

        // YearGanzhi 基本合法性
        Assert.Equal(2, lunar.YearGanzhi.Length);
        Assert.Contains(lunar.YearGanzhi[0].ToString(), "甲乙丙丁戊己庚辛壬癸");
        Assert.Contains(lunar.YearGanzhi[1].ToString(), "子丑寅卯辰巳午未申酉戌亥");
    }

    [Fact]
    [DisplayName("日文本_初一初十十一二十廿一廿九三十边界")]
    public void DayText_BoundarySamples_ShouldBeCorrect()
    {
        // 以 2024-02-10 为农历正月初一为基准
        var d1 = new DateTime(2024, 2, 10);
        var l1 = NewLife.Holiday.Lunar.FromDateTime(d1);
        Assert.Equal(1, l1.Day);
        Assert.Equal("初一", l1.DayText);

        var d10 = d1.AddDays(9); // 初十
        var l10 = NewLife.Holiday.Lunar.FromDateTime(d10);
        Assert.Equal(10, l10.Day);
        Assert.Equal("初十", l10.DayText);

        var d11 = d1.AddDays(10);
        var l11 = NewLife.Holiday.Lunar.FromDateTime(d11);
        Assert.Equal(11, l11.Day);
        Assert.Equal("十一", l11.DayText);

        var d20 = d1.AddDays(19);
        var l20 = NewLife.Holiday.Lunar.FromDateTime(d20);
        Assert.Equal(20, l20.Day);
        Assert.Equal("二十", l20.DayText);

        var d21 = d1.AddDays(20);
        var l21 = NewLife.Holiday.Lunar.FromDateTime(d21);
        Assert.Equal(21, l21.Day);
        Assert.Equal("廿一", l21.DayText);

        // 2023-04-19 为闰二月二十九
        var l29 = NewLife.Holiday.Lunar.FromDateTime(new DateTime(2023, 4, 19));
        Assert.Equal(29, l29.Day);
        Assert.Equal("廿九", l29.DayText);

        // 2023-03-21 为二月三十
        var l30 = NewLife.Holiday.Lunar.FromDateTime(new DateTime(2023, 3, 21));
        Assert.Equal(30, l30.Day);
        Assert.Equal("三十", l30.DayText);
    }

    [Theory]
    [DisplayName("闰月_正确标识并规格化月份")]
    [InlineData("2020-05-23", 4)] // 庚子年闰四月初一
    [InlineData("2023-03-22", 2)] // 癸卯年闰二月初一
    public void LeapMonthHandling_ShouldIndicateLeapAndNormalizeMonth(String gregorian, Int32 month)
    {
        var lunar = NewLife.Holiday.Lunar.FromDateTime(TestDate.Parse(gregorian));

        Assert.True(lunar.IsLeapMonth);
        Assert.Equal(month, lunar.Month);
        Assert.Contains("闰", lunar.ToString());
    }

    [Fact]
    [DisplayName("闰月之后的月份_回退序号且不标记闰月")]
    public void MonthAfterLeapMonth_ShouldNormalize()
    {
        // 2023-04-20 为闰二月之后的农历三月初一
        var lunar = NewLife.Holiday.Lunar.FromDateTime(new DateTime(2023, 4, 20));

        Assert.Equal(3, lunar.Month);
        Assert.False(lunar.IsLeapMonth);
        Assert.Equal("三", lunar.MonthText);
        Assert.DoesNotContain("闰", lunar.ToString());
    }

    [Fact]
    [DisplayName("农历支持范围_边界可转换且范围外不支持")]
    public void SupportedRange_Boundaries()
    {
        Assert.False(NewLife.Holiday.Lunar.IsSupported(new DateTime(1901, 2, 18)));
        Assert.True(NewLife.Holiday.Lunar.IsSupported(new DateTime(1901, 2, 19)));
        Assert.True(NewLife.Holiday.Lunar.IsSupported(new DateTime(2101, 1, 28)));
        Assert.False(NewLife.Holiday.Lunar.IsSupported(new DateTime(2101, 1, 29)));

        Assert.Equal(1901, NewLife.Holiday.Lunar.FromDateTime(new DateTime(1901, 2, 19)).Year);
        Assert.Equal(2100, NewLife.Holiday.Lunar.FromDateTime(new DateTime(2101, 1, 28)).Year);
    }

    [Fact]
    [DisplayName("月份文本_三年逐日扫描与映射一致")]
    public void MonthText_ShouldMatchMapping_ForManyDates()
    {
        // 扫描一段日期，验证 MonthText 与 Month 的映射关系
        var start = new DateTime(2023, 1, 1);
        var end = new DateTime(2025, 12, 31);

        var map = new Dictionary<Int32, String>
        {
            [1] = "正",
            [2] = "二",
            [3] = "三",
            [4] = "四",
            [5] = "五",
            [6] = "六",
            [7] = "七",
            [8] = "八",
            [9] = "九",
            [10] = "十",
            [11] = "冬",
            [12] = "腊",
        };

        for (var dt = start; dt <= end; dt = dt.AddDays(1))
        {
            var lunar = NewLife.Holiday.Lunar.FromDateTime(dt);
            Assert.Equal(map[lunar.Month], lunar.MonthText);
        }
    }

    [Fact]
    [DisplayName("超出农历支持范围抛出参数越界异常")]
    public void FromDateTime_OutOfRange_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => NewLife.Holiday.Lunar.FromDateTime(new DateTime(1800, 1, 1)));
        Assert.Throws<ArgumentOutOfRangeException>(() => NewLife.Holiday.Lunar.FromDateTime(new DateTime(1901, 2, 18)));
        Assert.Throws<ArgumentOutOfRangeException>(() => NewLife.Holiday.Lunar.FromDateTime(new DateTime(2101, 1, 29)));
        Assert.Throws<ArgumentOutOfRangeException>(() => NewLife.Holiday.Lunar.FromDateTime(new DateTime(2200, 1, 1)));
    }
}

