using System;
using System.ComponentModel;
using System.Linq;
using NewLife.Holiday;
using Xunit;

namespace XUnitTest;

public class GuangxiHolidayTests
{
    [Theory]
    [DisplayName("广西三月三_数据与农历推算命中")]
    [InlineData("2022/4/3")]
    [InlineData("2023/4/22")]
    [InlineData("2023/4/23")]
    [InlineData("2022/4/5")]
    [InlineData("2024/4/11")]
    [InlineData("2024/4/12")]
    public void Sanyuesan_DataAndLunar(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsGuangxiHoliday();

        Assert.True(rs);

        var infs = HolidayExtensions.Guangxi.Query(dt).ToList();
        Assert.True(infs.Count > 0);

        var inf = infs.FirstOrDefault(e => e.Category == "Guangxi");
        Assert.NotNull(inf);
        Assert.Equal("三月三", inf.Name);
        //Assert.True(inf.Days >= 2);
    }

    [Theory]
    [DisplayName("广西三月三_远期年份农历推算")]
    [InlineData("2029/4/16")]
    public void Sanyuesan_Predict(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsGuangxiHoliday();

        Assert.True(rs);

        var infs = HolidayExtensions.Guangxi.Query(dt).ToList();
        Assert.True(infs.Count > 0);

        var inf = infs.FirstOrDefault(e => e.Category == "Guangxi");
        Assert.NotNull(inf);
        Assert.Equal("三月三", inf.Name);
        Assert.True(inf.Days >= 2);
    }

    [Theory]
    [DisplayName("广西判定_继承全国假期与调休")]
    [InlineData("2023/10/1", true)]
    [InlineData("2023/10/7", false)]
    [InlineData("2023/10/8", false)]
    [InlineData("2023/9/23", true)]
    public void InheritsChinaHoliday(String date, Boolean result)
    {
        Assert.Equal(result, TestDate.Parse(date).IsGuangxiHoliday());
    }

    [Fact]
    [DisplayName("三月三推算_非节日与超范围日期返回false")]
    public void TryGetSanyuesan_NonHoliday_ReturnFalse()
    {
        var holiday = new GuangxiHoliday();

        // 2023/4/21 是广西三月三数据假期首日，但农历为三月初二，不由推算命中
        Assert.False(holiday.TryGetSanyuesan(new DateTime(2023, 4, 21), out _));
        Assert.False(holiday.TryGetSanyuesan(new DateTime(2122, 4, 1), out _));
    }
}

