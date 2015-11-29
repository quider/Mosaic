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
            LibSettings.Properties.Settings.Default.Ratio = double.Parse(tbRatio.Text);
            LibSettings.Properties.Settings.Default.Treshold = (int)nudTreshold.Value;
            if (rdbtFindColors.Checked)
            {
                LibSettings.Properties.Settings.Default.TilesPlaced = 1;
            }
            else if (rbtRandomTiles.Checked)
            {
                LibSettings.Properties.Settings.Default.TilesPlaced = 0;
            }
            LibSettings.Properties.Settings.Default.TilesInGroup = (int)nudTilesInGroup.Value;
            LibSettings.Properties.Settings.Default.Hue = cbxHueSetting.Checked;
            LibSettings.Properties.Settings.Default.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
