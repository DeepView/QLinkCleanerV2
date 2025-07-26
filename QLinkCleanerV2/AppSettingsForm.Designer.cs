namespace QLinkCleanerV2
{
    partial class AppSettingsForm
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
            materialSwitch_Startup = new MaterialSkin.Controls.MaterialSwitch();
            materialButton_AboutThis = new MaterialSkin.Controls.MaterialButton();
            materialSlider_RetryTimes = new MaterialSkin.Controls.MaterialSlider();
            SuspendLayout();
            // 
            // materialSwitch_Startup
            // 
            materialSwitch_Startup.AutoSize = true;
            materialSwitch_Startup.Depth = 0;
            materialSwitch_Startup.Location = new Point(16, 76);
            materialSwitch_Startup.Margin = new Padding(0);
            materialSwitch_Startup.MouseLocation = new Point(-1, -1);
            materialSwitch_Startup.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch_Startup.Name = "materialSwitch_Startup";
            materialSwitch_Startup.Ripple = true;
            materialSwitch_Startup.Size = new Size(247, 37);
            materialSwitch_Startup.TabIndex = 0;
            materialSwitch_Startup.Text = "登录Windows之后自动启动\r\n";
            materialSwitch_Startup.UseVisualStyleBackColor = true;
            // 
            // materialButton_AboutThis
            // 
            materialButton_AboutThis.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_AboutThis.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_AboutThis.Depth = 0;
            materialButton_AboutThis.HighEmphasis = true;
            materialButton_AboutThis.Icon = null;
            materialButton_AboutThis.Location = new Point(16, 290);
            materialButton_AboutThis.Margin = new Padding(4, 6, 4, 6);
            materialButton_AboutThis.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_AboutThis.Name = "materialButton_AboutThis";
            materialButton_AboutThis.NoAccentTextColor = Color.Empty;
            materialButton_AboutThis.Size = new Size(167, 36);
            materialButton_AboutThis.TabIndex = 1;
            materialButton_AboutThis.Text = "关于 QLink Cleaner";
            materialButton_AboutThis.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            materialButton_AboutThis.UseAccentColor = false;
            materialButton_AboutThis.UseVisualStyleBackColor = true;
            materialButton_AboutThis.Click += materialButton_AboutThis_Click;
            // 
            // materialSlider_RetryTimes
            // 
            materialSlider_RetryTimes.Depth = 0;
            materialSlider_RetryTimes.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialSlider_RetryTimes.Location = new Point(21, 116);
            materialSlider_RetryTimes.MouseState = MaterialSkin.MouseState.HOVER;
            materialSlider_RetryTimes.Name = "materialSlider_RetryTimes";
            materialSlider_RetryTimes.RangeMax = 1000;
            materialSlider_RetryTimes.Size = new Size(434, 40);
            materialSlider_RetryTimes.TabIndex = 2;
            materialSlider_RetryTimes.Text = "删除快捷方式的最大重试次数";
            materialSlider_RetryTimes.Value = 500;
            materialSlider_RetryTimes.ValueMax = 1000;
            materialSlider_RetryTimes.ValueSuffix = "次";
            materialSlider_RetryTimes.onValueChanged += materialSlider_RetryTimes_onValueChanged;
            materialSlider_RetryTimes.Click += materialSlider_RetryTimes_Click;
            // 
            // AppSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 346);
            Controls.Add(materialSlider_RetryTimes);
            Controls.Add(materialButton_AboutThis);
            Controls.Add(materialSwitch_Startup);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AppSettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "应用程序设置";
            Load += AppSettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialSwitch materialSwitch_Startup;
        private MaterialSkin.Controls.MaterialButton materialButton_AboutThis;
        private MaterialSkin.Controls.MaterialSlider materialSlider_RetryTimes;
    }
}