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
    }
}
