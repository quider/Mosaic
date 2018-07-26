using ColorsCalculation;
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

namespace MosaicApplication
{
    public delegate void TileCollectedEventHandler(string realPath, string filename, int index, int fileCount);

    public class Context : ApplicationContext
    {
        internal event TileCollectedEventHandler TileCollected;

        private static ILog log = LogManager.GetLogger(typeof(Context));

        internal ColorCalculation MosaicColors
        {
            get;
            set;
        }

        internal HashSet<string> TilesImages
        {
            get;
            set;
        }

        public Color[,] AverageColors
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
            this.TileCollected += ((MainForm)this.MainForm).TileCollected;
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
            if(TilesImages == null)
                TilesImages = new HashSet<string>();

            int index = 0;
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {               
                string tilesDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Properties.Settings.Default.TilesFolder);
                Utils.CreateEmptyDirectory(tilesDirectory);

                if (Directory.Exists(directoryOfImages))
                {
                    log.InfoFormat("Selected directory {0}", directoryOfImages);
                    DirectoryInfo di = new DirectoryInfo(directoryOfImages);
                    var directoryInfo = di.GetFiles();
                    var ofFiles = directoryInfo.Length;
                    foreach (FileInfo fN in directoryInfo)
                    {
                        bool saved = SaveTileInFolder(fN, tilesDirectory, width, height);
                        if (saved)
                        {
                            if (TileCollected != null)
                            {
                                TileCollected(fN.FullName, fN.Name, index, ofFiles);
                            }
                            index++;
                        }
                    }
                }
                else
                {
                    log.InfoFormat(strings.DirectoryDoesNotExist);
                }
                return index;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fN"></param>
        /// <param name="tilesDirectory"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private bool SaveTileInFolder(FileInfo fN, string tilesDirectory, int width, int height)
        {
            var name = fN.FullName;
            try
            {
                var sizeTile = new Size(width, height);
                var tilename = Path.Combine(tilesDirectory, Path.GetFileNameWithoutExtension(fN.Name) + Properties.Settings.Default.TilesExtList[Properties.Settings.Default.TilesExt]);
                TilesImages.Add(tilename);
                log.DebugFormat("Creating tile {0}", tilename);
                using (Stream stream = new FileStream(name, FileMode.Open, FileAccess.Read))
                {
                    Bitmap bitmapTile;
                    using (bitmapTile = (Bitmap)Bitmap.FromStream(stream))
                    {
                        using (Stream saveStream = new FileStream(tilename, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            bitmapTile = Utils.ResizeBitmap(bitmapTile, sizeTile);
                            //TODO: format to change
                            bitmapTile.Save(saveStream, ImageFormat.Bmp);
                        }
                    }
                }
                return true;
            }
            catch (ArgumentException ex)
            {
                log.ErrorFormat("{0}: {1}", name, ex.Message);
                return false;
            }
            catch (OutOfMemoryException ex)
            {
                log.ErrorFormat("Problem with image {0}", name);
                log.Error(ex.Message, ex);
                GC.WaitForPendingFinalizers();
                return false;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }
            //what when file already exists?
        }


    }
}
