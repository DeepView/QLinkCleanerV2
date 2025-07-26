using MaterialSkin.Controls;
using QLinkCleanerV2.Core;
using System.ComponentModel;
namespace QLinkCleanerV2
{
    public partial class MainForm : MaterialForm
    {
        private LogHelper _log;
        private string _startupArg;
        private MaterialContextMenuStrip _contextMenuStrip;

        public MainForm(string arg, string logFilePath)
        {
            InitializeComponent();
            InitContextMenuStrip();
            LogFilePath = logFilePath;
            _log = new LogHelper(LogFilePath);
            _startupArg = arg;
            Watcher = new(WatcherStrategy.All, LogFilePath)
            {
                Manifest = []
            };
            Watcher.InitList();
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LogFilePath { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Watcher Watcher { get; set; }

        public void ReInitializeWatcher()
        {
            WatcherStrategy strategy = (WatcherStrategy)Properties.Settings.Default.Watcher_Strategy;
            Watcher = new(strategy, LogFilePath)
            {
                Manifest = []
            };
            Watcher.InitList();
            //materialSwitch_SwitchWatching_CheckedChanged(null, null);
            Log("Watcher", LogLevel.Info, "监视器已重新初始化。");
        }

        public void LoadSettings()
        {
            materialSwitch_SwitchWatching.Checked = Properties.Settings.Default.Watcher_Switch;
            Log("App", LogLevel.Info, $"加载设置：Watcher_Switch = {materialSwitch_SwitchWatching.Checked}");
            Watcher.Strategy = (WatcherStrategy)Properties.Settings.Default.Watcher_Strategy;
            Log("App", LogLevel.Info, $"加载设置：Watcher_Strategy = {Watcher.Strategy}");
        }

        public void StartupDo()
        {
            if (!string.IsNullOrEmpty(_startupArg))
            {
                switch (_startupArg.ToLower())
                {
                    case "--hide":
                        Hide();
                        break;
                    case "--minimized":
                        WindowState = FormWindowState.Minimized;
                        break;
                    default:
                        break;
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
        /// 初始化托盘图标的右键菜单。
        /// </summary>
        private void InitContextMenuStrip()
        {
            _contextMenuStrip = new MaterialContextMenuStrip();
            _contextMenuStrip.Items.Add("显示主窗口", null, (s, e) => Show());
            _contextMenuStrip.Items.Add("退出", null, (s, e) => Application.Exit());
            notifyIcon_Background.ContextMenuStrip = _contextMenuStrip;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = new Size(590, 406);
            LoadSettings();
            materialSwitch_SwitchWatching_CheckedChanged(sender, e);

            // 如果需要在启动时显示拦截结果，可以取消注释以下代码
            //InterceptionResultForm f = new InterceptionResultForm();
            //f.Show();
        }
        private static void ChangePicBorderStyle(PictureBox pictureBox, bool isSelected)
        {
            if (isSelected)
            {
                pictureBox.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                pictureBox.BorderStyle = BorderStyle.None;
            }
        }
        private void pictureBox_Strategy_MouseDown(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, true);
        }

        private void pictureBox_Strategy_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, false);
        }

        private void pictureBox_Manifest_MouseDown(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, true);
        }
        private void pictureBox_Manifest_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, false);
        }

        private void pictureBox_Log_MouseDown(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, true);
        }

        private void pictureBox_Log_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, false);
        }

        private void pictureBox_Statistics_MouseDown(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, true);
        }

        private void pictureBox_Statistics_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, false);
        }

        private void pictureBox_Configure_MouseDown(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, true);
        }

        private void pictureBox_Configure_MouseUp(object sender, MouseEventArgs e)
        {
            ChangePicBorderStyle((PictureBox)sender, false);
        }

        private void materialSwitch_SwitchWatching_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch_SwitchWatching.Checked)
            {
                pictureBox_Sataus.Image = Properties.Resources.StatusInfo;
                label_StatusText.Text = "我们正在保护您的桌面";
                Properties.Settings.Default.Watcher_Switch = true;
                Watcher.Start();
            }
            else
            {
                pictureBox_Sataus.Image = Properties.Resources.StatusError;
                label_StatusText.Text = "您的桌面已停止保护";
                Properties.Settings.Default.Watcher_Switch = false;
                Watcher.Stop();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    // 阻止窗口关闭
                Hide();             // 隐藏窗口而不是关闭
            }
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                notifyIcon_Background.Visible = false; // 隐藏托盘图标
                Log("App", LogLevel.Info, "应用程序窗口已显示。");

            }
            else
            {
                notifyIcon_Background.Visible = true; // 显示托盘图标
                Log("App", LogLevel.Info, "应用程序窗口已隐藏到任务栏托盘区域。");
                notifyIcon_Background.ShowBalloonTip(3000, "QLinkCleanerV2", "应用程序已隐藏到托盘。", ToolTipIcon.Info);
                string statusText = materialSwitch_SwitchWatching.Checked ? "ON" : "OFF";
                notifyIcon_Background.Text = $"QLink Cleaner\n监视状态：{statusText}\n拦截策略：{Watcher.Strategy}";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            StartupDo();
        }

        private void pictureBox_Strategy_Click(object sender, EventArgs e)
        {
            StrategySetForm strategySetForm = new();
            WatcherStrategy strategy = Watcher.Strategy;
            DialogResult result = strategySetForm.ShowDialog(ref strategy);
            if (result == DialogResult.OK)
            {
                Watcher.Strategy = strategy;
                Log("Watcher", LogLevel.Info, $"监视策略已更改为：{strategy}");
                Properties.Settings.Default.Watcher_Strategy = (int)strategy;
                materialButton_ResetWatchers_Click(sender, e); // 重新开始监视
            }
        }

        private void pictureBox_Manifest_Click(object sender, EventArgs e)
        {
            ManifestForm manifestForm = new(LogFilePath);
            manifestForm.Show();
        }

        private void materialButton_ResetWatchers_Click(object sender, EventArgs e)
        {
            materialSwitch_SwitchWatching.Checked = false; // 停止监视
            ReInitializeWatcher();
            materialSwitch_SwitchWatching.Checked = true; // 重新开始监视
        }

        private void materialSwitch_SwitchWatching_CheckStateChanged(object sender, EventArgs e)
        {
            materialSwitch_SwitchWatching_CheckedChanged(sender, e);
        }

        private void pictureBox_Log_Click(object sender, EventArgs e)
        {
            LogViewForm logViewForm = new();
            logViewForm.Show();
        }

        private void pictureBox_Statistics_Click(object sender, EventArgs e)
        {
            int count = Properties.Settings.Default.Intercept_Count;
            DateTime lastInterceptTime = Properties.Settings.Default.Intercept_LastTime;
            if (count > 0)
            {
                string message = $"拦截次数：{count}\n" +
                                 $"上次拦截时间：{lastInterceptTime:yyyy-MM-dd HH:mm:ss}";
                MaterialMessageBox.Show(message, "统计信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MaterialMessageBox.Show("当前没有拦截记录。", "统计信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox_Configure_Click(object sender, EventArgs e)
        {
            AppSettingsForm appSettingsForm = new(_log);
            appSettingsForm.ShowDialog();
        }
    }
}
