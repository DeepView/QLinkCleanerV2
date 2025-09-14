using System.IO;
using System.Text;
namespace QLinkCleanerV2.Core
{
    /// <summary>
    /// 拦截记录辅助类。
    /// </summary>
    public class InterceptionRecordHelper
    {
        private (long interceptTimeTicks, string shortcutName, string from, string path)[] _records;
        /// <summary>
        /// 构造函数，初始化拦截记录数组。
        /// </summary>
        /// <param name="records">所有的拦截记录。</param>
        private InterceptionRecordHelper((long interceptTimeTicks, string shortcutName, string from, string path)[] records) => _records = records;
        /// <summary>
        /// 解析指定文件路径的拦截记录文件，并返回一个 InterceptionRecordHelper 实例。
        /// </summary>
        /// <param name="filePath">拦截记录文件。</param>
        /// <returns>该操作会返回当前实例。</returns>
        /// <exception cref="FileNotFoundException">当拦截记录文件未找到，则将会抛出这个异常。</exception>
        public static InterceptionRecordHelper Parse(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found.", filePath);
            var lines = File.ReadAllLines(filePath, Encoding.UTF8);
            var records = new List<(long interceptTimeTicks, string shortcutName, string from, string path)>();
            if (lines.Length == 0)
                return new InterceptionRecordHelper([.. records]);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length != 4)
                    continue;
                if (!long.TryParse(parts[0], out long ticks))
                    continue;
                records.Add((ticks, parts[1], parts[2], parts[3]));
            }
            return new InterceptionRecordHelper([.. records]);
        }
        /// <summary>
        /// 保存当前的拦截记录到指定的文件路径。
        /// </summary>
        /// <param name="filePath">拦截文件记录的路径。</param>
        public void Save(string filePath)
        {
            var lines = _records.Select(r => $"{r.interceptTimeTicks}|{r.shortcutName}|{r.from}|{r.path}").ToArray();
            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }
        /// <summary>
        /// 新增一条拦截记录。
        /// </summary>
        /// <param name="interceptTimeTicks">记录时间。</param>
        /// <param name="shortcutName">快捷方式名称。</param>
        /// <param name="from">来源。</param>
        /// <param name="path">详细路径。</param>
        public void AddRecord(long interceptTimeTicks, string shortcutName, string from, string path)
        {
            var recordsList = _records.ToList();
            recordsList.Add((interceptTimeTicks, shortcutName, from, path));
            _records = [.. recordsList];
        }
        /// <summary>
        /// 移除指定索引的拦截记录。
        /// </summary>
        /// <param name="index">指定的索引。</param>
        /// <exception cref="ArgumentOutOfRangeException">当索引超出范围时，则将会抛出这个异常。</exception>
        public void RemoveRecordAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            var recordsList = _records.ToList();
            recordsList.RemoveAt(index);
            _records = [.. recordsList];
        }
        /// <summary>
        /// 清空所有的拦截记录。
        /// </summary>
        public void ClearRecords() => _records = [];
        /// <summary>
        /// 获取所有的拦截记录。
        /// </summary>
        /// <returns>该操作会返回所有拦截记录的元组数组表达形式。</returns>
        public (long interceptTimeTicks, string shortcutName, string from, string path)[] GetAllRecords() => _records;
        /// <summary>
        /// 根据指定的条件筛选拦截记录。
        /// </summary>
        /// <param name="predicate">谓词，指定的条件。</param>
        /// <returns>该操作将会返回符合条件的记录。</returns>
        public IEnumerable<(long interceptTimeTicks, string shortcutName, string from, string path)> Where(
            Func<(long interceptTimeTicks, string shortcutName, string from, string path), bool> predicate
        )
        {
            foreach (var record in _records)
            {
                if (predicate(record))
                    yield return record;
            }
        }
        /// <summary>
        /// 获取最新的一条拦截记录。
        /// </summary>
        /// <returns>该操作将会返回一个元组，表示最新的拦截记录。</returns>
        /// <exception cref="InvalidOperationException">当记录计数为0时，则将会抛出这个异常。</exception>
        public (long interceptTimeTicks, string shortcutName, string from, string path) GetLatestRecord()
        {
            if (Count == 0)
                throw new InvalidOperationException("No records available.");
            return _records.OrderByDescending(r => r.interceptTimeTicks).First();
        }
        /// <summary>
        /// 按照来源位置统计拦截记录的数量。
        /// </summary>
        /// <returns>该操作会返回一个元组，用于表示按照来源位置统计的拦截记录的数量。</returns>
        public (int countOfUser,int countOfPublic) GetRecordsCountByLocation()
        {
            int userCount = 0;
            int publicCount = 0;
            foreach (var (interceptTimeTicks, shortcutName, from, path) in _records)
            {
                if (from.Equals("USER", StringComparison.CurrentCultureIgnoreCase))
                    userCount++;
                else if (from.Equals("PUBLIC", StringComparison.CurrentCultureIgnoreCase))
                    publicCount++;
            }
            return (userCount, publicCount);
        }
        /// <summary>
        /// 获取当前拦截记录的数量。
        /// </summary>
        public int Count => _records.Length;
        /// <summary>
        /// 获取或设置指定索引的拦截记录。
        /// </summary>
        /// <param name="index">指定的索引。</param>
        /// <returns>该操作会返回一个元组，用于存储一条拦截记录。</returns>
        /// <exception cref="ArgumentOutOfRangeException">当索引超出范围时，则将会抛出这个异常。</exception>
        public (long interceptTimeTicks, string shortcutName, string from, string path) this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                return _records[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                var recordsList = _records.ToList();
                recordsList[index] = value;
                _records = [.. recordsList];
            }
        }
        /// <summary>
        /// 获取指定索引的拦截记录的字符串表示形式。
        /// </summary>
        /// <param name="index">指定的索引。</param>
        /// <returns>该操作会返回一个字符串，用于表示能让用户阅读的拦截记录。</returns>
        public string GetRecordAsString(int index)
        {
            (long interceptTimeTicks, string shortcutName, string from, string path) r = this[index];
            return GetRecordAsString(r);
        }
        /// <summary>
        /// 获取指定拦截记录的字符串表示形式。
        /// </summary>
        /// <param name="record">指定的拦截记录。</param>
        /// <returns>该操作会返回一个字符串，用于表示能让用户阅读的拦截记录。</returns>
        public static string GetRecordAsString((long interceptTimeTicks, string shortcutName, string from, string path) record)
        {
            var interceptTime = new DateTime(record.interceptTimeTicks);
            return $"记录时间：{interceptTime:G}\r\n快捷方式名称：{record.shortcutName}\r\n来源：{record.from}\r\n详细路径：{record.path}";
        }
    }
}
