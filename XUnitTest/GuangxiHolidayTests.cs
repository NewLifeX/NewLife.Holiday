using System;
using System.Linq;
using NewLife.Holiday;
using Xunit;

namespace XUnitTest;

public class GuangxiHolidayTests
{
    [Theory]
    [InlineData("2022/4/3")]
    [InlineData("2023/4/14")]
    [InlineData("2022/4/2")]
    public void Test广西三月三(String date)
    {
        var dt = date.ToDateTime();
        var rs = dt.IsGuangxiHoliday();

        Assert.True(rs);

        var infs = HolidayExtensions.Guangxi.Query(dt).ToList();
        Assert.True(infs.Count > 0);

        var inf = infs.FirstOrDefault(e => e.Category == "Guangxi");
        Assert.Equal("三月三", inf.Name);
        //Assert.True(inf.Days >= 2);
    }
}
