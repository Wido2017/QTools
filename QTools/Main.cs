using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using windowHelper;

namespace QManager
{
    public partial class Main : Form
    {
        public Main()
        {
            WindowHelper wh = new WindowHelper();
            InitializeComponent();
            wh.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MinimizeButton.Image = null;
            MinimizeButton.Image = Properties.Resources.min;
            MinimizeButton.SizeMode = PictureBoxSizeMode.CenterImage;
            CloseButton.Image = null;
            CloseButton.Image = Properties.Resources.close;
            CloseButton.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void MinimizeButton_MouseEnter(object sender, EventArgs e)
        {
            MinimizeButton.BorderStyle = BorderStyle.FixedSingle;
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            MinimizeButton.BorderStyle = BorderStyle.None;
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            this.CloseButton.BorderStyle = BorderStyle.FixedSingle;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            this.CloseButton.BorderStyle = BorderStyle.None;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
        }

        private void ToolbarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(this.Handle, Win32.WM_SYSCOMMAND, Win32.SC_MOVE + Win32.HTCAPTION, 0);
        }

        private void system_Click(object sender, EventArgs e)
        {
            Frm_system systemcheck = new Frm_system();
            systemcheck.Show();
        }

        private void cleaner_Click(object sender, EventArgs e)
        {
            Frm_SysTool frm = new Frm_SysTool();
            frm.Show();
        }

        private void stool_Click(object sender, EventArgs e)
        {
            Frm_SysTool frm = new Frm_SysTool();
            frm.Show();
        }

        private void youhua_Click(object sender, EventArgs e)
        {
            Frm_Optimize optimize = new Frm_Optimize();
            optimize.Show();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void 显示主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(null,null);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result==DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized; 
            }
        }
    }
}
