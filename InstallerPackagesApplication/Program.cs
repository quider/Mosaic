using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InstallerPackagesApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            Console.WriteLine(args[1]);
            Console.WriteLine(args[2]);
            Console.WriteLine(args[3]);
            Assembly assembly = Assembly.LoadFile(Path.Combine(args[1], "Bin", args[3], "Mosaic.exe"));
            var version = assembly.GetName().Version;

            string filename = args[0];
            string ftpServerIP = "ftp.quider.pl/";
            string ftpUserName = "quiderpl";
            string ftpPassword = "!nichuja.1990";

            FileInfo objFile = new FileInfo(filename + ".msi");
            string movedFile = filename + "_" + args[3] + "_" + args[2] + "_" + version.ToString(4) + ".msi";
            try
            {
                objFile.MoveTo(movedFile);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            FtpWebRequest objFTPRequest;

            // Create FtpWebRequest object 
            objFTPRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/public_html/mosaic/" + objFile.Name));

            // Set Credintials
            objFTPRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            objFTPRequest.KeepAlive = false;

            // Set the data transfer type.
            objFTPRequest.UseBinary = true;

            // Set content length
            objFTPRequest.ContentLength = objFile.Length;

            // Set request method
            objFTPRequest.Method = WebRequestMethods.Ftp.UploadFile;

            // Set buffer size
            int intBufferLength = 16 * 1024;
            byte[] objBuffer = new byte[intBufferLength];

            // Opens a file to read
            FileStream objFileStream = objFile.OpenRead();

            try
            {
                // Get Stream of the file
                Stream objStream = objFTPRequest.GetRequestStream();

                int len = 0;

                while ((len = objFileStream.Read(objBuffer, 0, intBufferLength)) != 0)
                {
                    // Write file Content 
                    objStream.Write(objBuffer, 0, len);

                }

                objStream.Close();
                objFileStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
            connString.Server = "sql7.netmark.pl";
            connString.UserID = "quiderpl_transac";
            connString.Password = "!nichuja";
            connString.Database = "quiderpl_biblioteka_actual";

            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connString.ToString());
            connection.Open();
            using (MySqlCommand cmd = connection.CreateCommand())
            {    //watch out for this SQL injection vulnerability below
                cmd.CommandText =
                    "INSERT INTO actual_mosaic (address, major, minor, `release`, build, date) VALUES ( @address, @major, @minor, @release, @build, @date)";

                cmd.Parameters.AddWithValue("@address", Path.GetFileName(movedFile));
                cmd.Parameters.AddWithValue("@major", version.Major);
                cmd.Parameters.AddWithValue("@minor", version.Minor);
                cmd.Parameters.AddWithValue("@release", version.MinorRevision);
                cmd.Parameters.AddWithValue("@build", version.Build);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyyMMddHHmmss"));

                var reader = cmd.ExecuteNonQuery();

            }
        }

    }
}
