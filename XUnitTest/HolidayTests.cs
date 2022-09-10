using System;
using NewLife.Holiday;
using Xunit;

namespace XUnitTest;

public class HolidayTests
{
    [Theory]
    [InlineData("2022/1/29", false)]
    [InlineData("2022/1/30", false)]
    [InlineData("2022/1/31", true)]
    [InlineData("2022/2/1", true)]
    [InlineData("2022/2/2", true)]
    [InlineData("2022/2/3", true)]
    [InlineData("2022/2/4", true)]
    [InlineData("2022/2/5", true)]
    [InlineData("2022/2/6", true)]
    [InlineData("2022/2/7", false)]
    public void Test春节(String date, Boolean result)
    {
        var rs = date.ToDateTime().IsChinaHoliday();

        Assert.Equal(result, rs);
    }

    [Theory]
    [InlineData("2022/9/9", false)]
    [InlineData("2022/9/10", true)]
    [InlineData("2022/9/11", true)]
    [InlineData("2022/9/12", true)]
    [InlineData("2022/9/13", false)]
    public void Test中秋(String date, Boolean result)
    {
        var rs = date.ToDateTime().IsChinaHoliday();

        Assert.Equal(result, rs);
    }
}
