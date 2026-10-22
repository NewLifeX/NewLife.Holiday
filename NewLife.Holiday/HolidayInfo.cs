using NewLife;

namespace NewLife.Holiday;

/// <summary>
/// 假期信息
/// </summary>
public class HolidayInfo
{
    #region 属性
    /// <summary>名称</summary>
    public String Name { get; set; }

    /// <summary>本地化名称。按当前界面语言翻译假期名称，未提供译文时回退原名</summary>
    public String DisplayName => Name.IsNullOrEmpty() ? Name : Localization.Translate(Name);

    /// <summary>分类</summary>
    public String Category { get;set; }

    /// <summary>日期</summary>
    public DateTime Date { get; set; }

    /// <summary>天数。从Date日期算起的天数，默认1</summary>
    public Int32 Days { get; set; }

    /// <summary>假期状态。常规、放假、调休</summary>
    public HolidayStatus Status { get; set; }
    #endregion
}