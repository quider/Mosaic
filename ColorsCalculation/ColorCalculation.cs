using API;
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
    public class ColorCalculation : ACalculateColors
    {
        private static ILog log = LogManager.GetLogger(typeof(ColorCalculation));
        private int height;
        private int width;

        public Color[,] avgsMaster
        {
            get;
            set;
        }

        public ColorCalculation(int w, int h){
            this.width = w;
            this.height = h;
        }

        public override Image CalculateColors(string fileName, out Color[,] color)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                var image = Image.FromFile(fileName);
                var height = this.height;
                var width = this.width;
                log.InfoFormat("Images size of {0}x{1}", width, height);
                var szTile = new Size((int)width, (int)height);
                Boolean bLoaded = false;
                Bitmap bMaster = null;

                log.Info("Averaging colors");


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

                                using (Graphics g = Graphics.FromImage(image))
                                {
                                    g.FillRectangle(new SolidBrush(avgsMaster[x, y]), r);
                                    OnColorCalculated(avgsMaster[x, y], x, y, tX, tY);
                                }
                            };
                        };
                    }
                }
                catch (Exception ex)
                {
                    log.FatalFormat("Fatal error during putting images into big image");
                    log.Fatal(ex.Message, ex);
                }
                color = this.avgsMaster;
                return image;
            }
        }
    }
}
