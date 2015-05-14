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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbxTiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            this.gbxMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxTiles
            // 
            this.lbxTiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxTiles.FormattingEnabled = true;
            this.lbxTiles.Location = new System.Drawing.Point(17, 19);
            this.lbxTiles.Name = "lbxTiles";
            this.lbxTiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxTiles.Size = new System.Drawing.Size(243, 303);
            this.lbxTiles.TabIndex = 0;
            // 
            // gbxTiles
            // 
            this.gbxTiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxTiles.Controls.Add(this.lblHeight);
            this.gbxTiles.Controls.Add(this.lblWidth);
            this.gbxTiles.Controls.Add(this.nudHeight);
            this.gbxTiles.Controls.Add(this.nudWidth);
            this.gbxTiles.Controls.Add(this.lblOperation);
            this.gbxTiles.Controls.Add(this.pgbOperation);
            this.gbxTiles.Controls.Add(this.btnRemove);
            this.gbxTiles.Controls.Add(this.btnAdd);
            this.gbxTiles.Controls.Add(this.lbxTiles);
            this.gbxTiles.Location = new System.Drawing.Point(12, 98);
            this.gbxTiles.Name = "gbxTiles";
            this.gbxTiles.Size = new System.Drawing.Size(348, 416);
            this.gbxTiles.TabIndex = 1;
            this.gbxTiles.TabStop = false;
            this.gbxTiles.Text = "Tiles";
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(265, 109);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 8;
            this.lblHeight.Text = "Height";
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(265, 83);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 7;
            this.lblWidth.Text = "Width";
            // 
            // nudHeight
            // 
            this.nudHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudHeight.Location = new System.Drawing.Point(304, 107);
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
            this.nudHeight.Size = new System.Drawing.Size(38, 20);
            this.nudHeight.TabIndex = 6;
            this.nudHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // nudWidth
            // 
            this.nudWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWidth.Location = new System.Drawing.Point(304, 81);
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
            this.nudWidth.Size = new System.Drawing.Size(38, 20);
            this.nudWidth.TabIndex = 5;
            this.nudWidth.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            // 
            // lblOperation
            // 
            this.lblOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOperation.AutoSize = true;
            this.lblOperation.Location = new System.Drawing.Point(14, 366);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(38, 13);
            this.lblOperation.TabIndex = 4;
            this.lblOperation.Text = "Ready";
            // 
            // pgbOperation
            // 
            this.pgbOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbOperation.Location = new System.Drawing.Point(17, 382);
            this.pgbOperation.Name = "pgbOperation";
            this.pgbOperation.Size = new System.Drawing.Size(325, 23);
            this.pgbOperation.TabIndex = 3;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(269, 48);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(73, 27);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(269, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(73, 27);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbxMaster
            // 
            this.gbxMaster.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxMaster.Controls.Add(this.cbxAdjustTiles);
            this.gbxMaster.Controls.Add(this.btnBrowse);
            this.gbxMaster.Controls.Add(this.tbxBrowse);
            this.gbxMaster.Location = new System.Drawing.Point(12, 12);
            this.gbxMaster.Name = "gbxMaster";
            this.gbxMaster.Size = new System.Drawing.Size(348, 80);
            this.gbxMaster.TabIndex = 2;
            this.gbxMaster.TabStop = false;
            this.gbxMaster.Text = "Master Image";
            // 
            // cbxAdjustTiles
            // 
            this.cbxAdjustTiles.AutoSize = true;
            this.cbxAdjustTiles.Location = new System.Drawing.Point(85, 51);
            this.cbxAdjustTiles.Name = "cbxAdjustTiles";
            this.cbxAdjustTiles.Size = new System.Drawing.Size(98, 17);
            this.cbxAdjustTiles.TabIndex = 5;
            this.cbxAdjustTiles.Text = "Adjust Tile Hue";
            this.cbxAdjustTiles.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(6, 45);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(73, 27);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbxBrowse
            // 
            this.tbxBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxBrowse.Location = new System.Drawing.Point(6, 19);
            this.tbxBrowse.Name = "tbxBrowse";
            this.tbxBrowse.Size = new System.Drawing.Size(336, 20);
            this.tbxBrowse.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(6, 19);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(96, 27);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(6, 82);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(523, 405);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.pictureBox);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Location = new System.Drawing.Point(366, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 502);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mosaic";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "Calculate colors";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 526);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxMaster);
            this.Controls.Add(this.gbxTiles);
            this.Name = "MainForm";
            this.Text = "Mosaic";
            this.gbxTiles.ResumeLayout(false);
            this.gbxTiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            this.gbxMaster.ResumeLayout(false);
            this.gbxMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}

