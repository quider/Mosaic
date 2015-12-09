using API;
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

namespace ClassicMosaic
{
    public class ClassicMosaicCalculation:Mosaic
    {
        private static ILog log = LogManager.GetLogger(typeof(ClassicMosaicCalculation));
        private bool useHue;
        private int buffer;
        private int tilesInGroup;

        public ClassicMosaicCalculation(bool applyHue, int buffer, int tilesInGroup)
        {
            this.buffer = buffer;
            this.useHue = applyHue;
            this.tilesInGroup = tilesInGroup;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CalculateMosaic(object sender, DoWorkEventArgs e)
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
            //int index = 0;

            //foreach (var tilePath in tilesNames)
            //{
            //    try
            //    {
            //        var tilename = "tiles\\" + index.ToString() + ".bmp";
            //        log.DebugFormat("Creating tile {0}", tilename);
            //        using (Stream stream = new FileStream(tilePath, FileMode.Open))
            //        {
            //            Bitmap bitmapTile;
            //            using (bitmapTile = (Bitmap)Bitmap.FromStream(stream))
            //            {
            //                bitmapTile = Utils.ResizeBitmap(bitmapTile, sizeTile);
            //                bitmapTile.Save(tilename);
            //                log.DebugFormat("Tile saved");
            //                tilesColors.Add(tilename, Utils.GetTileAverage(bitmapTile, 0, 0, sizeTile.Width, sizeTile.Height));
            //                log.DebugFormat("Color added to collection {0}", tilesColors[tilename]);
            //                worker.ReportProgress((int)((index / maximum) * 100), String.Format(strings.LoadingAndResizingTiles));
            //            }
            //            index++;
            //        }
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        log.ErrorFormat("{0}: {1}", tilePath, ex.Message);
            //    }
            //    catch (OutOfMemoryException ex)
            //    {
            //        log.ErrorFormat("Problem with image {0}", tilePath);
            //        log.Error(ex.Message, ex);
            //        GC.WaitForPendingFinalizers();
            //    }
            //}

            if (tilesColors.Count > 0)
            {
                //TODO: get as parameter
                //if (bAdjustHue)
                log.Debug("Non hue algorythm");
                worker.ReportProgress(0, strings.CalculateMosaic);
                // Don't adjust hue - keep searching for a tile close enough
                log.DebugFormat("Image divided onto {0}x{1}", tX, tY);
                var searchCounter = 1;
                List<string>[,] matchedColors = new List<string>[tX, tY];

                Parallel.For(0, tX, x =>
                {
                    Parallel.For(0, tY, (y) =>
                    {
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
                                if (Utils.GetDifference(avgsMaster[x, y], tilesColors[name]) < buffer)
                                {
                                    colors.Add(name);
                                    log.InfoFormat("added for x={0} y={1} filename: {2}", x, y, name);
                                }
                                else
                                {
                                    // in case of buffer is not enough
                                }
                            }
                            catch (Exception ex)
                            {
                                log.ErrorFormat("Name of tile during error {0}", name);
                                log.Error(ex.Message, ex);
                            }
                            i++;
                            if (tilesColors.Count == i && colors.Count < this.tilesInGroup)
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
                {
                    Parallel.For(0, tY, y =>
                    {
                        try
                        {
                            searchCounter++;
                            maximum = tX * tY + 1;
                            var percentage = (int)((searchCounter / maximum) * 100);
                            worker.ReportProgress(percentage, strings.TilesRandomize);

                            Bitmap found = null;
                            if (matchedColors[x, y].Count > 1)
                            {
                                log.InfoFormat("array do not contain any tile!");
                            }
                            var list = matchedColors[x, y].ToArray();
                            var name = list[random.Next(list.Length)];
                            log.InfoFormat("Image fit to average color: {0}", avgsMaster[x, y]);
                            found = new Bitmap(name);
                            log.DebugFormat("Created bitmap from image {0}", name);
                            TextureBrush tBrush = new TextureBrush(found);

                            if (this.useHue)
                            {
                                found = Utilities.Utils.AdjustHue(found, avgsMaster[x, y]);
                            }

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
            if (this.useHue)
            {
            }
            log.DebugFormat("Finishig calculate of mosaic");
            e.Result = image;
        }


        public override Image CalculateMosaic(Image averageImage, Color[,] colorMatrix, List<string> tilesNames)
        {
            throw new NotImplementedException();
        }
    }
}
