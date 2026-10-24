using System.Reflection;
using NewLife.IO;
using NewLife.Log;

namespace NewLife.Holiday;

/// <summary>中国假期</summary>
public class ChinaHoliday : IHoliday
{
    #region 属性
    /// <summary>所有假期信息</summary>
    public IList<HolidayInfo> Infos { get; set; }

    /// <summary>日志对象。默认空日志，需要观察数据加载过程时传入 XTrace.Log 或自定义日志</summary>
    public ILog Log { get; set; } = Logger.Null;

    /// <summary>日志前缀。实例前缀不参与本地化，先翻译消息再拼接</summary>
    public virtual String LogPrefix => $"[{GetType().Name}]";
    #endregion

    #region 构造
    /// <summary>实例化</summary>
    public ChinaHoliday() : this(null) { }

    /// <summary>使用指定日志对象实例化，便于记录数据加载过程</summary>
    /// <param name="log">日志对象，为空时使用空日志</param>
    public ChinaHoliday(ILog log)
    {
        if (log != null) Log = log;

        Load("China");

        // 排序，先按照日期排，再按照状态排，便于放假优先覆盖调休
        if (Infos is List<HolidayInfo> list) Infos = list.OrderBy(x => x.Date).ThenBy(e => e.Status).ToList();
    }

    /// <summary>加载指定前缀的资源</summary>
    /// <param name="category"></param>
    protected virtual void Load(String category)
    {
        // 加载所有嵌入式资源
        var asm = Assembly.GetExecutingAssembly();
        var names = asm.GetManifestResourceNames();

        var files = 0;
        var start = Infos?.Count ?? 0;
        foreach (var item in names)
        {
            if (item.EndsWithIgnoreCase(".csv") && item.Contains($".{category}."))
            {
                using var ms = asm.GetManifestResourceStream(item);
                if (ms == null) continue;

                try
                {
                    Load(ms, category);
                    files++;
                }
                catch (Exception ex)
                {
                    WriteError("Failed to load embedded resource [{0}]: {1}", item, ex.Message);
                    throw;
                }
            }
        }

        if (files == 0)
            WriteWarn("No embedded resources found for [{0}].", category);
        else
            WriteLog("Loaded {0} holiday records from {1} embedded resources for [{2}].", (Infos?.Count ?? 0) - start, files, category);
    }
    #endregion

    #region 方法
    /// <summary>加载Csv数据流中的数据</summary>
    /// <param name="stream"></param>
    /// <param name="category"></param>
    public void Load(Stream stream, String category)
    {
        using var csv = new CsvFile(stream, true);

        var list = Infos ??= [];
        var skip = 0;

        while (true)
        {
            var line = csv.ReadLine();
            if (line == null) break;
            if (line.Length == 0 || line[0].EqualIgnoreCase("Name")) continue;

            var info = new HolidayInfo
            {
                Name = line[0],
                Category = category,
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
            else
            {
                skip++;
            }
        }

        if (skip > 0) WriteDebug("Skipped {0} invalid holiday records from [{1}].", skip, category);
    }

    /// <summary>查询指定日期的假期信息</summary>
    /// <param name="date">指定日期</param>
    /// <returns>假期信息</returns>
    public virtual IEnumerable<HolidayInfo> Query(DateTime date)
    {
        var list = Infos;
        if (list == null || list.Count == 0) yield break;

        // 列表数据少于1000行，直接遍历性能很快
        date = date.Date;
        var count = 0;
        foreach (var inf in list)
        {
            // 后面的数据不会再匹配
            if (inf.Date > date) break;

            if (inf.Date == date)
            {
                count++;
                yield return inf;
            }
            // 多天。起始日已在上方返回，避免同一条记录重复产出
            else if (inf.Days > 1)
            {
                var d = (Int32)(date - inf.Date).TotalDays;
                if (d >= 0 && d < inf.Days)
                {
                    count++;
                    yield return inf;
                }
            }
        }

        // 如果前面没有匹配，强制性假期
        if (count == 0)
        {
            if (TryGetYuandan(date, out var holiday)) yield return holiday;
            if (TryGetQingming(date, out holiday)) yield return holiday;
            if (TryGetLaodong(date, out holiday)) yield return holiday;
            if (TryGetGuoqing(date, out holiday)) yield return holiday;
            if (TryGetChunjie(date, out holiday)) yield return holiday;
            if (TryGetDuanwu(date, out holiday)) yield return holiday;
            if (TryGetZhongqiu(date, out holiday)) yield return holiday;
        }
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

    /// <summary>尝试获取劳动节假期（2025年及以后：5月1-2日，共2天；之前：5月1日，共1天）</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetLaodong(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (date.Month != 5) return false;

        var year = date.Year;
        if (year >= 2025)
        {
            // 2025 起：5/1-5/2 两天
            if (date.Day != 1 && date.Day != 2) return false;

            var start = new DateTime(year, 5, 1);
            holiday = new HolidayInfo
            {
                Name = "劳动节",
                Date = start,
                Days = 2,
                Status = HolidayStatus.On
            };
            return true;
        }
        else
        {
            // 2024 及之前：仅 5/1 一天
            if (date.Day != 1) return false;

            holiday = new HolidayInfo
            {
                Name = "劳动节",
                Date = date.Date,
                Days = 1,
                Status = HolidayStatus.On
            };
            return true;
        }
    }

    /// <summary>尝试获取国庆节假期（10月1-3日，共3天）</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetGuoqing(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (date.Month != 10 || (date.Day < 1 || date.Day > 3)) return false;

        var start = new DateTime(date.Year, 10, 1);
        holiday = new HolidayInfo
        {
            Name = "国庆节",
            Date = start,
            Days = 3,
            Status = HolidayStatus.On
        };

        return true;
    }

    /// <summary>尝试获取春节假期（农历除夕至正月初三，共4天）</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetChunjie(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (!Lunar.IsSupported(date)) return false;

        var lunar = Lunar.FromDateTime(date);
        if (lunar.IsLeapMonth || lunar.Month is not 1 and not 12) return false;

        // 有些年十二月最后一天是二十九，没有三十
        var next = date.AddDays(1);
        var isLastDay = !Lunar.IsSupported(next) || Lunar.FromDateTime(next).Day == 1;

        // 命中范围：除夕 或 正月初一..初三
        var inRange = (lunar.Month == 12 && isLastDay) || (lunar.Month == 1 && lunar.Day <= 3);
        if (!inRange) return false;

        // 统一以“除夕”为起始日，跨度 4 天
        var start = lunar.Month == 12 ? date.Date : date.Date.AddDays(-lunar.Day);

        holiday = new HolidayInfo
        {
            Name = "春节",
            Date = start,
            Days = 4,
            Status = HolidayStatus.On
        };

        return true;
    }

    /// <summary>尝试获取端午节假期</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetDuanwu(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (!Lunar.IsSupported(date)) return false;

        var lunar = Lunar.FromDateTime(date);

        if (lunar.Month == 5 && lunar.Day == 5 && !lunar.IsLeapMonth)
        {
            holiday = new HolidayInfo
            {
                Name = "端午节",
                Date = date.Date,
                Days = 1,
                Status = HolidayStatus.On
            };

            return true;
        }

        return false;
    }

    /// <summary>尝试获取中秋节假期</summary>
    /// <param name="date"></param>
    /// <param name="holiday"></param>
    /// <returns></returns>
    public Boolean TryGetZhongqiu(DateTime date, out HolidayInfo holiday)
    {
        holiday = null;
        if (!Lunar.IsSupported(date)) return false;

        var lunar = Lunar.FromDateTime(date);

        if (lunar.Month == 8 && lunar.Day == 15 && !lunar.IsLeapMonth)
        {
            holiday = new HolidayInfo
            {
                Name = "中秋节",
                Date = date.Date,
                Days = 1,
                Status = HolidayStatus.On
            };

            return true;
        }

        return false;
    }
    #endregion

    #region 日志
    /// <summary>写调试日志。前缀在翻译之后拼接</summary>
    /// <param name="format">格式化模板</param>
    /// <param name="args">格式化参数</param>
    protected virtual void WriteDebug(String format, params Object[] args) => Log?.WritePrefixed(LogLevel.Debug, LogPrefix, format, args);

    /// <summary>写信息日志。前缀在翻译之后拼接</summary>
    /// <param name="format">格式化模板</param>
    /// <param name="args">格式化参数</param>
    protected virtual void WriteLog(String format, params Object[] args) => Log?.InfoPrefixed(LogPrefix, format, args);

    /// <summary>写警告日志。前缀在翻译之后拼接</summary>
    /// <param name="format">格式化模板</param>
    /// <param name="args">格式化参数</param>
    protected virtual void WriteWarn(String format, params Object[] args) => Log?.WritePrefixed(LogLevel.Warn, LogPrefix, format, args);

    /// <summary>写错误日志。前缀在翻译之后拼接</summary>
    /// <param name="format">格式化模板</param>
    /// <param name="args">格式化参数</param>
    protected virtual void WriteError(String format, params Object[] args) => Log?.ErrorPrefixed(LogPrefix, format, args);
    #endregion
}
