using windowHelper.Model;
using screenCapture;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace windowHelper
{
    public partial class WindowHelper : Form
    {
        private WeatherDescription wd;
        private CaptureForm cf;
        private int x;
        private int y;
        string[] s = new string[23];//声明string数组存放返回结果 
        Weather_data[] weather_datas;//存放天气数据
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow([MarshalAs(UnmanagedType.LPTStr)] string lpClassName, [MarshalAs(UnmanagedType.LPTStr)] string lpWindowName);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        //判断网络状况的方法,返回值true为连接，false为未连接  
        public extern static bool InternetGetConnectedState(out int conState, int reder);

        public WindowHelper()
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            wd = new WeatherDescription();
            cf = new CaptureForm();
            x = System.Windows.Forms.SystemInformation.WorkingArea.Width - this.Size.Width;
            y = System.Windows.Forms.SystemInformation.WorkingArea.Height / 10;
            this.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            this.Location = (Point)new Size(x-20, y);         //窗体的起始位置为(x,y)
            timer1_Tick(null,null);
            timer2_Tick(null, null);
        }
        //实现对label的拖动
        private bool isMouseDown = false;
        private Point FormLoacation;
        private Point mouseOffset;


        private void TimeLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLoacation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void TimeLabel_MouseMove(object sender, MouseEventArgs e)
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

        private void TimeLabel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TimeLabel.Text = DateTime.Now.ToShortTimeString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            this.DateLabel.Text = month + "月" + day + "日";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    this.WeekLabel.Text = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    this.WeekLabel.Text = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    this.WeekLabel.Text = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    this.WeekLabel.Text = "星期四";
                    break;
                case DayOfWeek.Friday:
                    this.WeekLabel.Text = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    this.WeekLabel.Text = "星期六";
                    break;
                case DayOfWeek.Sunday:
                    this.WeekLabel.Text = "星期日";
                    break;

            }
        }

        private void TimePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                FormLoacation = this.Location;
                mouseOffset = Control.MousePosition;
            }
        }

        private void TimePanel_MouseMove(object sender, MouseEventArgs e)
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

        private void TimePanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void WindowHelper_Load(object sender, EventArgs e)
        {
            
        }

        private static byte[] GetURLContents(string url)
        {
            var content = new MemoryStream();

            var webReq = (HttpWebRequest)WebRequest.Create(url);

            using (WebResponse response = webReq.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    responseStream.CopyTo(content);
                }
            }

            return content.ToArray();
        }

        private void weatherButter_MouseLeave(object sender, EventArgs e)
        {
            wd.Hide();
        }

        private void weatherButter_MouseHover(object sender, EventArgs e)
        {
            wd.StartPosition = FormStartPosition.Manual; //窗体的位置由Location属性决定
            wd.Location = (Point)new Size(this.Location.X+10,this.Location.Y+this.Height+5);         //窗体的起始位置为(x,y)
            wd.Show();
        }
        private void weatherLoad(string city)
        {
            /*cn.com.webxml.www.WeatherWebService w = new cn.com.webxml.www.WeatherWebService();
            s = w.getWeatherbyCityName(city);
            if (s[8] == "")
            {
                wd.cityLabel.Text = "暂无天气信息";
            }
            else
            {
                this.weatherButter.Image = Image.FromFile(Application.StartupPath + "\\weather\\" + s[8]);
                this.weatherLabel.Text = s[5];
                wd.cityLabel.Text = s[8];
            }*/
            baiduWeather weather = new baiduWeather(city);
            WeatherMessage weathermessage = weather.GetWeather();
            String content = "";
            if (weathermessage.status.Equals("success"))
            {
                WeatherModel weatherModel = weathermessage.results[0];
                content = content + weatherModel.currentCity + "\n";
                weather_datas = weatherModel.weather_data;
                content = content + weather_datas[0].date + "\n";
                content = content + weather_datas[0].weather + "\n";
                content = content + weather_datas[0].temperature + "\n";
                content = content + weather_datas[0].wind + "\n";
                wd.cityLabel.Text = content;
                String[] dateInfo = null;
                dateInfo = weather_datas[0].date.Split('(');
                this.weatherLabel.Text = dateInfo[1].Substring(0,dateInfo[1].Length-1);
                String url = null;
                if(DateTime.Now.Hour<6|| DateTime.Now.Hour>18)
                {
                    url = weather_datas[0].nightPictureUrl;
                }
                else
                {
                    url = weather_datas[0].dayPictureUrl;
                }
                WebRequest webreq = WebRequest.Create(url);
                WebResponse webres = webreq.GetResponse();
                Stream stream = webres.GetResponseStream();
                this.weatherButten.Image = Image.FromStream(stream);
            }
            else
            {
                wd.cityLabel.Text = "暂无天气信息";
            }
        }
        private SinaAddress getAddress()
        {
            // 新浪定位url  
            string url = "http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=js";
            // 请求数据  
            byte[] con = GetURLContents(url);
            // byte转string  
            string str = Encoding.ASCII.GetString(con);

            string strSp = str.Split('=')[1].Trim().TrimEnd(';');
            // 解析json字符串  
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<SinaAddress>(strSp); 
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int n = 0;
            if (InternetGetConnectedState(out n, 0))
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("119.75.218.45");//百度IP
                if (reply.Status == IPStatus.Success)
                {
                    SinaAddress sinaAddress = getAddress();
                    // 国家  
                    string country = sinaAddress.country;
                    // 省份  
                    string province = sinaAddress.province;
                    // 城市  
                    string city = sinaAddress.city;
                    if (city == null)
                    {
                        city = province;
                    }
                    weatherLoad(city);
                }
            }
            else
            {
                wd.cityLabel.Text = "暂无天气信息";
            }
        }

        private void weatherButten_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (InternetGetConnectedState(out n, 0))
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send("119.75.218.45");//百度IP
                if (reply.Status == IPStatus.Success)
                {
                    SinaAddress sinaAddress = getAddress();
                    // 国家  
                    string country = sinaAddress.country;
                    // 省份  
                    string province = sinaAddress.province;
                    // 城市  
                    string city = sinaAddress.city;
                    if (city == null)
                    {
                        city = province;
                    }
                    weatherLoad(city);
                }
            }
            else
            {
                wd.cityLabel.Text = "暂无天气信息";
            }
        }

    }
}
