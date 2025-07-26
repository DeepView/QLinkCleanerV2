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
    public partial class ManifestForm : MaterialForm
    {
        private bool IsChanged { get; set; }
        private Manifest[] Manifests { get; set; }

        private string _logFilePath;

        private const string BLACKLIST_PATH = @"manifests\blacklist";
        private const string WHITELIST_PATH = @"manifests\whitelist";
        public ManifestForm(string logFilePath)
        {
            InitializeComponent();
            Manifests = [new() { Name = "黑名单" }, new() { Name = "白名单" }];
            if (!Directory.Exists("manifests"))
                Directory.CreateDirectory("manifests");
            LoadManifests(BLACKLIST_PATH, WHITELIST_PATH);
            _logFilePath = logFilePath;
        }

        private void Log(string category, LogLevel level, string message)
        {
            LogHelper log = new(_logFilePath);
            log.Record(category, level, message);
        }

        public void LoadManifests(string blackListPath, string whiteListPath)
        {
            if (!File.Exists(blackListPath)) File.Create(blackListPath).Close();
            if (!File.Exists(whiteListPath)) File.Create(whiteListPath).Close();
            Manifests[0].Parse(blackListPath);
            Manifests[1].Parse(whiteListPath);
        }

        private void LoadManifestToListView()
        {
            materialListView_ManifestView.Items.Clear();
            if (materialComboBox_ManifestType.Text == "黑名单")
            {
                foreach (var item in Manifests[0])
                {
                    string[] data = item.ToString().Split('|');
                    data[3] = data[3] == "-1" ? "未拦截" : new DateTime(long.Parse(data[3])).ToString("yyyy-MM-dd HH:mm:ss");
                    materialListView_ManifestView.Items.Add(new ListViewItem(data));
                }
            }
            else if (materialComboBox_ManifestType.Text == "白名单")
            {
                foreach (var item in Manifests[1])
                {
                    string[] data = item.ToString().Split('|');
                    data[3] = data[3] == "-1" ? "未拦截" : new DateTime(long.Parse(data[3])).ToString("yyyy-MM-dd HH:mm:ss");
                    materialListView_ManifestView.Items.Add(new ListViewItem(data));
                }
            }
        }

        private void ManifestForm_Load(object sender, EventArgs e)
        {
            LoadManifestToListView();
            Size = new(847, 568);
        }

        private void materialComboBox_ManifestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadManifestToListView();
        }

        private void materialButton_Add_Click(object sender, EventArgs e)
        {
            SingleDataForm add = new SingleDataForm();
            string name = string.Empty;
            bool isWatchingUserDesktop = false;
            bool isWatchingPublicDesktop = false;
            DialogResult result = add.ShowDialog(true, ref name, ref isWatchingUserDesktop, ref isWatchingPublicDesktop);
            if (result == DialogResult.OK)
            {
                ListData data = new(name)
                {
                    IsWatchingUserDesktop = isWatchingUserDesktop,
                    IsWatchingPublicDesktop = isWatchingPublicDesktop,
                    LastTimeOfInterception = null
                };
                if (materialComboBox_ManifestType.Text == "黑名单")
                {
                    Manifests[0].Add(data);
                    LoadManifestToListView();
                    Log("Manifest", LogLevel.Info, $"已添加黑名单项目：{data.Name}");
                }
                else
                {
                    Manifests[1].Add(data);
                    LoadManifestToListView();
                    Log("Manifest", LogLevel.Info, $"已添加白名单项目：{data.Name}");
                }
                IsChanged = true;
            }
        }

        private void materialListView_ManifestView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialListView_ManifestView.SelectedItems.Count > 0)
            {
                materialButton_Modify.Enabled = true;
                materialButton_Remove.Enabled = true;
            }
            else
            {
                materialButton_Modify.Enabled = false;
                materialButton_Remove.Enabled = false;
            }
        }

        private void materialButton_Save_Click(object sender, EventArgs e)
        {
            foreach (var manifest in Manifests)
            {
                string filePath = manifest.Name == "黑名单" ? BLACKLIST_PATH : WHITELIST_PATH;
                try
                {
                    manifest.Save(filePath);
                    IsChanged = false;
                    Log("Manifest", LogLevel.Info, $"{manifest.Name}已保存，文件修改标识符已重置为{IsChanged}。");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "遭遇异常情况，无法保存清单！",
                        "错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    IsChanged = true;
                    string err_filename = Program.GenerateErrorTraceLogFileName();
                    Program.CreateAndWriteErrorTraceLog(err_filename, ex);
                    Log(
                        "Manifest",
                        LogLevel.Error,
                        $"错误，遭遇异常情况，{manifest.Name}保存失败，文件修改标识符为{IsChanged}，异常信息参考文件：{err_filename}。"
                    );
                }
            }
        }

        private void materialButton_Remove_Click(object sender, EventArgs e)
        {
            if (materialListView_ManifestView.SelectedItems.Count >= 0)
            {
                int index = materialListView_ManifestView.SelectedIndices[0];
                int manifestIndex = materialComboBox_ManifestType.Text == "黑名单" ? 0 : 1;
                Manifests[manifestIndex].RemoveAt(index);
                IsChanged = true;
                Log("Manifest", LogLevel.Info, $"已从{materialComboBox_ManifestType.Text}中删除移除项目：{Manifests[manifestIndex][index].Name}");
            }
            LoadManifestToListView();
        }

        private void materialButton_Modify_Click(object sender, EventArgs e)
        {
            if (materialListView_ManifestView.SelectedIndices.Count > 0)
            {
                int index = materialListView_ManifestView.SelectedIndices[0];
                int manifestIndex = materialComboBox_ManifestType.Text == "黑名单" ? 0 : 1;
                SingleDataForm modify = new();
                string name = Manifests[manifestIndex][index].Name;
                bool isWatchingUserDesktop = Manifests[manifestIndex][index].IsWatchingUserDesktop;
                bool isWatchingPublicDesktop = Manifests[manifestIndex][index].IsWatchingPublicDesktop;
                DialogResult result = modify.ShowDialog(false, ref name, ref isWatchingUserDesktop, ref isWatchingPublicDesktop);
                if (result == DialogResult.OK)
                {
                    Manifests[manifestIndex][index] = new ListData(name)
                    {
                        IsWatchingUserDesktop = isWatchingUserDesktop,
                        IsWatchingPublicDesktop = isWatchingPublicDesktop,
                        LastTimeOfInterception = Manifests[manifestIndex][index].LastTimeOfInterception
                    };
                    IsChanged = true;
                    Log("Manifest", LogLevel.Info, $"已修改{materialComboBox_ManifestType.Text}项目：{name}");
                }
                LoadManifestToListView();
            }
        }
    }
}
