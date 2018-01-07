using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QManager
{
    public partial class Frm_Optimize : Form
    {
        public Frm_Optimize()
        {
            InitializeComponent();
        }
        Operator oper = new Operator();//公共操作类的对象

        /// <summary>
        /// 通过操作注册表优化系统
        /// </summary>
        /// <param name="str">字符串，表示要优化的项</param>
        private void SetRegValue(string str)
        {
            switch (str)
            {
                case "开机和关机"://优化开关机速度
                    oper.CurrentRegOptimize("SYSTEM\\CurrentControlSet\\Control", "WaitToKillServiceTimeout", 1000, 0);
                    break;
                case "菜单"://优化菜单显示速度
                    oper.CurrentRegOptimize("Control Panel\\Desktop", "MenuShowDelay", 40, 0);
                    break;
                case "程序"://优化程序运行速度
                    oper.LocalRegOptimize("SYSTEM\\CurrentControlSet\\Control\\FileSystem", "ConfigFileAllocSize", "dword:000001f4", 0);
                    break;
                case "加快预读能力"://加速预读能力
                    oper.LocalRegOptimize("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters", "EnablePrefetcher", 4, 1);
                    break;
                case "自动清除内存中多余的DLL资料"://自动清除内存中多余的DLL
                    oper.LocalRegOptimize("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "AlwaysUnloadDLL", 1, 1);
                    break;
                case "禁止远程修改注册表"://禁止远程修改注册表
                    oper.LocalRegOptimize("SYSTEM\\CurrentControlSet\\Control\\SecurePipeServers\\winreg", "RemoteRegAccess", 1, 1);
                    break;
                case "禁用系统还原"://禁用系统还原
                    oper.LocalRegOptimize("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\SystemRestore", "DisableSR", 1, 1);
                    break;
                case "在桌面上显示系统版本"://在桌面上显示系统版本
                    oper.CurrentRegOptimize("Control Panel\\Desktop", "PaintDesktopVersion", 1, 1);
                    break;
                case "关机时自动关闭停止响应的程序"://关机时自动关闭停止响应的程序
                    oper.CurrentRegOptimize("Control Panel\\Desktop", "AutoEndTasks", 1, 1);
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//备份注册表
        {
            try
            {
                string cmd = "regedit /e " + Application.StartupPath + "\\backup.reg";//设置备份注册表命令
                oper.CMDOperator(cmd);//执行注册表备份操作
                MessageBox.Show("注册表备份成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("注册表备份失败，请确认当前系统用户是否具有注册表操作权限！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)//还原注册表
        {
            try
            {
                string cmd = "regedit /size " + Application.StartupPath.ToString() + "\\backup.reg";//设置还原注册表命令
                oper.CMDOperator(cmd);//执行注册表还原操作
                MessageBox.Show("注册表还原成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("注册表还原失败，请确认当前系统用户是否具有注册表操作权限！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)//遍历ListView中的所有项
            {
                if (listView1.Items[i].Checked == true)//判断遍历项是否被选中
                {
                    SetRegValue(listView1.Items[i].Text);//优化选中项
                }
                else
                {
                }
            }
            if (MessageBox.Show("优化系统成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)//显示优化成功的提示信息
            {
                Close();//关闭当前窗体
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();//关闭当前窗体
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
