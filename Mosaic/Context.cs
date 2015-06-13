using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mosaic
{
    public class Context : ApplicationContext
    {
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
            return this.MainForm;
        }
    }
}
