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
    public partial class AboutForm : MaterialForm
    {
        public AboutForm()
        {
            InitializeComponent();
        }
        public string GetVersion()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return version;
        }
        public string GetBuildDate()
        {
            DateTime buildDate = System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return buildDate.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public string GetCopyright()
        {
            string copyright = System.Reflection.Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(System.Reflection.AssemblyCopyrightAttribute), false)
                .Cast<System.Reflection.AssemblyCopyrightAttribute>()
                .FirstOrDefault()?.Copyright ?? "未设置版权信息";
            return copyright;
        }

        private void materialButton_Accept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            materialLabel_Version.Text= $"版本：{GetVersion()}";
            materialLabel_LastBuildDate.Text = $"构建日期：{GetBuildDate()}";
            materialLabel_Copyright.Text = $"版权：{GetCopyright()}";
        }
    }
}
