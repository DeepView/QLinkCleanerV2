using QLinkCleanerV2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.AppBroadcasting;

namespace QLinkCleanerV2
{
    public partial class TestDomainForm : Form
    {
        private LogHelper _log;
        private int _operationCount = 0;
        public TestDomainForm(string logFilePath)
        {
            InitializeComponent();
            _log = new LogHelper(logFilePath);
        }

        private void OptCounterIncrement() => _operationCount++;

        private void Log(string category, LogLevel level, string message) => _log.Record(category, level, message);

        private void linkLabel_ShowUnhandledExceptionDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OptCounterIncrement();
            Log("TestDomain", LogLevel.Debug, "正在尝试手动触发异常，该操作可以监测应用程序能否捕获未处理的异常。");
            throw new Exception("This is a test exception to check unhandled exception logging.");
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void linkLabel_ViewStackTraceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OptCounterIncrement();
            string ex_trace_dir = "exception_trace";
            if (!Directory.Exists(ex_trace_dir))
            {
                Directory.CreateDirectory(ex_trace_dir);
                MessageBox.Show("未检测到应用程序异常跟踪文件目录，现已创建新的目录。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Log("TestDomain", LogLevel.Info, "正在尝试读取并显示最新的异常堆栈跟踪文件。");
                List<string> files = [.. Directory.GetFiles(ex_trace_dir, "*.txt")];
                files.Sort((x, y) => DateTime.Compare(
                    File.GetLastWriteTime(y), // Sort by last write time, newest first
                    File.GetLastWriteTime(x)
                ));
                if (files.Count > 0)
                {
                    string latestFile = files[0];
                    string content = File.ReadAllText(latestFile);
                    Form stackTraceView = new()
                    {
                        Size = new Size(640, 400),
                        Text = $"异常堆栈跟踪信息：{files[0]}",
                        StartPosition = FormStartPosition.CenterScreen,
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };
                    TextBox infoBox = new()
                    {
                        Multiline = true,
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        ScrollBars = ScrollBars.Both,
                        Font = new Font("Consolas", 11F),
                        Text = content
                    };
                    stackTraceView.Controls.Add(infoBox);
                    Log("TestDomain", LogLevel.Info, $"已读取最新的异常堆栈跟踪文件：{latestFile}");
                    stackTraceView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("未检测到任何异常堆栈跟踪文件。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void linkLabel_OpenTraceDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OptCounterIncrement();
            Process.Start("explorer.exe", "exception_trace");
        }

        private void TestDomainForm_Load(object sender, EventArgs e)
        {
            Log("App", LogLevel.Info, "已进入 Test Domain 模式。");
        }

        private void TestDomainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("TestDomain", LogLevel.Info, $"用户已经在 Test Domain 模式中执行了 {_operationCount} 次操作。");
            Log("App", LogLevel.Info, "已退出 Test Domain 模式。");
        }

        private void linkLabel_OpenAssemblyRootDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OptCounterIncrement();
            string assemblyDir = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start("explorer.exe", assemblyDir);
            Log("TestDomain", LogLevel.Info, $"已打开应用程序程序集根目录：{assemblyDir}");
        }

        private void linkLabel_AppProcessInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OptCounterIncrement();
            string processInfo = $"当前应用程序进程信息：\r\n\r\n" +
                $"进程ID: {Environment.ProcessId}\r\n" +
                $"进程名称: {Process.GetCurrentProcess().ProcessName}\r\n" + 
                $"启动时间: {Process.GetCurrentProcess().StartTime}\r\n" +
                $"运行时长: {DateTime.Now - Process.GetCurrentProcess().StartTime}\r\n" +
                $"物理内存使用: {Process.GetCurrentProcess().PrivateMemorySize64 / 1024 / 1024} MB\r\n" +
                $"当前工作集（内存使用）: {Process.GetCurrentProcess().WorkingSet64 / 1024 / 1024} MB\r\n" +
                $"峰值工作集（内存使用）: {Process.GetCurrentProcess().PeakWorkingSet64 / 1024 / 1024} MB\r\n" +
                $"虚拟内存大小: {Process.GetCurrentProcess().VirtualMemorySize64 / 1024 / 1024} MB\r\n" +
                $"峰值虚拟内存大小: {Process.GetCurrentProcess().PeakVirtualMemorySize64 / 1024 / 1024} MB\r\n" +
                $"非分页系统内存大小: {Process.GetCurrentProcess().NonpagedSystemMemorySize64 / 1024 / 1024} MB\r\n" +
                $"分页系统内存大小: {Process.GetCurrentProcess().PagedSystemMemorySize64 / 1024 / 1024} MB\r\n" +
                $"已分页内存大小: {Process.GetCurrentProcess().PagedMemorySize64 / 1024 / 1024} MB\r\n" +
                $"峰值已分页内存大小: {Process.GetCurrentProcess().PeakPagedMemorySize64 / 1024 / 1024} MB\r\n" +
                $"响应状态: {Process.GetCurrentProcess().Responding}\r\n" +
                $"会话ID: {Process.GetCurrentProcess().SessionId}\r\n" +
                $"优先级类: {Process.GetCurrentProcess().PriorityClass}\r\n" +
                $"实时优先级: {Process.GetCurrentProcess().BasePriority}\r\n" +
                $"内核处理器时间: {Process.GetCurrentProcess().PrivilegedProcessorTime}\r\n" +
                $"用户处理器时间: {Process.GetCurrentProcess().UserProcessorTime}\r\n" +
                $"总处理器时间: {Process.GetCurrentProcess().TotalProcessorTime}\r\n" +
                $"当前应用程序域: {AppDomain.CurrentDomain.FriendlyName}\r\n" +
                $"操作系统（OS平台）: {Environment.OSVersion.Platform}\r\n" +
                $"操作系统版本: {Environment.OSVersion}\r\n" +
                $"64位操作系统: {Environment.Is64BitOperatingSystem}\r\n" +
                $"当前进程是否为64位: {Environment.Is64BitProcess}\r\n" +
                $"处理器数量: {Environment.ProcessorCount}\r\n" +
                $"用户交互模式: {Environment.UserInteractive}\r\n" +
                $"系统目录: {Environment.SystemDirectory}\r\n" +
                $"应用程序目录: {AppDomain.CurrentDomain.BaseDirectory}\r\n" +
                $"当前用户域名: {Environment.UserDomainName}\r\n" +
                $"当前用户名: {Environment.UserName}\r\n" +
                $"CLR 版本: {Environment.Version}\r\n";
            MessageBox.Show(processInfo, "应用程序进程信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log("TestDomain", LogLevel.Info, "已显示当前应用程序进程信息。");
        }
    }
}
