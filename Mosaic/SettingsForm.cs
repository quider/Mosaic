using i18n;
using Mosaic.Properties;
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
            this.rbtRandomTiles.Text = strings.RandomPlacedTiles;
            this.rdbtFindColors.Text = strings.ColorPlacedTiles;
            this.cbxHueSetting.Text = strings.AddHue;
            this.lblTilesInGroup.Text = strings.TilesInGroup;
            this.lblBuffer.Text = strings.Buffer;
            this.lblPercentage.Text = strings.Ratio;
            this.lblRatioExplanation.Text = strings.RatioExplanation;
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

        private void btMosaicSettingsOK_Click(object sender, EventArgs e)
        {
            Settings.Default.Ratio = double.Parse(tbRatio.Text);
            Settings.Default.Treshold = (int)nudTreshold.Value;
            if (rdbtFindColors.Checked)
            {
                Settings.Default.TilesPlaced = 1;
            }
            else if (rbtRandomTiles.Checked)
            {
                Settings.Default.TilesPlaced = 0;
            }
            Settings.Default.TilesInGroup = (int)nudTilesInGroup.Value;
            Settings.Default.Hue = cbxHueSetting.Checked;
            Settings.Default.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
