using ColorsCalculation;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Mosaic
{
    public class Context : ApplicationContext
    {
        internal ColorCalculation MosaicColors
        {
            get;
            set;
        }

        public Form MainForm
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Form CreateMainForm()
        {
            this.MainForm = new MainForm();
            this.MainForm.Ctx = this;
            return this.MainForm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        internal void RunBackgroundWorkerForCalculateColorsOfMosaic(string fileName)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                this.MosaicColors = new ColorCalculation();
                var backgroundCalculateColorsOnPicture = new BackgroundWorker();
                backgroundCalculateColorsOnPicture.WorkerReportsProgress = true;
                backgroundCalculateColorsOnPicture.DoWork += MosaicColors.CalculateColorsWork;
                backgroundCalculateColorsOnPicture.ProgressChanged += this.CalculateColorsProgressChanged;
                backgroundCalculateColorsOnPicture.RunWorkerCompleted += this.CalculateColorsCompleted;
                backgroundCalculateColorsOnPicture.RunWorkerAsync(new object[] { Image.FromFile(fileName), this.nudHeight.Value, nudWidth.Value });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void CalculateColorsProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                var progres = e.ProgressPercentage;
                var v = e.UserState as String;
                this.pgbOperation.Value = progres;
                this.lblPercentage.Text = string.Format("{0}%", progres);
                this.lblOperation.Text = v;
            }
        }
    }
}
