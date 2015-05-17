namespace Mosaic
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbxTiles = new System.Windows.Forms.ListBox();
            this.gbxTiles = new System.Windows.Forms.GroupBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.lblOperation = new System.Windows.Forms.Label();
            this.pgbOperation = new System.Windows.Forms.ProgressBar();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbxMaster = new System.Windows.Forms.GroupBox();
            this.cbxAdjustTiles = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbxBrowse = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.gbxMosaic = new System.Windows.Forms.GroupBox();
            this.lblAddFirst = new System.Windows.Forms.Label();
            this.gbxTiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.gbxMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.gbxMosaic.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxTiles
            // 
            resources.ApplyResources(this.lbxTiles, "lbxTiles");
            this.lbxTiles.FormattingEnabled = true;
            this.lbxTiles.Name = "lbxTiles";
            this.lbxTiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // gbxTiles
            // 
            resources.ApplyResources(this.gbxTiles, "gbxTiles");
            this.gbxTiles.Controls.Add(this.lblHeight);
            this.gbxTiles.Controls.Add(this.lblWidth);
            this.gbxTiles.Controls.Add(this.nudHeight);
            this.gbxTiles.Controls.Add(this.nudWidth);
            this.gbxTiles.Controls.Add(this.lblOperation);
            this.gbxTiles.Controls.Add(this.pgbOperation);
            this.gbxTiles.Controls.Add(this.btnRemove);
            this.gbxTiles.Controls.Add(this.btnAdd);
            this.gbxTiles.Controls.Add(this.lbxTiles);
            this.gbxTiles.Name = "gbxTiles";
            this.gbxTiles.TabStop = false;
            // 
            // lblHeight
            // 
            resources.ApplyResources(this.lblHeight, "lblHeight");
            this.lblHeight.Name = "lblHeight";
            // 
            // lblWidth
            // 
            resources.ApplyResources(this.lblWidth, "lblWidth");
            this.lblWidth.Name = "lblWidth";
            // 
            // nudHeight
            // 
            resources.ApplyResources(this.nudHeight, "nudHeight");
            this.nudHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Value = new decimal(new int[] {
            26,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            resources.ApplyResources(this.nudWidth, "nudWidth");
            this.nudWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Value = new decimal(new int[] {
            26,
            0,
            0,
            0});
            // 
            // lblOperation
            // 
            resources.ApplyResources(this.lblOperation, "lblOperation");
            this.lblOperation.Name = "lblOperation";
            // 
            // pgbOperation
            // 
            resources.ApplyResources(this.pgbOperation, "pgbOperation");
            this.pgbOperation.Name = "pgbOperation";
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbxMaster
            // 
            resources.ApplyResources(this.gbxMaster, "gbxMaster");
            this.gbxMaster.Controls.Add(this.cbxAdjustTiles);
            this.gbxMaster.Controls.Add(this.btnBrowse);
            this.gbxMaster.Controls.Add(this.tbxBrowse);
            this.gbxMaster.Name = "gbxMaster";
            this.gbxMaster.TabStop = false;
            // 
            // cbxAdjustTiles
            // 
            resources.ApplyResources(this.cbxAdjustTiles, "cbxAdjustTiles");
            this.cbxAdjustTiles.Name = "cbxAdjustTiles";
            this.cbxAdjustTiles.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbxBrowse
            // 
            resources.ApplyResources(this.tbxBrowse, "tbxBrowse");
            this.tbxBrowse.Name = "tbxBrowse";
            // 
            // btnGo
            // 
            resources.ApplyResources(this.btnGo, "btnGo");
            this.btnGo.Name = "btnGo";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // gbxMosaic
            // 
            this.gbxMosaic.Controls.Add(this.lblAddFirst);
            this.gbxMosaic.Controls.Add(this.pictureBox);
            this.gbxMosaic.Controls.Add(this.btnGo);
            resources.ApplyResources(this.gbxMosaic, "gbxMosaic");
            this.gbxMosaic.Name = "gbxMosaic";
            this.gbxMosaic.TabStop = false;
            // 
            // lblAddFirst
            // 
            resources.ApplyResources(this.lblAddFirst, "lblAddFirst");
            this.lblAddFirst.Name = "lblAddFirst";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxMosaic);
            this.Controls.Add(this.gbxMaster);
            this.Controls.Add(this.gbxTiles);
            this.Name = "MainForm";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.gbxTiles.ResumeLayout(false);
            this.gbxTiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.gbxMaster.ResumeLayout(false);
            this.gbxMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.gbxMosaic.ResumeLayout(false);
            this.gbxMosaic.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxTiles;
        private System.Windows.Forms.GroupBox gbxTiles;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbxMaster;
        private System.Windows.Forms.TextBox tbxBrowse;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ProgressBar pgbOperation;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.CheckBox cbxAdjustTiles;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox gbxMosaic;
        private System.Windows.Forms.Label lblAddFirst;
    }
}

