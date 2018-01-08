using cbgfinder;
using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class stkrDaemon
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
            this.SuspendLayout();
            // 
            // stkrDaemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "stkrDaemon";
            this.ShowInTaskbar = false;
            this.Text = "stkrDaemon";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.stkrDaemon_Load);
            this.ResumeLayout(false);

        }

        public void OpenAllStickers()
        {
     
            var stickers = Directory.GetFiles("stickers");
            foreach(var sticker in stickers)
            {
                Form1 stkrWnd=new Form1(this,sticker);
                stkrList.Add(stkrWnd);
                stkrWnd.Show();
                stkrNum++;
            }
            if (stkrNum == 0) NewSticker();
        }
        public void NewSticker()
        {
            Form1 stkrWnd = new Form1(this);
            stkrList.Add(stkrWnd);
            stkrWnd.Show();
            this.stkrNum++;
        }

        public void CloseOneSticker()
        {
            stkrNum--;
            if(stkrNum==0)
            {
                NewSticker();
            }
        }

        public void CloseAllStickers()
        {
            foreach(Form1 stkrWnd in stkrList)
            {
                if (!stkrWnd.IsDisposed)
                {
                    stkrWnd.Save();
                    stkrWnd.Close();
                }
            }
            this.Close();
        }

        #endregion
        private ArrayList stkrList = new ArrayList();
        private int stkrNum = 0;
        //public static IntPtr hwnd;
        public IntPtr parWnd;
        public IntPtr wpWnd;
    }
}