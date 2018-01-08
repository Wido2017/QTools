using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using WindowsFormsApp1;

namespace cbgfinder
{
    public delegate bool Callback(IntPtr hwnd,int lParam);

    enum WindowLongFlags : int
    {
        GWL_EXSTYLE = -20,
        GWLP_HINSTANCE = -6,
        GWLP_HWNDPARENT = -8,
        GWL_ID = -12,
        GWL_STYLE = -16,
        GWL_USERDATA = -21,
        GWL_WNDPROC = -4,
        DWLP_USER = 0x8,
        DWLP_MSGRESULT = 0x0,
        DWLP_DLGPROC = 0x4
    }

    [Flags]
    enum WindowStyles : uint
    {
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = 0x80000000,
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_GROUP = 0x00020000,
        WS_TABSTOP = 0x00010000,

        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,

        WS_CAPTION = WS_BORDER | WS_DLGFRAME,
        WS_TILED = WS_OVERLAPPED,
        WS_ICONIC = WS_MINIMIZE,
        WS_SIZEBOX = WS_THICKFRAME,
        WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW,

        WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
        WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU,
        WS_CHILDWINDOW = WS_CHILD,

        //Extended Window Styles

        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_NOPARENTNOTIFY = 0x00000004,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_ACCEPTFILES = 0x00000010,
        WS_EX_TRANSPARENT = 0x00000020,



        //#if(WINVER >= 0x0400)

        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_WINDOWEDGE = 0x00000100,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,

        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,

        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,

        WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
        WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),


        //#endif /* WINVER >= 0x0400 */

        //#if(WIN32WINNT >= 0x0500)

        WS_EX_LAYERED = 0x00080000,


        //#endif /* WIN32WINNT >= 0x0500 */

        //#if(WINVER >= 0x0500)

        WS_EX_NOINHERITLAYOUT = 0x00100000, // Disable inheritence of mirroring by children
        WS_EX_LAYOUTRTL = 0x00400000, // Right to left mirroring


        //#endif /* WINVER >= 0x0500 */

        //#if(WIN32WINNT >= 0x0500)

        WS_EX_COMPOSITED = 0x02000000,
        WS_EX_NOACTIVATE = 0x08000000


        //#endif /* WIN32WINNT >= 0x0500 */

    }


    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPTStr)] string lpClassName, [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(Callback lpEnumFunc,int lParam);

        [DllImport("user32")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        static extern int SetClassLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        public Form1(stkrDaemon daemon)
        {
            this.daemon = daemon;
            //this.Owner = daemon;
            InitializeComponent();
            NewSticker();
        }

        public Form1(stkrDaemon daemon,string fileName)
        {
            this.daemon = daemon;
            //his.Owner = daemon;
            InitializeComponent();
            OpenSticker(fileName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SetParent(this.Handle, daemon.parWnd);

            //ShoveToBackground();
            SetWindowLong(this.Handle, (int)WindowLongFlags.GWL_STYLE, (uint)(WindowStyles.WS_POPUP
                |WindowStyles.WS_CLIPSIBLINGS));
            SetWindowLong(this.Handle, (int)WindowLongFlags.GWL_EXSTYLE, (uint)(WindowStyles.WS_EX_TOOLWINDOW));
            SetClassLong(this.Handle, -26, 0);
        }

        private IntPtr workerw = IntPtr.Zero;
        public bool Find_SHELLDLL_DefView(IntPtr hwnd,int lParam)
        {
            if(FindWindowEx(hwnd,IntPtr.Zero,"SHELLDLL_DefView",null)!=IntPtr.Zero)
            {
                workerw = hwnd;
                return false;
            }
            return true;
        }

        private bool isMouseDown = false;
        private Point FormLocation;     //form的location
        private Point mouseOffset;      //鼠标的按下位置
        private void TextBox1_mDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLocation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void TextBox1_mUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void TextBox1_mMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if (isMouseDown)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;

                this.Location = new Point(FormLocation.X - _x, FormLocation.Y - _y);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
            daemon.CloseOneSticker();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.daemon.NewSticker();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.daemon.CloseAllStickers();
        }





        #region

        int QQ_MODE = 0, QQ_T = 3, QQ_XY = 6;//0为不停靠,1为X轴,2为Y轴,3为顶部；QQ_T为显示的像素；QQ_XY为误差

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            //如果左键按下就不处理当前逻辑[是否收缩]
            if (MouseButtons == MouseButtons.Left)
                return;

            //鼠标的位置
            int x = MousePosition.X, y = MousePosition.Y;

            //鼠标移动到窗口内，显示
            if (x > (this.Location.X - QQ_XY)
                &&
                x < (this.Location.X + this.Width + QQ_XY)
                &&
                y > (this.Location.Y - QQ_XY)
                &&
                y < (this.Location.Y + this.Height + QQ_XY))
            {
                if (this.QQ_MODE == 1)
                    this.Location = new Point(QQ_T, this.Location.Y);
                else if (this.QQ_MODE == 2)
                    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - QQ_T, this.Location.Y);
                else if (this.QQ_MODE == 3)
                    this.Location = new Point(this.Location.X, QQ_T);
            }
            else//鼠标移动到窗口外，隐藏
            {
                if (this.Location.Y <= QQ_T)//上
                {
                    this.Location = new Point(this.Location.X, QQ_T - this.Height);
                    this.QQ_MODE = 3;
                }
                else if (this.Location.X <= QQ_T)//左
                {
                    this.Location = new Point(QQ_T - this.Width, this.Location.Y);
                    this.QQ_MODE = 1;
                }
                else if (this.Location.X >= Screen.PrimaryScreen.WorkingArea.Width - this.Width - QQ_T)//右
                {
                    this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - QQ_T, this.Location.Y);
                    this.QQ_MODE = 2;
                }
                else
                    this.QQ_MODE = 0;
            }
        }

        //移动窗体时，解决QQ逻辑
        private void ToolsMenu_Move(object sender, EventArgs e)
        {
            this.QQ_MODE = 0;
        }

        #endregion
    }
}

