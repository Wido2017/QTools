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
    public partial class frm_Close : Form
    {
        public frm_Close()
        {
            InitializeComponent();
        }
        Operator oper = new Operator();
        private void button2_Click(object sender, EventArgs e)
        {
            Win32.ExitWindowsEx(0,0);//注销计算机的功能。
        }

        private void button3_Click(object sender, EventArgs e)
        {
            oper.CMDOperator("shutdown -s -t 0");//关闭计算机
        }

        private void button4_Click(object sender, EventArgs e)
        {
            oper.CMDOperator("shutdown -r -t 0");//重新启动
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();//
        }
    }
}
