using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
namespace QManager
{
    public partial class Frm_SysTool : Form
    {
        public Frm_SysTool()
        {
            InitializeComponent();
        }
        Operator oper = new Operator();

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Text = "QTool管家——系统清理";
            tabClear.Visible = true;
            tabClear.Dock = DockStyle.Fill;
            tacSy.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i =0; i<listView3.Items.Count; i++)
            {
                if(listView3.Items[i].Checked==true)//判断选项表示是否选中
                {
                    oper.ClearSystem(this.Handle, listView3.Items[i].Text);//清理相应的内容
                }
            }
            MessageBox.Show("系统垃圾清理成功", "成功", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            frm_Close closewindows = new frm_Close();
            closewindows.ShowDialog(); 
        }

        private void tsbtnTool_Click(object sender, EventArgs e)
        {
            this.Text = "QTool--实用工具";
            tacSy.Visible = true;
            tacSy.Dock = DockStyle.Fill;
            tabClear.Visible = false;
        }

        private void toolStripButton20_MouseMove(object sender, MouseEventArgs e)
        {
            richTextBox2.Text = "Windows自带的DirectX游戏\r支持系统检测工具";
            toolStripButton20.ForeColor = Color.Red;
        }

        private void toolStripButton20_MouseLeave(object sender, EventArgs e)
        {
            toolStripButton20.ForeColor = Color.Black;
        }

        private void toolStripButton20_Click(object sender, EventArgs e)
        {
            string restr = Environment.SystemDirectory.ToString() + "\\dxdiag.exe";
            System.Diagnostics.Process.Start(restr);
        }

        private void toolStripButton19_MouseMove(object sender, MouseEventArgs e)
        {
            richTextBox2.Text = "为windows系统提供仿XP的关机程序";
            toolStripButton19.ForeColor = Color.Red;
        }

        private void toolStripButton19_MouseLeave(object sender, EventArgs e)
        {
            toolStripButton19.ForeColor = Color.Black;
        }

        private void toolStripButton21_MouseMove(object sender, MouseEventArgs e)
        {
            richTextBox2.Text = "管理windows的各种事件、\r后台服务等";
            toolStripButton21.ForeColor = Color.Red;
        }

        private void toolStripButton21_MouseLeave(object sender, EventArgs e)
        {
            toolStripButton21.ForeColor = Color.Black;
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            string str = Environment.SystemDirectory.ToString() + "\\compmgmt.msc";
            System.Diagnostics.Process.Start(str);
        }

        private void toolStripButton22_MouseMove(object sender, MouseEventArgs e)
        {
            richTextBox2.Text = "查看系统的属性，其中包括常规选项、计算机名、硬件信息、高级等";
            toolStripButton22.ForeColor = Color.Red;
        }

        private void toolStripButton22_MouseLeave(object sender, EventArgs e)
        {
            toolStripButton22.ForeColor = Color.Black;
        }

        private void toolStripButton22_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("sysdm.cpl");
        }

        private void toolStripButton27_MouseMove(object sender, MouseEventArgs e)
        {
            richTextBox2.Text = "打开系统自带的声音和音频设备窗口，在此窗口中可以对声音进行相应的设置";
            toolStripButton27.ForeColor = Color.Red;
        }

        private void toolStripButton27_MouseLeave(object sender, EventArgs e)
        {
            toolStripButton27.ForeColor = Color.Black;
        }

        private void toolStripButton27_Click(object sender, EventArgs e)
        {
           System.Diagnostics.Process.Start("mmsys.cpl");
        }

        private void tsBtnReSet_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认重启计算机吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                oper.CMDOperator("shutdown -r -t 0");
        }
    }
}
