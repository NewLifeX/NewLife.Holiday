using System;
using NewLife.Holiday;
using Xunit;

namespace XUnitTest;

public class GuangxiHolidayTests
{
    [Theory]
    [InlineData("2022/4/3")]
    [InlineData("2023/4/3")]
    [InlineData("2122/4/3")]
    public void Test广西三月三(String date)
    {
        var dt = date.ToDateTime();
        var rs = dt.IsGuangxiHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.Guangxi.Query(dt);
        Assert.NotNull(inf);
        Assert.Equal("三月三", inf.Name);
        Assert.True(inf.Days >= 2);
    }
}
