namespace QLinkCleanerV2
{
    partial class StrategySetForm
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
            materialComboBox_Strategy = new MaterialSkin.Controls.MaterialComboBox();
            materialButton_Cancel = new MaterialSkin.Controls.MaterialButton();
            materialButton_Accept = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialComboBox_Strategy
            // 
            materialComboBox_Strategy.AutoResize = false;
            materialComboBox_Strategy.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox_Strategy.Depth = 0;
            materialComboBox_Strategy.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox_Strategy.DropDownHeight = 174;
            materialComboBox_Strategy.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox_Strategy.DropDownWidth = 121;
            materialComboBox_Strategy.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox_Strategy.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox_Strategy.FormattingEnabled = true;
            materialComboBox_Strategy.IntegralHeight = false;
            materialComboBox_Strategy.ItemHeight = 43;
            materialComboBox_Strategy.Items.AddRange(new object[] { "监视所有的快捷方式", "黑名单模式", "白名单模式" });
            materialComboBox_Strategy.Location = new Point(19, 93);
            materialComboBox_Strategy.MaxDropDownItems = 4;
            materialComboBox_Strategy.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox_Strategy.Name = "materialComboBox_Strategy";
            materialComboBox_Strategy.Size = new Size(295, 49);
            materialComboBox_Strategy.StartIndex = 0;
            materialComboBox_Strategy.TabIndex = 0;
            // 
            // materialButton_Cancel
            // 
            materialButton_Cancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Cancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Cancel.Depth = 0;
            materialButton_Cancel.HighEmphasis = true;
            materialButton_Cancel.Icon = null;
            materialButton_Cancel.Location = new Point(178, 194);
            materialButton_Cancel.Margin = new Padding(4, 6, 4, 6);
            materialButton_Cancel.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Cancel.Name = "materialButton_Cancel";
            materialButton_Cancel.NoAccentTextColor = Color.Empty;
            materialButton_Cancel.Size = new Size(64, 36);
            materialButton_Cancel.TabIndex = 1;
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
            materialButton_Accept.Location = new Point(250, 194);
            materialButton_Accept.Margin = new Padding(4, 6, 4, 6);
            materialButton_Accept.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Accept.Name = "materialButton_Accept";
            materialButton_Accept.NoAccentTextColor = Color.Empty;
            materialButton_Accept.Size = new Size(64, 36);
            materialButton_Accept.TabIndex = 1;
            materialButton_Accept.Text = "确认";
            materialButton_Accept.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_Accept.UseAccentColor = false;
            materialButton_Accept.UseVisualStyleBackColor = true;
            materialButton_Accept.Click += materialButton_Accept_Click;
            // 
            // StrategySetForm
            // 
            AcceptButton = materialButton_Accept;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = materialButton_Cancel;
            ClientSize = new Size(334, 252);
            Controls.Add(materialButton_Accept);
            Controls.Add(materialButton_Cancel);
            Controls.Add(materialComboBox_Strategy);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StrategySetForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "拦截策略";
            Load += StrategySetForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox materialComboBox_Strategy;
        private MaterialSkin.Controls.MaterialButton materialButton_Cancel;
        private MaterialSkin.Controls.MaterialButton materialButton_Accept;
    }
}