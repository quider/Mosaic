using log4net;
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
        private MosaicClass mosaicClass;
        private static ILog log = LogManager.GetLogger(typeof(MainForm));

        public MainForm()
        {
            this.MaximizeBox = false;
            log.Debug("initializing components");
            InitializeComponent();
            log.InfoFormat("Setting up {0}",strings.MasterImage);
            this.gbxMaster.Text = strings.MasterImage;
            log.InfoFormat("Setting up {0}",strings.Browse);
            this.btnBrowse.Text = strings.Browse;
            log.InfoFormat("Setting up {0}",strings.Add);
            this.btnAdd.Text = strings.Add;
            log.InfoFormat("Setting up {0}",strings.Remove);
            this.btnRemove.Text = strings.Remove;
            log.InfoFormat("Setting up {0}",strings.Go);
            this.btnGo.Text = strings.Go;
            log.InfoFormat("Setting up {0}",strings.AddTilesFirst);
            this.lblAddFirst.Text = strings.AddTilesFirst;
            log.InfoFormat("Setting up {0}",strings.AdjustHue);
            this.cbxAdjustTiles.Text = strings.AdjustHue;
            log.InfoFormat("Setting up {0}",strings.Height);
            this.lblHeight.Text = strings.Height;
            log.InfoFormat("Setting up {0}",strings.Width);
            this.lblWidth.Text = strings.Width;
            log.InfoFormat("Setting up {0}",strings.Tiles);
            this.gbxTiles.Text = strings.Tiles;
            log.InfoFormat("Setting up {0}",strings.Mosaic);
            this.gbxMosaic.Text = strings.Mosaic;

            this.fileToolStripMenuItem.Text = strings.FileMenu;
            this.newToolStripMenuItem.Text = strings.New;
            this.saveAsToolStripMenuItem.Text = strings.SaveAs;
            this.saveToolStripMenuItem.Text = strings.Save;
            this.printPreviewToolStripMenuItem.Text = strings.PrintPreview;
            this.printToolStripMenuItem.Text = strings.Print;
            this.helpToolStripMenuItem.Text = strings.HelpMenu;
            this.toolsToolStripMenuItem.Text = strings.ToolsMenu;
            this.contentsToolStripMenuItem.Text = strings.Contents;
            this.aboutToolStripMenuItem.Text = strings.Aboutbox;
            this.optionsToolStripMenuItem.Text = strings.Options;
            this.customizeToolStripMenuItem.Text = strings.Customize;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (NDC.Push(MethodBase.GetCurrentMethod().Name))
            {
                try
                {
                    OpenFileDialog oD = new OpenFileDialog();
                    oD.Multiselect = false;
                    this.mosaicClass = new MosaicClass();
                    var backgroundCalculateColorsOnPicture = new BackgroundWorker();
                    backgroundCalculateColorsOnPicture.WorkerReportsProgress = true;
                    backgroundCalculateColorsOnPicture.DoWork += this.mosaicClass.CalculateColorsWork;
                    backgroundCalculateColorsOnPicture.ProgressChanged += this.CalculateColorsProgressChanged;
                    backgroundCalculateColorsOnPicture.RunWorkerCompleted += this.CalculateColorsCompleted;

                    if (oD.ShowDialog() == DialogResult.OK)
                    {
                        tbxBrowse.Text = oD.FileName;
                        this.pictureBox.Image = Image.FromFile(oD.FileName);
                    }

                    backgroundCalculateColorsOnPicture.RunWorkerAsync(new object[] { Image.FromFile(oD.FileName), this.nudHeight.Value, nudWidth.Value });
                    
                    gbxTiles.Enabled = true;
                }
                catch (Exception ex)
                {
                    log.Fatal(ex.Message, ex);
                }
            }
        }

        private void CalculateColorsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Set all to 0;
            pgbOperation.Value = 0;
            lblOperation.Text = strings.ColorsCalculated;
            this.AverageImage = e.Result as Image;
            this.pictureBox.Image = this.AverageImage;
            this.pictureBox.Refresh();
        }

        void calculateMosaicBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var image = e.Result as Image;
            this.pictureBox.Image = image;
            this.pictureBox.Refresh();
            this.pgbOperation.Value = 0;
            this.lblOperation.Text = strings.Finished;
        }

        private void CalculateColorsProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progres = e.ProgressPercentage;
            var v = e.UserState as String;
            this.pgbOperation.Value = progres;
            this.lblOperation.Text = v;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog oD = new FolderBrowserDialog();
            if (oD.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(oD.SelectedPath))
                {
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

        private void btnRemove_Click(object sender, EventArgs e)
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> items = new List<string>();
                foreach(string item in this.lbxTiles.Items){
                    items.Add(item);
                }
                Cursor = Cursors.WaitCursor;
                Size szTile = new Size(Convert.ToInt16(nudWidth.Value), Convert.ToInt16(nudHeight.Value));
                var calculateMosaicBackgroundWorker = new BackgroundWorker();
                calculateMosaicBackgroundWorker.ProgressChanged += CalculateColorsProgressChanged;
                calculateMosaicBackgroundWorker.RunWorkerCompleted += calculateMosaicBackgroundWorker_RunWorkerCompleted;
                calculateMosaicBackgroundWorker.DoWork += this.mosaicClass.CalculateMosaic;

                calculateMosaicBackgroundWorker.WorkerReportsProgress = true;

                calculateMosaicBackgroundWorker.RunWorkerAsync(new object[] { this.AverageImage, items, (int)this.nudHeight.Value, (int)this.nudWidth.Value});


                //LockBitmap test = MosaicClass.GenerateMosaic(tbxBrowse.Text, lbxTiles.Items.Cast<String>().ToArray(), szTile, lblOperation, pgbOperation, cbxAdjustTiles.Checked, tbxCache.Text, this.pictureBox);
                //test.Save("test.bmp");
                //pictureBox.Image = test.source;
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            lblAddFirst.Visible = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        public Image AverageImage
        {
            get;
            set;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileOk += sfd_FileOk;
            sfd.ShowDialog();
        }

        void sfd_FileOk(object sender, CancelEventArgs e)
        {
            var sfd = sender as SaveFileDialog;
            this.pictureBox.Image.Save(sfd.FileName);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ContentForm();
            form.ShowDialog();
        }
    }
}
