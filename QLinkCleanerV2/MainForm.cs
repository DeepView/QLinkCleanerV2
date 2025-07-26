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
            Log("Watcher", LogLevel.Info, "�����������³�ʼ����");
        }

        public void LoadSettings()
        {
            materialSwitch_SwitchWatching.Checked = Properties.Settings.Default.Watcher_Switch;
            Log("App", LogLevel.Info, $"�������ã�Watcher_Switch = {materialSwitch_SwitchWatching.Checked}");
            Watcher.Strategy = (WatcherStrategy)Properties.Settings.Default.Watcher_Strategy;
            Log("App", LogLevel.Info, $"�������ã�Watcher_Strategy = {Watcher.Strategy}");
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
        /// ��¼��־��
        /// </summary>
        /// <param name="category">��־���͡�</param>
        /// <param name="level">��־����</param>
        /// <param name="message">��־���ݡ�</param>
        private void Log(string category, LogLevel level, string message) => _log.Record(category, level, message);

        /// <summary>
        /// ��ʼ������ͼ����Ҽ��˵���
        /// </summary>
        private void InitContextMenuStrip()
        {
            _contextMenuStrip = new MaterialContextMenuStrip();
            _contextMenuStrip.Items.Add("��ʾ������", null, (s, e) => Show());
            _contextMenuStrip.Items.Add("�˳�", null, (s, e) => Application.Exit());
            notifyIcon_Background.ContextMenuStrip = _contextMenuStrip;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = new Size(590, 406);
            LoadSettings();
            materialSwitch_SwitchWatching_CheckedChanged(sender, e);

            // �����Ҫ������ʱ��ʾ���ؽ��������ȡ��ע�����´���
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
                label_StatusText.Text = "�������ڱ�����������";
                Properties.Settings.Default.Watcher_Switch = true;
                Watcher.Start();
            }
            else
            {
                pictureBox_Sataus.Image = Properties.Resources.StatusError;
                label_StatusText.Text = "����������ֹͣ����";
                Properties.Settings.Default.Watcher_Switch = false;
                Watcher.Stop();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    // ��ֹ���ڹر�
                Hide();             // ���ش��ڶ����ǹر�
            }
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                notifyIcon_Background.Visible = false; // ��������ͼ��
                Log("App", LogLevel.Info, "Ӧ�ó��򴰿�����ʾ��");

            }
            else
            {
                notifyIcon_Background.Visible = true; // ��ʾ����ͼ��
                Log("App", LogLevel.Info, "Ӧ�ó��򴰿������ص���������������");
                notifyIcon_Background.ShowBalloonTip(3000, "QLinkCleanerV2", "Ӧ�ó��������ص����̡�", ToolTipIcon.Info);
                string statusText = materialSwitch_SwitchWatching.Checked ? "ON" : "OFF";
                notifyIcon_Background.Text = $"QLink Cleaner\n����״̬��{statusText}\n���ز��ԣ�{Watcher.Strategy}";
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
                Log("Watcher", LogLevel.Info, $"���Ӳ����Ѹ���Ϊ��{strategy}");
                Properties.Settings.Default.Watcher_Strategy = (int)strategy;
                materialButton_ResetWatchers_Click(sender, e); // ���¿�ʼ����
            }
        }

        private void pictureBox_Manifest_Click(object sender, EventArgs e)
        {
            ManifestForm manifestForm = new(LogFilePath);
            manifestForm.Show();
        }

        private void materialButton_ResetWatchers_Click(object sender, EventArgs e)
        {
            materialSwitch_SwitchWatching.Checked = false; // ֹͣ����
            ReInitializeWatcher();
            materialSwitch_SwitchWatching.Checked = true; // ���¿�ʼ����
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
                string message = $"���ش�����{count}\n" +
                                 $"�ϴ�����ʱ�䣺{lastInterceptTime:yyyy-MM-dd HH:mm:ss}";
                MaterialMessageBox.Show(message, "ͳ����Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MaterialMessageBox.Show("��ǰû�����ؼ�¼��", "ͳ����Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox_Configure_Click(object sender, EventArgs e)
        {
            AppSettingsForm appSettingsForm = new(_log);
            appSettingsForm.ShowDialog();
        }
    }
}
