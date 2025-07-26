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
    public partial class SingleDataForm : MaterialForm
    {
        public SingleDataForm()
        {
            InitializeComponent();
        }
        public DialogResult ShowDialog(bool isAddItem, ref string name, ref bool isWatchingUserDesktop, ref bool isWatchingPublicDesktop)
        {
            if (isAddItem)
            {
                Text = "添加新项目";
                materialTextBox_Name.Text = string.Empty;
                materialCheckbox_UserDesktop.Checked = true;
                materialCheckbox_PublicDesktop.Checked = true;
            }
            else
            {
                Text = "编辑项目";
            }
            materialTextBox_Name.Text = name;
            materialCheckbox_UserDesktop.Checked = isWatchingUserDesktop;
            materialCheckbox_PublicDesktop.Checked = isWatchingPublicDesktop;
            DialogResult result = ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!ListData.FileNameCheck(materialTextBox_Name.Text))
                {
                    MessageBox.Show("文件名不合法，可能包含非法字符、保留关键字、长度超出限制或为空白名称，请重新指定文件名。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return DialogResult.None;
                }
                name = materialTextBox_Name.Text;
                isWatchingUserDesktop = materialCheckbox_UserDesktop.Checked;
                isWatchingPublicDesktop = materialCheckbox_PublicDesktop.Checked;
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
    }
}
