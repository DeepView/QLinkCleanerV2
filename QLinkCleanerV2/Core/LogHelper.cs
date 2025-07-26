namespace QLinkCleanerV2.Core
{
    /// <summary>
    /// 日志记录帮助类。
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 创建一个新的日志记录帮助类实例。
        /// </summary>
        /// <param name="logFilePath">指定的日志文件。</param>
        public LogHelper(string logFilePath)
        {
            LogFilePath = logFilePath;
            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath).Close(); // Ensure the file exists
            }
        }
        /// <summary>
        /// 获取或设置日志文件的路径。
        /// </summary>
        public string LogFilePath { get; set; }
        /// <summary>
        /// 记录一条日志。
        /// </summary>
        /// <param name="category">日志类型。</param>
        /// <param name="level">日志级别。</param>
        /// <param name="message">日志内容。</param>
        public void Record(string category, LogLevel level, string message)
        {
            try
            {
                File.AppendAllText(LogFilePath, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} * {category} * {level} * {message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log: {ex.Message}");
            }
        }
        /// <summary>
        /// 生成一个新的日志文件名。
        /// </summary>
        /// <returns>该操作将会返回一个字符串，表示log文件名称。</returns>
        public static string GenerateLogFileName() => $"app__{DateTime.Now:yyyy-MM-dd__HH-mm-ss}.log";
        /// <summary>
        /// 解析一行日志内容。
        /// </summary>
        /// <param name="line">一行日志内容。</param>
        /// <returns>该操作会返回一个元组，这个元组包含了以Ticks形式记录的日志时间信息，日志类型，日志的记录级别，以及日志的内容。</returns>
        /// <exception cref="FormatException">如果这条日志格式出错导致无法解析，则将会抛出这个异常。</exception>
        public static (long ticks, string category, LogLevel level, string message) ParseLogLine(string line)
        {
            var parts = line.Split(['*'], 4);
            if (parts.Length < 4) throw new FormatException("Invalid log line format.");
            return (
                ticks: DateTime.Parse(parts[0].Trim()).Ticks,
                category: parts[1].Trim(),
                level: Enum.TryParse<LogLevel>(parts[2].Trim(), out var level) ? level : LogLevel.Info,
                message: parts[3].Trim()
            );
        }
    }
    /// <summary>
    /// 日志的级别枚举
    /// </summary>
    public enum LogLevel : int
    {
        /// <summary>
        /// 信息级别。
        /// </summary>
        Info = 0x0000,
        /// <summary>
        /// 警告级别。
        /// </summary>
        Warning = 0x0001,
        /// <summary>
        /// 错误级别。
        /// </summary>
        Error = 0x0002,
        /// <summary>
        /// 调试级别。
        /// </summary>
        Debug = 0xffff
    }
}
