namespace QManager
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ToolbarPanel = new System.Windows.Forms.Panel();
            this.logoLabel = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.MinimizeButton = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.youhua = new System.Windows.Forms.PictureBox();
            this.stool = new System.Windows.Forms.PictureBox();
            this.cleaner = new System.Windows.Forms.PictureBox();
            this.system = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ToolbarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.youhua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cleaner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.system)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolbarPanel
            // 
            this.ToolbarPanel.BackColor = System.Drawing.Color.Transparent;
            this.ToolbarPanel.Controls.Add(this.logoLabel);
            this.ToolbarPanel.Controls.Add(this.logo);
            this.ToolbarPanel.Controls.Add(this.CloseButton);
            this.ToolbarPanel.Controls.Add(this.MinimizeButton);
            this.ToolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolbarPanel.Name = "ToolbarPanel";
            this.ToolbarPanel.Size = new System.Drawing.Size(1442, 129);
            this.ToolbarPanel.TabIndex = 0;
            this.ToolbarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolbarPanel_MouseDown);
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(149, 46);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(333, 42);
            this.logoLabel.TabIndex = 3;
            this.logoLabel.Text = "QTools 电脑助手";
            // 
            // logo
            // 
            this.logo.BackgroundImage = global::QManager.Properties.Resources._101;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.Location = new System.Drawing.Point(12, 2);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(131, 121);
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackgroundImage = global::QManager.Properties.Resources.close;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Location = new System.Drawing.Point(1340, 45);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(50, 50);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackgroundImage = global::QManager.Properties.Resources.min;
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MinimizeButton.Location = new System.Drawing.Point(1257, 46);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(50, 50);
            this.MinimizeButton.TabIndex = 0;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            this.MinimizeButton.MouseEnter += new System.EventHandler(this.MinimizeButton_MouseEnter);
            this.MinimizeButton.MouseLeave += new System.EventHandler(this.MinimizeButton_MouseLeave);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.Controls.Add(this.youhua);
            this.MainPanel.Controls.Add(this.stool);
            this.MainPanel.Controls.Add(this.cleaner);
            this.MainPanel.Controls.Add(this.system);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 129);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1442, 813);
            this.MainPanel.TabIndex = 1;
            // 
            // youhua
            // 
            this.youhua.BackgroundImage = global::QManager.Properties.Resources._9;
            this.youhua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.youhua.Location = new System.Drawing.Point(287, 631);
            this.youhua.Name = "youhua";
            this.youhua.Size = new System.Drawing.Size(145, 152);
            this.youhua.TabIndex = 3;
            this.youhua.TabStop = false;
            this.youhua.Click += new System.EventHandler(this.youhua_Click);
            // 
            // stool
            // 
            this.stool.BackgroundImage = global::QManager.Properties.Resources._6;
            this.stool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.stool.Location = new System.Drawing.Point(481, 631);
            this.stool.Name = "stool";
            this.stool.Size = new System.Drawing.Size(145, 152);
            this.stool.TabIndex = 2;
            this.stool.TabStop = false;
            this.stool.Click += new System.EventHandler(this.stool_Click);
            // 
            // cleaner
            // 
            this.cleaner.BackgroundImage = global::QManager.Properties.Resources._7;
            this.cleaner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cleaner.Location = new System.Drawing.Point(85, 631);
            this.cleaner.Name = "cleaner";
            this.cleaner.Size = new System.Drawing.Size(145, 152);
            this.cleaner.TabIndex = 1;
            this.cleaner.TabStop = false;
            this.cleaner.Click += new System.EventHandler(this.cleaner_Click);
            // 
            // system
            // 
            this.system.BackgroundImage = global::QManager.Properties.Resources.system;
            this.system.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.system.Location = new System.Drawing.Point(501, 418);
            this.system.Name = "system";
            this.system.Size = new System.Drawing.Size(364, 111);
            this.system.TabIndex = 0;
            this.system.TabStop = false;
            this.system.Click += new System.EventHandler(this.system_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主界面ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(222, 106);
            // 
            // 显示主界面ToolStripMenuItem
            // 
            this.显示主界面ToolStripMenuItem.Name = "显示主界面ToolStripMenuItem";
            this.显示主界面ToolStripMenuItem.Size = new System.Drawing.Size(221, 32);
            this.显示主界面ToolStripMenuItem.Text = "显示主界面";
            this.显示主界面ToolStripMenuItem.Click += new System.EventHandler(this.显示主界面ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(221, 32);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "QTools电脑助手";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QManager.Properties.Resources.timg;
            this.ClientSize = new System.Drawing.Size(1442, 942);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ToolbarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ToolbarPanel.ResumeLayout(false);
            this.ToolbarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.youhua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cleaner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.system)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ToolbarPanel;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox MinimizeButton;
        private System.Windows.Forms.PictureBox system;
        private System.Windows.Forms.PictureBox cleaner;
        private System.Windows.Forms.PictureBox youhua;
        private System.Windows.Forms.PictureBox stool;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.ToolStripMenuItem 显示主界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}