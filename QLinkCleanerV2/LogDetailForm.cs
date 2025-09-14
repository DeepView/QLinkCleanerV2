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

namespace QLinkCleanerV2
{
    public partial class LogDetailForm : MaterialForm
    {
        public LogDetailForm(string datetime, string type, string level, string detail)
        {
            InitializeComponent();
            Text = $"{datetime}";
            materialLabel_Type.Text = $"记录类型：{type}";
            materialLabel_Level.Text = $"日志级别：{level}";
            materialMultiLineTextBox_Detail.Text = detail;
        }

        private void materialButton_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"日期与时间：{Text}\n{materialLabel_Type.Text}\n{materialLabel_Level.Text}\n详细信息：{materialMultiLineTextBox_Detail.Text}");
        }

        private void materialButton_Accept_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
