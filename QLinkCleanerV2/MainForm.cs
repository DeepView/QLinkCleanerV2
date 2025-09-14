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
            string currentStrategy = Watcher.Strategy switch
            {
                WatcherStrategy.All => "监视所有的快捷方式（ALL: 0xFFFF）",
                WatcherStrategy.Blacklist => "黑名单模式（BLACKLIST: 0x0000）",
                WatcherStrategy.Whitelist => "白名单模式（WHITELIST: 0x0001）",
                _ => "未知策略（UNKNOWN）"
            };
            materialLabel_CurrentStrategy.Text = $"当前已应用的拦截策略：{currentStrategy}";
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
            _contextMenuStrip.Items.Add("重新开始监视", null, materialButton_ResetWatchers_Click);
            _contextMenuStrip.Items.Add("立即清理", null, materialButton_CleanNow_Click);
            _contextMenuStrip.Items.Add("打开日志浏览器", null, pictureBox_Log_Click);
            _contextMenuStrip.Items.Add("进入 Test Domain", null, (s, e) => new TestDomainForm(LogFilePath).Show());
            _contextMenuStrip.Items.Add("退出", null, (s, e) => Application.Exit());
            foreach (ToolStripItem item in _contextMenuStrip.Items)
            {
                item.Font = new Font(
                    "Microsoft Sans Serif",
                    20F, FontStyle.Regular,
                    GraphicsUnit.Point
                );
            }
            notifyIcon_Background.ContextMenuStrip = _contextMenuStrip;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = new Size(684, 497);
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
                //AdminOperations.RunAdminOperation();
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
            string currentStrategy = Watcher.Strategy switch
            {
                WatcherStrategy.All => "监视所有的快捷方式（ALL: 0xFFFF）",
                WatcherStrategy.Blacklist => "黑名单模式（BLACKLIST: 0x0000）",
                WatcherStrategy.Whitelist => "白名单模式（WHITELIST: 0x0001）",
                _ => "未知策略（UNKNOWN）"
            };
            materialLabel_CurrentStrategy.Text = $"当前已应用的拦截策略：{currentStrategy}";
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
            //int count = Properties.Settings.Default.Intercept_Count;
            //DateTime lastInterceptTime = Properties.Settings.Default.Intercept_LastTime;
            //if (count > 0)
            //{
            //    string message = $"拦截次数：{count}\n" +
            //                     $"上次拦截时间：{lastInterceptTime:yyyy-MM-dd HH:mm:ss}";
            //    MaterialMessageBox.Show(message, "统计信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MaterialMessageBox.Show("当前没有拦截记录。", "统计信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            InterceptionRecordsForm interceptionRecordsForm = new();
            interceptionRecordsForm.Show();
        }

        private void pictureBox_Configure_Click(object sender, EventArgs e)
        {
            AppSettingsForm appSettingsForm = new(_log);
            appSettingsForm.ShowDialog();
        }

        private void materialButton_CleanNow_Click(object sender, EventArgs e)
        {
            Watcher.CleanUpImmediately();
            Log("App", LogLevel.Info, "用户执行立即清理，如果有符合清理策略的快捷方式被清理，其清理结果的日志记录将会写入到这条日志记录之后。");
        }

    }
}
