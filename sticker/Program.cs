using cbgfinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            NewMethod();
            Application.SetCompatibleTextRenderingDefault(false);
            var stickers=Directory.GetFiles("stickers");
            
            Application.Run(new stkrDaemon());
          
        }

        private static void NewMethod()
        {
            Application.EnableVisualStyles();
        }
    }
}
