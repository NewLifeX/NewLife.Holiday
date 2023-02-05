using System.Globalization;

namespace NewLife.Holiday;

/// <summary>中国农历</summary>
public class ChineseLunisolar
{
    /// <summary>转农历字符串</summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static String Convert(DateTime date)
    {
        var cal = new ChineseLunisolarCalendar();

        var year = cal.GetYear(date);
        var month = cal.GetMonth(date);
        var day = cal.GetDayOfMonth(date);
        var leapMonth = cal.GetLeapMonth(year);
        return String.Format("农历{0}{1}（{2}）年{3}{4}月{5}{6}"
                            , "甲乙丙丁戊己庚辛壬癸"[(year - 4) % 10]
                            , "子丑寅卯辰巳午未申酉戌亥"[(year - 4) % 12]
                            , "鼠牛虎兔龙蛇马羊猴鸡狗猪"[(year - 4) % 12]
                            , month == leapMonth ? "闰" : ""
                            , "无正二三四五六七八九十冬腊"[leapMonth > 0 && leapMonth <= month ? month - 1 : month]
                            , "初十廿三"[day / 10]
                            , "日一二三四五六七八九"[day % 10]
                            );
    }
}