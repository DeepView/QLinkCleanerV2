using System.Diagnostics;
using QLinkCleanerV2.Core;

namespace QLinkCleanerV2
{
    internal static class Program
    {
        private static LogHelper _log;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string appName = @"QLinkCleanerV2";                             // Application name for the mutex
            string logFilePath = LogHelper.GenerateLogFileName();           // Generate a new log file name
            using Mutex mutex = new(true, appName);   // Create a named mutex to ensure single instance
            // Check if another instance is already running
            if (!mutex.WaitOne(0, false))
            {
                // If another instance is running, exit the application
                MessageBox.Show(
                    "另一个应用程序实例正在运行",
                    "实例检查",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            if (args.Length == 0 || args == null) args = [string.Empty];


            CreateLogInstance(logFilePath); // Create a log instance with the specified log file path
            StartupLog(args); // Log the startup information

            // TODO: 如果在后续版本中完成了在拦截结果提示框中加入白名单并切换到白名单功能，请删除或者注释掉以下行代码。
            DeleteShortcutBackup(); // 如果你需要删除备份的快捷方式，请调用此方法，否则请注释掉这行代码。

            // If this is the first instance, continue with application startup
            ApplicationConfiguration.Initialize();
            Application.ThreadException += Application_ThreadException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; // Register the UnhandledException event handler
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            //ExceptionTest();  // 取消注释此行可以测试未处理的异常。
            Application.Run(new MainForm(args[0], $@"log\{logFilePath}"));

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

        }

        private static void DeleteShortcutBackup()
        {
            if(Directory.Exists("removed")) 
            {
                Directory.Delete("removed", true);
            }
        }

        private static void ExceptionTest()
        {
            // This method is for testing unhandled exceptions
            throw new Exception("This is a test exception to check unhandled exception logging.");
        }

        private static void StartupLog(string[] args)
        {
            if (args[0] != string.Empty)
                // If there are startup arguments, log them
                Log("App", LogLevel.Info, $"应用程序已启动，启动参数: {args[0]}");
            else
                Log("App", LogLevel.Info, "应用程序已启动。");
        }

        private static void CreateLogInstance(string logFilePath)
        {
            if(!Directory.Exists("log"))
                Directory.CreateDirectory("log");
            // Create a new instance of LogHelper with the specified log file path
            _log = new LogHelper($@"log\{logFilePath}");
        }

        private static void Log(string category, LogLevel level, string message) =>
            // Record a log entry using the LogHelper instance
            _log.Record(category, level, message);

        /// <summary>
        /// 创建错误跟踪日志文件并写入内容。
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="content"></param>
        public static void CreateAndWriteErrorTraceLog(string filename, Exception exception)
        {
            File.Create(filename).Close(); // Create an empty file for error trace logs
            using StreamWriter writer = new(filename, false);
            writer.WriteLine($"{exception.Message}\n\n{exception.StackTrace}");
        }
        public static string GenerateErrorTraceLogFileName()
        {
            string ex_trace_dir = "exception_trace";
            if (!Directory.Exists(ex_trace_dir))
                Directory.CreateDirectory(ex_trace_dir);
            return $@"{ex_trace_dir}\app.unhandled_exception.stack_trace.{DateTime.Now:yyyy-MM-dd_hh-mm-ss}.txt";
        }

        /// <summary>
        /// 应用程序未处理异常事件需要处理的代码。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Handle unhandled exceptions by logging them
            if (e.ExceptionObject is Exception ex)
            {
                string unhandled_ex_log_file = GenerateErrorTraceLogFileName();
                CreateAndWriteErrorTraceLog(
                    unhandled_ex_log_file,
                    ex
                );
                Log("App", LogLevel.Debug, $"捕获到未被处理的异常，详细信息参阅文件：{unhandled_ex_log_file}");
                MessageBox.Show(
                    $"发生了一个未处理的异常，详细信息已记录到文件：{unhandled_ex_log_file}",
                    "未处理异常",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Process.Start("notepad.exe", unhandled_ex_log_file);
            }
            else
            {
                Log("App", LogLevel.Error, "发生了一个未处理的异常，但无法获取异常信息。");
                MessageBox.Show(
                    "发生了一个未处理的异常，但无法获取异常信息。",
                    "未处理异常",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Handle thread exceptions by logging them
            string unhandled_ex_log_file = GenerateErrorTraceLogFileName();
            CreateAndWriteErrorTraceLog(
                unhandled_ex_log_file,
                e.Exception
            );

            Log("App", LogLevel.Debug, $"捕获到未被处理的线程异常，详细信息参阅文件：{unhandled_ex_log_file}");
            MessageBox.Show(
                $"发生了一个未处理的线程异常，详细信息已记录到文件：{unhandled_ex_log_file}",
                "未处理线程异常",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            Process.Start("notepad.exe", unhandled_ex_log_file);
        }

        /// <summary>
        /// 应用程序退出事件需要处理的代码。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e) =>
            // Handle process exit by logging it
            Log("App", LogLevel.Info, "应用程序已退出。");
    }
}