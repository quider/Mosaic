using i18n;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RandomMosaic
{
    public class RandomMosaicCalculation
    {
        private static ILog log = LogManager.GetLogger(typeof(RandomMosaicCalculation));
        private bool useHue;

        public RandomMosaicCalculation(bool applyHue)
        {
            this.useHue = applyHue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CalculateRandomMosaic(object sender, DoWorkEventArgs e)
        {
            object[] arguments = e.Argument as object[];
            var image = arguments[0] as Image;
            var copyOfOryginalImage = (Image)image.Clone();
            List<string> tilesNames = arguments[1] as List<string>;
            var height = (int)arguments[2];
            var width = (int)arguments[3];
            var avgsMaster = (Color[,])arguments[4];
            var worker = sender as BackgroundWorker;
            var sizeTile = new Size(width, height);
            int tX = image.Width / sizeTile.Width;
            int tY = image.Height / sizeTile.Height;
            string[,] usedTiles = new string[tX, tY];


            worker.ReportProgress(0, String.Format(strings.LoadingAndResizingTiles));

            Dictionary<string, Color> tilesColors = new Dictionary<string, Color>();

            if (Directory.Exists("tiles\\"))
            {
                Directory.Delete("tiles\\", true);
            }

            Directory.CreateDirectory("tiles\\");

            double maximum = tilesNames.Count;
            int index = 0;

            foreach (var tilePath in tilesNames)
            {
                try
                {
                    var tilename = "tiles\\" + index.ToString() + ".bmp";
                    log.DebugFormat("Creating tile {0}", tilename);
                    using (Stream stream = new FileStream(tilePath, FileMode.Open))
                    {
                        Bitmap bitmapTile;
                        using (bitmapTile = (Bitmap)Bitmap.FromStream(stream))
                        {
                            bitmapTile = Utils.ResizeBitmap(bitmapTile, sizeTile);
                            bitmapTile.Save(tilename);
                            log.DebugFormat("Tile saved");
                            worker.ReportProgress((int)((index / maximum) * 100), String.Format(strings.LoadingAndResizingTiles));
                        }
                        index++;
                    }
                }
                catch (ArgumentException ex)
                {
                    log.ErrorFormat("{0}: {1}", tilePath, ex.Message);
                }
                catch (OutOfMemoryException ex)
                {
                    log.ErrorFormat("Problem with image {0}", tilePath);
                    log.Error(ex.Message, ex);
                    GC.WaitForPendingFinalizers();
                }
            }

            worker.ReportProgress(0, strings.CalculateMosaic);

            log.DebugFormat("Image divided onto {0}x{1}", tX, tY);
            var searchCounter = 1;
            List<string>[,] matchedColors = new List<string>[tX, tY];
            Random random = new Random();
            Parallel.For(0, tX, x =>
            {
                Parallel.For(0, tY, (y) =>
                {
                    Bitmap found = null;
                    maximum = tX * tY + 1;
                    var percentage = (int)((searchCounter / maximum) * 100);
                    worker.ReportProgress(percentage, strings.CalculateMosaic);
                    var i = random.Next(tilesNames.Count - 1);
                    log.DebugFormat("Used image: {0}, index: {1}", searchCounter, i);
                    string name = "tiles\\" + i.ToString() + ".bmp";
                    log.DebugFormat("Tile name {0}", name);
                    try
                    {
                        found = new Bitmap(name);
                        log.DebugFormat("Created bitmap from image {0}", name);

                        TextureBrush tBrush = new TextureBrush(Utils.AdjustHue(found, avgsMaster[x, y]));

                        Pen blackPen = new Pen(Color.Black);

                        using (var g = Graphics.FromImage(image))
                        {
                            g.FillRectangle(tBrush, new Rectangle(x * width, y * height, width, height));
                        }
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("Name of tile during error {0}", name);
                        log.Error(ex.Message, ex);
                    }
                    i++;
                    searchCounter++;
                });
            });
            
            log.DebugFormat("Finishig calculate of mosaic");
            e.Result = image;
        }

    }
}
