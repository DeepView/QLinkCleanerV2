namespace QLinkCleanerV2
{
    partial class LogDetailForm
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
            materialLabel_Type = new MaterialSkin.Controls.MaterialLabel();
            materialLabel_Level = new MaterialSkin.Controls.MaterialLabel();
            materialMultiLineTextBox_Detail = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            materialButton_Copy = new MaterialSkin.Controls.MaterialButton();
            materialButton_Accept = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel_Type
            // 
            materialLabel_Type.AutoSize = true;
            materialLabel_Type.Depth = 0;
            materialLabel_Type.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel_Type.Location = new Point(16, 80);
            materialLabel_Type.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_Type.Name = "materialLabel_Type";
            materialLabel_Type.Size = new Size(107, 19);
            materialLabel_Type.TabIndex = 0;
            materialLabel_Type.Text = "materialLabel1";
            // 
            // materialLabel_Level
            // 
            materialLabel_Level.AutoSize = true;
            materialLabel_Level.Depth = 0;
            materialLabel_Level.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel_Level.Location = new Point(16, 110);
            materialLabel_Level.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel_Level.Name = "materialLabel_Level";
            materialLabel_Level.Size = new Size(107, 19);
            materialLabel_Level.TabIndex = 1;
            materialLabel_Level.Text = "materialLabel1";
            // 
            // materialMultiLineTextBox_Detail
            // 
            materialMultiLineTextBox_Detail.AnimateReadOnly = false;
            materialMultiLineTextBox_Detail.BackgroundImageLayout = ImageLayout.None;
            materialMultiLineTextBox_Detail.CharacterCasing = CharacterCasing.Normal;
            materialMultiLineTextBox_Detail.Depth = 0;
            materialMultiLineTextBox_Detail.HideSelection = true;
            materialMultiLineTextBox_Detail.Location = new Point(16, 145);
            materialMultiLineTextBox_Detail.MaxLength = 32767;
            materialMultiLineTextBox_Detail.MouseState = MaterialSkin.MouseState.OUT;
            materialMultiLineTextBox_Detail.Name = "materialMultiLineTextBox_Detail";
            materialMultiLineTextBox_Detail.PasswordChar = '\0';
            materialMultiLineTextBox_Detail.ReadOnly = true;
            materialMultiLineTextBox_Detail.ScrollBars = ScrollBars.None;
            materialMultiLineTextBox_Detail.SelectedText = "";
            materialMultiLineTextBox_Detail.SelectionLength = 0;
            materialMultiLineTextBox_Detail.SelectionStart = 0;
            materialMultiLineTextBox_Detail.ShortcutsEnabled = true;
            materialMultiLineTextBox_Detail.Size = new Size(372, 156);
            materialMultiLineTextBox_Detail.TabIndex = 2;
            materialMultiLineTextBox_Detail.TabStop = false;
            materialMultiLineTextBox_Detail.Text = "materialMultiLineTextBox21";
            materialMultiLineTextBox_Detail.TextAlign = HorizontalAlignment.Left;
            materialMultiLineTextBox_Detail.UseSystemPasswordChar = false;
            // 
            // materialButton_Copy
            // 
            materialButton_Copy.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Copy.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Copy.Depth = 0;
            materialButton_Copy.HighEmphasis = true;
            materialButton_Copy.Icon = null;
            materialButton_Copy.Location = new Point(252, 327);
            materialButton_Copy.Margin = new Padding(4, 6, 4, 6);
            materialButton_Copy.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Copy.Name = "materialButton_Copy";
            materialButton_Copy.NoAccentTextColor = Color.Empty;
            materialButton_Copy.Size = new Size(64, 36);
            materialButton_Copy.TabIndex = 3;
            materialButton_Copy.Text = "复制";
            materialButton_Copy.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton_Copy.UseAccentColor = false;
            materialButton_Copy.UseVisualStyleBackColor = true;
            materialButton_Copy.Click += materialButton_Copy_Click;
            // 
            // materialButton_Accept
            // 
            materialButton_Accept.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Accept.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Accept.Depth = 0;
            materialButton_Accept.HighEmphasis = true;
            materialButton_Accept.Icon = null;
            materialButton_Accept.Location = new Point(324, 327);
            materialButton_Accept.Margin = new Padding(4, 6, 4, 6);
            materialButton_Accept.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Accept.Name = "materialButton_Accept";
            materialButton_Accept.NoAccentTextColor = Color.Empty;
            materialButton_Accept.Size = new Size(64, 36);
            materialButton_Accept.TabIndex = 0;
            materialButton_Accept.Text = "确认";
            materialButton_Accept.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_Accept.UseAccentColor = false;
            materialButton_Accept.UseVisualStyleBackColor = true;
            materialButton_Accept.Click += materialButton_Accept_Click;
            // 
            // LogDetailForm
            // 
            AcceptButton = materialButton_Accept;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(405, 376);
            Controls.Add(materialButton_Accept);
            Controls.Add(materialButton_Copy);
            Controls.Add(materialMultiLineTextBox_Detail);
            Controls.Add(materialLabel_Level);
            Controls.Add(materialLabel_Type);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LogDetailForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "日志详细";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel_Type;
        private MaterialSkin.Controls.MaterialLabel materialLabel_Level;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 materialMultiLineTextBox_Detail;
        private MaterialSkin.Controls.MaterialButton materialButton_Copy;
        private MaterialSkin.Controls.MaterialButton materialButton_Accept;
    }
}