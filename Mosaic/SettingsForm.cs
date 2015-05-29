using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mosaic
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudHeight_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbtSepia_MouseEnter(object sender, EventArgs e)
        {
            lblSepia.Visible = true;
        }

        private void rbtSepia_MouseLeave(object sender, EventArgs e)
        {
            lblSepia.Visible = false;
        }
    }
}
