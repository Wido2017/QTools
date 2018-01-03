using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace QManager
{
    class myHook
    {
        private IntPtr pKeyboardHook = IntPtr.Zero;//键盘钩子句柄
        //钩子委托声明
        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
        private HookProc KeyboardHookProcedure;//键盘钩子委托实例，不能省略变量
        public const int idHook = 13;//底层键盘钩子
        //安装钩子
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr pInstance, int threadID);
        //卸载钩子
        [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(IntPtr pHookHandle);

        //键盘钩子处理函数
        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            KeyMSG m = (KeyMSG)Marshal.PtrToStructure(lParam, typeof(KeyMSG));//键盘消息处理
            if (pKeyboardHook != IntPtr.Zero)//判断钩子句柄是否为空
            {
                switch (((Keys)m.vkCode))//判断按键
                { 
                    case Keys.LWin://键盘左侧的Win键
                    case Keys.RWin://键盘右侧的Win键
                    case Keys.Delete://Delete键
                    case Keys.Alt://Alt键
                    case Keys.Escape: //Esc键
                    case Keys.F4: //F4键
                    case Keys.Control://Ctrl键
                    case Keys.Tab://Tab键
                        return 1;//不执行任何操作
                }
            }
            return 0;
        }
        //安装钩子方法
        public bool InsertHook()
        {
            IntPtr pIn = (IntPtr)4194304;//将4194304转换为句柄
            if (this.pKeyboardHook == IntPtr.Zero)//不存在钩子时
            {
                //创建钩子
                this.KeyboardHookProcedure = new HookProc(KeyboardHookProc);
                //使用SetWindowsHookEx函数安装钩子
                this.pKeyboardHook = SetWindowsHookEx(idHook, KeyboardHookProcedure, pIn, 0);
                if (this.pKeyboardHook == IntPtr.Zero)//如果安装钩子失败
                {
                    this.UnInsertHook();//卸载钩子
                    return false;
                }
            }
            return true;
        }
        //卸载钩子方法
        public bool UnInsertHook()
        {
            bool result = true;
            if (this.pKeyboardHook != IntPtr.Zero)//如果存在钩子
            {
                //使用UnhookWindowsHookEx函数卸载钩子
                result = (UnhookWindowsHookEx(this.pKeyboardHook) && result);
                this.pKeyboardHook = IntPtr.Zero;//清空指针
            }
            return result;
        }
        //键盘消息处理结构
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyMSG
        {
            public int vkCode;//键盘按键
        }
    }
}
