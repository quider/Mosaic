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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Mosaic
{
    public partial class MainForm : Form
    {        
        private static ILog log = LogManager.GetLogger(typeof(MainForm));
        private BackgroundWorker calculateMosaicBackgroundWorker;
        
        public ColorCalculation mosaicColors
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
            this.Text += "-" + this.ProductVersion;
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
                    }

                    this.RunBackgroundWorkerForCalculateColorsOfMosaic(openDialog.FileName);

                    gbxTiles.Enabled = true;
                }
                catch (Exception ex)
                {
                    log.Fatal(ex.Message, ex);
                }
            }
        }

        private void RunBackgroundWorkerForCalculateColorsOfMosaic(string fileName)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                this.mosaicColors = new ColorCalculation();
                var backgroundCalculateColorsOnPicture = new BackgroundWorker();
                backgroundCalculateColorsOnPicture.WorkerReportsProgress = true;
                backgroundCalculateColorsOnPicture.DoWork += mosaicColors.CalculateColorsWork;
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
                this.pictureBox.Image = image;
                this.pictureBox.Refresh();
                this.pgbOperation.Value = 0;
                this.lblOperation.Text = strings.Finished;
                this.lblPercentage.Text = "0%";
                this.btnGo.Enabled = true;
                this.btCancelCalculate.Visible = false;
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                FolderBrowserDialog oD = new FolderBrowserDialog();
                if (oD.ShowDialog() == DialogResult.OK)
                {
                    if (Directory.Exists(oD.SelectedPath))
                    {
                        log.InfoFormat("Selected directory {0}", oD.SelectedPath);
                        DirectoryInfo di = new DirectoryInfo(oD.SelectedPath);
                        foreach (FileInfo fN in di.GetFiles())
                        {
                            if (!(lbxTiles.Items.Contains(fN.FullName)))
                            {
                                lbxTiles.Items.Add(fN.FullName);
                            }
                        }
                    }
                    else
                    {
                        log.InfoFormat(strings.DirectoryDoesNotExist);
                        MessageBox.Show(strings.DirectoryDoesNotExist);
                    }
                }

                log.DebugFormat("Count tiles {0}", this.lbxTiles.Items.Count);
                if (this.lbxTiles.Items.Count > 15)
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
            }
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
                List<String> fNS = new List<String>();
                for (int i = 0; i < lbxTiles.Items.Count; i++)
                {
                    if (!(lbxTiles.SelectedIndices.Contains(i)))
                    {
                        fNS.Add((String)lbxTiles.Items[i]);
                    }
                }
                lbxTiles.Items.Clear();
                lbxTiles.Items.AddRange(fNS.ToArray());
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
                switch (Settings.Default.TilesPlaced)
                {
                    case 0:
                        RandomMosaic(); break;
                    case 1:
                        ClassicMosaic();break;
                }
               
            }
        }

        private void RandomMosaic()
        {
            var mosaicClass = new RandomMosaicCalculation(Settings.Default.Hue);

            try
            {
                List<string> items = new List<string>();
                foreach (string item in this.lbxTiles.Items)
                {
                    items.Add(item);
                }

                Cursor = Cursors.WaitCursor;
                Size szTile = new Size(Convert.ToInt16(nudWidth.Value), Convert.ToInt16(nudHeight.Value));
                this.calculateMosaicBackgroundWorker = new BackgroundWorker();
                this.calculateMosaicBackgroundWorker.ProgressChanged += CalculateColorsProgressChanged;
                this.calculateMosaicBackgroundWorker.RunWorkerCompleted += calculateMosaicBackgroundWorker_RunWorkerCompleted;
                this.calculateMosaicBackgroundWorker.DoWork += mosaicClass.CalculateRandomMosaic;
                this.calculateMosaicBackgroundWorker.WorkerReportsProgress = true;
                this.calculateMosaicBackgroundWorker.WorkerSupportsCancellation = true;
                btCancelCalculate.Visible = true;
                this.calculateMosaicBackgroundWorker.RunWorkerAsync(new object[] { this.AverageImage, items, (int)this.nudHeight.Value, (int)this.nudWidth.Value, this.mosaicColors.avgsMaster });
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

        private void ClassicMosaic()
        {
            var mosaicClass = new ClassicMosaic.ClassicMosaicCalculation(Settings.Default.Hue);

            try
            {
                List<string> items = new List<string>();
                foreach (string item in this.lbxTiles.Items)
                {
                    items.Add(item);
                }

                Cursor = Cursors.WaitCursor;
                Size szTile = new Size(Convert.ToInt16(nudWidth.Value), Convert.ToInt16(nudHeight.Value));
                this.calculateMosaicBackgroundWorker = new BackgroundWorker();
                this.calculateMosaicBackgroundWorker.ProgressChanged += CalculateColorsProgressChanged;
                this.calculateMosaicBackgroundWorker.RunWorkerCompleted += calculateMosaicBackgroundWorker_RunWorkerCompleted;
                this.calculateMosaicBackgroundWorker.DoWork += mosaicClass.CalculateMosaic;
                this.calculateMosaicBackgroundWorker.WorkerReportsProgress = true;
                this.calculateMosaicBackgroundWorker.WorkerSupportsCancellation = true;
                btCancelCalculate.Visible = true;
                this.calculateMosaicBackgroundWorker.RunWorkerAsync(new object[] { this.AverageImage, items, (int)this.nudHeight.Value, (int)this.nudWidth.Value, this.mosaicColors.avgsMaster });
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
        public Image AverageImage
        {
            get;
            set;
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
                    sfd.Filter = "Bitmapa | *.bmp";
                    sfd.FileOk += sfd_FileOk;
                    sfd.ShowDialog();
                }
                catch (Exception)
                {

                    throw;
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
            this.pictureBox.Image.Save(sfd.FileName);
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

        
    }
}
