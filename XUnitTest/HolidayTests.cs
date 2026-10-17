using System;
using System.ComponentModel;
using System.Linq;
using NewLife.Holiday;
using Xunit;

namespace XUnitTest;

public class HolidayTests
{
    [Theory]
    [DisplayName("春节假期判定")]
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
        var rs = TestDate.Parse(date).IsChinaHoliday();

        Assert.Equal(result, rs);
    }

    [Theory]
    [DisplayName("中秋假期判定")]
    [InlineData("2022/9/9", false)]
    [InlineData("2022/9/10", true)]
    [InlineData("2022/9/11", true)]
    [InlineData("2022/9/12", true)]
    [InlineData("2022/9/13", false)]
    public void Test中秋(String date, Boolean result)
    {
        var rs = TestDate.Parse(date).IsChinaHoliday();

        Assert.Equal(result, rs);
    }

    [Theory]
    [DisplayName("元旦推算_数据年与远期年份")]
    [InlineData("2022/1/1")]
    [InlineData("2023/1/1")]
    [InlineData("2122/1/1")]
    public void Test元旦(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.China.Query(dt).FirstOrDefault();
        Assert.NotNull(inf);
        Assert.Equal("元旦", inf.Name);

        var hd = HolidayExtensions.China as ChinaHoliday;
        Assert.NotNull(hd);

        rs = hd.TryGetYuandan(dt, out var hi);
        Assert.True(rs);
        Assert.NotNull(hi);
        Assert.Equal("元旦", hi.Name);
        Assert.Equal(1, hi.Days);
    }

    [Theory]
    [DisplayName("清明节推算_数据年与远期年份")]
    [InlineData("2022/4/5")]
    [InlineData("2023/4/5")]
    [InlineData("2122/4/5")]
    public void Test清明节(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.China.Query(dt).FirstOrDefault();
        Assert.NotNull(inf);
        Assert.Equal("清明节", inf.Name);

        var hd = HolidayExtensions.China as ChinaHoliday;
        Assert.NotNull(hd);

        rs = hd.TryGetQingming(dt, out var hi);
        Assert.True(rs);
        Assert.NotNull(hi);
        Assert.Equal("清明节", hi.Name);
        Assert.Equal(1, hi.Days);
    }

    [Theory]
    [DisplayName("劳动节推算_2025年起为两天")]
    [InlineData("2022/5/1")]
    [InlineData("2023/5/1")]
    [InlineData("2025/5/1")]
    [InlineData("2122/5/1")]
    public void Test劳动节(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.China.Query(dt).FirstOrDefault();
        Assert.NotNull(inf);
        Assert.Equal("劳动节", inf.Name);
        Assert.True(inf.Days >= 2); // 调休可能更长，但法定为 2 天（5/1-5/2）

        var hd = HolidayExtensions.China as ChinaHoliday;
        Assert.NotNull(hd);

        rs = hd.TryGetLaodong(dt, out var hi);
        Assert.True(rs);
        Assert.NotNull(hi);
        Assert.Equal("劳动节", hi.Name);
        Assert.Equal(dt.Year >= 2025 ? 2 : 1, hi.Days);
    }

    [Theory]
    [DisplayName("国庆节推算_数据年与远期年份")]
    [InlineData("2022/10/1")]
    [InlineData("2023/10/1")]
    [InlineData("2122/10/1")]
    public void Test国庆节(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.China.Query(dt).FirstOrDefault();
        Assert.NotNull(inf);
        Assert.Equal("国庆节", inf.Name);
        Assert.True(inf.Days >= 3); // 调休可能更长，但法定为 3 天（10/1-10/3）

        var hd = HolidayExtensions.China as ChinaHoliday;
        Assert.NotNull(hd);

        rs = hd.TryGetGuoqing(dt, out var hi);
        Assert.True(rs);
        Assert.NotNull(hi);
        Assert.Equal("国庆节", hi.Name);
        Assert.Equal(3, hi.Days);
    }

    [Theory]
    [DisplayName("春节推算_远期年份")]
    [InlineData("2029/2/12")]
    [InlineData("2029/2/13")]
    [InlineData("2029/2/14")]
    [InlineData("2029/2/15")]
    public void Test春节2(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.China.Query(dt).FirstOrDefault();
        Assert.NotNull(inf);
        Assert.Equal("春节", inf.Name);
        Assert.True(inf.Days >= 4); // 调休可能更长，但法定为 4 天（除夕至初三）

        var hd = HolidayExtensions.China as ChinaHoliday;
        Assert.NotNull(hd);

        rs = hd.TryGetChunjie(dt, out var hi);
        Assert.True(rs);
        Assert.NotNull(hi);
        Assert.Equal("春节", hi.Name);
        Assert.Equal(4, hi.Days);
    }

    [Theory]
    [DisplayName("端午节推算_远期年份")]
    [InlineData("2029/6/16")]
    public void Test端午节(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.China.Query(dt).FirstOrDefault();
        Assert.NotNull(inf);
        Assert.Equal("端午节", inf.Name);
        Assert.True(inf.Days >= 1);

        var hd = HolidayExtensions.China as ChinaHoliday;
        Assert.NotNull(hd);

        rs = hd.TryGetDuanwu(dt, out var hi);
        Assert.True(rs);
        Assert.NotNull(hi);
        Assert.Equal("端午节", hi.Name);
        Assert.Equal(1, hi.Days);
    }

    [Theory]
    [DisplayName("中秋节推算_远期年份")]
    [InlineData("2029/9/22")]
    public void Test中秋节2(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var inf = HolidayExtensions.China.Query(dt).FirstOrDefault();
        Assert.NotNull(inf);
        Assert.Equal("中秋节", inf.Name);
        Assert.True(inf.Days >= 1);

        var hd = HolidayExtensions.China as ChinaHoliday;
        Assert.NotNull(hd);

        rs = hd.TryGetZhongqiu(dt, out var hi);
        Assert.True(rs);
        Assert.NotNull(hi);
        Assert.Equal("中秋节", hi.Name);
        Assert.Equal(1, hi.Days);
    }

    [Theory]
    [DisplayName("周末兜底判定")]
    [InlineData("2023/9/23")]
    [InlineData("2023/9/24")]
    public void Test周末(String date)
    {
        var dt = TestDate.Parse(date);
        var rs = dt.IsChinaHoliday();

        Assert.True(rs);

        var infs = HolidayExtensions.China.Query(dt).ToList();
        Assert.Empty(infs);
        //foreach (var item in infs)
        //{
        //    Assert.Equal(HolidayStatus.Normal, item.Status);
        //}
    }

    [Fact]
    [DisplayName("固定节日推算_非节日日期均返回false")]
    public void TryGetFixedHoliday_NonHoliday_ReturnFalse()
    {
        var holiday = new ChinaHoliday();
        var date = new DateTime(2023, 3, 15);

        Assert.False(holiday.TryGetYuandan(date, out _));
        Assert.False(holiday.TryGetQingming(date, out _));
        Assert.False(holiday.TryGetLaodong(date, out _));
        Assert.False(holiday.TryGetGuoqing(date, out _));
        Assert.False(holiday.TryGetChunjie(date, out _));
        Assert.False(holiday.TryGetDuanwu(date, out _));
        Assert.False(holiday.TryGetZhongqiu(date, out _));
    }

    [Theory]
    [DisplayName("超出农历范围的年份_固定节日仍可完整查询")]
    [InlineData("1901/1/1")]
    [InlineData("2122/1/1")]
    public void Query_OutOfLunarRange_FixedHolidayStillWorks(String date)
    {
        var dt = TestDate.Parse(date);

        var infos = HolidayExtensions.China.Query(dt).ToList();
        var inf = Assert.Single(infos, e => e.Name == "元旦");
        Assert.Equal(HolidayStatus.On, inf.Status);

        Assert.True(dt.IsChinaHoliday());
        Assert.True(dt.IsGuangxiHoliday());
    }

    [Fact]
    [DisplayName("超出农历范围_农历节日推算安全返回false")]
    public void TryGetLunarHoliday_OutOfRange_ReturnFalse()
    {
        var holiday = new ChinaHoliday();
        var date = new DateTime(2122, 2, 1);

        Assert.False(holiday.TryGetChunjie(date, out _));
        Assert.False(holiday.TryGetDuanwu(date, out _));
        Assert.False(holiday.TryGetZhongqiu(date, out _));
        Assert.False(new GuangxiHoliday().TryGetSanyuesan(date, out _));
    }
}

