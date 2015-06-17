using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
#if !DEBUG
            Execute(); 
#endif
        }

        public void Execute()
        {
            try
            {
                MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
                connString.Server = "sql7.netmark.pl";
                connString.UserID = "quiderpl_transac";
                connString.Password = "!nichuja";
                connString.Database = "quiderpl_biblioteka_actual";

                MySqlConnection connection = new MySqlConnection(connString.ToString());
                connection.Open();

                Assembly assembly = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Mosaic.exe"));
                var version = assembly.GetName().Version;
                string name = null;
                using (MySqlCommand cmd = connection.CreateCommand())
                {    //watch out for this SQL injection vulnerability below
                    cmd.CommandText = string.Format("Select major, minor, `release`, build, address  from actual_mosaic order by id");
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var major = reader.GetInt32(0);
                        var minor = reader.GetInt32(1);
                        var release = reader.GetInt32(2);
                        var build = reader.GetInt32(3);
                        name = reader.GetString(4);
                        if (version.Major < major)
                        {
                            Download(name);
                            ProcessStartInfo startProcess = new ProcessStartInfo("Msiexec.exe, /i " + name + " /quiet");
                            Process p = Process.Start(startProcess);
                            p.WaitForExit();
                        }
                        else if (version.Minor < minor)
                        {
                            Download(name);
                            ProcessStartInfo startProcess = new ProcessStartInfo("Msiexec.exe, /i " + name + " /quiet");
                            Process p = Process.Start(startProcess);
                            p.WaitForExit();
                        }
                        else if (version.Revision < release)
                        {
                            Download(name);
                            ProcessStartInfo startProcess = new ProcessStartInfo("Msiexec.exe, /i " + name + " /quiet");
                            Process p = Process.Start(startProcess);
                            p.WaitForExit();
                        }
                        else if (version.Build < build)
                        {
                            Download(name);
                            ProcessStartInfo startProcess = new ProcessStartInfo("Msiexec", "/i " + name + " /quiet");
                            Process p = Process.Start(startProcess);
                            p.WaitForExit();
                        }
                        if (File.Exists(name))
                            File.Delete(name);
                    }
                
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Download(string name)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(new Uri("http://quider.pl/mosaic/"+name));
            using (FileStream fs = new FileStream(name, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        
        }
    }
}
