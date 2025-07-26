namespace QLinkCleanerV2.Core
{
    /// <summary>
    /// 拦截统计助手类。
    /// </summary>
    public class StatisticalAssistant
    {
        /// <summary>
        /// 增加一次拦截统计。
        /// </summary>
        /// <param name="last">拦截的时间。</param>
        public static void Add(DateTime last)
        {
            Properties.Settings.Default.Intercept_Count++;
            Properties.Settings.Default.Intercept_LastTime = last;
        }
        /// <summary>
        /// 清空拦截统计数据。
        /// </summary>
        public static void Clear()
        {
            Properties.Settings.Default.Intercept_Count = 0;
            Properties.Settings.Default.Intercept_LastTime = DateTime.MinValue;
        }
        /// <summary>
        /// 获取拦截统计数据。
        /// </summary>
        /// <returns>返回一个元组，包含了拦截计数和上一次拦截的日期时间。</returns>
        public static (int count, DateTime last) GetStatistics()
        {
            int _count = Properties.Settings.Default.Intercept_Count;
            DateTime _last = Properties.Settings.Default.Intercept_LastTime;
            return (_count, _last);
        }
    }
}
