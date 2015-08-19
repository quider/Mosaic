using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class Utils
    {
        private static ILog log = LogManager.GetLogger(typeof(Utils));

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
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                try
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
                catch (Exception ex)
                {
                    log.Fatal(ex.Message, ex);
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int GetDifference(Color source, Color target)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                int dR = Math.Abs(source.R - target.R);
                int dG = Math.Abs(source.G - target.G);
                int dB = Math.Abs(source.B - target.B);
                int diff = Math.Max(dR, dG);
                diff = Math.Max(diff, dB);
                return diff;
            }
        }

        /// <summary>
        /// Chnage opacity of image passed in parameter. New image is being returned.
        /// </summary>
        /// <param name="img">Image to change opacity</param>
        /// <param name="opacityvalue">Visibility 0-not visible 100-visible</param>
        /// <returns></returns>
        public static Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                try
                {
                    Bitmap bmp = new Bitmap(img.Width, img.Height); // Determining Width and Height of Source Image
                    using (Graphics graphics = Graphics.FromImage(bmp))
                    {
                        ColorMatrix colormatrix = new ColorMatrix();
                        colormatrix.Matrix33 = opacityvalue;
                        ImageAttributes imgAttribute = new ImageAttributes();
                        imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
                        graphics.Dispose();
                        colormatrix = null;
                    }
                    return bmp;
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                    return null;
                } 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bSource"></param>
        /// <param name="targetColor"></param>
        /// <returns></returns>
        public static Bitmap AdjustHue(Bitmap bSource, Color targetColor)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
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
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bSource"></param>
        /// <param name="newSize"></param>
        /// <returns></returns>
        public static Bitmap ResizeBitmap(Bitmap bSource, Size newSize)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                Bitmap result = new Bitmap(newSize.Width, newSize.Height);
                using (Graphics g = Graphics.FromImage(result))
                {
                    g.DrawImage(bSource, 0, 0, newSize.Width, newSize.Height);
                }
                return result;
            }
        }


    }
}
