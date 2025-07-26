namespace QLinkCleanerV2
{
    partial class SingleDataForm
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
            materialTextBox_Name = new MaterialSkin.Controls.MaterialTextBox();
            materialCheckbox_UserDesktop = new MaterialSkin.Controls.MaterialCheckbox();
            materialCheckbox_PublicDesktop = new MaterialSkin.Controls.MaterialCheckbox();
            materialButton_Cancel = new MaterialSkin.Controls.MaterialButton();
            materialButton_Accept = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialTextBox_Name
            // 
            materialTextBox_Name.AnimateReadOnly = false;
            materialTextBox_Name.BorderStyle = BorderStyle.None;
            materialTextBox_Name.Depth = 0;
            materialTextBox_Name.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBox_Name.Hint = "快捷方式名称";
            materialTextBox_Name.LeadingIcon = null;
            materialTextBox_Name.Location = new Point(22, 84);
            materialTextBox_Name.MaxLength = 50;
            materialTextBox_Name.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBox_Name.Multiline = false;
            materialTextBox_Name.Name = "materialTextBox_Name";
            materialTextBox_Name.Size = new Size(337, 36);
            materialTextBox_Name.TabIndex = 0;
            materialTextBox_Name.Text = "";
            materialTextBox_Name.TrailingIcon = null;
            materialTextBox_Name.UseTallSize = false;
            // 
            // materialCheckbox_UserDesktop
            // 
            materialCheckbox_UserDesktop.AutoSize = true;
            materialCheckbox_UserDesktop.Depth = 0;
            materialCheckbox_UserDesktop.Location = new Point(13, 133);
            materialCheckbox_UserDesktop.Margin = new Padding(0);
            materialCheckbox_UserDesktop.MouseLocation = new Point(-1, -1);
            materialCheckbox_UserDesktop.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox_UserDesktop.Name = "materialCheckbox_UserDesktop";
            materialCheckbox_UserDesktop.ReadOnly = false;
            materialCheckbox_UserDesktop.Ripple = true;
            materialCheckbox_UserDesktop.Size = new Size(185, 37);
            materialCheckbox_UserDesktop.TabIndex = 2;
            materialCheckbox_UserDesktop.Text = "是否监控当前用户桌面";
            materialCheckbox_UserDesktop.UseVisualStyleBackColor = true;
            // 
            // materialCheckbox_PublicDesktop
            // 
            materialCheckbox_PublicDesktop.AutoSize = true;
            materialCheckbox_PublicDesktop.Depth = 0;
            materialCheckbox_PublicDesktop.Location = new Point(13, 170);
            materialCheckbox_PublicDesktop.Margin = new Padding(0);
            materialCheckbox_PublicDesktop.MouseLocation = new Point(-1, -1);
            materialCheckbox_PublicDesktop.MouseState = MaterialSkin.MouseState.HOVER;
            materialCheckbox_PublicDesktop.Name = "materialCheckbox_PublicDesktop";
            materialCheckbox_PublicDesktop.ReadOnly = false;
            materialCheckbox_PublicDesktop.Ripple = true;
            materialCheckbox_PublicDesktop.Size = new Size(155, 37);
            materialCheckbox_PublicDesktop.TabIndex = 2;
            materialCheckbox_PublicDesktop.Text = "是否监控公共桌面";
            materialCheckbox_PublicDesktop.UseVisualStyleBackColor = true;
            // 
            // materialButton_Cancel
            // 
            materialButton_Cancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Cancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Cancel.Depth = 0;
            materialButton_Cancel.HighEmphasis = true;
            materialButton_Cancel.Icon = null;
            materialButton_Cancel.Location = new Point(223, 229);
            materialButton_Cancel.Margin = new Padding(4, 6, 4, 6);
            materialButton_Cancel.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Cancel.Name = "materialButton_Cancel";
            materialButton_Cancel.NoAccentTextColor = Color.Empty;
            materialButton_Cancel.Size = new Size(64, 36);
            materialButton_Cancel.TabIndex = 3;
            materialButton_Cancel.Text = "取消";
            materialButton_Cancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton_Cancel.UseAccentColor = false;
            materialButton_Cancel.UseVisualStyleBackColor = true;
            materialButton_Cancel.Click += materialButton_Cancel_Click;
            // 
            // materialButton_Accept
            // 
            materialButton_Accept.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Accept.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Accept.Depth = 0;
            materialButton_Accept.HighEmphasis = true;
            materialButton_Accept.Icon = null;
            materialButton_Accept.Location = new Point(295, 229);
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
            // SingleDataForm
            // 
            AcceptButton = materialButton_Accept;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = materialButton_Cancel;
            ClientSize = new Size(383, 285);
            Controls.Add(materialButton_Accept);
            Controls.Add(materialButton_Cancel);
            Controls.Add(materialCheckbox_PublicDesktop);
            Controls.Add(materialCheckbox_UserDesktop);
            Controls.Add(materialTextBox_Name);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SingleDataForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "SingleDataForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox materialTextBox_Name;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_UserDesktop;
        private MaterialSkin.Controls.MaterialCheckbox materialCheckbox_PublicDesktop;
        private MaterialSkin.Controls.MaterialButton materialButton_Cancel;
        private MaterialSkin.Controls.MaterialButton materialButton_Accept;
    }
}