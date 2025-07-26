namespace QLinkCleanerV2
{
    partial class InterceptionResultForm
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
            components = new System.ComponentModel.Container();
            materialMultiLineTextBox_Tips = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            materialButton_Accept = new MaterialSkin.Controls.MaterialButton();
            materialLabel_Countdown = new MaterialSkin.Controls.MaterialLabel();
            timer_Countdown = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // materialMultiLineTextBox_Tips
            // 
            materialMultiLineTextBox_Tips.BackColor = Color.FromArgb(255, 255, 255);
            materialMultiLineTextBox_Tips.BorderStyle = BorderStyle.None;
            materialMultiLineTextBox_Tips.Depth = 0;
            materialMultiLineTextBox_Tips.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialMultiLineTextBox_Tips.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialMultiLineTextBox_Tips.Location = new Point(15, 37);
            materialMultiLineTextBox_Tips.MouseState = MaterialSkin.MouseState.HOVER;
            materialMultiLineTextBox_Tips.Name = "materialMultiLineTextBox_Tips";
            materialMultiLineTextBox_Tips.Size = new Size(343, 152);
            materialMultiLineTextBox_Tips.TabIndex = 0;
            materialMultiLineTextBox_Tips.Text = "";
            // 
            // materialDivider1
            // 
            materialDivider1.BackColor = Color.White;
            materialDivider1.Depth = 0;
            materialDivider1.Dock = DockStyle.Top;
            materialDivider1.Location = new Point(3, 24);
            materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            materialDivider1.Name = "materialDivider1";
            materialDivider1.Size = new Size(367, 181);
            materialDivider1.TabIndex = 1;
            materialDivider1.Text = "materialDivider1";
            // 
            // materialButton_Accept
            // 
            materialButton_Accept.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Accept.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Accept.Depth = 0;
            materialButton_Accept.HighEmphasis = true;
            materialButton_Accept.Icon = null;
            materialButton_Accept.Location = new Point(294, 214);
            materialButton_Accept.Margin = new Padding(4, 6, 4, 6);
            materialButton_Accept.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Accept.Name = "materialButton_Accept";
            materialButton_Accept.NoAccentTextColor = Color.Empty;
            materialButton_Accept.Size = new Size(64, 36);
            materialButton_Accept.TabIndex = 2;
            materialButton_Accept.Text = "确认";
            materialButton_Accept.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_Accept.UseAccentColor = false;
            materialButton_Accept.UseVisualStyleBackColor = true;
            materialButton_Accept.Click += materialButton_Accept_Click;
            // 
            // materialLabel_Countdown
            // 
            materialLabel_Countdown.AutoSize = true;
            materialLabel_Countdown.Depth = 0;
            materialLabel_Countdown.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel_Countdown.Location = new Point(15, 224);
            materialLabel_Countdown.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_Countdown.Name = "materialLabel_Countdown";
            materialLabel_Countdown.Size = new Size(192, 19);
            materialLabel_Countdown.TabIndex = 3;
            materialLabel_Countdown.Text = "提示框将在 15 秒后自动关闭";
            // 
            // timer_Countdown
            // 
            timer_Countdown.Interval = 1000;
            timer_Countdown.Tick += timer_Countdown_Tick;
            // 
            // InterceptionResultForm
            // 
            AcceptButton = materialButton_Accept;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 262);
            Controls.Add(materialLabel_Countdown);
            Controls.Add(materialButton_Accept);
            Controls.Add(materialMultiLineTextBox_Tips);
            Controls.Add(materialDivider1);
            FormStyle = FormStyles.ActionBar_None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InterceptionResultForm";
            Padding = new Padding(3, 24, 3, 3);
            Sizable = false;
            Text = "Interception Result";
            Load += InterceptionResultForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialMultiLineTextBox materialMultiLineTextBox_Tips;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialButton materialButton_Accept;
        private MaterialSkin.Controls.MaterialLabel materialLabel_Countdown;
        private System.Windows.Forms.Timer timer_Countdown;
    }
}