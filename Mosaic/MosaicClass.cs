using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using log4net;
using System.Threading.Tasks;

namespace Mosaic
{
    public class MosaicClass
    {
        private static ILog log = LogManager.GetLogger(typeof(MosaicClass));
        private Color[,] avgsMaster;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int GetDifference(Color source, Color target)
        {
            int dR = Math.Abs(source.R - target.R);
            int dG = Math.Abs(source.G - target.G);
            int dB = Math.Abs(source.B - target.B);
            int diff = Math.Max(dR, dG);
            diff = Math.Max(diff, dB);
            return diff;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bSource"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Color GetTileAverage(Bitmap bSource, int x, int y, int width, int height)
        {
            long aR = 0;
            long aG = 0;
            long aB = 0;
            for (int w = x; w < x + width; w++)
            {
                for (int h = y; h < y + height; h++)
                {
                    Color cP = bSource.GetPixel(w, h);
                    aR += cP.R;
                    aG += cP.G;
                    aB += cP.B;
                }
            }
            aR = aR / (width * height);
            aG = aG / (width * height);
            aB = aB / (width * height);
            return Color.FromArgb(255, Convert.ToInt32(aR), Convert.ToInt32(aG), Convert.ToInt32(aB));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bSource"></param>
        /// <param name="targetColor"></param>
        /// <returns></returns>
        public static Bitmap AdjustHue(Bitmap bSource, Color targetColor)
        {
            Bitmap result = new Bitmap(bSource.Width, bSource.Height);
            for (int w = 0; w < bSource.Width; w++)
            {
                for (int h = 0; h < bSource.Height; h++)
                {
                    // Get current output color
                    Color clSource = bSource.GetPixel(w, h);
                    int R = Math.Min(255, Math.Max(0, ((clSource.R + targetColor.R) / 2)));
                    int G = Math.Min(255, Math.Max(0, ((clSource.G + targetColor.G) / 2)));
                    int B = Math.Min(255, Math.Max(0, ((clSource.B + targetColor.B) / 2)));
                    Color clAvg = Color.FromArgb(R, G, B);

                    result.SetPixel(w, h, clAvg);
                    Application.DoEvents();
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bSource"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        private static Bitmap ResizeBitmap(Bitmap bSource, Size newSize)
        {
            Bitmap result = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bSource, 0, 0, newSize.Width, newSize.Height);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void CalculateColorsWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var arguments = e.Argument as object[];
            var worker = sender as BackgroundWorker;
            var image = arguments[0] as Image;
            var height = (decimal)arguments[1];
            var width = (decimal)arguments[2];
            var szTile = new Size((int)width, (int)height);
            Boolean bLoaded = false;
            Bitmap bMaster = null;

            worker.ReportProgress(1, String.Format(strings.LoadingMasterFile));

            while (!bLoaded)
            {
                try
                {
                    bMaster = new Bitmap((Image)image.Clone());
                    bLoaded = true;
                }
                catch (OutOfMemoryException)
                {
                    GC.WaitForPendingFinalizers();
                }
            }

            int tX = bMaster.Width / szTile.Width;
            int tY = bMaster.Height / szTile.Height;
            this.avgsMaster = new Color[tX, tY];

            worker.ReportProgress(1, String.Format(strings.AveragingMasterBitmap));

            var maximum = tX * tY;

            lock (image)
            {
                for (int x = 0; x < tX; x++)
                {
                    for (int y = 0; y < tY; y++)
                    {
                        avgsMaster[x, y] = GetTileAverage(bMaster, x * szTile.Width, y * szTile.Height, szTile.Width, szTile.Height);
                        Rectangle r = new Rectangle(szTile.Width * x, szTile.Height * y, szTile.Width, szTile.Height);
                        worker.ReportProgress((int)((double)x / tX * 100), String.Format(strings.AveragingMasterBitmap));

                        using (Graphics g = Graphics.FromImage(image))
                        {
                            g.FillRectangle(new SolidBrush(avgsMaster[x, y]), r);
                        }
                    }
                }
            }

            e.Result = image;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void CalculateMosaic(object sender, DoWorkEventArgs e)
        {
            object[] arguments = e.Argument as object[];
            var image = arguments[0] as Image;
            List<string> tilesNames = arguments[1] as List<string>;
            var height = (int)arguments[2];
            var width = (int)arguments[3];
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
            foreach (string tilePath in tilesNames)
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
                            bitmapTile = ResizeBitmap(bitmapTile, sizeTile);
                            bitmapTile.Save(tilename);
                            log.DebugFormat("Tile saved");
                            tilesColors.Add(tilename, GetTileAverage(bitmapTile, 0, 0, sizeTile.Width, sizeTile.Height));
                            log.DebugFormat("Color added to collection {0}", tilesColors[tilename]);
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

            if (tilesColors.Count > 0)
            {
                //TODO: get as parameter
                //if (bAdjustHue)
                if (false)
                {
                    List<Tile> tileQueue = new List<Tile>();
                    Tile tFound = null;
                    int maxQueueLength = Math.Min(1000, Math.Max(0, tilesColors.Count - 50));

                    for (int x = 0; x < tX; x++)
                    {
                        for (int y = 0; y < tY; y++)
                        {
                            int i = 0;
                            // Check if it's the same as the last (X)?
                            if (tileQueue.Count > 1)
                            {
                                //while (tileQueue.Contains(tilesColors[i]))
                                //{
                                //    i = r.Next(tilesColors.Count);
                                //}
                            }

                            // Add to the 'queue'
                            tFound = null;//tilesColors[i];
                            if ((tileQueue.Count >= maxQueueLength) && (tileQueue.Count > 0))
                            {
                                tileQueue.RemoveAt(0);
                            }
                            tileQueue.Add(tFound);

                            // Apply found tile to section
                            for (int w = 0; w < sizeTile.Width; w++)
                            {
                                for (int h = 0; h < sizeTile.Height; h++)
                                {
                                    // bOut.SetPixel(x * szTile.Width + w, y * szTile.Height + h, bAdjusted.GetPixel(w, h));
                                }
                            }
                        }
                    }
                }
                else
                {
                    log.Debug("Non hue algorythm");
                    worker.ReportProgress(0, strings.CalculateMosaic);
                    // Don't adjust hue - keep searching for a tile close enough
                    log.DebugFormat("Image divided onto {0}x{1}", tX, tY);
                    var searchCounter = 1;
                    List<string>[,] matchedColors = new List<string>[tX, tY];

                    Parallel.For(0, tX, x =>
                    //for (int x = 0; x < tX; x++)
                    {
                        Parallel.For(0, tY, (y) =>
                        {

                            //for (int y = 0; y < tY; y++)
                            //{
                            var buffer = 25;
                            log.DebugFormat("Color buffer set to {0}", buffer);

                            int i = 0;
                            maximum = tX * tY + 1;
                            var percentage = (int)((searchCounter / maximum) * 100);
                            worker.ReportProgress(percentage, strings.CalculateMosaic);

                            var colors = new List<string>();

                            while (tilesColors.Count - 1 >= i)
                            {
                                log.DebugFormat("Searchcounter: {0}, index: {1}", searchCounter, i);
                                string name = "tiles\\" + i.ToString() + ".bmp";
                                log.DebugFormat("Tile name {0}", name);
                                try
                                {
                                    if (GetDifference(this.avgsMaster[x, y], tilesColors[name]) < buffer)
                                    {
                                        colors.Add(name);
                                        log.InfoFormat("added for x={0} y={1} filename: {2}", x, y, name);
                                    }
                                    else
                                    {
                                    }
                                }
                                catch (Exception ex)
                                {
                                    log.ErrorFormat("Name of tile during error {0}", name);
                                    log.Error(ex.Message, ex);
                                }
                                i++;
                                if (tilesColors.Count == i && colors.Count < 3)
                                {
                                    i = 0;
                                    buffer += 25;
                                    log.InfoFormat("buffer set to {0}", buffer);
                                }
                            }
                            matchedColors[x, y] = colors;
                            searchCounter++;
                        });
                    });

                    //here looking for colors in table and chose from list:

                    var random = new Random();
                    searchCounter = 0;
                    Parallel.For(0, tX, x =>
                    //for (int x = 0; x < tX; x++)
                    {
                        Parallel.For(0,tY,y=>
                        //for (int y = 0; y < tY; y++)
                        {
                            try
                            {
                                searchCounter++;
                                maximum = tX * tY + 1;
                                var percentage = (int)((searchCounter / maximum) * 100);
                                worker.ReportProgress(percentage, "Tiles randomize");

                                Bitmap found = null;
                                if (matchedColors[x, y].Count > 1)
                                {
                                    log.InfoFormat("array do not contain any tile!");
                                }
                                var list = matchedColors[x, y].ToArray();
                                var name = list[random.Next(list.Length)];
                                log.InfoFormat("Image fit to average color: {0}", this.avgsMaster[x, y]);
                                found = new Bitmap(name);
                                log.DebugFormat("Created bitmap from image {0}", name);
                                TextureBrush tBrush = new TextureBrush(found);
                                Pen blackPen = new Pen(Color.Black);
                                using (var g = Graphics.FromImage(image))
                                {
                                    g.FillRectangle(tBrush, new Rectangle(x * width, y * height, width, height));
                                }
                            }
                            catch (Exception ex)
                            {
                                log.ErrorFormat("Error during finding x={0} y={1}", x, y);
                                log.Error(ex.Message, ex);
                            }
                        });
                    });
                }
            }
            log.DebugFormat("Finishig calculate of mosaic");
            e.Result = image;
        }
    }

    public class Tile
    {
        private Bitmap bitmap;
        private Color color;

        public Bitmap getBitmap()
        {
            return bitmap;
        }
        public Color getColor()
        {
            return color;
        }
        public void setColor(Color average)
        {
            color = average;
        }

        public Tile(Bitmap bSource, Color cSource)
        {
            bitmap = bSource;
            color = cSource;
        }

        public void Close()
        {
            bitmap.Dispose();
            bitmap = null;
        }
    }
}
