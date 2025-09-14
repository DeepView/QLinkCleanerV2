using Carlos.Extends;
using MaterialSkin.Controls;
using QLinkCleanerV2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLinkCleanerV2
{
    public partial class AppSettingsForm : MaterialForm
    {
        //private string _logFilePath;
        private bool _isChanged = false; // 用于跟踪设置是否已更改
        private LogHelper _log;
        public AppSettingsForm()
        {
            InitializeComponent();
        }
        public AppSettingsForm(LogHelper log) : this()
        {
            _log = log;
        }

        private void AppSettingsForm_Load(object sender, EventArgs e)
        {
            materialSwitch_Startup.Checked = Properties.Settings.Default.App_FollowSystemStartup;
            materialSlider_RetryTimes.Value = Properties.Settings.Default.App_MaxRetryTimesWithDelShortcut;
            materialSwitch_Startup.CheckedChanged += materialSwitch_Startup_CheckedChanged;
        }

        private void Log(string category, LogLevel level, string message) => _log.Record(category, level, message);

        private void materialSwitch_Startup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.App_FollowSystemStartup = materialSwitch_Startup.Checked;
            _isChanged = true; // 标记设置已更改
            if (materialSwitch_Startup.Checked)
            {
                // 添加到系统启动项
                AddToStartup();
                if (_isChanged)
                    Log("App", LogLevel.Info, "应用程序已添加到系统启动项。");
            }
            else
            {
                // 从系统启动项中移除
                RemoveFromStartup();
                if (_isChanged)
                    Log("App", LogLevel.Info, "应用程序已从系统启动项中移除。");
            }
        }
        private static void AddToStartup()
        {
            // 这里添加代码以将应用程序添加到系统启动项
            // 例如，使用注册表或其他方法
            // 获取启动文件夹的路径
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            // 获取应用程序的可执行文件路径
            string exePath = Assembly.GetExecutingAssembly().Location;
            // 创建快捷方式的文件路径
            string shortcutPath = Path.Combine(startupFolderPath, "QLink Cleaner.lnk");
            exePath = $"{exePath.Left(exePath.Length - 4)}.exe";
            // 检查快捷方式是否已存在
            if (!File.Exists(shortcutPath))
            {
                // 创建快捷方式
                var shortcut = (IWshRuntimeLibrary.WshShortcut)new IWshRuntimeLibrary.WshShell().CreateShortcut(shortcutPath);
                shortcut.TargetPath = exePath;
                shortcut.Arguments = "--hide"; // 可以在这里添加启动参数，如果需要的话
                shortcut.WorkingDirectory = Path.GetDirectoryName(exePath);
                shortcut.Save();
            }
        }
        private static void RemoveFromStartup()
        {
            // 这里添加代码以从系统启动项中移除应用程序
            // 例如，删除注册表项或快捷方式
            string startupFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(startupFolderPath, "QLink Cleaner.lnk");
            if (File.Exists(shortcutPath))
            {
                File.Delete(shortcutPath);
            }
        }

        private void materialButton_AboutThis_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new();
            aboutForm.ShowDialog();
        }

        private void materialSlider_RetryTimes_Click(object sender, EventArgs e)
        {

        }

        private void materialSlider_RetryTimes_onValueChanged(object sender, int newValue)
        {
            Properties.Settings.Default.App_MaxRetryTimesWithDelShortcut = newValue;
        }

        private void materialButton_OpenTestDomain_Click(object sender, EventArgs e)
        {
            TestDomainForm testDomainForm = new(_log.LogFilePath);
            testDomainForm.Show();
        }
    }
}
