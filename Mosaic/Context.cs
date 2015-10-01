using log4net;
using Mosaic.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Mosaic
{
    public class Context : ApplicationContext
    {

        private ILog log = LogManager.GetLogger(typeof(Context));

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
            this.MainForm = new MainForm(this);
            return this.MainForm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picturePath"></param>
        /// <returns></returns>
        public Image LoadPicture(string picturePath)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                try
                {
                    log.DebugFormat("Try to load image from {0} ", picturePath);
                    Image returnImage = Image.FromFile(picturePath);
                    return returnImage;
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
        /// <param name="image"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool CalculateHeightAndWidthImage(Image image, out decimal height, out decimal width)
        {
            height = 0;
            width = 0;
            try
            {
                var w = image.Width;
                var h = image.Height;
                height = new Decimal(h * (Settings.Default.Ratio / 100));
                width = new Decimal(w * (Settings.Default.Ratio / 100));
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }
        }
    }
}
