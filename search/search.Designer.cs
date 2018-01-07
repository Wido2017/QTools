
namespace search
{
    partial class search
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.百度搜索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.谷歌搜索ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Location = new System.Drawing.Point(1, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            this.textBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            this.textBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseMove);
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.百度搜索ToolStripMenuItem,
            this.谷歌搜索ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 百度搜索ToolStripMenuItem
            // 
            this.百度搜索ToolStripMenuItem.Name = "百度搜索ToolStripMenuItem";
            this.百度搜索ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.百度搜索ToolStripMenuItem.Text = "百度搜索";
            this.百度搜索ToolStripMenuItem.Click += new System.EventHandler(this.百度搜索ToolStripMenuItem_Click);
            // 
            // 谷歌搜索ToolStripMenuItem
            // 
            this.谷歌搜索ToolStripMenuItem.Name = "谷歌搜索ToolStripMenuItem";
            this.谷歌搜索ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.谷歌搜索ToolStripMenuItem.Text = "谷歌搜索";
            this.谷歌搜索ToolStripMenuItem.Click += new System.EventHandler(this.谷歌搜索ToolStripMenuItem_Click);
            // 
            // search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "search";
            this.ShowInTaskbar = false;
            this.Text = ",l";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 百度搜索ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 谷歌搜索ToolStripMenuItem;
    }
}

