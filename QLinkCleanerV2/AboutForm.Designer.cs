namespace QLinkCleanerV2
{
    partial class AboutForm
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
            materialLabel_Version = new MaterialSkin.Controls.MaterialLabel();
            materialLabel_LastBuildDate = new MaterialSkin.Controls.MaterialLabel();
            materialLabel_Copyright = new MaterialSkin.Controls.MaterialLabel();
            materialButton_Accept = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel_Version
            // 
            materialLabel_Version.AutoSize = true;
            materialLabel_Version.Depth = 0;
            materialLabel_Version.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel_Version.Location = new Point(17, 87);
            materialLabel_Version.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_Version.Name = "materialLabel_Version";
            materialLabel_Version.Size = new Size(54, 19);
            materialLabel_Version.TabIndex = 0;
            materialLabel_Version.Text = "Version";
            // 
            // materialLabel_LastBuildDate
            // 
            materialLabel_LastBuildDate.AutoSize = true;
            materialLabel_LastBuildDate.Depth = 0;
            materialLabel_LastBuildDate.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel_LastBuildDate.Location = new Point(17, 116);
            materialLabel_LastBuildDate.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_LastBuildDate.Name = "materialLabel_LastBuildDate";
            materialLabel_LastBuildDate.Size = new Size(101, 19);
            materialLabel_LastBuildDate.TabIndex = 1;
            materialLabel_LastBuildDate.Text = "LastBuildDate";
            // 
            // materialLabel_Copyright
            // 
            materialLabel_Copyright.AutoSize = true;
            materialLabel_Copyright.Depth = 0;
            materialLabel_Copyright.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel_Copyright.Location = new Point(17, 145);
            materialLabel_Copyright.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_Copyright.Name = "materialLabel_Copyright";
            materialLabel_Copyright.Size = new Size(69, 19);
            materialLabel_Copyright.TabIndex = 2;
            materialLabel_Copyright.Text = "Copyright";
            // 
            // materialButton_Accept
            // 
            materialButton_Accept.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Accept.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Accept.Depth = 0;
            materialButton_Accept.HighEmphasis = true;
            materialButton_Accept.Icon = null;
            materialButton_Accept.Location = new Point(300, 216);
            materialButton_Accept.Margin = new Padding(4, 6, 4, 6);
            materialButton_Accept.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Accept.Name = "materialButton_Accept";
            materialButton_Accept.NoAccentTextColor = Color.Empty;
            materialButton_Accept.Size = new Size(64, 36);
            materialButton_Accept.TabIndex = 3;
            materialButton_Accept.Text = "确认";
            materialButton_Accept.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_Accept.UseAccentColor = false;
            materialButton_Accept.UseVisualStyleBackColor = true;
            materialButton_Accept.Click += materialButton_Accept_Click;
            // 
            // AboutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 267);
            Controls.Add(materialButton_Accept);
            Controls.Add(materialLabel_Copyright);
            Controls.Add(materialLabel_LastBuildDate);
            Controls.Add(materialLabel_Version);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "关于 QLink Cleaner";
            Load += AboutForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel_Version;
        private MaterialSkin.Controls.MaterialLabel materialLabel_LastBuildDate;
        private MaterialSkin.Controls.MaterialLabel materialLabel_Copyright;
        private MaterialSkin.Controls.MaterialButton materialButton_Accept;
    }
}