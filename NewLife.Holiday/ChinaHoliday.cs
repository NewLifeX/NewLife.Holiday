﻿using System.Reflection;
using NewLife.IO;

namespace NewLife.Holiday;

/// <summary>中国假期</summary>
public class ChinaHoliday : IHoliday
{
    #region 属性
    /// <summary>所有假期信息</summary>
    public IList<HolidayInfo> Infos { get; set; }
    #endregion

    #region 构造
    /// <summary>实例化</summary>
    public ChinaHoliday()
    {
        // 加载所有嵌入式资源
        var asm = Assembly.GetExecutingAssembly();
        var names = asm.GetManifestResourceNames();

        foreach (var item in names)
        {
            if (item.EndsWithIgnoreCase(".csv"))
            {
                var ms = asm.GetManifestResourceStream(item);
                Load(ms);
            }
        }

        if (Infos is List<HolidayInfo> list) list = list.OrderBy(x => x.Date).ToList();
    }
    #endregion

    #region 方法
    /// <summary>加载Csv数据流中的数据</summary>
    /// <param name="stream"></param>
    public void Load(Stream stream)
    {
        using var csv = new CsvFile(stream, true);

        var list = Infos ??= new List<HolidayInfo>();

        while (true)
        {
            var line = csv.ReadLine();
            if (line == null) break;
            if (line.Length == 0 || line[0].EqualIgnoreCase("Name")) continue;

            var info = new HolidayInfo
            {
                Name = line[0],
                Date = line[1].ToDateTime().Date,
                Days = line[2].ToInt(),
                Status = (HolidayStatus)line[3].ToInt(),
            };

            // 有效假期数据
            if (info.Date.Year > 1000)
            {
                if (info.Days <= 0) info.Days = 1;

                list.Add(info);
            }
        }
    }

    /// <summary>查询指定日期的假期信息</summary>
    /// <param name="date">指定日期</param>
    /// <returns>假期信息</returns>
    public HolidayInfo Query(DateTime date)
    {
        var list = Infos;
        if (list == null || list.Count == 0) return null;

        // 列表数据少于1000行，直接遍历性能很快
        date = date.Date;
        foreach (var inf in list)
        {
            if (inf.Date == date) return inf;

            // 多天
            if (inf.Days > 1)
            {
                var d = (Int32)(date - inf.Date).TotalDays;
                if (d >= 0 && d < inf.Days) return inf;
            }
        }

        // 强制性假期
        if (TryGetYuandan(date, out var holiday)) return holiday;
        if (TryGetQingming(date, out holiday)) return holiday;
        if (TryGetLaodong(date, out holiday)) return holiday;
        if (TryGetGuoqing(date, out holiday)) return holiday;

        return null;
    }

    /// <summary>尝试获取元旦假期</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetYuandan(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (date.Month != 1 || date.Day != 1) return false;

        holiday = new HolidayInfo
        {
            Name = "元旦",
            Date = date.Date,
            Days = 1,
            Status = HolidayStatus.On
        };

        return true;
    }

    /// <summary>尝试获取清明节假期</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetQingming(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (date.Month != 4 || date.Day != 5) return false;

        holiday = new HolidayInfo
        {
            Name = "清明节",
            Date = date.Date,
            Days = 1,
            Status = HolidayStatus.On
        };

        return true;
    }

    /// <summary>尝试获取劳动节假期</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetLaodong(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (date.Month != 5 || date.Day != 1) return false;

        holiday = new HolidayInfo
        {
            Name = "劳动节",
            Date = date.Date,
            Days = 3,
            Status = HolidayStatus.On
        };

        return true;
    }

    /// <summary>尝试获取国庆节假期</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetGuoqing(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (date.Month != 10 || date.Day != 1) return false;

        holiday = new HolidayInfo
        {
            Name = "国庆节",
            Date = date.Date,
            Days = 3,
            Status = HolidayStatus.On
        };

        return true;
    }
    #endregion
}