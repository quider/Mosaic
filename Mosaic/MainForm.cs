using ColorsCalculation;
using i18n;
using log4net;
using Mosaic.Properties;
using RandomMosaic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class MainForm : Form
    {
        private static ILog log = LogManager.GetLogger(typeof(MainForm));
        private BackgroundWorker calculateMosaicBackgroundWorker;
        private Image orginalImage;

        /// <summary>
        /// 
        /// </summary>
        public Context Ctx
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Image AverageImage
        {
            get;
            set;
        }

        public MainForm()
        {
            this.MaximizeBox = false;
            log.Debug("initializing components");
            InitializeComponent();
            this.gbxMaster.Text = strings.MasterImage;
            this.btnBrowse.Text = strings.Browse;
            this.btnAdd.Text = strings.Add;
            this.btnRemove.Text = strings.Remove;
            this.btnGo.Text = strings.Go;
            this.btnGo.Image = LibResources.Properties.Resources.send.GetThumbnailImage(16, 16, Abort, IntPtr.Zero);
            this.lblAddFirst.Text = strings.AddTilesFirst;
            this.cbxAdjustTiles.Text = strings.AdjustHue;
            this.lblHeight.Text = strings.Height;
            this.lblWidth.Text = strings.Width;
            this.gbxTiles.Text = strings.Tiles;
            this.gbxMosaic.Text = strings.Mosaic;
            this.fileToolStripMenuItem.Text = strings.FileMenu;
            this.newToolStripMenuItem.Text = strings.New;
            this.saveAsToolStripMenuItem.Text = strings.SaveAs;
            this.saveToolStripMenuItem.Text = strings.Save;
            this.printPreviewToolStripMenuItem.ToolTipText = strings.WillBeInFuture;
            this.printPreviewToolStripMenuItem.Text = strings.PrintPreview;
            this.printToolStripMenuItem.ToolTipText = strings.WillBeInFuture;
            this.printToolStripMenuItem.Text = strings.Print;
            this.helpToolStripMenuItem.Text = strings.HelpMenu;
            this.toolsToolStripMenuItem.Text = strings.ToolsMenu;
            this.contentsToolStripMenuItem.Text = strings.Contents;
            this.aboutToolStripMenuItem.Text = strings.Aboutbox;
            this.optionsToolStripMenuItem.Text = strings.Options;
            this.optionsToolStripMenuItem.ToolTipText = strings.WillBeInFuture;
            this.customizeToolStripMenuItem.Text = strings.Customize;
            this.customizeToolStripMenuItem.ToolTipText = strings.WillBeInFuture;
            this.checkUpdatesToolStripMenuItem.Text = strings.Update;
            this.btCancelCalculate.Text = strings.Cancel;
            this.btRescale.Text = strings.Rescale;
            this.cbOpacity.Text = strings.Opacity;
            this.Text += "-" + this.ProductVersion;
            this.lblSetContrast.Text = strings.Contrast;
        }

        private bool Abort()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                try
                {
                    this.pictureBox.Image = null;
                    this.pictureBox.Refresh();
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Multiselect = false;

                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        tbxBrowse.Text = openDialog.FileName;
                        this.pictureBox.Image = Image.FromFile(openDialog.FileName);
                        var w = this.pictureBox.Image.Width;
                        var h = this.pictureBox.Image.Height;
                        this.nudHeight.Value = new Decimal(h * (LibSettings.Properties.Settings.Default.Ratio / 100));
                        this.nudWidth.Value = new Decimal(w * (LibSettings.Properties.Settings.Default.Ratio / 100));
                    }

                    //this.RunBackgroundWorkerForCalculateColorsOfMosaic(openDialog.FileName);

                    gbxTiles.Enabled = true;
                }
                catch (Exception ex)
                {
                    log.Fatal(ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private void RunBackgroundWorkerForCalculateColorsOfMosaic(string fileName)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                this.Ctx.MosaicColors = new ColorCalculation();
                var backgroundCalculateColorsOnPicture = new BackgroundWorker();
                backgroundCalculateColorsOnPicture.WorkerReportsProgress = true;
                backgroundCalculateColorsOnPicture.DoWork += Ctx.MosaicColors.CalculateColorsWork;
                backgroundCalculateColorsOnPicture.ProgressChanged += this.CalculateColorsProgressChanged;
                backgroundCalculateColorsOnPicture.RunWorkerCompleted += this.CalculateColorsCompleted;
                backgroundCalculateColorsOnPicture.RunWorkerAsync(new object[] { Image.FromFile(fileName), this.nudHeight.Value, nudWidth.Value });
            }
        }

        /// <summary>
        /// Set values to 0 for all settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>      
        private void CalculateColorsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                //Set all to 0;
                pgbOperation.Value = 0;
                this.lblPercentage.Text = "0%";
                lblOperation.Text = strings.ColorsCalculated;
                this.AverageImage = e.Result as Image;
                this.orginalImage = e.Result as Image;
                this.pictureBox.Image = this.AverageImage;
                this.pictureBox.Refresh();
                this.btnGo.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void calculateMosaicBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                var image = e.Result as Image;
                this.orginalImage = e.Result as Image;
                this.pictureBox.Image = image;
                this.pictureBox.Refresh();
                this.pgbOperation.Value = 0;
                this.lblOperation.Text = strings.Finished;
                this.lblPercentage.Text = "0%";
                this.btnGo.Enabled = true;
                this.btCancelCalculate.Visible = false;

                if (this.cbOpacity.Checked)
                {
                    this.trackBar_ValueChanged(this.trackBar, new EventArgs());
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                this.lblOperation.Text = "Ładuję obrazki";
                int count = 0;
                FolderBrowserDialog browserDialog = new FolderBrowserDialog();
                if (browserDialog.ShowDialog() == DialogResult.OK)
                {
                    count = Ctx.CollectImages(browserDialog.SelectedPath, (int)nudWidth.Value, (int)nudHeight.Value);
                }
                else
                {                    
                    MessageBox.Show(strings.DirectoryDoesNotExist);
                }

                log.DebugFormat("Count tiles {0}", count);
                if (count > 15)
                {
                    btnGo.Enabled = true;
                    lblAddFirst.Visible = false;
                }
                else
                {
                    btnGo.Enabled = false;
                    lblAddFirst.Visible = true;
                    lblAddFirst.Text = strings.AddAtLeast15Tiles;
                }
                this.lblOperation.Text = "Obrazki załadowane";
                this.lblPercentage.Text = "0%";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="realPath"></param>
        /// <param name="filename"></param>
        internal void TileCollected(string realPath, string filename, int index, int fileCount)
        {
            string fileName = Path.GetFileNameWithoutExtension(filename);
            ListViewItem item = new ListViewItem(fileName);
            item.SubItems.Add(realPath);
            item.Tag = filename;

            listView.Items.Add(item);
            this.pgbOperation.Value = (int)(100 * (float)index / (float)fileCount);
            this.lblPercentage.Text = ((float)index / (float)fileCount).ToString("P1");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                //List<String> fNS = new List<String>();
                //for (int i = 0; i < lbxTiles.Items.Count; i++)
                //{
                //    if (!(lbxTiles.SelectedIndices.Contains(i)))
                //    {
                //        fNS.Add((String)lbxTiles.Items[i]);
                //    }
                //}
                //lbxTiles.Items.Clear();
                //lbxTiles.Items.AddRange(fNS.ToArray());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                var settingsForm = new SettingsForm();
                var result = settingsForm.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show(strings.TerminatedByUser, strings.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    log.InfoFormat("Procedure terminated by user");
                    return;
                }
                switch (LibSettings.Properties.Settings.Default.TilesPlaced)
                {
                    case 0:
                        RandomMosaic();
                        break;
                    case 1:
                        ClassicMosaic();
                        break;
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RandomMosaic()
        {
            var mosaicClass = new RandomMosaicCalculation(LibSettings.Properties.Settings.Default.Hue);

            try
            {
                List<string> items = new List<string>();
                //foreach (string item in this.lbxTiles.Items)
                //{
                //    items.Add(item);
                //}

                Cursor = Cursors.WaitCursor;
                Size szTile = new Size(Convert.ToInt16(nudWidth.Value), Convert.ToInt16(nudHeight.Value));
                this.calculateMosaicBackgroundWorker = new BackgroundWorker();
                this.calculateMosaicBackgroundWorker.ProgressChanged += CalculateColorsProgressChanged;
                this.calculateMosaicBackgroundWorker.RunWorkerCompleted += calculateMosaicBackgroundWorker_RunWorkerCompleted;
                this.calculateMosaicBackgroundWorker.DoWork += mosaicClass.CalculateRandomMosaic;
                this.calculateMosaicBackgroundWorker.WorkerReportsProgress = true;
                this.calculateMosaicBackgroundWorker.WorkerSupportsCancellation = true;
                btCancelCalculate.Visible = true;
                this.calculateMosaicBackgroundWorker.RunWorkerAsync(new object[] { this.AverageImage, items, (int)this.nudHeight.Value, (int)this.nudWidth.Value, this.Ctx.MosaicColors.avgsMaster });
                btnGo.Enabled = false;
            }
            catch (Exception x)
            {
                log.Fatal(x.Message, x);
                MessageBox.Show(this, x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateColorsProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                var progres = e.ProgressPercentage;
                var v = e.UserState as String;
                this.pgbOperation.Value = progres;
                this.lblPercentage.Text = string.Format("{0}%", progres);
                this.lblOperation.Text = v;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClassicMosaic()
        {
            var mosaicClass = new ClassicMosaic.ClassicMosaicCalculation(LibSettings.Properties.Settings.Default.Hue, LibSettings.Properties.Settings.Default.Treshold, LibSettings.Properties.Settings.Default.TilesInGroup);

            try
            {
                List<string> items = new List<string>();
                //foreach (string item in this.lbxTiles.Items)
                //{
                //    items.Add(item);
                //}

                Cursor = Cursors.WaitCursor;
                Size szTile = new Size(Convert.ToInt16(nudWidth.Value), Convert.ToInt16(nudHeight.Value));
                this.calculateMosaicBackgroundWorker = new BackgroundWorker();
                this.calculateMosaicBackgroundWorker.ProgressChanged += CalculateColorsProgressChanged;
                this.calculateMosaicBackgroundWorker.RunWorkerCompleted += calculateMosaicBackgroundWorker_RunWorkerCompleted;
                this.calculateMosaicBackgroundWorker.DoWork += mosaicClass.CalculateMosaic;
                this.calculateMosaicBackgroundWorker.WorkerReportsProgress = true;
                this.calculateMosaicBackgroundWorker.WorkerSupportsCancellation = true;
                btCancelCalculate.Visible = true;
                this.calculateMosaicBackgroundWorker.RunWorkerAsync(new object[] { this.AverageImage, items, (int)this.nudHeight.Value, (int)this.nudWidth.Value, this.Ctx.MosaicColors.avgsMaster });
                btnGo.Enabled = false;
            }
            catch (Exception x)
            {
                log.Fatal(x.Message, x);
                MessageBox.Show(this, x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            lblAddFirst.Visible = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                try
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    StringBuilder sb = new StringBuilder();
                    sb.Append(strings.Bitmap);
                    sb.Append("|*.bmp|");
                    sb.Append(strings.PNGPicture);
                    sb.Append("|*.png|");
                    sb.Append(strings.GIFPicture);
                    sb.Append("|*.gif");

                    sfd.Filter = sb.ToString();
                    sfd.FileOk += sfd_FileOk;
                    sfd.ShowDialog();
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                    MessageBox.Show(ex.Message, strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void sfd_FileOk(object sender, CancelEventArgs e)
        {
            var sfd = sender as SaveFileDialog;
            var extension = Path.GetExtension(sfd.FileName).ToUpper();
            ImageFormat imageFormat = ImageFormat.Bmp;
            switch (extension)
            {
                case ".BMP":
                    imageFormat = ImageFormat.Bmp;
                    break;
                case ".PNG":
                    imageFormat = ImageFormat.Png;
                    break;
                case ".GIF":
                    imageFormat = ImageFormat.Gif;
                    break;
            }
            this.pictureBox.Image.Save(sfd.FileName, imageFormat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ContentForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm();
            form.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancelCalculate_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                this.calculateMosaicBackgroundWorker.CancelAsync();
                btnGo.Enabled = true;
            }
        }

        /// <summary>
        /// When text changed and lenght of text is longer than nothing
        /// btrescale shohuld be ebabled or disabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxBrowse_TextChanged(object sender, EventArgs e)
        {
            if (tbxBrowse.Text.Length > 0)
            {
                btRescale.Enabled = true;
            }
            else
            {
                btRescale.Enabled = false;
            }
        }

        /// <summary>
        /// Action for clicking button rescale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btRescale_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                RunBackgroundWorkerForCalculateColorsOfMosaic(this.tbxBrowse.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {

                try
                {
                    this.lblOpacity.Text = trackBar.Value.ToString();
                    this.pictureBox.Image = null;
                    this.pictureBox.Refresh();
                    if (this.orginalImage != null)
                    {
                        //using (
                        var image = new Bitmap(this.orginalImage);//)
                        //  {
                        var tmpImage = Image.FromFile(this.tbxBrowse.Text);
                        TextureBrush tBrush = new TextureBrush(Utils.ChangeOpacity(tmpImage, (float)((float)this.trackBar.Value / 100f)));

                        Pen blackPen = new Pen(Color.Black);

                        using (var g = Graphics.FromImage(image))
                        {
                            g.FillRectangle(tBrush, new Rectangle(0, 0, image.Width, image.Height));
                        }
                        this.pictureBox.Image = image;
                        this.pictureBox.Refresh();
                        //   }
                    }
                }
                catch (OutOfMemoryException ex)
                {
                    log.Error("Out of memory!", ex);

                }
                catch (Exception ex)
                {
                    log.ErrorFormat("Generic error {0}", ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbOpacity_CheckedChanged(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                try
                {
                    log.DebugFormat("Changing opacity of image. Checkbox opacity is {0}", this.cbOpacity.Checked);
                    this.trackBar.Enabled = this.cbOpacity.Checked;

                    if (this.cbOpacity.Checked)
                    {
                        log.DebugFormat("Opacity Trackbar value: {0}", this.trackBar.Value);
                        this.trackBar.Value = 25;
                        log.DebugFormat("Value changed delegate fired");
                        this.trackBar_ValueChanged(this.trackBar, new EventArgs());
                    }
                    else
                    {
                        log.DebugFormat("Changing opacity is disabled");
                        this.trackBar.Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(strings.WillBeInFuture, strings.Warning, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudContrast_ValueChanged(object sender, EventArgs e)
        {
            var contrastedimage = Utilities.Utils.SetContrast(new Bitmap(this.tbxBrowse.Text), (double)nudContrast.Value);
            //Ctx.RunBackgroundWorkerForCalculateColorsOfMosaic()
        }

    }
}
