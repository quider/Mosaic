using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace Mosaic
{
    public class MosaicClass
    {
        public static int GetDifference(Color source, Color target)
        {
            int dR = Math.Abs(source.R - target.R);
            int dG = Math.Abs(source.G - target.G);
            int dB = Math.Abs(source.B - target.B);
            int diff = Math.Max(dR, dG);
            diff = Math.Max(diff, dB);
            return diff;
        }

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

        private static Bitmap ResizeBitmap(Bitmap bSource, Size newSize)
        {
            Bitmap result = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bSource, 0, 0, newSize.Width, newSize.Height);
                g.Dispose();
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
            LockBitmap bOut = null;

            /// Notification
            // lblUpdate.Text = 
            worker.ReportProgress(1, String.Format(strings.LoadingMasterFile));

            /// File Load Phase  
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

            /// Notification
            worker.ReportProgress(1, String.Format(strings.AveragingMasterBitmap));

            /// Average Master Image Phase
            int tX = bMaster.Width / szTile.Width;
            int tY = bMaster.Height / szTile.Height;
            Color[,] avgsMaster = new Color[tX, tY];

            /// Notification
            var maximum = tX * tY;
            var progres = 4;
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

            /// Output Load Phase                
            bLoaded = false;
            while (!bLoaded)
            {
                try
                {
                    bOut = new LockBitmap(bMaster);
                    bLoaded = true;
                }
                catch (OutOfMemoryException)
                {
                    GC.WaitForPendingFinalizers();
                }
            }

            /// Close Master Image Phase
            bMaster.Dispose();
            bMaster = null;

            /// Notification
            //lblUpdate.Text = String.Format("Loading and Resizing Tile Images...");
            e.Result = image;
        }

        internal void CalculateMosaic(object sender, DoWorkEventArgs e)
        {
            /// Notification
            //lblUpdate.Text = String.Format("Loading and Resizing Tile Images...");

            /// Tile Load And Resize Phase
            List<Tile> bTiles = new List<Tile>();
            string[] fTiles = Directory.GetFiles(@"\tiles");
            String errorFiles = String.Empty;
            Bitmap bTile;
            var arguments = e.Argument as object[];
            var worker = sender as BackgroundWorker;
            var image = arguments[0] as Image;
            var szTile = image.Size;
            int tX = image.Width / szTile.Width;
            int tY = image.Height / szTile.Height;
            Color[,] avgsMaster = new Color[tX, tY];
            LockBitmap bOut = null;
            /// Notification
            //pgbUpdate.Maximum = fTiles.Count();
            //pgbUpdate.Value = 0;

            for (int i = 0; i < fTiles.Count(); i++)
            {
                try
                {
                    bTile = (Bitmap)Bitmap.FromFile(fTiles[i]);
                    bTile = ResizeBitmap(bTile, szTile);
                    bTile.Save("\\tile" + i.ToString() + ".bmp");
                    bTile.Dispose();
                    //pgbUpdate.Value++;
                }
                catch (ArgumentException ex)
                {
                    errorFiles += String.Format("{0}: {1}\r\n", fTiles[i], ex.Message);
                }
                catch (OutOfMemoryException)
                {
                    GC.WaitForPendingFinalizers();
                    i--;
                }
            }

            if (errorFiles.Length > 0)
            {
                throw new Exception(errorFiles);
            }

            /// Notification
            //lblUpdate.Text = String.Format("Reloading Tiles...");
            //pgbUpdate.Maximum = fTiles.Count();
            //pgbUpdate.Value = 0;

            /// Tile Reload Phase
            for (int i = 0; i < fTiles.Count(); i++)
            {
                bTile = new Bitmap("\\tile" + i.ToString() + ".bmp");
                bTiles.Add(new Tile(bTile, Color.Black));
                //pgbUpdate.Value++;
            }

            /// Notification
            //lblUpdate.Text = String.Format("Averaging Tiles...");
            //pgbUpdate.Maximum = bTiles.Count();
            //pgbUpdate.Value = 0;

            /// Average Tile Images Phase
            foreach (Tile t in bTiles)
            {
                t.setColor(GetTileAverage(t.getBitmap(), 0, 0, t.getBitmap().Width, t.getBitmap().Height));
                //pgbUpdate.Value++;
            }

            /// Iterative Replacement Phase / Search Phase
            if (bTiles.Count > 0)
            {
                /// Notification
                //lblUpdate.Text = String.Format("Applying Search Pattern...");
                //pgbUpdate.Maximum = tX * tY;
                //pgbUpdate.Value = 0;


                Random r = new Random();

                //TODO: get as parameter
                //if (bAdjustHue)
                if (false)
                {
                    // Adjust hue - get the first (random) tile found and adjust its colours
                    // to suit the average
                    List<Tile> tileQueue = new List<Tile>();
                    Tile tFound = null;
                    int maxQueueLength = Math.Min(1000, Math.Max(0, bTiles.Count - 50));

                    for (int x = 0; x < tX; x++)
                    {
                        for (int y = 0; y < tY; y++)
                        {
                            int index = 0;
                            // Check if it's the same as the last (X)?
                            if (tileQueue.Count > 1)
                            {
                                while (tileQueue.Contains(bTiles[index]))
                                {
                                    index = r.Next(bTiles.Count);
                                }
                            }

                            // Add to the 'queue'
                            tFound = bTiles[index];
                            if ((tileQueue.Count >= maxQueueLength) && (tileQueue.Count > 0))
                            {
                                tileQueue.RemoveAt(0);
                            }
                            tileQueue.Add(tFound);

                            // Adjust the hue
                            //Bitmap bAdjusted = AdjustHue(tFound.getBitmap(), avgsMaster[x, y]);

                            // Apply found tile to section
                            for (int w = 0; w < szTile.Width; w++)
                            {
                                for (int h = 0; h < szTile.Height; h++)
                                {
                                    // bOut.SetPixel(x * szTile.Width + w, y * szTile.Height + h, bAdjusted.GetPixel(w, h));
                                }
                            }
                            // Increment the progress bar
                            // pgbUpdate.Value++;
                        }
                    }
                }
                else
                {
                    // Don't adjust hue - keep searching for a tile close enough
                    for (int x = 0; x < tX; x++)
                    {
                        for (int y = 0; y < tY; y++)
                        {
                            // Reset searching threshold
                            int threshold = 0;
                            int index = 0;
                            int searchCounter = 0;
                            Tile tFound = null;
                            while (tFound == null)
                            {
                                index = r.Next(bTiles.Count);
                                if (GetDifference(avgsMaster[x, y], bTiles[index].getColor()) < threshold)
                                {
                                    tFound = bTiles[index];
                                    Application.DoEvents();
                                }
                                else
                                {
                                    searchCounter++;
                                    if (searchCounter >= bTiles.Count)
                                    {
                                        threshold += 5;
                                    }
                                    Application.DoEvents();
                                }
                            }
                            // Apply found tile to section
                            for (int w = 0; w < szTile.Width; w++)
                            {
                                for (int h = 0; h < szTile.Height; h++)
                                {
                                    bOut.SetPixel(x * szTile.Width + w, y * szTile.Height + h, tFound.getBitmap().GetPixel(w, h));
                                    Application.DoEvents();
                                }
                            }
                            // Increment the progress bar
                            //pgbUpdate.Value++;
                        }
                    }
                }
            }

            // Close Files Phase
            foreach (Tile t in bTiles)
            {
                t.Close();
            }

            /// Notification
            //lblUpdate.Text = String.Format("Job Completed");
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
