namespace Mosaic
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPageMainSettings = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbtFindColors = new System.Windows.Forms.RadioButton();
            this.rbtRandomTiles = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxHueSetting = new System.Windows.Forms.CheckBox();
            this.gbxMosaicDimensions = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTilesInGroup = new System.Windows.Forms.NumericUpDown();
            this.lblTilesInGroup = new System.Windows.Forms.Label();
            this.lblBuffer = new System.Windows.Forms.Label();
            this.nudTreshold = new System.Windows.Forms.NumericUpDown();
            this.lblRatioExplanation = new System.Windows.Forms.Label();
            this.tbRatio = new System.Windows.Forms.TextBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbxEffects = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSharp = new System.Windows.Forms.Label();
            this.lblMono = new System.Windows.Forms.Label();
            this.lblSepia = new System.Windows.Forms.Label();
            this.lblNone = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.rbtSharp = new System.Windows.Forms.RadioButton();
            this.rbtMono = new System.Windows.Forms.RadioButton();
            this.rbtSepia = new System.Windows.Forms.RadioButton();
            this.rbtNone = new System.Windows.Forms.RadioButton();
            this.btMosaicSettingsOK = new System.Windows.Forms.Button();
            this.btnMosaicSettingsCancel = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.tabPageMainSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbxMosaicDimensions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTilesInGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTreshold)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.gbxEffects.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPageMainSettings);
            this.tabSettings.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabSettings, "tabSettings");
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            // 
            // tabPageMainSettings
            // 
            this.tabPageMainSettings.Controls.Add(this.groupBox2);
            this.tabPageMainSettings.Controls.Add(this.groupBox1);
            this.tabPageMainSettings.Controls.Add(this.gbxMosaicDimensions);
            resources.ApplyResources(this.tabPageMainSettings, "tabPageMainSettings");
            this.tabPageMainSettings.Name = "tabPageMainSettings";
            this.tabPageMainSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbtFindColors);
            this.groupBox2.Controls.Add(this.rbtRandomTiles);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rdbtFindColors
            // 
            resources.ApplyResources(this.rdbtFindColors, "rdbtFindColors");
            this.rdbtFindColors.Checked = true;
            this.rdbtFindColors.Name = "rdbtFindColors";
            this.rdbtFindColors.TabStop = true;
            this.rdbtFindColors.UseVisualStyleBackColor = true;
            // 
            // rbtRandomTiles
            // 
            resources.ApplyResources(this.rbtRandomTiles, "rbtRandomTiles");
            this.rbtRandomTiles.Name = "rbtRandomTiles";
            this.rbtRandomTiles.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxHueSetting);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbxHueSetting
            // 
            resources.ApplyResources(this.cbxHueSetting, "cbxHueSetting");
            this.cbxHueSetting.Name = "cbxHueSetting";
            this.cbxHueSetting.UseVisualStyleBackColor = true;
            // 
            // gbxMosaicDimensions
            // 
            this.gbxMosaicDimensions.Controls.Add(this.label3);
            this.gbxMosaicDimensions.Controls.Add(this.nudTilesInGroup);
            this.gbxMosaicDimensions.Controls.Add(this.lblTilesInGroup);
            this.gbxMosaicDimensions.Controls.Add(this.lblBuffer);
            this.gbxMosaicDimensions.Controls.Add(this.nudTreshold);
            this.gbxMosaicDimensions.Controls.Add(this.lblRatioExplanation);
            this.gbxMosaicDimensions.Controls.Add(this.tbRatio);
            this.gbxMosaicDimensions.Controls.Add(this.lblPercentage);
            resources.ApplyResources(this.gbxMosaicDimensions, "gbxMosaicDimensions");
            this.gbxMosaicDimensions.Name = "gbxMosaicDimensions";
            this.gbxMosaicDimensions.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // nudTilesInGroup
            // 
            resources.ApplyResources(this.nudTilesInGroup, "nudTilesInGroup");
            this.nudTilesInGroup.Name = "nudTilesInGroup";
            this.nudTilesInGroup.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // lblTilesInGroup
            // 
            resources.ApplyResources(this.lblTilesInGroup, "lblTilesInGroup");
            this.lblTilesInGroup.Name = "lblTilesInGroup";
            // 
            // lblBuffer
            // 
            resources.ApplyResources(this.lblBuffer, "lblBuffer");
            this.lblBuffer.Name = "lblBuffer";
            // 
            // nudTreshold
            // 
            resources.ApplyResources(this.nudTreshold, "nudTreshold");
            this.nudTreshold.Name = "nudTreshold";
            this.nudTreshold.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // lblRatioExplanation
            // 
            resources.ApplyResources(this.lblRatioExplanation, "lblRatioExplanation");
            this.lblRatioExplanation.Name = "lblRatioExplanation";
            // 
            // tbRatio
            // 
            resources.ApplyResources(this.tbRatio, "tbRatio");
            this.tbRatio.Name = "tbRatio";
            // 
            // lblPercentage
            // 
            resources.ApplyResources(this.lblPercentage, "lblPercentage");
            this.lblPercentage.Name = "lblPercentage";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbxEffects);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbxEffects
            // 
            this.gbxEffects.Controls.Add(this.label6);
            this.gbxEffects.Controls.Add(this.label5);
            this.gbxEffects.Controls.Add(this.lblSharp);
            this.gbxEffects.Controls.Add(this.lblMono);
            this.gbxEffects.Controls.Add(this.lblSepia);
            this.gbxEffects.Controls.Add(this.lblNone);
            this.gbxEffects.Controls.Add(this.radioButton6);
            this.gbxEffects.Controls.Add(this.radioButton5);
            this.gbxEffects.Controls.Add(this.rbtSharp);
            this.gbxEffects.Controls.Add(this.rbtMono);
            this.gbxEffects.Controls.Add(this.rbtSepia);
            this.gbxEffects.Controls.Add(this.rbtNone);
            resources.ApplyResources(this.gbxEffects, "gbxEffects");
            this.gbxEffects.Name = "gbxEffects";
            this.gbxEffects.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblSharp
            // 
            resources.ApplyResources(this.lblSharp, "lblSharp");
            this.lblSharp.Name = "lblSharp";
            // 
            // lblMono
            // 
            resources.ApplyResources(this.lblMono, "lblMono");
            this.lblMono.Name = "lblMono";
            // 
            // lblSepia
            // 
            resources.ApplyResources(this.lblSepia, "lblSepia");
            this.lblSepia.Name = "lblSepia";
            // 
            // lblNone
            // 
            resources.ApplyResources(this.lblNone, "lblNone");
            this.lblNone.Name = "lblNone";
            // 
            // radioButton6
            // 
            resources.ApplyResources(this.radioButton6, "radioButton6");
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            resources.ApplyResources(this.radioButton5, "radioButton5");
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // rbtSharp
            // 
            resources.ApplyResources(this.rbtSharp, "rbtSharp");
            this.rbtSharp.Name = "rbtSharp";
            this.rbtSharp.UseVisualStyleBackColor = true;
            // 
            // rbtMono
            // 
            resources.ApplyResources(this.rbtMono, "rbtMono");
            this.rbtMono.Name = "rbtMono";
            this.rbtMono.UseVisualStyleBackColor = true;
            // 
            // rbtSepia
            // 
            resources.ApplyResources(this.rbtSepia, "rbtSepia");
            this.rbtSepia.Name = "rbtSepia";
            this.rbtSepia.UseVisualStyleBackColor = true;
            // 
            // rbtNone
            // 
            this.rbtNone.Checked = true;
            resources.ApplyResources(this.rbtNone, "rbtNone");
            this.rbtNone.Name = "rbtNone";
            this.rbtNone.TabStop = true;
            this.rbtNone.UseVisualStyleBackColor = true;
            // 
            // btMosaicSettingsOK
            // 
            resources.ApplyResources(this.btMosaicSettingsOK, "btMosaicSettingsOK");
            this.btMosaicSettingsOK.Name = "btMosaicSettingsOK";
            this.btMosaicSettingsOK.UseVisualStyleBackColor = true;
            this.btMosaicSettingsOK.Click += new System.EventHandler(this.btMosaicSettingsOK_Click);
            // 
            // btnMosaicSettingsCancel
            // 
            this.btnMosaicSettingsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnMosaicSettingsCancel, "btnMosaicSettingsCancel");
            this.btnMosaicSettingsCancel.Name = "btnMosaicSettingsCancel";
            this.btnMosaicSettingsCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btMosaicSettingsOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnMosaicSettingsCancel;
            this.Controls.Add(this.btMosaicSettingsOK);
            this.Controls.Add(this.btnMosaicSettingsCancel);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.tabSettings.ResumeLayout(false);
            this.tabPageMainSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxMosaicDimensions.ResumeLayout(false);
            this.gbxMosaicDimensions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTilesInGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTreshold)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.gbxEffects.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPageMainSettings;
        private System.Windows.Forms.Button btMosaicSettingsOK;
        private System.Windows.Forms.Button btnMosaicSettingsCancel;
        private System.Windows.Forms.GroupBox gbxMosaicDimensions;
        private System.Windows.Forms.Label lblRatioExplanation;
        private System.Windows.Forms.TextBox tbRatio;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbtFindColors;
        private System.Windows.Forms.RadioButton rbtRandomTiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxHueSetting;
        private System.Windows.Forms.NumericUpDown nudTilesInGroup;
        private System.Windows.Forms.Label lblTilesInGroup;
        private System.Windows.Forms.Label lblBuffer;
        private System.Windows.Forms.NumericUpDown nudTreshold;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbxEffects;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSharp;
        private System.Windows.Forms.Label lblMono;
        private System.Windows.Forms.Label lblSepia;
        private System.Windows.Forms.Label lblNone;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton rbtSharp;
        private System.Windows.Forms.RadioButton rbtMono;
        private System.Windows.Forms.RadioButton rbtSepia;
        private System.Windows.Forms.RadioButton rbtNone;
        private System.Windows.Forms.Label label3;
    }
}