using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace search
{
    public partial class search : Form
    {
        private const int WM_HOTKEY = 0x312; //窗口消息-热键  
        private const int WM_CREATE = 0x1; //窗口消息-创建  
        private const int WM_DESTROY = 0x2; //窗口消息-销毁  
        private const int Space = 0x3572; //热键ID  
        public search()
        {
            InitializeComponent();
            this.Show() ;
            this.textBox1.Visible = false;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_HOTKEY: //窗口消息-热键ID  
                    switch (m.WParam.ToInt32())
                    {
                        case Space: //热键ID  
                            if (this.textBox1.Visible == false)
                            {
                                this.textBox1.Visible = true;
                            }
                            else
                            {
                                this.textBox1.Visible = false;
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                case WM_CREATE: //窗口消息-创建  
                    AppHotKey.RegKey(Handle, Space, AppHotKey.KeyModifiers.Ctrl | AppHotKey.KeyModifiers.Alt, Keys.S);
                    break;
                case WM_DESTROY: //窗口消息-销毁  
                    AppHotKey.UnRegKey(Handle, Space); //销毁热键  
                    break;
                default:
                    break;
            }
        }
        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//如果输入的是回车键  
            {
                this.百度搜索ToolStripMenuItem_Click(sender,e);//触发button事件  
            }
        }

        private void 百度搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == null || this.textBox1.Text == "")
            {
                System.Diagnostics.Process.Start("http://www.baidu.com/s?wd");
            }else
                System.Diagnostics.Process.Start("http://www.baidu.com/s?wd=" + this.textBox1.Text + "");
        }

        private void 谷歌搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == null || this.textBox1.Text == "")
            {
                System.Diagnostics.Process.Start("http://www.google.com.hk/webhp?hl=zh-CN");
            }else
                System.Diagnostics.Process.Start(" http://www.google.com.hk/webhp?hl=zh-CN&q&hl=zh-CN&tab=ew#hl=zh-CN&newwindow=1&safe=strict&site=webhp&source=hp&q=" + this.textBox1.Text + "");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.S)
            {
                this.textBox1.Visible = true;

            }
        }
        private bool isMouseDown = false;
        private Point FormLoacation;
        private Point mouseOffset;

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLoacation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;
                this.Location = new Point(FormLoacation.X - _x, FormLoacation.Y - _y);
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}
