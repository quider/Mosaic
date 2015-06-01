using i18n;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ColorsCalculation
{
    public class ColorCalculation
    {
        private static ILog log = LogManager.GetLogger(typeof(ColorCalculation));
        
        public Color[,] avgsMaster
        {
            get;
            set;
        }


        public ColorCalculation()
        {
        
        }

        public void CalculateColorsWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                var arguments = e.Argument as object[];
                var worker = sender as BackgroundWorker;
                var image = arguments[0] as Image;
                var height = (decimal)arguments[1];
                var width = (decimal)arguments[2];
                log.InfoFormat("Images size of {0}x{1}", width, height);
                var szTile = new Size((int)width, (int)height);
                Boolean bLoaded = false;
                Bitmap bMaster = null;

                log.Info("Averaging colors");

                worker.ReportProgress(1, String.Format(strings.LoadingMasterFile));

                while (!bLoaded)
                {
                    try
                    {
                        bMaster = new Bitmap((Image)image.Clone());
                        log.InfoFormat("Main image set");
                        bLoaded = true;
                    }
                    catch (OutOfMemoryException ex)
                    {
                        log.Error(ex.Message, ex);
                        GC.WaitForPendingFinalizers();
                    }
                }

                int tX = bMaster.Width / szTile.Width;
                int tY = bMaster.Height / szTile.Height;
                this.avgsMaster = new Color[tX, tY];

                worker.ReportProgress(1, String.Format(strings.AveragingMasterBitmap));

                var maximum = tX * tY;

                try
                {
                    lock (image)
                    {
                        for (int x = 0; x < tX; x++)
                        {
                            for (int y = 0; y < tY; y++)
                            {
                                avgsMaster[x, y] = Utils.GetTileAverage(bMaster, x * szTile.Width, y * szTile.Height, szTile.Width, szTile.Height);
                                Rectangle r = new Rectangle(szTile.Width * x, szTile.Height * y, szTile.Width, szTile.Height);
                                worker.ReportProgress((int)((double)x / tX * 100), String.Format(strings.AveragingMasterBitmap));

                                using (Graphics g = Graphics.FromImage(image))
                                {
                                    g.FillRectangle(new SolidBrush(avgsMaster[x, y]), r);
                                }
                            };
                        };
                    }
                }
                catch (Exception ex)
                {
                    log.FatalFormat("Fatal error during putting images into big image");
                    log.Fatal(ex.Message, ex);
                    worker.CancelAsync();
                    return;
                }

                e.Result = image;
            }
        }

       
    }
}
