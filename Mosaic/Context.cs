using ColorsCalculation;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Mosaic
{
    public class Context : ApplicationContext
    {
        internal ColorCalculation MosaicColors
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

    }
}
