using MySql.Data.MySqlClient;
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
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
            connString.Server = "sql7.netmark.pl";
            connString.UserID = "quiderpl_transac";
            connString.Password = "!nichuja";
            connString.Database = "quiderpl_biblioteka_actual";

            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connString.ToString());
            connection.Open();
            using (MySqlCommand cmd = connection.CreateCommand())
            {    //watch out for this SQL injection vulnerability below
                cmd.CommandText = string.Format("Select * from actual_mosaic");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                
                }
            }
            
            Assembly assembly = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"Mosaic.exe"));
            var version = assembly.GetName().Version;
            
            WebClient wc = new WebClient();
            wc.DownloadData("quider.pl/mosaic/");
        }
    }
}
