using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using QLinkCleanerV2.Core;

namespace QLinkCleanerV2
{
    public partial class StrategySetForm : MaterialForm
    {
        string[] strategies = ["监视所有的快捷方式", "黑名单模式", "白名单模式"];
        int selectedStrategyIndex = 0;
        public StrategySetForm()
        {
            InitializeComponent();
        }
        public DialogResult ShowDialog(ref WatcherStrategy strategy)
        {
            selectedStrategyIndex = strategy switch
            {
                WatcherStrategy.All => 0,
                WatcherStrategy.Blacklist => 1,
                WatcherStrategy.Whitelist => 2,
                _ => 0,
            };
            DialogResult result = ShowDialog();
            if (result == DialogResult.OK)
            {
                switch (materialComboBox_Strategy.Text)
                {
                    case "监视所有的快捷方式":
                        strategy = WatcherStrategy.All;
                        break;
                    case "黑名单模式":
                        strategy = WatcherStrategy.Blacklist;
                        break;
                    case "白名单模式":
                        strategy = WatcherStrategy.Whitelist;
                        break;
                    default:
                        MessageBox.Show("未选择任何策略，请重新选择。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return DialogResult.None;
                }
            }
            return result;
        }

        private void materialButton_Accept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void materialButton_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void StrategySetForm_Load(object sender, EventArgs e)
        {
            materialComboBox_Strategy.Text = selectedStrategyIndex switch
            {
                0 => strategies[0],
                1 => strategies[1],
                2 => strategies[2],
                _ => strategies[0],
            };
        }
    }
}
