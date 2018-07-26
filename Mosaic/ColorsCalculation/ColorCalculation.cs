using API;
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

namespace ColorsCalculation {
    public class ColorCalculation : ACalculateColors {
        private static ILog log = LogManager.GetLogger(typeof(ColorCalculation));
        private int height;
        private int width;

        public Color[,] averageColorsOfMasterImage {
            get;
            set;
        }

        public ColorCalculation(int w, int h) {
            this.width = w;
            this.height = h;
        }

        public override Image CalculateColors(string fileName, out Color[,] colorsArray) {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name)) {
                var image = Image.FromFile(fileName);
                var height = this.height;
                var width = this.width;
                log.InfoFormat("Images size of {0}x{1}", width, height);
                var tileSize = new Size((int)width, (int)height);
                Boolean bitmapLoaded = false;
                Bitmap masterBitMap = null;

                log.Info("Averaging colors");

                while (!bitmapLoaded) {
                    try {
                        masterBitMap = new Bitmap((Image)image.Clone());
                        log.InfoFormat("Main image set");
                        bitmapLoaded = true;
                    } catch (OutOfMemoryException ex) {
                        log.Error(ex.Message, ex);
                        GC.WaitForPendingFinalizers();
                    }
                }

                int tX = masterBitMap.Width / tileSize.Width;
                int tY = masterBitMap.Height / tileSize.Height;
                averageColorsOfMasterImage = new Color[tX, tY];


                var maximum = tX * tY;

                try {
                    lock (image) {
                        for (int x = 0; x < tX; x++) {
                            for (int y = 0; y < tY; y++) {
                                averageColorsOfMasterImage[x, y] = Utils.GetTileAverage(masterBitMap, x * tileSize.Width, y * tileSize.Height, tileSize.Width, tileSize.Height);
                                Rectangle r = new Rectangle(tileSize.Width * x, tileSize.Height * y, tileSize.Width, tileSize.Height);

                                using (Graphics g = Graphics.FromImage(image)) {
                                    g.FillRectangle(new SolidBrush(averageColorsOfMasterImage[x, y]), r);
                                    OnColorCalculated(averageColorsOfMasterImage[x, y], x, y, tX, tY);
                                }
                            };
                        };
                    }
                } catch (Exception ex) {
                    log.FatalFormat("Fatal error during putting images into big image");
                    log.Fatal(ex.Message, ex);
                }
                colorsArray = averageColorsOfMasterImage;
                return image;
            }
        }
    }
}
