using Carlos.Extends;
namespace QLinkCleanerV2.Core
{
    /// <summary>
    /// 列表数据项。
    /// </summary>
    public class ListData
    {
        /// <summary>
        /// 获取或设置需要被监视的快捷方式名称（不包含后缀名）。
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置是否监视当前用户桌面的快捷方式。
        /// </summary>
        public bool IsWatchingUserDesktop { get; set; } = true;
        /// <summary>
        /// 获取或设置是否监视公共桌面的快捷方式。
        /// </summary>
        public bool IsWatchingPublicDesktop { get; set; } = true;
        /// <summary>
        /// 获取或设置当前快捷方式最后一次被拦截的时间。
        /// </summary>
        public DateTime? LastTimeOfInterception { get; set; } = null;
        /// <summary>
        /// 创建一个具有文件名的新列表数据项。
        /// </summary>
        /// <param name="name">快捷方式的文件名。</param>
        public ListData(string name)
        {
            if (!FileNameCheck(name))
                throw new NotSupportedException(
                    "文件名不合法，可能包含非法字符、保留关键字、长度超出限制或为空白名称。"
                );
            else Name = name;
        }
        /// <summary>
        /// 创建一个具有文件名和文件类型的新列表数据项。
        /// </summary>
        /// <param name="name">快捷方式的文件名。</param>
        /// <param name="type">快捷方式的文件类型。</param>
        /// <param name="isWatchingUserDesktop">是否监视当前用户桌面的快捷方式。</param>
        /// <param name="isWatchingPublicDesktop">是否监视公共桌面的快捷方式。</param>
        public ListData(
            string name,
            bool isWatchingUserDesktop = true,
            bool isWatchingPublicDesktop = true)
        {
            FileNameCheck(name);
            Name = name;
            IsWatchingUserDesktop = isWatchingUserDesktop;
            IsWatchingPublicDesktop = isWatchingPublicDesktop;
        }
        /// <summary>
        /// 文件名称合法性检查。
        /// </summary>
        /// <param name="name">文件名称（不含后缀名）。</param>
        /// <exception cref="ArgumentException">一旦文件名不合法，比如包含非法字符，包含保留关键字，长度超出限制和设置为空白名称，则将会抛出这个异常。</exception>
        public static bool FileNameCheck(string name)
        {
            bool isValid = true;
            string invalidCharsPattern = @"[\/:*?""<>|]";
            string[] reservedNames = [
                "CON", "PRN", "AUX", "NUL",
                "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
            ];
            string baseName = name.ToUpper();
            if (string.IsNullOrEmpty(name))
                isValid = false;
            if (name.Match(invalidCharsPattern))
                isValid = false;
            if (Array.Exists(reservedNames, name => name == baseName))
                isValid = false;
            if (name.Length > 255)
                isValid = false;
            return isValid;
        }
        /// <summary>
        /// 获取当前列表数据项的字符串表示形式。
        /// </summary>
        /// <returns>该操作会返回一个字符串，这个字符串为当前实例的字符串表达形式。</returns>
        public override string ToString()
        {
            long dateTicks;
            if (LastTimeOfInterception == null)
                dateTicks = -1;
            else
                dateTicks = LastTimeOfInterception.Value.Ticks;
            return $@"{Name}|{IsWatchingUserDesktop}|{IsWatchingPublicDesktop}|{dateTicks}";
        }
        /// <summary>
        /// 解析一个字符串为 ListData 实例。
        /// </summary>
        /// <param name="data">需要被解析的数据。</param>
        /// <returns>该操作将会返回一个ListData对象。</returns>
        /// <exception cref="FormatException">如果格式有误，则将会抛出这个异常。</exception>
        public static ListData Parse(string data)
        {
            var parts = data.Split('|');
            if (parts.Length < 4)
                throw new FormatException("Invalid ListData format.");
            return new ListData(
                name: parts[0],
                isWatchingUserDesktop: bool.Parse(parts[1]),
                isWatchingPublicDesktop: bool.Parse(parts[2])
            )
            {
                LastTimeOfInterception = long.TryParse(parts[3], out long ticks) && ticks >= 0 ? new DateTime(ticks) : null
            };
        }
    }
}
