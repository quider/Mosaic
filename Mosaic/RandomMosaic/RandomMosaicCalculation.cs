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

namespace RandomMosaic
{
    public class RandomMosaicCalculation : Mosaic
    {
        private static ILog log = LogManager.GetLogger(typeof(RandomMosaicCalculation));
        private bool useHue;

        public int Height
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public RandomMosaicCalculation(bool applyHue, int width, int height)
        {
            this.useHue = applyHue;
            this.Width = width;
            this.Height = height;
        }

        public override Image CalculateMosaic(Image averageImage, Color[,] colorMatrix, List<string> tilesNames)
        {
            var copyOfOryginalImage = (Image)averageImage.Clone();
            var sizeTile = new Size(this.Width, this.Height);
            int tX = averageImage.Width / sizeTile.Width;
            int tY = averageImage.Height / sizeTile.Height;
            string[,] usedTiles = new string[tX, tY];

            double maximum = tilesNames.Count;
 
            log.DebugFormat("Image divided onto {0}x{1}", tX, tY);
            var searchCounter = 1;
            List<string>[,] matchedColors = new List<string>[tX, tY];
            Random random = new Random();
            //Parallel.For(0, tX, x =>
            for (int x =0 ; x< tX; x++)
            {
                //Parallel.For(0, tY, (y) =>
                for(int y = 0; y< tY; y++)
                {
                    Bitmap found = null;
                    maximum = tX * tY + 1;
                    var percentage = (int)((searchCounter / maximum) * 100);
                    //worker.ReportProgress(percentage, strings.CalculateMosaic);
                    var i = random.Next(tilesNames.Count - 1);
                    log.DebugFormat("Used image: {0}, index: {1}", searchCounter, i);
                    string name = Path.Combine(tilesNames[i]);
                    log.DebugFormat("Tile name {0}", name);
                    try
                    {
                        found = new Bitmap(name);
                        OnTileFit(this, new MosaicEventArgs()
                        {
                            TileAverage = colorMatrix[x, y],
                            TilePath = name,
                            X = tX,
                            Y = tY,
                            CurrentX = x,
                            CurrentY = y,
                            Percentage = percentage,
                            MaximumTiles = maximum
                        });

                        log.DebugFormat("Created bitmap from image {0}", name);

                        TextureBrush tBrush = new TextureBrush(Utils.AdjustHue(found, colorMatrix[x, y]));

                        Pen blackPen = new Pen(Color.Black);

                        using (var g = Graphics.FromImage(averageImage))
                        {
                            g.FillRectangle(tBrush, new Rectangle(x * this.Width, y * this.Height,this.Width, this.Height));
                            OnTilePlaced(this, new MosaicEventArgs()
                            {
                                TileAverage = colorMatrix[x,y],
                                TilePath = name,
                                X = tX,
                                Y = tY,
                                CurrentX = x,
                                CurrentY = y,
                                Percentage = percentage,
                                MaximumTiles = maximum
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        log.ErrorFormat("Name of tile during error {0}", name);
                        log.Error(ex.Message, ex);
                        OnTileSkipped(this,  new MosaicEventArgs()
                            {
                                TileAverage = colorMatrix[x,y],
                                TilePath = name,
                                X = tX,
                                Y = tY,
                                CurrentX = x,
                                CurrentY = y,
                                Percentage = percentage,
                                MaximumTiles = maximum
                            });
                    }
                    i++;
                    searchCounter++;
                }//);
            }//);
            OnCalculated(this, new MosaicEventArgs());
            log.DebugFormat("Finishig calculate of mosaic");
            return averageImage;
        }
    }
}
