using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLinkCleanerV2.Core
{
    /// <summary>
    /// 监视器类，用于监视桌面快捷方式，并提供快捷方式的自动清理功能。
    /// </summary>
    public class Watcher
    {
        private readonly FileSystemWatcher[] _watchers;
        private string[] _userDesktopWatchList;
        private string[] _publicDesktopWatchList;
        private readonly LogHelper _log;
        private readonly Lock __sync_lock = new();
        private int _tiggeringCountOfEvents = 0;
        private readonly InterceptionResultForm _interceptionResultForm;
        /// <summary>
        /// 创建一个新的监视器实例。
        /// </summary>
        /// <param name="strategy">监视器策略。</param>
        /// <param name="logFilePath">日志文件路径。</param>
        public Watcher(WatcherStrategy strategy, string logFilePath)
        {
            if (!Directory.Exists("log"))
                Directory.CreateDirectory("log");
            _watchers = [
                new FileSystemWatcher(GetUserDesktopDirectory()),
                new FileSystemWatcher(GetPublicDesktopDirectory())
            ];
            _userDesktopWatchList = [];
            _publicDesktopWatchList = [];
            _log = new LogHelper(logFilePath);
            Strategy = strategy;

            _interceptionResultForm = new();

            Log("Watcher", LogLevel.Info, "监视器已创建，正在初始化。");
        }
        /// <summary>
        /// 获取或设置监视器策略。
        /// </summary>
        public WatcherStrategy Strategy { get; set; }
        /// <summary>
        /// 获取或设置监视器的清单。
        /// </summary>
        public Manifest Manifest { get; set; } = [];
        /// <summary>
        /// 初始化监视列表。
        /// </summary>
        public void InitList()
        {
            _userDesktopWatchList = [.. Manifest
                .Where(x => x.IsWatchingUserDesktop)
                .Select(x => x.Name)];
            _publicDesktopWatchList = [.. Manifest
                .Where(x => x.IsWatchingPublicDesktop)
                .Select(x => x.Name)];
            Log("Manifest", LogLevel.Info, "已初始化监视列表。");
        }
        /// <summary>
        /// 监视器事件触发计数器自增一次。
        /// </summary>
        public void TiggeringCountOfEventsAdd()
        {
            lock (__sync_lock)
            {
                _tiggeringCountOfEvents++;
            }
        }
        /// <summary>
        /// 监视器事件触发计数器重置为0。
        /// </summary>
        public void TiggeringCountOfEventsReset()
        {
            lock (__sync_lock)
            {
                _tiggeringCountOfEvents = 0;
            }
        }

        /// <summary>
        /// 开始监视桌面快捷方式。
        /// </summary>
        public void Start()
        {
            InitList();
            foreach (var watcher in _watchers)
            {
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Size;
                watcher.Filter = "*";
                watcher.Deleted += OnDeleted;
            }
            _watchers[0].Created += UserDesktopWatchEvent;
            _watchers[1].Created += PublicDesktopWatchEvent;
            _watchers[0].Changed += UserDesktopWatchEvent;
            _watchers[1].Changed += PublicDesktopWatchEvent;
            _watchers[0].Renamed += UserDesktopWatchEvent;
            _watchers[1].Renamed += PublicDesktopWatchEvent;
            foreach (var watcher in _watchers) watcher.EnableRaisingEvents = true;
            Log("Watcher", LogLevel.Info, "监视器已启动，正在保护您的桌面。");
        }
        /// <summary>
        /// 停止监视桌面快捷方式。
        /// </summary>
        public void Stop()
        {
            foreach (var watcher in _watchers)
            {
                watcher.EnableRaisingEvents = false;
                //watcher.Dispose();
            }
            Log("Watcher", LogLevel.Warning, "监视器已停止，您的桌面已经停止保护。");
        }
        public void RemoveShortcut(string file, DesktopType desktopType)
        {
            bool isDeleted = false;
            int loopCount = 0;
            int maxLoopCount = Properties.Settings.Default.App_MaxRetryTimesWithDelShortcut;
            string dir_usr = @"removed\user";
            string dir_pub = @"removed\public";
            if (!Directory.Exists(dir_usr))
                Directory.CreateDirectory(dir_usr);
            if (!Directory.Exists(dir_pub))
                Directory.CreateDirectory(dir_pub);
            string filename = Path.GetFileName(file);
            do
            {
                try
                {
                    File.Copy(file, $@"removed\{desktopType.ToString().ToLower()}\{filename}", true);
                    File.Delete(file);
                }
                catch (Exception throwedException)
                {
                    if (throwedException != null)
                    {
                        loopCount++;
                        if (loopCount > maxLoopCount)
                        {
                            Log("Watcher", LogLevel.Error, $"无法删除快捷方式文件：{file}。尝试删除的次数：{loopCount}");
                            return;// 重试次数超过指定次数，强行退出循环，并退出方法。
                        }
                        Thread.Sleep(100); // 等待1秒后重试
                    }
                }
            } while (File.Exists(file));
        }
        /// <summary>
        /// 用户桌面监视事件处理方法。
        /// </summary>
        /// <param name="sender">事件的发送源。</param>
        /// <param name="e">事件参数。</param>
        private void UserDesktopWatchEvent(object sender, FileSystemEventArgs e)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(e.Name);
            bool isShortcut = e.FullPath.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase);
            bool isUrl = e.FullPath.EndsWith(".url", StringComparison.OrdinalIgnoreCase);
            bool isContains = _userDesktopWatchList.Contains(fileNameWithoutExtension, StringComparer.OrdinalIgnoreCase);
            switch (Strategy)
            {
                case WatcherStrategy.All:
                    if (isShortcut || isUrl)
                    {
                        if (File.Exists(e.FullPath))
                        {
                            RemoveShortcut(e.FullPath, DesktopType.User);
                            TiggeringCountOfEventsAdd();
                        }
                    }
                    break;
                case WatcherStrategy.Blacklist:
                    if (isShortcut || isUrl)
                        if (isContains)
                        {
                            if (File.Exists(e.FullPath))
                            {
                                RemoveShortcut(e.FullPath, DesktopType.User);
                                DateTime last = DateTime.Now;
                                Manifest
                                    .Where(item => item.Name == fileNameWithoutExtension)
                                    .ToList()
                                    .ForEach(item => item.LastTimeOfInterception = last);
                                TiggeringCountOfEventsAdd();
                            }
                        }
                    break;
                case WatcherStrategy.Whitelist:
                    if (isShortcut || isUrl)
                        if (!isContains)
                        {
                            if (File.Exists(e.FullPath))
                            {
                                RemoveShortcut(e.FullPath, DesktopType.User);
                                TiggeringCountOfEventsAdd();
                            }
                        }
                    break;
            }
        }
        /// <summary>
        /// 公共桌面监视事件处理方法。
        /// </summary>
        /// <param name="sender">事件的发送源。</param>
        /// <param name="e">事件参数。</param>
        private void PublicDesktopWatchEvent(object sender, FileSystemEventArgs e)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(e.Name);
            bool isShortcut = e.FullPath.EndsWith(".lnk", StringComparison.OrdinalIgnoreCase);
            bool isUrl = e.FullPath.EndsWith(".url", StringComparison.OrdinalIgnoreCase);
            bool isContains = _publicDesktopWatchList.Contains(fileNameWithoutExtension, StringComparer.OrdinalIgnoreCase);
            switch (Strategy)
            {
                case WatcherStrategy.All:
                    if (isShortcut || isUrl)
                    {
                        if (File.Exists(e.FullPath))
                        {
                            RemoveShortcut(e.FullPath, DesktopType.Public);
                            TiggeringCountOfEventsAdd();
                        }
                    }
                    break;
                case WatcherStrategy.Blacklist:
                    if (isShortcut || isUrl)
                        if (isContains)
                        {
                            if (File.Exists(e.FullPath))
                            {
                                RemoveShortcut(e.FullPath, DesktopType.Public);
                                DateTime last = DateTime.Now;
                                Manifest
                                    .Where(item => item.Name == fileNameWithoutExtension)
                                    .ToList()
                                    .ForEach(item => item.LastTimeOfInterception = last);
                                TiggeringCountOfEventsAdd();
                            }
                        }
                    break;
                case WatcherStrategy.Whitelist:
                    if (isShortcut || isUrl)
                        if (!isContains)
                        {
                            if (File.Exists(e.FullPath))
                            {
                                RemoveShortcut(e.FullPath, DesktopType.Public);
                                TiggeringCountOfEventsAdd();
                            }
                        }
                    break;
            }
        }
        /// <summary>
        /// 删除事件处理方法。
        /// </summary>
        /// <param name="sender">事件的发送源。</param>
        /// <param name="e">事件参数。</param>
        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(e.Name);
            DateTime last = DateTime.Now;
            foreach (
                var item in
                from item in Manifest
                where item.Name == fileNameWithoutExtension
                select item
            ) item.LastTimeOfInterception = last;
            if (File.Exists(e.FullPath))
                Log("Watcher", LogLevel.Error, $"发生严重错误，快捷方式/URL文件 {e.FullPath} 清除失败。");
            else
            {
                if (_tiggeringCountOfEvents > 0)
                {
                    TiggeringCountOfEventsReset();

                    DesktopType desktopType = e.FullPath.StartsWith(
                        GetUserDesktopDirectory(),
                        StringComparison.OrdinalIgnoreCase)
                        ? DesktopType.User
                        : DesktopType.Public;
                    //_interceptionResultForm = new();
                    _interceptionResultForm.Show(e.FullPath, Strategy, desktopType);// 显示拦截结果提示框

                    Log("Watcher", LogLevel.Info, $"快捷方式/URL文件 {e.FullPath} 已经被清除，事件Hash代码：{e.GetHashCode()}。");
                    StatisticalAssistant.Add(DateTime.Now);
                    int count = Properties.Settings.Default.Intercept_Count;
                    Log("Statistics", LogLevel.Info, $"应用程序累计拦截并成功清除{count}次，最后一次拦截并清除的时间：{last:yyyy-MM-dd HH:mm:ss.fff}");
                }
            }
        }
        /// <summary>
        /// 记录日志。
        /// </summary>
        /// <param name="category">日志类型。</param>
        /// <param name="level">日志级别。</param>
        /// <param name="message">日志内容。</param>
        private void Log(string category, LogLevel level, string message) => _log.Record(category, level, message);
        /// <summary>
        /// 获取当前用户桌面的目录路径。
        /// </summary>
        /// <returns>返回一个表示当前用户桌面路径的字符串。</returns>
        private static string GetUserDesktopDirectory() => Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        /// <summary>
        /// 获取公共桌面的目录路径。
        /// </summary>
        /// <returns>返回一个表示公共桌面路径的字符串。</returns>
        private static string GetPublicDesktopDirectory() => Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory);
    }
    /// <summary>
    /// 监视器策略枚举。
    /// </summary>
    public enum WatcherStrategy : int
    {
        /// <summary>
        /// 监视桌面下的所有快捷方式。
        /// </summary>
        All = 0xffff,
        /// <summary>
        /// 黑名单模式。
        /// </summary>
        Blacklist = 0x0000,
        /// <summary>
        /// 白名单模式。
        /// </summary>
        Whitelist = 0x0001
    }
    /// <summary>
    /// 已移除的快捷方式信息结构体。
    /// </summary>
    public struct RemovedShortcutInfo
    {
        /// <summary>
        /// 获取或设置已移除快捷方式的文件路径。
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 获取或设置已移除快捷方式所在的桌面类型。
        /// </summary>
        public DesktopType DesktopType { get; set; }
        /// <summary>
        /// 创建一个新的已移除快捷方式信息结构实例。
        /// </summary>
        /// <param name="filePath">已移除快捷方式的文件路径。</param>
        /// <param name="desktopType">已移除快捷方式所在的桌面类型。</param>
        public RemovedShortcutInfo(string filePath, DesktopType desktopType)
        {
            FilePath = filePath;
            DesktopType = desktopType;
        }
    }
    /// <summary>
    /// 桌面类型枚举。
    /// </summary>
    public enum DesktopType : int
    {
        /// <summary>
        /// 当前用户桌面。
        /// </summary>
        User = 0x0000,
        /// <summary>
        /// 公共桌面。
        /// </summary>
        Public = 0x0001
    }
}
