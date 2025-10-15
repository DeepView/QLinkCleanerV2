namespace QLinkCleanerV2
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            label_StatusText = new Label();
            pictureBox_Sataus = new PictureBox();
            pictureBox_Strategy = new PictureBox();
            pictureBox_Manifest = new PictureBox();
            pictureBox_Log = new PictureBox();
            pictureBox_Statistics = new PictureBox();
            pictureBox_Configure = new PictureBox();
            materialSwitch_SwitchWatching = new MaterialSkin.Controls.MaterialSwitch();
            materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            toolTip_ButtonTips = new ToolTip(components);
            notifyIcon_Background = new NotifyIcon(components);
            materialButton_ResetWatchers = new MaterialSkin.Controls.MaterialButton();
            materialButton_CleanNow = new MaterialSkin.Controls.MaterialButton();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel_CurrentStrategy = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Sataus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Strategy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Manifest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Log).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Statistics).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Configure).BeginInit();
            SuspendLayout();
            // 
            // label_StatusText
            // 
            label_StatusText.AutoSize = true;
            label_StatusText.BackColor = Color.White;
            label_StatusText.Font = new Font("Microsoft YaHei UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label_StatusText.ForeColor = Color.FromArgb(64, 64, 64);
            label_StatusText.Location = new Point(121, 45);
            label_StatusText.Name = "label_StatusText";
            label_StatusText.Size = new Size(370, 46);
            label_StatusText.TabIndex = 0;
            label_StatusText.Text = "我们正在保护您的桌面";
            // 
            // pictureBox_Sataus
            // 
            pictureBox_Sataus.BackColor = Color.White;
            pictureBox_Sataus.Image = Properties.Resources.StatusInfo;
            pictureBox_Sataus.Location = new Point(19, 42);
            pictureBox_Sataus.Name = "pictureBox_Sataus";
            pictureBox_Sataus.Size = new Size(96, 96);
            pictureBox_Sataus.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Sataus.TabIndex = 1;
            pictureBox_Sataus.TabStop = false;
            // 
            // pictureBox_Strategy
            // 
            pictureBox_Strategy.BackColor = Color.Transparent;
            pictureBox_Strategy.Image = Properties.Resources.ButtonStrategy;
            pictureBox_Strategy.Location = new Point(306, 414);
            pictureBox_Strategy.Name = "pictureBox_Strategy";
            pictureBox_Strategy.Size = new Size(64, 64);
            pictureBox_Strategy.TabIndex = 2;
            pictureBox_Strategy.TabStop = false;
            pictureBox_Strategy.Tag = "策略";
            toolTip_ButtonTips.SetToolTip(pictureBox_Strategy, "策略");
            pictureBox_Strategy.Click += pictureBox_Strategy_Click;
            pictureBox_Strategy.MouseDown += pictureBox_Strategy_MouseDown;
            pictureBox_Strategy.MouseUp += pictureBox_Strategy_MouseUp;
            // 
            // pictureBox_Manifest
            // 
            pictureBox_Manifest.BackColor = Color.Transparent;
            pictureBox_Manifest.Image = Properties.Resources.ButtonManifest;
            pictureBox_Manifest.Location = new Point(380, 414);
            pictureBox_Manifest.Name = "pictureBox_Manifest";
            pictureBox_Manifest.Size = new Size(64, 64);
            pictureBox_Manifest.TabIndex = 2;
            pictureBox_Manifest.TabStop = false;
            pictureBox_Manifest.Tag = "清单";
            toolTip_ButtonTips.SetToolTip(pictureBox_Manifest, "清单");
            pictureBox_Manifest.Click += pictureBox_Manifest_Click;
            pictureBox_Manifest.MouseDown += pictureBox_Manifest_MouseDown;
            pictureBox_Manifest.MouseUp += pictureBox_Manifest_MouseUp;
            // 
            // pictureBox_Log
            // 
            pictureBox_Log.BackColor = Color.Transparent;
            pictureBox_Log.Image = Properties.Resources.ButtonLog;
            pictureBox_Log.Location = new Point(454, 414);
            pictureBox_Log.Name = "pictureBox_Log";
            pictureBox_Log.Size = new Size(64, 64);
            pictureBox_Log.TabIndex = 2;
            pictureBox_Log.TabStop = false;
            pictureBox_Log.Tag = "日志";
            toolTip_ButtonTips.SetToolTip(pictureBox_Log, "日志");
            pictureBox_Log.Click += pictureBox_Log_Click;
            pictureBox_Log.MouseDown += pictureBox_Log_MouseDown;
            pictureBox_Log.MouseUp += pictureBox_Log_MouseUp;
            // 
            // pictureBox_Statistics
            // 
            pictureBox_Statistics.BackColor = Color.Transparent;
            pictureBox_Statistics.Image = Properties.Resources.ButtonStatistics;
            pictureBox_Statistics.Location = new Point(528, 414);
            pictureBox_Statistics.Name = "pictureBox_Statistics";
            pictureBox_Statistics.Size = new Size(64, 64);
            pictureBox_Statistics.TabIndex = 2;
            pictureBox_Statistics.TabStop = false;
            pictureBox_Statistics.Tag = "统计";
            toolTip_ButtonTips.SetToolTip(pictureBox_Statistics, "统计");
            pictureBox_Statistics.Click += pictureBox_Statistics_Click;
            pictureBox_Statistics.MouseDown += pictureBox_Statistics_MouseDown;
            pictureBox_Statistics.MouseUp += pictureBox_Statistics_MouseUp;
            // 
            // pictureBox_Configure
            // 
            pictureBox_Configure.BackColor = Color.Transparent;
            pictureBox_Configure.Image = Properties.Resources.ButtonConfigure;
            pictureBox_Configure.Location = new Point(602, 414);
            pictureBox_Configure.Name = "pictureBox_Configure";
            pictureBox_Configure.Size = new Size(64, 64);
            pictureBox_Configure.TabIndex = 2;
            pictureBox_Configure.TabStop = false;
            pictureBox_Configure.Tag = "设置";
            toolTip_ButtonTips.SetToolTip(pictureBox_Configure, "设置");
            pictureBox_Configure.Click += pictureBox_Configure_Click;
            pictureBox_Configure.MouseDown += pictureBox_Configure_MouseDown;
            pictureBox_Configure.MouseUp += pictureBox_Configure_MouseUp;
            // 
            // materialSwitch_SwitchWatching
            // 
            materialSwitch_SwitchWatching.AutoSize = true;
            materialSwitch_SwitchWatching.BackColor = Color.White;
            materialSwitch_SwitchWatching.Depth = 0;
            materialSwitch_SwitchWatching.ForeColor = SystemColors.ControlText;
            materialSwitch_SwitchWatching.Location = new Point(121, 101);
            materialSwitch_SwitchWatching.Margin = new Padding(0);
            materialSwitch_SwitchWatching.MouseLocation = new Point(-1, -1);
            materialSwitch_SwitchWatching.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_SwitchWatching.Name = "materialSwitch_SwitchWatching";
            materialSwitch_SwitchWatching.Ripple = true;
            materialSwitch_SwitchWatching.Size = new Size(250, 37);
            materialSwitch_SwitchWatching.TabIndex = 3;
            materialSwitch_SwitchWatching.Text = "单击此处可以切换监视状态";
            materialSwitch_SwitchWatching.UseVisualStyleBackColor = false;
            materialSwitch_SwitchWatching.CheckedChanged += materialSwitch_SwitchWatching_CheckedChanged;
            materialSwitch_SwitchWatching.CheckStateChanged += materialSwitch_SwitchWatching_CheckStateChanged;
            // 
            // materialDivider1
            // 
            materialDivider1.BackColor = Color.White;
            materialDivider1.Depth = 0;
            materialDivider1.Dock = DockStyle.Top;
            materialDivider1.Location = new Point(3, 24);
            materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            materialDivider1.Name = "materialDivider1";
            materialDivider1.Size = new Size(694, 371);
            materialDivider1.TabIndex = 4;
            materialDivider1.Text = "materialDivider1";
            // 
            // toolTip_ButtonTips
            // 
            toolTip_ButtonTips.AutoPopDelay = 5000;
            toolTip_ButtonTips.InitialDelay = 10;
            toolTip_ButtonTips.ReshowDelay = 10;
            // 
            // notifyIcon_Background
            // 
            notifyIcon_Background.Icon = (Icon)resources.GetObject("notifyIcon_Background.Icon");
            notifyIcon_Background.Text = "QLink Cleaner";
            // 
            // materialButton_ResetWatchers
            // 
            materialButton_ResetWatchers.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_ResetWatchers.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_ResetWatchers.Depth = 0;
            materialButton_ResetWatchers.HighEmphasis = true;
            materialButton_ResetWatchers.Icon = null;
            materialButton_ResetWatchers.Location = new Point(412, 249);
            materialButton_ResetWatchers.Margin = new Padding(4, 6, 4, 6);
            materialButton_ResetWatchers.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_ResetWatchers.Name = "materialButton_ResetWatchers";
            materialButton_ResetWatchers.NoAccentTextColor = Color.Empty;
            materialButton_ResetWatchers.Size = new Size(85, 36);
            materialButton_ResetWatchers.TabIndex = 5;
            materialButton_ResetWatchers.Text = "重置监视";
            materialButton_ResetWatchers.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton_ResetWatchers.UseAccentColor = false;
            materialButton_ResetWatchers.UseVisualStyleBackColor = true;
            materialButton_ResetWatchers.Click += materialButton_ResetWatchers_Click;
            // 
            // materialButton_CleanNow
            // 
            materialButton_CleanNow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_CleanNow.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_CleanNow.Depth = 0;
            materialButton_CleanNow.HighEmphasis = true;
            materialButton_CleanNow.Icon = null;
            materialButton_CleanNow.Location = new Point(428, 209);
            materialButton_CleanNow.Margin = new Padding(4, 6, 4, 6);
            materialButton_CleanNow.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_CleanNow.Name = "materialButton_CleanNow";
            materialButton_CleanNow.NoAccentTextColor = Color.Empty;
            materialButton_CleanNow.Size = new Size(85, 36);
            materialButton_CleanNow.TabIndex = 6;
            materialButton_CleanNow.Text = "立即清理";
            materialButton_CleanNow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton_CleanNow.UseAccentColor = false;
            materialButton_CleanNow.UseVisualStyleBackColor = true;
            materialButton_CleanNow.Click += materialButton_CleanNow_Click;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(129, 219);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(289, 19);
            materialLabel1.TabIndex = 7;
            materialLabel1.Text = "若您需要现在清理桌面快捷方式，请单击";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(129, 259);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(273, 19);
            materialLabel2.TabIndex = 7;
            materialLabel2.Text = "若需要重置应用程序的监视器，请单击";
            // 
            // materialLabel_CurrentStrategy
            // 
            materialLabel_CurrentStrategy.AutoSize = true;
            materialLabel_CurrentStrategy.Depth = 0;
            materialLabel_CurrentStrategy.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel_CurrentStrategy.Location = new Point(129, 179);
            materialLabel_CurrentStrategy.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_CurrentStrategy.Name = "materialLabel_CurrentStrategy";
            materialLabel_CurrentStrategy.Size = new Size(177, 19);
            materialLabel_CurrentStrategy.TabIndex = 8;
            materialLabel_CurrentStrategy.Text = "当前已应用的拦截策略：";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 536);
            Controls.Add(materialLabel_CurrentStrategy);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(materialButton_CleanNow);
            Controls.Add(materialButton_ResetWatchers);
            Controls.Add(materialSwitch_SwitchWatching);
            Controls.Add(pictureBox_Configure);
            Controls.Add(pictureBox_Statistics);
            Controls.Add(pictureBox_Log);
            Controls.Add(pictureBox_Manifest);
            Controls.Add(pictureBox_Strategy);
            Controls.Add(pictureBox_Sataus);
            Controls.Add(label_StatusText);
            Controls.Add(materialDivider1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            FormStyle = FormStyles.ActionBar_None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Padding = new Padding(3, 24, 3, 3);
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QLink Cleaner";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            VisibleChanged += MainForm_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)pictureBox_Sataus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Strategy).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Manifest).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Log).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Statistics).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Configure).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_StatusText;
        private PictureBox pictureBox_Sataus;
        private PictureBox pictureBox_Strategy;
        private PictureBox pictureBox_Manifest;
        private PictureBox pictureBox_Log;
        private PictureBox pictureBox_Statistics;
        private PictureBox pictureBox_Configure;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch_SwitchWatching;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private ToolTip toolTip_ButtonTips;
        private NotifyIcon notifyIcon_Background;
        private MaterialSkin.Controls.MaterialButton materialButton_ResetWatchers;
        private MaterialSkin.Controls.MaterialButton materialButton_CleanNow;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel_CurrentStrategy;
    }
}
