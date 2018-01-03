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
    public partial class Frm_system : Form
    {
        public Frm_system()
        {
            InitializeComponent();
        }
        private void GetInfo(string node)
        {
            Operator oper = new Operator();
            switch (node)//判断选中的节点名称
            {
                case "Windows信息":
                    oper.GetInfo(lvInfo);
                    break;
                case "Windows用户":
                    oper.InsertInfo("Win32_UserAccount", ref lvInfo, true);
                    break;
                case "用户组别":
                    oper.InsertInfo("Win32_Group", ref lvInfo, true);
                    break;
                case "当前进程":
                    oper.InsertInfo("Win32_Process", ref lvInfo, true);
                    break;
                case "系统服务":
                    oper.InsertInfo("Win32_Service", ref lvInfo, true);
                    break;
                case "系统驱动":
                    oper.InsertInfo("Win32_SystemDriver", ref lvInfo, true);
                    break;
                case "中央处理器":
                    oper.InsertInfo("Win32_Processor", ref lvInfo, true);
                    break;
                case "主板":
                    oper.InsertInfo("Win32_BaseBoard", ref lvInfo, true);
                    break;
                case "BIOS信息":
                    oper.InsertInfo("Win32_BIOS", ref lvInfo, true);
                    break;
                case "显卡":
                    oper.InsertInfo("Win32_VideoController", ref lvInfo, true);
                    break;
                case "音频设备":
                    oper.InsertInfo("Win32_SoundDevice", ref lvInfo, true);
                    break;
                case "物理内存":
                    oper.InsertInfo("Win32_PhysicalMemory", ref lvInfo, true);
                    break;
                case "磁盘":
                    oper.InsertInfo("Win32_LogicalDisk", ref lvInfo, true);
                    break;
                case "网络适配器":
                    oper.InsertInfo("Win32_NetworkAdapter", ref lvInfo, true);
                    break;
                case "网络协议":
                    oper.InsertInfo("Win32_NetworkProtocol", ref lvInfo, true);
                    break;
                case "打印与传真":
                    oper.InsertInfo("Win32_Printer", ref lvInfo, true);
                    break;
                case "键盘":
                    oper.InsertInfo("Win32_Keyboard", ref lvInfo, true);
                    break;
                case "鼠标":
                    oper.InsertInfo("Win32_PointingDevice", ref lvInfo, true);
                    break;
                case "串口":
                    oper.InsertInfo("Win32_SerialPort", ref lvInfo, true);
                    break;
                case "IDE控制器":
                    oper.InsertInfo("Win32_IDEController", ref lvInfo, true);
                    break;
                case "软驱控制器":
                    oper.InsertInfo("Win32_FloppyController", ref lvInfo, true);
                    break;
                case "USB控制器":
                    oper.InsertInfo("Win32_USBController", ref lvInfo, true);
                    break;
                case "SCSI控制器":
                    oper.InsertInfo("Win32_SCSIController", ref lvInfo, true);
                    break;
                case "PCMCIA卡控制器":
                    oper.InsertInfo("Win32_PCMCIAController", ref lvInfo, true);
                    break;
                case "1394控制器":
                    oper.InsertInfo("Win32_1394Controller", ref lvInfo, true);
                    break;
                case "即插即用设备":
                    oper.InsertInfo("Win32_PnPEntity", ref lvInfo, true);
                    break;
                default:
                    oper.GetInfo(lvInfo);//默认显示Windows信息
                    break;
            }
        }

        private void Frm_system_Load(object sender, EventArgs e)
        {
            #region 创建treeNode对象作为父节点
            TreeNode tn1 = new TreeNode("Windows");
            TreeNode tn2 = new TreeNode("CPU与主板");
            TreeNode tn3 = new TreeNode("视频设备");
            TreeNode tn4 = new TreeNode("音频设备");
            TreeNode tn5 = new TreeNode("存储设备");
            TreeNode tn6 = new TreeNode("网络设备");
            TreeNode tn8 = new TreeNode("总线与接口");
            TreeNode tn9 = new TreeNode("输入设备");
            TreeNode tn10 = new TreeNode("打印与传真");
            #endregion
            #region Windows父节点的子节点
            tn1.Nodes.Add("Windows信息");
            tn1.Nodes.Add("Windows用户");
            tn1.Nodes.Add("用户组别");
            tn1.Nodes.Add("当前进程");
            tn1.Nodes.Add("系统服务");
            tn1.Nodes.Add("系统驱动");
            #endregion
            #region CPU与主板父节点的子节点
            tn2.Nodes.Add("中央处理器");
            tn2.Nodes.Add("主板");
            tn2.Nodes.Add("BIOS信息");
            #endregion
            #region 视频设备父节点的子节点
            tn3.Nodes.Add("显卡");
            #endregion
            #region 存储设备父节点的子节点
            tn5.Nodes.Add("物理内存");
            tn5.Nodes.Add("磁盘");
            #endregion
            #region 网络设备父节点的子节点
            tn6.Nodes.Add("网络适配器");
            tn6.Nodes.Add("网络协议");
            #endregion
            #region 总线与接口父节点的子节点
            tn8.Nodes.Add("串口");
            tn8.Nodes.Add("IDE控制器");
            tn8.Nodes.Add("软驱控制器");
            tn8.Nodes.Add("USB控制器");
            tn8.Nodes.Add("SCSI控制器");
            tn8.Nodes.Add("PCMCIA卡控制器");
            tn8.Nodes.Add("1394控制器");
            tn8.Nodes.Add("即插即用设备");
            #endregion
            #region 输入设备父节点的子节点
            tn9.Nodes.Add("鼠标");
            tn9.Nodes.Add("键盘");
            #endregion
            #region 将创建的父节点添加到树列表中
            tvItem.Nodes.Add(tn1);
            tvItem.Nodes.Add(tn10);
            tvItem.Nodes.Add(tn2);
            tvItem.Nodes.Add(tn3);
            tvItem.Nodes.Add(tn4);
            tvItem.Nodes.Add(tn5);
            tvItem.Nodes.Add(tn6);
            tvItem.Nodes.Add(tn8);
            tvItem.Nodes.Add(tn9);
            #endregion
            GetInfo("");//默认获得Windows信息的相关信息
        }
    }
}
