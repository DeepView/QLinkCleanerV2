namespace QLinkCleanerV2
{
    partial class InterceptionRecordsForm
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
            materialListView_Records = new MaterialSkin.Controls.MaterialListView();
            columnHeader_Time = new ColumnHeader();
            columnHeader_Shortcut = new ColumnHeader();
            columnHeader_From = new ColumnHeader();
            columnHeader_Path = new ColumnHeader();
            SuspendLayout();
            // 
            // materialListView_Records
            // 
            materialListView_Records.AutoSizeTable = false;
            materialListView_Records.BackColor = Color.FromArgb(255, 255, 255);
            materialListView_Records.BorderStyle = BorderStyle.None;
            materialListView_Records.Columns.AddRange(new ColumnHeader[] { columnHeader_Time, columnHeader_Shortcut, columnHeader_From, columnHeader_Path });
            materialListView_Records.Depth = 0;
            materialListView_Records.Dock = DockStyle.Fill;
            materialListView_Records.FullRowSelect = true;
            materialListView_Records.Location = new Point(3, 64);
            materialListView_Records.MinimumSize = new Size(200, 100);
            materialListView_Records.MouseLocation = new Point(-1, -1);
            materialListView_Records.MouseState = MaterialSkin.MouseState.OUT;
            materialListView_Records.Name = "materialListView_Records";
            materialListView_Records.OwnerDraw = true;
            materialListView_Records.Size = new Size(1187, 647);
            materialListView_Records.TabIndex = 0;
            materialListView_Records.UseCompatibleStateImageBehavior = false;
            materialListView_Records.View = View.Details;
            materialListView_Records.MouseClick += materialListView_Records_MouseClick;
            // 
            // columnHeader_Time
            // 
            columnHeader_Time.Text = "拦截记录时间";
            columnHeader_Time.Width = 160;
            // 
            // columnHeader_Shortcut
            // 
            columnHeader_Shortcut.Text = "快捷方式名称";
            columnHeader_Shortcut.Width = 300;
            // 
            // columnHeader_From
            // 
            columnHeader_From.Text = "来源";
            columnHeader_From.Width = 90;
            // 
            // columnHeader_Path
            // 
            columnHeader_Path.Text = "详细路径";
            columnHeader_Path.Width = 600;
            // 
            // InterceptionRecordsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1193, 714);
            Controls.Add(materialListView_Records);
            MaximizeBox = false;
            Name = "InterceptionRecordsForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "拦截记录查看器";
            Load += InterceptionRecordsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialListView materialListView_Records;
        private ColumnHeader columnHeader_Time;
        private ColumnHeader columnHeader_Shortcut;
        private ColumnHeader columnHeader_From;
        private ColumnHeader columnHeader_Path;
    }
}