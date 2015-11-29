using ColorsCalculation;
using i18n;
using LibSettings.Properties;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Utilities;

namespace Mosaic
{
    public class Context : ApplicationContext
    {
        private static ILog log = LogManager.GetLogger(typeof(Context));

        internal ColorCalculation MosaicColors
        {
            get;
            set;
        }

        internal List<string> TilesImages
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
            ((MainForm)this.MainForm).Ctx = this;
            return this.MainForm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>number of collected images</returns>
        internal int CollectImages(string directoryOfImages, int width, int height)
        {
            TilesImages = new List<string>();
            int index = 0;
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                string tilesDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Settings.Default.TilesFolder);
                Utils.CreateEmptyDirectory(tilesDirectory);

                if (Directory.Exists(directoryOfImages))
                {
                    log.InfoFormat("Selected directory {0}", directoryOfImages);
                    DirectoryInfo di = new DirectoryInfo(directoryOfImages);
                    foreach (FileInfo fN in di.GetFiles())
                    {
                        var name = fN.FullName;
                        try
                        {
                            var sizeTile = new Size(width, height);
                            var tilename = Path.Combine(tilesDirectory, name + Settings.Default.TilesExtList[Settings.Default.TilesExt]);
                            TilesImages.Add(tilename);
                            log.DebugFormat("Creating tile {0}", tilename);
                            using (Stream stream = new FileStream(name, FileMode.Open,FileAccess.ReadWrite))
                            {
                                Bitmap bitmapTile;
                                using (bitmapTile = (Bitmap)Bitmap.FromStream(stream))
                                {
                                    using (Stream saveStream = new FileStream(tilename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                    {
                                        bitmapTile = Utils.ResizeBitmap(bitmapTile, sizeTile);
                                        //TODO: format to change
                                        bitmapTile.Save(saveStream,ImageFormat.Bmp);
                                    }
                                    //log.DebugFormat("Tile saved");
                                    //tilesColors.Add(tilename, Utils.GetTileAverage(bitmapTile, 0, 0, sizeTile.Width, sizeTile.Height));
                                    //log.DebugFormat("Color added to collection {0}", tilesColors[tilename]);
                                    // worker.ReportProgress((int)((index / maximum) * 100), String.Format(strings.LoadingAndResizingTiles));
                                }
                                index++;
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            log.ErrorFormat("{0}: {1}", name, ex.Message);
                        }
                        catch (OutOfMemoryException ex)
                        {
                            log.ErrorFormat("Problem with image {0}", name);
                            log.Error(ex.Message, ex);
                            GC.WaitForPendingFinalizers();
                        }
                        catch (Exception ex)
                        {
                            log.Error(ex.Message, ex);
                        }
                        //what when file already exists?
                    }
                }
                else
                {
                    log.InfoFormat(strings.DirectoryDoesNotExist);
                }
                return index;

            }
        }

    }
}
