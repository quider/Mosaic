using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateApplication
{
    public class Context : ApplicationContext
    {
        public Context()
        {
            Execute();
        }

        public void Execute()
        {
            
            Assembly assembly = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"Mosaic.exe"));
            var version = assembly.GetName().Version;
            
            WebClient wc = new WebClient();
            wc.DownloadData("quider.pl/mosaic/");
        }
    }
}
