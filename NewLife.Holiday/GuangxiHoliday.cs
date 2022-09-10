namespace NewLife.Holiday;

/// <summary>广西假期。特有三月三</summary>
public class GuangxiHoliday : ChinaHoliday
{
    #region 构造
    /// <summary>实例化</summary>
    public GuangxiHoliday()
    {
        // 加载所有嵌入式资源
        //Load("China");
        Load("Guangxi");

        // 排序，先按照日期排，再按照状态排，便于放假优先覆盖调休
        if (Infos is List<HolidayInfo> list) Infos = list.OrderBy(x => x.Date).ThenBy(e => e.Status).ToList();
    }
    #endregion
}