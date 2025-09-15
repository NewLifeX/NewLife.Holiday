using System;
using System.Collections.Generic;

namespace NewLife.Holiday;

/// <summary>
/// 24节气枚举（按公历月份顺序：1月小寒起，至12月冬至止）
/// </summary>
public enum SolarTerm
{
    /// <summary>小寒（1月）</summary>
    小寒 = 0,
    /// <summary>大寒（1月）</summary>
    大寒 = 1,
    /// <summary>立春（2月）</summary>
    立春 = 2,
    /// <summary>雨水（2月）</summary>
    雨水 = 3,
    /// <summary>惊蛰（3月）</summary>
    惊蛰 = 4,
    /// <summary>春分（3月）</summary>
    春分 = 5,
    /// <summary>清明（4月）</summary>
    清明 = 6,
    /// <summary>谷雨（4月）</summary>
    谷雨 = 7,
    /// <summary>立夏（5月）</summary>
    立夏 = 8,
    /// <summary>小满（5月）</summary>
    小满 = 9,
    /// <summary>芒种（6月）</summary>
    芒种 = 10,
    /// <summary>夏至（6月）</summary>
    夏至 = 11,
    /// <summary>小暑（7月）</summary>
    小暑 = 12,
    /// <summary>大暑（7月）</summary>
    大暑 = 13,
    /// <summary>立秋（8月）</summary>
    立秋 = 14,
    /// <summary>处暑（8月）</summary>
    处暑 = 15,
    /// <summary>白露（9月）</summary>
    白露 = 16,
    /// <summary>秋分（9月）</summary>
    秋分 = 17,
    /// <summary>寒露（10月）</summary>
    寒露 = 18,
    /// <summary>霜降（10月）</summary>
    霜降 = 19,
    /// <summary>立冬（11月）</summary>
    立冬 = 20,
    /// <summary>小雪（11月）</summary>
    小雪 = 21,
    /// <summary>大雪（12月）</summary>
    大雪 = 22,
    /// <summary>冬至（12月）</summary>
    冬至 = 23,
}

/// <summary>
/// 指定时间点相对最近节气的结果。
/// </summary>
/// <remarks>
/// 使用指定节气日期与参考时间构造结果。
/// </remarks>
/// <param name="term">节气。</param>
/// <param name="termDate">节气的公历日期（按本地时区，时间部分忽略）。</param>
/// <param name="from">参考时间。</param>
public readonly struct SolarTermResult(SolarTerm term, DateTime termDate, DateTime from)
{
    /// <summary>最近的节气。</summary>
    public SolarTerm Term { get; } = term;

    /// <summary>节气对应的公历日期（本地时区零点）。</summary>
    public DateTime TermDate { get; } = termDate.Date;

    /// <summary>
    /// 与节气日零点的带符号天数差。
    /// 指定时间在节气之前为正数，在节气之后为负数，可为小数。
    /// </summary>
    public Double DaysTo { get; } = (termDate.Date - from).TotalDays;

    /// <summary>指定时间当天是否就是该节气日。</summary>
    public Boolean IsTermDay { get; } = from.Date == termDate.Date;

    /// <summary>指定日期是否在节气日前后一天（含节气日）。</summary>
    public Boolean IsWithinOneDay { get; } = Math.Abs((from.Date - termDate.Date).TotalDays) <= 1;

    /// <summary>格式化为“节气 yyyy-MM-dd ±X天”。</summary>
    public override String ToString() => $"{Term} {TermDate:yyyy-MM-dd} {(DaysTo >= 0 ? "+" : "")}{DaysTo:0.#}天";
}

/// <summary>
/// 24节气计算（1901-2100 近似算法，按日精度）。
/// </summary>
/// <remarks>
/// 使用常见近似算法 day = floor(Y * D + C) - floor((Y - 1)/4)。
/// 其中 Y 为公历年后两位；C 为20/21世纪常数；D = 0.2422。
/// 范围 1901-2100，按日精度，个别年份存在 ±1 天误差，代码中包含少量修正项。
/// 结果为本地时区的公历日期（时间部分为 00:00:00）。
/// </remarks>
public static class SolarTerms
{
    // 近似算法：day = floor(Y * D + C) - floor((Y - 1)/4)
    // 其中 Y 为公历年后两位；C 为各节气常数（20世纪 / 21世纪），D = 0.2422。
    // 该算法能在 1901-2100 年范围内给出节气的公历日期（少数年份可能会有 ±1 天误差）。

    private const Double D = 0.2422;

    // 与枚举顺序完全一致（小寒..冬至）
    private static readonly Double[] C20 = // 1901-2000
    {
        6.11, 20.84, 4.6295, 19.4599, 6.3826, 21.4155, 5.59, 20.888, 6.318, 21.86, 6.5, 22.20,
        7.928, 23.65, 8.35, 23.95, 8.44, 23.822, 9.098, 24.218, 8.218, 23.08, 7.9, 22.60
    };

    private static readonly Double[] C21 = // 2001-2100
    {
        5.4055, 20.12, 3.87, 18.73, 5.63, 20.646, 4.81, 20.1, 5.52, 21.04, 5.678, 21.37,
        7.108, 22.83, 7.5, 23.13, 7.646, 23.042, 8.318, 23.438, 7.438, 22.36, 7.18, 21.94
    };

    // 每个节气对应的公历月份（与枚举顺序一一对应）
    private static readonly Int32[] TermMonths =
    {
        1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6,
        7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12
    };

    /// <summary>
    /// 计算指定年份的某个节气在公历中的日期（零点）。
    /// </summary>
    /// <param name="year">公历年。</param>
    /// <param name="term">节气。</param>
    /// <returns>节气的公历日期（本地时区零点）。</returns>
    public static DateTime GetTermDate(Int32 year, SolarTerm term)
    {
        var idx = (Int32)term;
        var month = TermMonths[idx];
        var y = year % 100;
        var c = year >= 2001 ? C21[idx] : C20[idx];
        // 基本修正项
        var l = (Int32)Math.Floor((y - 1) / 4.0);
        var day = (Int32)Math.Floor(y * D + c) - l;

        // 个别年份的已知修正（少量特殊年，避免 ±1 天误差）。
        day += SpecialOffset(year, term);

        return new DateTime(year, month, day);
    }

    /// <summary>
    /// 返回某年的全部24节气日期。
    /// </summary>
    /// <param name="year">公历年。</param>
    /// <returns>按节气顺序（小寒..冬至）的列表。</returns>
    public static IReadOnlyList<(SolarTerm Term, DateTime Date)> GetAll(Int32 year)
    {
        var list = new List<(SolarTerm, DateTime)>(24);
        for (var i = 0; i < 24; i++)
        {
            var t = (SolarTerm)i;
            list.Add((t, GetTermDate(year, t)));
        }
        return list;
    }

    /// <summary>
    /// 已知特殊年份的日数微调（覆盖常见误差）。未列出的返回 0。
    /// </summary>
    private static Int32 SpecialOffset(Int32 year, SolarTerm term)
    {
        // 仅列举较为常见的偏差修正，保持轻量。
        // 资料来源于公共领域常用近似法总结，1901-2100 少量年份会发生 ±1 天误差。
        switch (term)
        {
            case SolarTerm.春分:
                if (year == 2084) return -1;
                break;
            case SolarTerm.夏至:
                if (year == 2002) return 1;
                break;
            case SolarTerm.小暑:
                if (year == 2016) return 1;
                break;
            case SolarTerm.白露:
                if (year == 2002) return 1;
                break;
            case SolarTerm.冬至:
                if (year == 1918) return 1;
                if (year == 2021) return -1;
                break;
        }
        return 0;
    }
}
