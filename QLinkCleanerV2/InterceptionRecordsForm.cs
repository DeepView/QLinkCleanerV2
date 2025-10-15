using System;
using System.IO;
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
    public partial class InterceptionRecordsForm : MaterialForm
    {
        private readonly string _interceptionRecordsFilePath = @"interception_records.log-carlos";
        private readonly InterceptionRecordHelper _recordHelper;
        private MaterialContextMenuStrip _contextMenu;
        public InterceptionRecordsForm()
        {
            InitializeComponent();
            if (!File.Exists(_interceptionRecordsFilePath))
                File.Create(_interceptionRecordsFilePath).Close();
            _recordHelper = InterceptionRecordHelper.Parse(_interceptionRecordsFilePath);

        }
        private void LoadRecordsToListView()
        {
            materialListView_Records.Items.Clear();
            foreach (var (interceptTimeTicks, shortcutName, from, path) in _recordHelper.GetAllRecords())
            {
                var interceptTime = new DateTime(interceptTimeTicks);
                string[] data =
                [
                    $"{interceptTime:G}",
                    shortcutName,
                    from,
                    path,
                ];
                materialListView_Records.Items.Add(new ListViewItem(data));
            }
        }
        private void LoadContextMenu()
        {
            _contextMenu = new MaterialContextMenuStrip();
            var showDetailItem = new ToolStripMenuItem("显示详细信息");
            showDetailItem.Click += (s, e) =>
            {
                if (materialListView_Records.SelectedItems.Count > 0)
                {
                    var selectedItemIndex = materialListView_Records.SelectedItems[0].Index;
                    var recordText = _recordHelper.GetRecordAsString(selectedItemIndex);
                    MaterialMessageBox.Show(
                        recordText,
                        "拦截记录详情",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            };
            _contextMenu.Items.Add(showDetailItem);
            var copyItem = new ToolStripMenuItem("复制选择的拦截记录");
            copyItem.Click += (s, e) =>
            {
                if (materialListView_Records.SelectedItems.Count > 0)
                {
                    var selectedItemIndex = materialListView_Records.SelectedItems[0].Index;
                    var recordText = _recordHelper.GetRecordAsString(selectedItemIndex);
                    Clipboard.SetText(recordText);
                }
            };
            _contextMenu.Items.Add(copyItem);
            var refleshItem = new ToolStripMenuItem("刷新拦截记录列表");
            refleshItem.Click += (s, e) => LoadRecordsToListView();
            _contextMenu.Items.Add(refleshItem);
            var statisticsItem = new ToolStripMenuItem("查看统计信息");
            statisticsItem.Click += (s, e) =>
            {
                if (_recordHelper.Count == 0)
                {
                    MaterialMessageBox.Show(
                        "当前没有任何拦截记录。",
                        "统计信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    var (countOfUser, countOfPublic) = _recordHelper.GetRecordsCountByLocation();
                    var totalRecords = _recordHelper.Count;
                    var uniqueShortcuts = _recordHelper.GetAllRecords().Select(r => r.shortcutName).Distinct().Count();
                    var lastRecord = InterceptionRecordHelper.GetRecordAsString(_recordHelper.GetLatestRecord());
                    var message = $"总拦截记录数: {totalRecords}\r\n不同快捷方式数: {uniqueShortcuts}\r\n拦截来源统计（User, Public）:{countOfUser}, {countOfPublic}\r\n\r\n最新的拦截记录：\r\n{lastRecord}";
                    MaterialMessageBox.Show(
                        message,
                        "统计信息",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            };
            _contextMenu.Items.Add(statisticsItem);
            var clearAllItem = new ToolStripMenuItem("清除所有的拦截记录");
            clearAllItem.Click += (s, e) =>
            {
                var confirmResult = MaterialMessageBox.Show(
                    "确定要清除所有拦截记录吗？此操作不可撤销！",
                    "确认清除",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (confirmResult == DialogResult.Yes)
                {
                    _recordHelper.ClearRecords();
                    _recordHelper.Save(_interceptionRecordsFilePath);
                }
                LoadRecordsToListView();
            };
            _contextMenu.Items.Add(clearAllItem);
            foreach (ToolStripItem item in _contextMenu.Items)
            {
                item.Font = new Font(
                    "Microsoft Sans Serif",
                    20F, FontStyle.Regular,
                    GraphicsUnit.Point
                );
            }
            materialListView_Records.ContextMenuStrip = _contextMenu;
        }
        private void InterceptionRecordsForm_Load(object sender, EventArgs e)
        {
            LoadRecordsToListView();
            LoadContextMenu();
        }

        private void materialListView_Records_MouseClick(object sender, MouseEventArgs e)
        {
            if (materialListView_Records.FocusedItem != null && materialListView_Records.FocusedItem.Bounds.Contains(e.Location))
            {
                var selectedItemIndex = materialListView_Records.SelectedItems[0].Index;
                var recordText = _recordHelper.GetRecordAsString(selectedItemIndex);
                MaterialMessageBox.Show(
                    recordText,
                    "拦截记录详情",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}
