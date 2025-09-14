namespace QLinkCleanerV2
{
    partial class TestDomainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestDomainForm));
            label1 = new Label();
            linkLabel_ShowUnhandledExceptionDialog = new LinkLabel();
            button_Close = new Button();
            linkLabel_ViewStackTraceInfo = new LinkLabel();
            splitContainer_Page = new SplitContainer();
            groupBox_Test = new GroupBox();
            groupBox_Debug = new GroupBox();
            linkLabel_OpenTraceDir = new LinkLabel();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Page).BeginInit();
            splitContainer_Page.Panel1.SuspendLayout();
            splitContainer_Page.Panel2.SuspendLayout();
            splitContainer_Page.SuspendLayout();
            groupBox_Test.SuspendLayout();
            groupBox_Debug.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(805, 39);
            label1.TabIndex = 1;
            label1.Text = "Test Domain 是一个用于测试应用程序部分功能的窗口，在这里，将会有一些等待验证和方便开发者Debug的功能，以帮助开发者改善用户体验。在未来，这里也可能会加入更多的测试选项，方便应用程序的测试以及异常排查。";
            // 
            // linkLabel_ShowUnhandledExceptionDialog
            // 
            linkLabel_ShowUnhandledExceptionDialog.AutoSize = true;
            linkLabel_ShowUnhandledExceptionDialog.Location = new Point(6, 35);
            linkLabel_ShowUnhandledExceptionDialog.Name = "linkLabel_ShowUnhandledExceptionDialog";
            linkLabel_ShowUnhandledExceptionDialog.Size = new Size(138, 17);
            linkLabel_ShowUnhandledExceptionDialog.TabIndex = 2;
            linkLabel_ShowUnhandledExceptionDialog.TabStop = true;
            linkLabel_ShowUnhandledExceptionDialog.Text = "弹出“未捕获异常”对话框";
            linkLabel_ShowUnhandledExceptionDialog.LinkClicked += linkLabel_ShowUnhandledExceptionDialog_LinkClicked;
            // 
            // button_Close
            // 
            button_Close.Location = new Point(695, 11);
            button_Close.Name = "button_Close";
            button_Close.Size = new Size(136, 34);
            button_Close.TabIndex = 3;
            button_Close.Text = "退出 Test Domain";
            button_Close.UseVisualStyleBackColor = true;
            button_Close.Click += button_Close_Click;
            // 
            // linkLabel_ViewStackTraceInfo
            // 
            linkLabel_ViewStackTraceInfo.AutoSize = true;
            linkLabel_ViewStackTraceInfo.Location = new Point(3, 35);
            linkLabel_ViewStackTraceInfo.Name = "linkLabel_ViewStackTraceInfo";
            linkLabel_ViewStackTraceInfo.Size = new Size(212, 17);
            linkLabel_ViewStackTraceInfo.TabIndex = 4;
            linkLabel_ViewStackTraceInfo.TabStop = true;
            linkLabel_ViewStackTraceInfo.Text = "查看应用程序保存的最新堆栈跟踪信息";
            linkLabel_ViewStackTraceInfo.LinkClicked += linkLabel_ViewStackTraceInfo_LinkClicked;
            // 
            // splitContainer_Page
            // 
            splitContainer_Page.Location = new Point(12, 63);
            splitContainer_Page.Name = "splitContainer_Page";
            // 
            // splitContainer_Page.Panel1
            // 
            splitContainer_Page.Panel1.Controls.Add(groupBox_Test);
            splitContainer_Page.Panel1MinSize = 404;
            // 
            // splitContainer_Page.Panel2
            // 
            splitContainer_Page.Panel2.Controls.Add(groupBox_Debug);
            splitContainer_Page.Size = new Size(811, 419);
            splitContainer_Page.SplitterDistance = 404;
            splitContainer_Page.TabIndex = 5;
            // 
            // groupBox_Test
            // 
            groupBox_Test.Controls.Add(linkLabel_ShowUnhandledExceptionDialog);
            groupBox_Test.Dock = DockStyle.Fill;
            groupBox_Test.Location = new Point(0, 0);
            groupBox_Test.Name = "groupBox_Test";
            groupBox_Test.Size = new Size(404, 419);
            groupBox_Test.TabIndex = 0;
            groupBox_Test.TabStop = false;
            groupBox_Test.Text = "测试";
            // 
            // groupBox_Debug
            // 
            groupBox_Debug.Controls.Add(linkLabel_OpenTraceDir);
            groupBox_Debug.Controls.Add(linkLabel_ViewStackTraceInfo);
            groupBox_Debug.Dock = DockStyle.Fill;
            groupBox_Debug.Location = new Point(0, 0);
            groupBox_Debug.Name = "groupBox_Debug";
            groupBox_Debug.Size = new Size(403, 419);
            groupBox_Debug.TabIndex = 0;
            groupBox_Debug.TabStop = false;
            groupBox_Debug.Text = "Debug";
            // 
            // linkLabel_OpenTraceDir
            // 
            linkLabel_OpenTraceDir.AutoSize = true;
            linkLabel_OpenTraceDir.Location = new Point(3, 52);
            linkLabel_OpenTraceDir.Name = "linkLabel_OpenTraceDir";
            linkLabel_OpenTraceDir.Size = new Size(164, 17);
            linkLabel_OpenTraceDir.TabIndex = 5;
            linkLabel_OpenTraceDir.TabStop = true;
            linkLabel_OpenTraceDir.Text = "打开堆栈跟踪信息的文件目录";
            linkLabel_OpenTraceDir.LinkClicked += linkLabel_OpenTraceDir_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button_Close);
            panel1.Location = new Point(-8, 501);
            panel1.Name = "panel1";
            panel1.Size = new Size(854, 71);
            panel1.TabIndex = 6;
            // 
            // TestDomainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(835, 558);
            Controls.Add(splitContainer_Page);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "TestDomainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Test Domain";
            FormClosing += TestDomainForm_FormClosing;
            Load += TestDomainForm_Load;
            splitContainer_Page.Panel1.ResumeLayout(false);
            splitContainer_Page.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Page).EndInit();
            splitContainer_Page.ResumeLayout(false);
            groupBox_Test.ResumeLayout(false);
            groupBox_Test.PerformLayout();
            groupBox_Debug.ResumeLayout(false);
            groupBox_Debug.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel_ShowUnhandledExceptionDialog;
        private Button button_Close;
        private LinkLabel linkLabel_ViewStackTraceInfo;
        private SplitContainer splitContainer_Page;
        private GroupBox groupBox_Test;
        private GroupBox groupBox_Debug;
        private LinkLabel linkLabel_OpenTraceDir;
        private Panel panel1;
    }
}