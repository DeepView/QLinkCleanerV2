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
                    "��һ��Ӧ�ó���ʵ����������",
                    "ʵ�����",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            if (args.Length == 0 || args == null) args = [string.Empty];


            CreateLogInstance(logFilePath); // Create a log instance with the specified log file path
            StartupLog(args); // Log the startup information

            // TODO: ����ں����汾������������ؽ����ʾ���м�����������л������������ܣ���ɾ������ע�͵������д��롣
            DeleteShortcutBackup(); // �������Ҫɾ�����ݵĿ�ݷ�ʽ������ô˷�����������ע�͵����д��롣

            // If this is the first instance, continue with application startup
            ApplicationConfiguration.Initialize();
            Application.ThreadException += Application_ThreadException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; // Register the UnhandledException event handler
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            //ExceptionTest();  // ȡ��ע�ʹ��п��Բ���δ������쳣��
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
                Log("App", LogLevel.Info, $"Ӧ�ó�������������������: {args[0]}");
            else
                Log("App", LogLevel.Info, "Ӧ�ó�����������");
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
        /// �������������־�ļ���д�����ݡ�
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
        /// Ӧ�ó���δ�����쳣�¼���Ҫ����Ĵ��롣
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
                Log("App", LogLevel.Debug, $"����δ��������쳣����ϸ��Ϣ�����ļ���{unhandled_ex_log_file}");
                MessageBox.Show(
                    $"������һ��δ������쳣����ϸ��Ϣ�Ѽ�¼���ļ���{unhandled_ex_log_file}",
                    "δ�����쳣",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Process.Start("notepad.exe", unhandled_ex_log_file);
            }
            else
            {
                Log("App", LogLevel.Error, "������һ��δ������쳣�����޷���ȡ�쳣��Ϣ��");
                MessageBox.Show(
                    "������һ��δ������쳣�����޷���ȡ�쳣��Ϣ��",
                    "δ�����쳣",
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

            Log("App", LogLevel.Debug, $"����δ��������߳��쳣����ϸ��Ϣ�����ļ���{unhandled_ex_log_file}");
            MessageBox.Show(
                $"������һ��δ������߳��쳣����ϸ��Ϣ�Ѽ�¼���ļ���{unhandled_ex_log_file}",
                "δ�����߳��쳣",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            Process.Start("notepad.exe", unhandled_ex_log_file);
        }

        /// <summary>
        /// Ӧ�ó����˳��¼���Ҫ����Ĵ��롣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_ProcessExit(object sender, EventArgs e) =>
            // Handle process exit by logging it
            Log("App", LogLevel.Info, "Ӧ�ó������˳���");
    }
}