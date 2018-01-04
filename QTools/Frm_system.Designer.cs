namespace QManager
{
    partial class Frm_system
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
            this.tvItem = new System.Windows.Forms.TreeView();
            this.lvInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // tvItem
            // 
            this.tvItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(33)))), ((int)(((byte)(49)))));
            this.tvItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvItem.ForeColor = System.Drawing.Color.White;
            this.tvItem.Location = new System.Drawing.Point(0, 0);
            this.tvItem.Name = "tvItem";
            this.tvItem.Size = new System.Drawing.Size(281, 903);
            this.tvItem.TabIndex = 0;
            this.tvItem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvItem_AfterSelect);
            // 
            // lvInfo
            // 
            this.lvInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.lvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInfo.ForeColor = System.Drawing.Color.White;
            this.lvInfo.GridLines = true;
            this.lvInfo.Location = new System.Drawing.Point(281, 0);
            this.lvInfo.Name = "lvInfo";
            this.lvInfo.Size = new System.Drawing.Size(818, 903);
            this.lvInfo.TabIndex = 1;
            this.lvInfo.UseCompatibleStateImageBehavior = false;
            this.lvInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "数值";
            this.columnHeader2.Width = 250;
            // 
            // Frm_system
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(168F, 168F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1099, 903);
            this.Controls.Add(this.lvInfo);
            this.Controls.Add(this.tvItem);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_system";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统检测";
            this.Load += new System.EventHandler(this.Frm_system_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvItem;
        private System.Windows.Forms.ListView lvInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}