namespace QLinkCleanerV2
{
    partial class LogViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MaterialSkin.MaterialListBoxItem materialListBoxItem1 = new MaterialSkin.MaterialListBoxItem();
            splitContainer_Main = new SplitContainer();
            materialListBox_LogList = new MaterialSkin.Controls.MaterialListBox();
            materialListView_LogContent = new MaterialSkin.Controls.MaterialListView();
            Col_DateTime = new ColumnHeader();
            Col_Category = new ColumnHeader();
            Col_Level = new ColumnHeader();
            Col_Message = new ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Main).BeginInit();
            splitContainer_Main.Panel1.SuspendLayout();
            splitContainer_Main.Panel2.SuspendLayout();
            splitContainer_Main.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer_Main
            // 
            splitContainer_Main.Dock = DockStyle.Fill;
            splitContainer_Main.Location = new Point(3, 64);
            splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            splitContainer_Main.Panel1.Controls.Add(materialListBox_LogList);
            splitContainer_Main.Panel1MinSize = 320;
            // 
            // splitContainer_Main.Panel2
            // 
            splitContainer_Main.Panel2.Controls.Add(materialListView_LogContent);
            splitContainer_Main.Size = new Size(1126, 604);
            splitContainer_Main.SplitterDistance = 372;
            splitContainer_Main.TabIndex = 0;
            // 
            // materialListBox_LogList
            // 
            materialListBox_LogList.BackColor = Color.White;
            materialListBox_LogList.BorderColor = Color.LightGray;
            materialListBox_LogList.Density = MaterialSkin.Controls.MaterialListBox.MaterialItemDensity.Default;
            materialListBox_LogList.Depth = 0;
            materialListBox_LogList.Dock = DockStyle.Fill;
            materialListBox_LogList.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialListBoxItem1.SecondaryText = "12222222222222222222";
            materialListBoxItem1.Tag = null;
            materialListBoxItem1.Text = "ListBoxItem";
            materialListBox_LogList.Items.Add(materialListBoxItem1);
            materialListBox_LogList.Location = new Point(0, 0);
            materialListBox_LogList.MouseState = MaterialSkin.MouseState.HOVER;
            materialListBox_LogList.Name = "materialListBox_LogList";
            materialListBox_LogList.SelectedIndex = -1;
            materialListBox_LogList.SelectedItem = null;
            materialListBox_LogList.ShowBorder = false;
            materialListBox_LogList.ShowScrollBar = true;
            materialListBox_LogList.Size = new Size(372, 604);
            materialListBox_LogList.Style = MaterialSkin.Controls.MaterialListBox.ListBoxStyle.TwoLine;
            materialListBox_LogList.TabIndex = 0;
            materialListBox_LogList.UseAccentColor = true;
            materialListBox_LogList.SelectedIndexChanged += materialListBox_LogList_SelectedIndexChanged;
            // 
            // materialListView_LogContent
            // 
            materialListView_LogContent.AutoSizeTable = false;
            materialListView_LogContent.BackColor = Color.FromArgb(255, 255, 255);
            materialListView_LogContent.BorderStyle = BorderStyle.None;
            materialListView_LogContent.Columns.AddRange(new ColumnHeader[] { Col_DateTime, Col_Category, Col_Level, Col_Message });
            materialListView_LogContent.Depth = 0;
            materialListView_LogContent.Dock = DockStyle.Fill;
            materialListView_LogContent.FullRowSelect = true;
            materialListView_LogContent.Location = new Point(0, 0);
            materialListView_LogContent.MinimumSize = new Size(200, 100);
            materialListView_LogContent.MouseLocation = new Point(-1, -1);
            materialListView_LogContent.MouseState = MaterialSkin.MouseState.OUT;
            materialListView_LogContent.Name = "materialListView_LogContent";
            materialListView_LogContent.OwnerDraw = true;
            materialListView_LogContent.Size = new Size(750, 604);
            materialListView_LogContent.TabIndex = 0;
            materialListView_LogContent.UseCompatibleStateImageBehavior = false;
            materialListView_LogContent.View = View.Details;
            // 
            // Col_DateTime
            // 
            Col_DateTime.Text = "日期与时间";
            Col_DateTime.Width = 180;
            // 
            // Col_Category
            // 
            Col_Category.Text = "记录类型";
            Col_Category.Width = 120;
            // 
            // Col_Level
            // 
            Col_Level.Text = "警告级别";
            Col_Level.Width = 120;
            // 
            // Col_Message
            // 
            Col_Message.Text = "内容";
            Col_Message.Width = 800;
            // 
            // LogViewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 671);
            Controls.Add(splitContainer_Main);
            MinimumSize = new Size(973, 598);
            Name = "LogViewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "日志浏览器";
            Load += LogViewForm_Load;
            SizeChanged += LogViewForm_SizeChanged;
            splitContainer_Main.Panel1.ResumeLayout(false);
            splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Main).EndInit();
            splitContainer_Main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer_Main;
        private MaterialSkin.Controls.MaterialListBox materialListBox_LogList;
        private MaterialSkin.Controls.MaterialListView materialListView_LogContent;
        private ColumnHeader Col_DateTime;
        private ColumnHeader Col_Category;
        private ColumnHeader Col_Level;
        private ColumnHeader Col_Message;
    }
}