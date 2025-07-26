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
    public partial class LogViewForm : MaterialForm
    {
        private MaterialContextMenuStrip _logListContextmenuStrip;
        public LogViewForm()
        {
            InitializeComponent();
        }

        private void LogViewForm_SizeChanged(object sender, EventArgs e)
        {
            materialListView_LogContent.Columns[3].Width =
                materialListView_LogContent.Width -
                materialListView_LogContent.Columns[0].Width -
                materialListView_LogContent.Columns[1].Width -
                materialListView_LogContent.Columns[2].Width - 20; // 20 for padding
            splitContainer_Main.SplitterDistance = 360;
        }

        private void LogViewForm_Load(object sender, EventArgs e)
        {
            LogViewForm_SizeChanged(sender, e);
            splitContainer_Main.SplitterDistance = 360;
            LoadLogList();
            InitializeContextMenu();
            materialListBox_LogList.ContextMenuStrip = _logListContextmenuStrip;
            materialListBox_LogList.SelectedIndex = materialListBox_LogList.Items.Count > 0 ? materialListBox_LogList.Items.Count - 1 : -1;
            materialListBox_LogList_SelectedIndexChanged(sender, materialListBox_LogList.SelectedItem as MaterialSkin.MaterialListBoxItem);
            WindowState = FormWindowState.Maximized;
        }

        public void InitializeContextMenu()
        {
            _logListContextmenuStrip = new MaterialContextMenuStrip();
            var deleteMenuItem = new ToolStripMenuItem("删除日志文件");
            deleteMenuItem.Click += (s, e) =>
            {
                if (materialListBox_LogList.SelectedItem is MaterialSkin.MaterialListBoxItem selectedItem)
                {
                    string logFilePath = $@"{Environment.CurrentDirectory}\log\{selectedItem.Text}";
                    if (File.Exists(logFilePath))
                    {
                        File.Delete(logFilePath);
                        LoadLogList();
                        MessageBox.Show("日志文件已删除。", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("日志文件不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                LoadLogList();
            };
            var refreshMenuItem = new ToolStripMenuItem("刷新日志列表");
            refreshMenuItem.Click += (s, e) =>
            {
                LoadLogList();
                if (materialListBox_LogList.Items.Count > 0)
                {
                    materialListBox_LogList.SelectedIndex = materialListBox_LogList.Items.Count - 1;
                }
            };
            var toLogDirectoryMenuItem = new ToolStripMenuItem("打开日志目录");
            toLogDirectoryMenuItem.Click += (s, e) =>
            {
                string logDirectory = $@"{Environment.CurrentDirectory}\log";
                if (Directory.Exists(logDirectory))
                {
                    System.Diagnostics.Process.Start("explorer.exe", logDirectory);
                }
                else
                {
                    MessageBox.Show("日志目录不存在。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            _logListContextmenuStrip.Items.Add(deleteMenuItem);
            _logListContextmenuStrip.Items.Add(refreshMenuItem);
            _logListContextmenuStrip.Items.Add(toLogDirectoryMenuItem);
        }

        private void LoadLogList()
        {
            string logDirectory = $@"{Environment.CurrentDirectory}\log";
            if (Directory.Exists(logDirectory))
            {
                var logFiles = Directory.GetFiles(logDirectory, "*.log");
                materialListBox_LogList.Items.Clear();
                foreach (var logFile in logFiles)
                {
                    FileInfo info = new(logFile);
                    string secondaryText = "Size：";
                    secondaryText += info.Length > 1024
                        ? $"{info.Length / 1024.0:F2} KiB"
                        : $"{info.Length} Byte";
                    secondaryText += $" | Last Write：{info.LastWriteTime:yyyy-MM-dd HH:mm:ss}";
                    materialListBox_LogList.Items.Add(new MaterialSkin.MaterialListBoxItem(Path.GetFileName(logFile), secondaryText));
                }
            }
            else
            {
                MessageBox.Show("Log directory does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void materialListBox_LogList_SelectedIndexChanged(object sender, MaterialSkin.MaterialListBoxItem selectedItem)
        {
            if (selectedItem != null)
            {
                string selectedLogFile = selectedItem.Text;
                string logFilePath = $@"{Environment.CurrentDirectory}\log\{selectedLogFile}";
                if (File.Exists(logFilePath))
                {
                    materialListView_LogContent.Items.Clear();
                    var logLines = File.ReadAllLines(logFilePath);
                    foreach (var line in logLines)
                    {
                        var parts = line.Split(['*'], 4);
                        if (parts.Length == 4)
                        {
                            var item = new ListViewItem([parts[0], parts[1], parts[2], parts[3]]);
                            materialListView_LogContent.Items.Add(item);
                        }
                    }
                    Text = $"日志查看器：{selectedLogFile} （ {selectedItem.SecondaryText}）";
                }
                else
                {
                    MessageBox.Show("Selected log file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
