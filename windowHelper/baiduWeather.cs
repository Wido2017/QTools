using windowHelper.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace windowHelper
{
    class baiduWeather
    {
        public const String service_http = "http://api.map.baidu.com/telematics/v3/weather?output=json&ak=6tYzTvGZSOpYB5Oc2YGGOKt8&location=";//这里使用了别人的百度ak（密钥），有需要的话自己申请  
        public String location = "";
        public String http = "";
        public baiduWeather(String location)
        {
            this.location = location;
            http = service_http + location;
        }
        public string HttpGet()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(http);
            request.Method = "GET";
            // request.ContentType= "text/html;charset=UTF-8";  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
        public WeatherMessage GetWeather()
        {

            WeatherMessage weatherMessage = JsonConvert.DeserializeObject<WeatherMessage>(HttpGet());
            return weatherMessage;
        }
    }
}
