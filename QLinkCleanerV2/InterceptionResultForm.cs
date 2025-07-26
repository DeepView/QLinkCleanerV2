using MaterialSkin.Controls;
using QLinkCleanerV2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLinkCleanerV2
{
    public partial class InterceptionResultForm : MaterialForm
    {
        private int _countdownDuration = 15000; // 15 seconds
        public InterceptionResultForm()
        {
            InitializeComponent();
        }

        public void Show(string file, WatcherStrategy strategy, DesktopType desktopType)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => Show(file, strategy, desktopType)));
                }
                else
                {
                    // 在UI线程上调用 Show 方法
                    Show();
                    ShowInTaskbar = false;
                    string strategyStr = strategy switch
                    {
                        WatcherStrategy.All => $"全面拦截模式 ({strategy})",
                        WatcherStrategy.Whitelist => $"黑名单模式 ({strategy})",
                        WatcherStrategy.Blacklist => $"白名单模式 ({strategy})",
                        _ => $"全面拦截模式 ({strategy})",
                    };
                    string desktopTypeStr = desktopType switch
                    {
                        DesktopType.User => $"当前用户桌面 ({desktopType})",
                        DesktopType.Public => $"公共桌面 ({desktopType})",
                        _ => "其他桌面 (N/A)",
                    };
                    string tips = $"已拦截快捷方式：{file}\n" +
                            $"拦截策略：{strategyStr}\n" +
                            $"桌面类型：{desktopTypeStr}";
                    materialMultiLineTextBox_Tips.Text = tips;
                    materialMultiLineTextBox_Tips.ReadOnly = true;
                    timer_Countdown.Start();
                }
            }
            catch (Exception)
            {
                var audioStream = Properties.Resources.MessageInterceptionTips;
                System.Media.SoundPlayer player = new(audioStream);
                player.Play();
            }

        }

        private void timer_Countdown_Tick(object sender, EventArgs e)
        {
            materialLabel_Countdown.Text = $"提示框将在 {(_countdownDuration / 1000):D2} 秒后自动关闭。";
            if (_countdownDuration <= 0)
            {
                timer_Countdown.Stop();
                Close();
            }
            else
            {
                _countdownDuration -= 1000; // 每秒减少1000毫秒
            }
        }

        private void InterceptionResultForm_Load(object sender, EventArgs e)
        {
            var audioStream = Properties.Resources.MessageInterceptionTips;
            System.Media.SoundPlayer player = new (audioStream);            
            player.Play();

            Screen screen = Screen.FromControl(this);
            Rectangle rectangle = screen.WorkingArea;

            Point shownLocation = new(rectangle.Right - Width, rectangle.Bottom - Height);
            Location = shownLocation;
            materialMultiLineTextBox_Tips.Clear();

            timer_Countdown.Start();
        }

        private void materialButton_Accept_Click(object sender, EventArgs e)
        {
            timer_Countdown.Stop();
            Close();
        }
    }
}
