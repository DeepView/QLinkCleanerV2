namespace QLinkCleanerV2
{
    partial class ManifestForm
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
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialComboBox_ManifestType = new MaterialSkin.Controls.MaterialComboBox();
            materialButton_Add = new MaterialSkin.Controls.MaterialButton();
            materialButton_Remove = new MaterialSkin.Controls.MaterialButton();
            materialButton_Modify = new MaterialSkin.Controls.MaterialButton();
            materialListView_ManifestView = new MaterialSkin.Controls.MaterialListView();
            Col_Name = new ColumnHeader();
            Col_UserDesktop = new ColumnHeader();
            Col_PublicDesktop = new ColumnHeader();
            Col_Last = new ColumnHeader();
            materialButton_Save = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(15, 95);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(61, 19);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "清单类型";
            // 
            // materialComboBox_ManifestType
            // 
            materialComboBox_ManifestType.AutoResize = false;
            materialComboBox_ManifestType.BackColor = Color.FromArgb(255, 255, 255);
            materialComboBox_ManifestType.Depth = 0;
            materialComboBox_ManifestType.DrawMode = DrawMode.OwnerDrawVariable;
            materialComboBox_ManifestType.DropDownHeight = 118;
            materialComboBox_ManifestType.DropDownStyle = ComboBoxStyle.DropDownList;
            materialComboBox_ManifestType.DropDownWidth = 121;
            materialComboBox_ManifestType.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialComboBox_ManifestType.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialComboBox_ManifestType.FormattingEnabled = true;
            materialComboBox_ManifestType.IntegralHeight = false;
            materialComboBox_ManifestType.ItemHeight = 29;
            materialComboBox_ManifestType.Items.AddRange(new object[] { "黑名单", "白名单" });
            materialComboBox_ManifestType.Location = new Point(82, 88);
            materialComboBox_ManifestType.MaxDropDownItems = 4;
            materialComboBox_ManifestType.MouseState = MaterialSkin.MouseState.OUT;
            materialComboBox_ManifestType.Name = "materialComboBox_ManifestType";
            materialComboBox_ManifestType.Size = new Size(196, 35);
            materialComboBox_ManifestType.StartIndex = 0;
            materialComboBox_ManifestType.TabIndex = 1;
            materialComboBox_ManifestType.UseTallSize = false;
            materialComboBox_ManifestType.SelectedIndexChanged += materialComboBox_ManifestType_SelectedIndexChanged;
            // 
            // materialButton_Add
            // 
            materialButton_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Add.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Add.Depth = 0;
            materialButton_Add.HighEmphasis = true;
            materialButton_Add.Icon = null;
            materialButton_Add.Location = new Point(552, 85);
            materialButton_Add.Margin = new Padding(4, 6, 4, 6);
            materialButton_Add.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Add.Name = "materialButton_Add";
            materialButton_Add.NoAccentTextColor = Color.Empty;
            materialButton_Add.Size = new Size(64, 36);
            materialButton_Add.TabIndex = 2;
            materialButton_Add.Text = "添加";
            materialButton_Add.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton_Add.UseAccentColor = false;
            materialButton_Add.UseVisualStyleBackColor = true;
            materialButton_Add.Click += materialButton_Add_Click;
            // 
            // materialButton_Remove
            // 
            materialButton_Remove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Remove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Remove.Depth = 0;
            materialButton_Remove.HighEmphasis = true;
            materialButton_Remove.Icon = null;
            materialButton_Remove.Location = new Point(624, 85);
            materialButton_Remove.Margin = new Padding(4, 6, 4, 6);
            materialButton_Remove.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Remove.Name = "materialButton_Remove";
            materialButton_Remove.NoAccentTextColor = Color.Empty;
            materialButton_Remove.Size = new Size(64, 36);
            materialButton_Remove.TabIndex = 2;
            materialButton_Remove.Text = "删除";
            materialButton_Remove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton_Remove.UseAccentColor = false;
            materialButton_Remove.UseVisualStyleBackColor = true;
            materialButton_Remove.Click += materialButton_Remove_Click;
            // 
            // materialButton_Modify
            // 
            materialButton_Modify.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Modify.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Modify.Depth = 0;
            materialButton_Modify.HighEmphasis = true;
            materialButton_Modify.Icon = null;
            materialButton_Modify.Location = new Point(696, 85);
            materialButton_Modify.Margin = new Padding(4, 6, 4, 6);
            materialButton_Modify.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Modify.Name = "materialButton_Modify";
            materialButton_Modify.NoAccentTextColor = Color.Empty;
            materialButton_Modify.Size = new Size(64, 36);
            materialButton_Modify.TabIndex = 2;
            materialButton_Modify.Text = "修改";
            materialButton_Modify.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButton_Modify.UseAccentColor = false;
            materialButton_Modify.UseVisualStyleBackColor = true;
            materialButton_Modify.Click += materialButton_Modify_Click;
            // 
            // materialListView_ManifestView
            // 
            materialListView_ManifestView.AutoSizeTable = false;
            materialListView_ManifestView.BackColor = Color.FromArgb(255, 255, 255);
            materialListView_ManifestView.BorderStyle = BorderStyle.None;
            materialListView_ManifestView.Columns.AddRange(new ColumnHeader[] { Col_Name, Col_UserDesktop, Col_PublicDesktop, Col_Last });
            materialListView_ManifestView.Depth = 0;
            materialListView_ManifestView.FullRowSelect = true;
            materialListView_ManifestView.Location = new Point(15, 147);
            materialListView_ManifestView.MinimumSize = new Size(200, 100);
            materialListView_ManifestView.MouseLocation = new Point(-1, -1);
            materialListView_ManifestView.MouseState = MaterialSkin.MouseState.OUT;
            materialListView_ManifestView.MultiSelect = false;
            materialListView_ManifestView.Name = "materialListView_ManifestView";
            materialListView_ManifestView.OwnerDraw = true;
            materialListView_ManifestView.Size = new Size(817, 405);
            materialListView_ManifestView.TabIndex = 3;
            materialListView_ManifestView.UseCompatibleStateImageBehavior = false;
            materialListView_ManifestView.View = View.Details;
            materialListView_ManifestView.SelectedIndexChanged += materialListView_ManifestView_SelectedIndexChanged;
            // 
            // Col_Name
            // 
            Col_Name.Text = "快捷方式名称";
            Col_Name.Width = 260;
            // 
            // Col_UserDesktop
            // 
            Col_UserDesktop.Text = "是否监视用户桌面";
            Col_UserDesktop.Width = 160;
            // 
            // Col_PublicDesktop
            // 
            Col_PublicDesktop.Text = "是否监视公共桌面";
            Col_PublicDesktop.Width = 160;
            // 
            // Col_Last
            // 
            Col_Last.Text = "最近拦截日期时间";
            Col_Last.Width = 200;
            // 
            // materialButton_Save
            // 
            materialButton_Save.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton_Save.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton_Save.Depth = 0;
            materialButton_Save.HighEmphasis = true;
            materialButton_Save.Icon = null;
            materialButton_Save.Location = new Point(768, 85);
            materialButton_Save.Margin = new Padding(4, 6, 4, 6);
            materialButton_Save.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton_Save.Name = "materialButton_Save";
            materialButton_Save.NoAccentTextColor = Color.Empty;
            materialButton_Save.Size = new Size(64, 36);
            materialButton_Save.TabIndex = 2;
            materialButton_Save.Text = "保存";
            materialButton_Save.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton_Save.UseAccentColor = false;
            materialButton_Save.UseVisualStyleBackColor = true;
            materialButton_Save.Click += materialButton_Save_Click;
            // 
            // ManifestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 568);
            Controls.Add(materialListView_ManifestView);
            Controls.Add(materialButton_Save);
            Controls.Add(materialButton_Modify);
            Controls.Add(materialButton_Remove);
            Controls.Add(materialButton_Add);
            Controls.Add(materialComboBox_ManifestType);
            Controls.Add(materialLabel1);
            MaximizeBox = false;
            Name = "ManifestForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "清单管理";
            Load += ManifestForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox_ManifestType;
        private MaterialSkin.Controls.MaterialButton materialButton_Add;
        private MaterialSkin.Controls.MaterialButton materialButton_Remove;
        private MaterialSkin.Controls.MaterialButton materialButton_Modify;
        private MaterialSkin.Controls.MaterialListView materialListView_ManifestView;
        private ColumnHeader Col_Name;
        private ColumnHeader Col_UserDesktop;
        private ColumnHeader Col_PublicDesktop;
        private MaterialSkin.Controls.MaterialButton materialButton_Save;
        private ColumnHeader Col_Last;
    }
}