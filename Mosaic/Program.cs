using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MosaicApplication {
    static class Program {
        static ILog log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            log.InfoFormat("Start application. Username: {0}, System directory: {1}, System Version {2}, Processor count: {3}, OSVersion: {4}, MachineName: {5}, Is 64Bit process: {6}, is 64 bit os: {7}, Working set: {8}",
                Environment.UserName,
                Environment.SystemDirectory,
                Environment.Version,
                Environment.ProcessorCount,
                Environment.OSVersion,
                Environment.MachineName,
                Environment.Is64BitProcess,
                Environment.Is64BitOperatingSystem,
                Environment.WorkingSet);

            log.InfoFormat("Culture info:{0}", CultureInfo.CurrentCulture);


            var context = new Context();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(context.CreateMainForm());
        }
    }
}
