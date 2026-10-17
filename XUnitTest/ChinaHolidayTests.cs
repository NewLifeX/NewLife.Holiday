using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using NewLife.Holiday;
using Xunit;

namespace XUnitTest;

public class ChinaHolidayTests
{
    [Fact]
    [DisplayName("加载自定义CSV_解析有效行并跳过无效行")]
    public void Load_CustomCsv_ParsesValidRowsAndSkipsInvalid()
    {
        const String csv = "Name,Date,Days,Status\r\n测试节,2026-05-20,0,1\r\n无效,0999-01-01,1,1\r\n调休日,2026-05-21,1,2\r\n";

        var holiday = new ChinaHoliday { Infos = [] };
        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));
        holiday.Load(stream, "Test");

        Assert.Equal(2, holiday.Infos.Count);

        var on = Assert.Single(holiday.Infos, e => e.Name == "测试节");
        Assert.Equal("Test", on.Category);
        Assert.Equal(new DateTime(2026, 5, 20), on.Date);
        Assert.Equal(1, on.Days);
        Assert.Equal(HolidayStatus.On, on.Status);

        var off = Assert.Single(holiday.Infos, e => e.Name == "调休日");
        Assert.Equal(HolidayStatus.Off, off.Status);
    }

    [Fact]
    [DisplayName("多天假期查询_覆盖起止日期且不越界")]
    public void Query_MultiDayHoliday_CoversRange()
    {
        var holiday = new ChinaHoliday
        {
            Infos =
            [
                new HolidayInfo { Name = "测试节", Category = "Test", Date = new DateTime(2026, 10, 1), Days = 3, Status = HolidayStatus.On }
            ]
        };

        Assert.Single(holiday.Query(new DateTime(2026, 10, 1)));
        Assert.Single(holiday.Query(new DateTime(2026, 10, 3)));
        Assert.Empty(holiday.Query(new DateTime(2026, 10, 4)));
    }

    [Fact]
    [DisplayName("内置数据_按日期和状态升序排序")]
    public void Constructor_EmbeddedData_IsSorted()
    {
        var holiday = new ChinaHoliday();

        Assert.NotEmpty(holiday.Infos);
        for (var i = 1; i < holiday.Infos.Count; i++)
        {
            var prev = holiday.Infos[i - 1];
            var curr = holiday.Infos[i];

            Assert.True(prev.Date < curr.Date || prev.Date == curr.Date && prev.Status <= curr.Status);
        }
    }
}
