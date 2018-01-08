using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public delegate bool Callback(IntPtr hwnd, int lParam);

    public partial class stkrDaemon : Form
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPTStr)] string lpClassName, [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(Callback lpEnumFunc, int lParam);

        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr hwnd);

        public stkrDaemon()
        {
            InitializeComponent();
            //hwnd = this.Handle;
            OpenAllStickers();
        }

        private void stkrDaemon_Load(object sender, EventArgs e)
        {
          

            SetParent(this.Handle, parWnd);

            //Console.WriteLine(this.Parent.Handle.ToString());
            
            this.Hide();
        }

        private IntPtr workerw = IntPtr.Zero;
        public bool Find_SHELLDLL_DefView(IntPtr hwnd, int lParam)
        {
            
            if (FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero)
            {
                workerw = hwnd;
                return false;
            }
            return true;
        }

   
    }
}
