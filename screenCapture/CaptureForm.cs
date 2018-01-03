﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace screenCapture
{
    public partial class CaptureForm : Form
    {
        public CaptureForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //隐藏窗口
            this.Hide();
            this.CutImage.Hide();
            //注册快捷键
            this.hotKeyId = GlobalAddAtom("QTools") - 0xC000;
            if (this.hotKeyId == 0)
            {
                //如果获取失败，设定一个默认值；  
                this.hotKeyId = 0xBFFE;
            }

            if (this.HotKeyMode == 0)
            {
                RegisterHotKey(Handle, hotKeyId, (uint)KeyModifiers.Control | (uint)KeyModifiers.Alt, Keys.A);
            }
            else
            {
                RegisterHotKey(Handle, hotKeyId, (uint)KeyModifiers.Control | (uint)KeyModifiers.Shift, Keys.A);
            }
        }
        #region 截图基本变量  
        /// <summary>  
        /// 用于判断是否已经开始截图，控制信息框是否显示。  
        /// </summary>  
        private bool isCuting;
        /// <summary>  
        /// 用于判断是否开始移动。  
        /// </summary>  
        private bool isMoving;
        /// <summary>  
        /// 鼠标按下的点  
        /// </summary>  
        private Point beginPoint;
        /// <summary>  
        /// 最终确定的绘图基点  
        /// </summary>  
        private Point endPoint;
        /// <summary>  
        /// 用于记录截图显示区域的大小（包括调整块的区域，调整区域边框宽度2px）  
        /// </summary>  
        private Rectangle cutImageRect = new Rectangle(0, 0, 5, 5);
        /// <summary>  
        /// 记录鼠标上一次移动的时间  
        /// </summary>  
        private long lastMouseMoveTime = System.DateTime.Now.Ticks;
        #endregion
        #region 热键定义
        // <summary>  
        /// 向全局原子表添加一个字符串，并返回这个字符串的唯一标识符（原子ATOM）。  
        /// </summary>  
        /// <param name="lpString">自己设定的一个字符串</param>  
        /// <returns></returns>  
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern Int32 GlobalAddAtom(string lpString);

        /// <summary>  
        /// 注册热键  
        /// </summary>  
        /// <param name="hWnd"></param>  
        /// <param name="id"></param>  
        /// <param name="fsModifiers"></param>  
        /// <param name="vk"></param>  
        /// <returns></returns>  
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);

        /// <summary>  
        /// 取消热键注册  
        /// </summary>  
        /// <param name="hWnd"></param>  
        /// <param name="id"></param>  
        /// <returns></returns>  
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>  
        /// 热键ID  
        /// </summary>  
        public int hotKeyId = 100;

        /// <summary>  
        /// 热键模式:0=Ctrl + Alt + A, 1=Ctrl + Shift + A  
        /// </summary>  
        public int HotKeyMode = 1;

        /// <summary>  
        /// 控制键的类型  
        /// </summary>  
        public enum KeyModifiers : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }
        #endregion
        /// <summary>  
        /// 用于保存截取的整个屏幕的图片  
        /// </summary>  
        protected Bitmap screenImage;

        /// <summary>  
        /// 更新UI的模式，用于标记哪些需要显示，哪些需要隐藏；  
        /// </summary>  
        [FlagsAttribute]
        public enum UpdateUIMode : uint
        {
            None = 0,
            ShowTextPro = 1,
            ShowPenStyle = 2,
            ShowToolBox = 4,
            ShowInfoBox = 8,
            ShowZoomBox = 16,
            ShowCutImage = 32,
            HideTextPro = 64,
            HidePenStyle = 128,
            HideToolBox = 256,
            HideInfoBox = 512
        }

        /// <summary>
        /// 更新截图信息显示框，截图编辑工具框
        /// </summary>
        private void UpdateCutInfoLabel(UpdateUIMode updateUIMode) // UpdateUIMode updateUIMode = UpdateUIMode.None
        {
            long mouseMoveTimeStep = System.DateTime.Now.Ticks - lastMouseMoveTime;
            if (mouseMoveTimeStep < 300 && updateUIMode == UpdateUIMode.None) { return; }
            lastMouseMoveTime = System.DateTime.Now.Ticks;
            if (this.CutImage.Visible || (updateUIMode & UpdateUIMode.ShowCutImage) != UpdateUIMode.None)
            {
                this.CutImage.SetBounds(this.cutImageRect.Left, this.cutImageRect.Top, this.cutImageRect.Width, this.cutImageRect.Height, BoundsSpecified.All);
                if (!this.CutImage.Visible)
                {
                    this.CutImage.Show();
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ShowForm();
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        protected void ShowForm()
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                Bitmap bkImage = new Bitmap(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
                Graphics g = Graphics.FromImage(bkImage);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.AllScreens[0].Bounds.Size, CopyPixelOperation.SourceCopy);
                screenImage = (Bitmap)bkImage.Clone();
                g.FillRectangle(new SolidBrush(Color.FromArgb(64, Color.Gray)), Screen.PrimaryScreen.Bounds);
                this.BackgroundImage = bkImage;

                this.ShowInTaskbar = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                this.Location = Screen.PrimaryScreen.Bounds.Location;

                this.WindowState = FormWindowState.Maximized;
                this.Show();
            }
        }

        private void CaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = false;
                UnregisterHotKey(this.Handle, hotKeyId);
            }
            else
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        /// <summary>  
        /// 计算并保存截图的区域框的大小  
        /// </summary>  
        private void SaveCutImageSize(Point beginPoint, Point endPoint)
        {
            // 保存最终的绘图基点，用于截取选中的区域  
            this.endPoint = beginPoint;

            // 计算截取图片的大小  
            int imgWidth = Math.Abs(endPoint.X - beginPoint.X) + 1;
            int imgHeight = Math.Abs(endPoint.Y - beginPoint.Y) + 1;
            int lblWidth = imgWidth + 4;
            int lblHeight = imgHeight + 4;

            // 设置截图区域的位置和大小  
            this.cutImageRect = new Rectangle(beginPoint.X - 2, beginPoint.Y - 2, lblWidth, lblHeight);
        }
        private void ExecCutImage(bool saveToDick, bool uploadImage)
        {
            if (!this.CutImage.Visible) return;
            Rectangle srcRect = new Rectangle();
            srcRect.X = this.CutImage.Location.X + 2;
            srcRect.Y = this.CutImage.Location.Y + 2;
            srcRect.Width = this.CutImage.Width - 4;
            srcRect.Height = this.CutImage.Height - 4;
            Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
            Bitmap bmp = new Bitmap(srcRect.Width, srcRect.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(this.screenImage, destRect, srcRect, GraphicsUnit.Pixel);
            //添加到剪切板
            Clipboard.SetImage(bmp);

            ExitCutImage(true);
        }

        /// <summary>  
        /// 退出截图过程  
        /// </summary>  
        private void ExitCutImage(bool hideWindow) //  = true  
        {
            this.CutImage.Visible = false;
            this.isCuting = false;

            if (hideWindow)
            {
                this.screenImage.Dispose();
                this.Hide();
            }
        }
        private Point pntBgn;
        private Point pntEnd;
        private void CaptureForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(!isMoving)
            // 左键单击事件  
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (!this.CutImage.Visible)
                {
                    this.isCuting = true;
                    this.beginPoint = e.Location;
                    this.endPoint = e.Location;
                    SaveCutImageSize(e.Location, e.Location);

                    UpdateCutInfoLabel(UpdateUIMode.ShowCutImage | UpdateUIMode.ShowInfoBox);
                }
            }
            // 左键双击事件  
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                if (this.CutImage.Visible)
                {
                    ExecCutImage(false, false);
                }

            }
            // 右键单击事件  
            if (e.Button == MouseButtons.Right)
            {
                ExitCutImage(!this.CutImage.Visible);
            }
        }

        private void CaptureForm_MouseMove(object sender, MouseEventArgs e)
        {
            // 如果截取区域不可见,则退出处理过程  
            if (!this.CutImage.Visible)
            {
                UpdateCutInfoLabel(UpdateUIMode.None);
                return;
            }

            pntBgn = this.beginPoint;
            pntEnd = e.Location;

            // 如果是反向拖动，重新设置起始点  
            if (e.Location.X < this.beginPoint.X && e.Location.Y < this.beginPoint.Y)
            {
                pntBgn = e.Location;
                pntEnd = this.beginPoint;
            }
            else
            {
                if (e.Location.X < this.beginPoint.X)
                {
                    pntBgn = new Point(e.Location.X, this.beginPoint.Y);
                    pntEnd = new Point(this.beginPoint.X, e.Location.Y);
                }
                else
                {
                    if (e.Location.Y < this.beginPoint.Y)
                    {
                        pntBgn = new Point(this.beginPoint.X, e.Location.Y);
                        pntEnd = new Point(e.Location.X, this.beginPoint.Y);
                    }
                }
            }

            if (this.isCuting)
            {
                SaveCutImageSize(pntBgn, pntEnd);
            }

            UpdateCutInfoLabel(UpdateUIMode.None);
        }

        private void CaptureForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.isCuting)
                {
                    this.isCuting = false;

                    UpdateCutInfoLabel(UpdateUIMode.None);
                }
            }
        }

        private void CutImage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.CutImage.Visible)
                {
                    ExecCutImage(false, false);
                }
            }
        }

        private void CutImage_Paint(object sender, PaintEventArgs e)
        {
            int imgWidth = this.CutImage.Width - 4;
            int imgHeight = this.CutImage.Height - 4;
            if (imgWidth < 1) { imgWidth = 1; }
            if (imgHeight < 1) { imgHeight = 1; }

            // 创建缓存图像，先将要绘制的内容全部绘制到缓存中，最后再一次性绘制到 Label 上，
            // 这样可以提高性能，并且可以防止屏幕闪烁的问题
            Bitmap bmp_lbl = new Bitmap(this.CutImage.Width, this.CutImage.Height);
            Graphics g = Graphics.FromImage(bmp_lbl);

            // 将要截取的部分绘制到缓存
            Rectangle destRect = new Rectangle(2, 2, imgWidth, imgHeight);
            Point srcPoint = this.CutImage.Location;
            srcPoint.Offset(2, 2);
            Rectangle srcRect = new Rectangle(srcPoint, new System.Drawing.Size(imgWidth, imgHeight));
            g.DrawImage(this.screenImage, destRect, srcRect, GraphicsUnit.Pixel);

            SolidBrush brush = new SolidBrush(Color.FromArgb(10, 124, 202));
            Pen pen = new Pen(brush, 1.0F);

            //以下部分（边框和调整块）的绘制放在（编辑内容）的后面，是解决绘制编辑内容会覆盖（边框和调整块）的问题

            // 绘制边框外的区域，解决会被编辑内容覆盖的问题
            // 上边
            destRect = new Rectangle(0, 0, this.CutImage.Width, 2);
            srcPoint = this.CutImage.Location;
            //srcPoint.Offset(2, 2);
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(this.CutImage.Width, 2));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 下边
            destRect = new Rectangle(0, this.CutImage.Height - 2, this.CutImage.Width, 2);
            srcPoint = this.CutImage.Location;
            srcPoint.Offset(0, this.CutImage.Height - 2);
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(this.CutImage.Width, 2));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 左边
            destRect = new Rectangle(0, 2, 2, this.CutImage.Height - 4);
            srcPoint = this.CutImage.Location;
            srcPoint.Offset(0, 2);
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(2, this.CutImage.Height - 4));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 右边
            destRect = new Rectangle(this.CutImage.Width - 2, 2, 2, this.CutImage.Height - 4);
            srcPoint = this.CutImage.Location;
            srcPoint.Offset(this.CutImage.Width - 2, 2);
            srcRect = new Rectangle(srcPoint, new System.Drawing.Size(2, this.CutImage.Height - 4));
            g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);

            // 绘制边框
            g.DrawLine(pen, 2, 2, this.CutImage.Width - 3, 2);
            g.DrawLine(pen, 2, 2, 2, this.CutImage.Height - 3);
            g.DrawLine(pen, this.CutImage.Width - 3, 2, this.CutImage.Width - 3, this.CutImage.Height - 3);
            g.DrawLine(pen, 2, this.CutImage.Height - 3, this.CutImage.Width - 3, this.CutImage.Height - 3);

            // 绘制四个角的调整块
            g.FillRectangle(brush, 0, 0, 4, 5);
            g.FillRectangle(brush, this.CutImage.Width - 4, 0, 4, 5);
            g.FillRectangle(brush, 0, this.CutImage.Height - 5, 4, 5);
            g.FillRectangle(brush, this.CutImage.Width - 4, this.CutImage.Height - 5, 4, 5);

            // 绘制中间的四个调整块
            int blockX = this.CutImage.Width / 2 - 2;
            int blockY = this.CutImage.Height / 2 - 2;
            g.FillRectangle(brush, blockX, 0, 4, 5);
            g.FillRectangle(brush, 0, blockY, 4, 5);
            g.FillRectangle(brush, blockX, this.CutImage.Height - 5, 4, 5);
            g.FillRectangle(brush, this.CutImage.Width - 4, blockY, 4, 5);

            // 绘制到 Label 上
            e.Graphics.DrawImage(bmp_lbl, 0, 0);
            bmp_lbl.Dispose();
        }

        private Point LabelLocation;
        private Point mouseOffset;
        private void CutImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                    this.isMoving = true;
                    LabelLocation = this.CutImage.Location;
                    mouseOffset = Control.MousePosition;
            }
        }

        private void CutImage_MouseMove(object sender, MouseEventArgs e)
        {
            int _x = 0;
            int _y = 0;
            if(isMoving==true)
            {
                Point pt = Control.MousePosition;
                _x = mouseOffset.X - pt.X;
                _y = mouseOffset.Y - pt.Y;
                this.CutImage.Location = new Point(LabelLocation.X - _x, LabelLocation.Y - _y);
                this.cutImageRect=new Rectangle(CutImage.Location.X, CutImage.Location.Y, CutImage.Width,CutImage.Height);
                this.CutImage.Invalidate();
                this.CutImage.Update();
            }

        }

        private void CutImage_MouseUp(object sender, MouseEventArgs e)
        {
            this.isMoving = false;
            this.CutImage.Invalidate();
            this.CutImage.Update();
        }
    }
}
