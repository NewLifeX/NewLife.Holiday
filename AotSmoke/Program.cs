// NewLife.Holiday NativeAOT compatibility smoke test.
// Runs a fixed set of scenarios against the holiday library and reports PASS/FAIL per scenario.
// Same binary is run under JIT (dotnet run) and NativeAOT (publish -p:PublishAot=true) to compare.
//
// 说明：AOT 能力验收冒烟件，由 .github/workflows/aot.yml 的 aot 矩阵（win-x64/linux-x64/linux-arm64
// 原生 runner）与 loongarch64 job（QEMU + 龙芯 SDK）自动执行（非 0 退出码即失败）。
// 时刻类断言以 UTC 绝对时刻为准，不依赖运行环境本地时区；本地日期断言仅选跨时区稳定的样例。
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Text;
using NewLife;
using NewLife.Holiday;
using NewLife.Log;

try { Console.OutputEncoding = Encoding.UTF8; } catch { }

Console.WriteLine("=== NewLife.Holiday AOT smoke ===");
Console.WriteLine($"framework={RuntimeInformation.FrameworkDescription}");
Console.WriteLine($"OS={RuntimeInformation.OSDescription} Arch={RuntimeInformation.OSArchitecture}");
Console.WriteLine($"IsDynamicCodeSupported={RuntimeFeature.IsDynamicCodeSupported} LocalTimeZone={TimeZoneInfo.Local.Id}");

var results = new List<(String Name, Boolean Ok, String Error)>();
void Run(String name, Action action)
{
    try
    {
        action();
        results.Add((name, true, ""));
        Console.WriteLine($"[PASS] {name}");
    }
    catch (Exception ex)
    {
        results.Add((name, false, $"{ex.GetType().Name}: {ex.Message}"));
        Console.WriteLine($"[FAIL] {name} -> {ex.GetType().Name}: {ex.Message}");
    }
}

// ---------------- 中国假期 ----------------

Run("中国假期-数据加载", () =>
{
    // 嵌入式资源加载：NativeAOT 下验证 GetManifestResourceNames/Stream 全链路可用
    var count = typeof(ChinaHoliday).Assembly.GetManifestResourceNames().Count(e => e.EndsWith(".csv", StringComparison.OrdinalIgnoreCase));
    if (count < 14) throw new Exception($"嵌入式Csv资源数量异常: {count}");

    var china = new ChinaHoliday();
    if (china.Infos.Count < 80) throw new Exception($"内置数据行数异常: {china.Infos.Count}");
    Console.WriteLine($"[diag] csv resources={count} rows={china.Infos.Count}");
});

Run("中国假期-2022春节与调休", () =>
{
    if (!"2022/1/31".ToDateTime().IsChinaHoliday()) throw new Exception("2022/1/31（除夕）应为假期");
    if (!"2022/2/6".ToDateTime().IsChinaHoliday()) throw new Exception("2022/2/6（春节假期内）应为假期");
    if ("2022/2/7".ToDateTime().IsChinaHoliday()) throw new Exception("2022/2/7（节后工作日）应为工作日");
});

Run("中国假期-2026最新数据", () =>
{
    var cases = new (String Date, Boolean Expected)[]
    {
        ("2026/1/1", true),    // 元旦
        ("2026/1/4", false),   // 元旦调休上班
        ("2026/2/15", true),   // 春节假期起
        ("2026/2/14", false),  // 春节调休上班
        ("2026/4/4", true),    // 清明节
        ("2026/5/1", true),    // 劳动节
        ("2026/6/19", true),   // 端午节
        ("2026/9/25", true),   // 中秋节
        ("2026/10/1", true),   // 国庆节
        ("2026/10/10", false), // 国庆调休上班
    };
    foreach (var (date, expected) in cases)
    {
        var rs = date.ToDateTime().IsChinaHoliday();
        if (rs != expected) throw new Exception($"{date} 期望 {expected}，实际 {rs}");
    }
});

Run("中国假期-周末兜底", () =>
{
    if (!"2023/9/23".ToDateTime().IsChinaHoliday()) throw new Exception("2023/9/23（周六）应为假期");
    if ("2023/9/25".ToDateTime().IsChinaHoliday()) throw new Exception("2023/9/25（周一）应为工作日");
});

Run("中国假期-跨数据年预测", () =>
{
    // 2122 年无内置数据，走固定节假日推算
    var cases = new (String Date, Boolean Expected)[]
    {
        ("2122/1/1", true),   // 元旦
        ("2122/4/5", true),   // 清明
        ("2122/5/1", true),   // 劳动节（5/1-5/2 两天）
        ("2122/5/2", true),
        ("2122/10/1", true),  // 国庆（10/1-10/3 三天）
        ("2122/10/3", true),
    };
    foreach (var (date, expected) in cases)
    {
        var rs = date.ToDateTime().IsChinaHoliday();
        if (rs != expected) throw new Exception($"{date} 期望 {expected}，实际 {rs}");
    }
});

Run("中国假期-农历节日预测", () =>
{
    // 2029 年无数据，需依赖 ChineseLunisolarCalendar 推算
    var chunjie = new[] { "2029/2/12", "2029/2/13", "2029/2/14", "2029/2/15" };
    foreach (var d in chunjie)
    {
        var inf = HolidayExtensions.China.Query(d.ToDateTime()).FirstOrDefault();
        if (inf?.Name != "春节") throw new Exception($"{d} 应为春节，实际 {inf?.Name ?? "null"}");
    }

    foreach (var (date, name) in new (String Date, String Name)[] { ("2029/6/16", "端午节"), ("2029/9/22", "中秋节") })
    {
        var inf = HolidayExtensions.China.Query(date.ToDateTime()).FirstOrDefault();
        if (inf?.Name != name) throw new Exception($"{date} 应为{name}，实际 {inf?.Name ?? "null"}");
    }
});

// ---------------- 广西假期 ----------------

Run("广西假期-数据加载与命中", () =>
{
    var gx = new GuangxiHoliday();
    var rows = gx.Infos.Where(e => e.Category == "Guangxi").ToList();
    if (rows.Count < 10) throw new Exception($"广西内置数据行数异常: {rows.Count}");

    var d1 = "2026/4/18".ToDateTime();
    var inf = HolidayExtensions.Guangxi.Query(d1).FirstOrDefault(e => e.Category == "Guangxi");
    if (inf?.Name != "三月三") throw new Exception("2026/4/18 应为广西三月三");
    if (!d1.IsGuangxiHoliday()) throw new Exception("2026/4/18 广西假期判定失败");

    // 2022/4/2 为三月三调休上班
    if ("2022/4/2".ToDateTime().IsGuangxiHoliday()) throw new Exception("2022/4/2（调休上班）应判定为工作日");
});

Run("广西假期-农历预测", () =>
{
    // 2029/4/16 无数据，走农历预测（三月初三）
    var d = "2029/4/16".ToDateTime();
    var inf = HolidayExtensions.Guangxi.Query(d).FirstOrDefault(e => e.Category == "Guangxi");
    if (inf?.Name != "三月三") throw new Exception($"2029/4/16 应为三月三预测，实际 {inf?.Name ?? "null"}");
    if (inf.Days < 2) throw new Exception($"三月三预测天数异常: {inf.Days}");
    if (!d.IsGuangxiHoliday()) throw new Exception("2029/4/16 广西假期判定失败");
});

// ---------------- 农历 ----------------

Run("农历-基础转换", () =>
{
    var lunar = Lunar.FromDateTime(new DateTime(2024, 2, 10));
    if (lunar.YearGanzhi != "甲辰") throw new Exception($"年干支异常: {lunar.YearGanzhi}");
    if (lunar.Zodiac != "龙") throw new Exception($"生肖异常: {lunar.Zodiac}");
    if (lunar.Month != 1 || lunar.Day != 1) throw new Exception($"正月初一异常: {lunar.Month}/{lunar.Day}");
    if (lunar.MonthText != "正" || lunar.DayText != "初一") throw new Exception($"文本异常: {lunar.MonthText}/{lunar.DayText}");
    if (!lunar.ToString().Contains("甲辰年正月初一")) throw new Exception($"ToString 异常: {lunar}");
});

Run("农历-闰月处理", () =>
{
    // 2012（壬辰年）闰四月：2012-05-21 至 2012-06-18
    var lunar = Lunar.FromDateTime(new DateTime(2012, 6, 1));
    if (!lunar.IsLeapMonth) throw new Exception("2012/6/1 应为闰月");
    if (lunar.Month != 4) throw new Exception($"闰月规格化异常: {lunar.Month}");
    if (!lunar.ToString().Contains("闰四月")) throw new Exception($"闰月 ToString 异常: {lunar}");

    // 闰月之后的月份需要回退一个插位：2012/6/20 为五月初二
    var normal = Lunar.FromDateTime(new DateTime(2012, 6, 20));
    if (normal.IsLeapMonth || normal.Month != 5 || normal.Day != 2) throw new Exception($"闰月后规格化异常: {normal}");
});

Run("农历-日文本边界", () =>
{
    var d1 = new DateTime(2024, 2, 10);
    var cases = new (Int32 Offset, String Text)[] { (9, "初十"), (10, "十一"), (19, "二十"), (20, "廿一") };
    foreach (var (offset, text) in cases)
    {
        var lunar = Lunar.FromDateTime(d1.AddDays(offset));
        if (lunar.DayText != text) throw new Exception($"+{offset} 天 期望 {text}，实际 {lunar.DayText}");
    }
});

Run("农历-最近节气", () =>
{
    var r1 = Lunar.FromDateTime(new DateTime(2024, 2, 4)).GetNearestSolarTerm();
    if (r1.Term != SolarTerm.立春 || !r1.IsTermDay) throw new Exception($"2024/2/4 应命中立春: {r1}");

    var r2 = Lunar.FromDateTime(new DateTime(2024, 2, 10)).GetNearestSolarTerm();
    if (r2.Term != SolarTerm.立春 || r2.DaysTo >= 0) throw new Exception($"2024/2/10 应位于立春之后: {r2}");

    var r3 = Lunar.FromDateTime(new DateTime(2024, 1, 30)).GetNearestSolarTerm();
    if (r3.Term != SolarTerm.立春 || r3.DaysTo <= 0) throw new Exception($"2024/1/30 最近节气应为立春（未来）: {r3}");
});

// ---------------- 节气 ----------------

Run("节气-已知日期", () =>
{
    // 仅选取跨时区稳定的样例（节气时刻距两日 0 点均超过 8 小时）
    var cases = new (Int32 Year, SolarTerm Term, String Date)[]
    {
        (2024, SolarTerm.立春, "2024-02-04"),
        (2025, SolarTerm.立春, "2025-02-03"),
        (2023, SolarTerm.冬至, "2023-12-22"),
        (2024, SolarTerm.冬至, "2024-12-21"),
        (2025, SolarTerm.冬至, "2025-12-21"),
    };
    foreach (var (year, term, date) in cases)
    {
        var d = SolarTerms.GetTermDate(year, term);
        if (d != date.ToDateTime().Date) throw new Exception($"{year} {term} 期望 {date}，实际 {d:yyyy-MM-dd}");
    }
});

Run("节气-黄经时刻对照", () =>
{
    // 与权威发布时刻（UTC）对照，验证简化太阳黄经模型精度；给 ±60 分钟窗口
    var cases = new (Int32 Year, SolarTerm Term, DateTime UtcTime)[]
    {
        (2024, SolarTerm.立春, new DateTime(2024, 2, 4, 8, 26, 53, DateTimeKind.Utc)),
        (2025, SolarTerm.立春, new DateTime(2025, 2, 3, 14, 10, 13, DateTimeKind.Utc)),
        (2025, SolarTerm.春分, new DateTime(2025, 3, 20, 9, 1, 24, DateTimeKind.Utc)),
        (2024, SolarTerm.冬至, new DateTime(2024, 12, 21, 9, 20, 20, DateTimeKind.Utc)),
    };
    foreach (var (year, term, utc) in cases)
    {
        var actual = SolarTerms.GetTermTime(year, term).ToUniversalTime();
        var diff = (actual - utc).TotalMinutes;
        Console.WriteLine($"[diag] {year} {term} = {actual:yyyy-MM-dd HH:mm} UTC diff={diff:n0}min");
        if (Math.Abs(diff) > 60) throw new Exception($"{year} {term} 与发布时刻相差 {diff:n0} 分钟，超出 ±60");
    }
});

Run("节气-全年数量与顺序", () =>
{
    var all = SolarTerms.GetAll(2025);
    if (all.Count != 24) throw new Exception($"GetAll 数量异常: {all.Count}");
    if (all[0].Term != SolarTerm.小寒) throw new Exception($"首个节气异常: {all[0].Term}");
    if (all[23].Term != SolarTerm.冬至) throw new Exception($"末个节气异常: {all[23].Term}");

    var times = SolarTerms.GetAllTimes(2025);
    if (times.Count != 24) throw new Exception($"GetAllTimes 数量异常: {times.Count}");

    // 按公历月份递增，且时刻精确到分钟
    var month = 0;
    foreach (var (term, time) in times)
    {
        if (time.Month < month) throw new Exception($"{term} 月份顺序异常");
        month = time.Month;
        if (time.Second != 0) throw new Exception($"{term} 未精确到分钟: {time:HH:mm:ss}");
    }
});

Run("节气-本地日期一致性", () =>
{
    foreach (var (term, time) in SolarTerms.GetAllTimes(2025))
    {
        var date = SolarTerms.GetTermDate(2025, term);
        if (date != time.Date) throw new Exception($"{term} GetTermDate 与 GetTermTime.Date 不一致: {date:yyyy-MM-dd} vs {time:yyyy-MM-dd}");
    }
});

// ---------------- 多语言与日志 ----------------

Run("多语言-运行时翻译与带前缀日志", () =>
{
    var savedCulture = Localization.Culture;
    var savedLogCulture = Localization.LogCulture;
    try
    {
        var result = new SolarTermResult(SolarTerm.春分, new DateTime(2025, 3, 20, 17, 1, 0), new DateTime(2025, 3, 20, 12, 0, 0));

        // 界面语言：编译期词表在 NativeAOT 下可用
        Localization.Culture = CultureInfo.GetCultureInfo("zh-Hans");
        if (!result.ToString().EndsWith("天")) throw new Exception($"中文译文异常: {result}");

        // 带实例前缀日志：先翻译消息再拼接前缀
        Localization.LogCulture = CultureInfo.GetCultureInfo("zh-Hans");
        var log = new ProbeLog();
        _ = new ChinaHoliday(log);
        if (log.Last == null || !log.Last.StartsWith("[ChinaHoliday]")) throw new Exception($"日志前缀异常: {log.Last}");
        if (!log.Last.Contains("条假期记录")) throw new Exception($"日志译文异常: {log.Last}");

        // 无译文的语言回退英文
        Localization.Culture = CultureInfo.GetCultureInfo("en");
        Localization.LogCulture = CultureInfo.GetCultureInfo("sw-KE");
        if (!result.ToString().EndsWith(" days")) throw new Exception($"英文回退异常: {result}");

        log = new ProbeLog();
        _ = new ChinaHoliday(log);
        if (log.Last == null || !log.Last.Contains("holiday records")) throw new Exception($"日志英文回退异常: {log.Last}");
    }
    finally
    {
        Localization.Culture = savedCulture;
        Localization.LogCulture = savedLogCulture;
    }
});

// ---------------- 汇总 ----------------

Console.WriteLine("=== summary ===");
var failed = 0;
foreach (var r in results)
{
    if (!r.Ok) failed++;
    Console.WriteLine($"{(r.Ok ? "PASS" : "FAIL")}\t{r.Name}{(r.Ok ? "" : "\t" + r.Error)}");
}
Console.WriteLine($"total={results.Count} pass={results.Count - failed} fail={failed}");
Environment.ExitCode = failed;

sealed class ProbeLog : ILog
{
    public String? Last { get; private set; }

    public Boolean Enable { get; set; } = true;

    public LogLevel Level { get; set; } = LogLevel.Debug;

    public void Write(LogLevel level, String format, params Object?[] args) => Last = args.Length > 0 ? String.Format(format, args) : format;

    public void Debug(String format, params Object?[] args) => Write(LogLevel.Debug, format, args);

    public void Info(String format, params Object?[] args) => Write(LogLevel.Info, format, args);

    public void Warn(String format, params Object?[] args) => Write(LogLevel.Warn, format, args);

    public void Error(String format, params Object?[] args) => Write(LogLevel.Error, format, args);

    public void Fatal(String format, params Object?[] args) => Write(LogLevel.Fatal, format, args);
}
