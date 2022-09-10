namespace NewLife.Holiday;

/// <summary>假期扩展</summary>
public static class HolidayExtensions
{
    /// <summary>中国假期</summary>
    public static IHoliday China { get; set; } = new ChinaHoliday();

    /// <summary>是否中国假期</summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static Boolean IsChinaHoliday(this DateTime date)
    {
        var inf = China.Query(date);
        if (inf != null)
        {
            switch (inf.Status)
            {
                case HolidayStatus.Normal:
                    break;
                case HolidayStatus.On:
                    return true;
                case HolidayStatus.Off:
                    return false;
                default:
                    break;
            }
        }

        return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }
}