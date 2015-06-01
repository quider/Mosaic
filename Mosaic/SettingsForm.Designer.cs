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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabPageMainSettings = new System.Windows.Forms.TabPage();
            this.gbxMosaicDimensions = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tbRatio = new System.Windows.Forms.TextBox();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.btMosaicSettingsOK = new System.Windows.Forms.Button();
            this.btnMosaicSettingsCancel = new System.Windows.Forms.Button();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxHueSetting = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtRandomTiles = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.tabSettings.SuspendLayout();
            this.tabPageMainSettings.SuspendLayout();
            this.gbxMosaicDimensions.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbxEffects.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPageMainSettings);
            this.tabSettings.Controls.Add(this.tabPage1);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(391, 440);
            this.tabSettings.TabIndex = 0;
            // 
            // tabPageMainSettings
            // 
            this.tabPageMainSettings.Controls.Add(this.groupBox2);
            this.tabPageMainSettings.Controls.Add(this.groupBox1);
            this.tabPageMainSettings.Controls.Add(this.gbxMosaicDimensions);
            this.tabPageMainSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainSettings.Name = "tabPageMainSettings";
            this.tabPageMainSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainSettings.Size = new System.Drawing.Size(383, 414);
            this.tabPageMainSettings.TabIndex = 1;
            this.tabPageMainSettings.Text = "Mosaic settings";
            this.tabPageMainSettings.UseVisualStyleBackColor = true;
            // 
            // gbxMosaicDimensions
            // 
            this.gbxMosaicDimensions.Controls.Add(this.numericUpDown2);
            this.gbxMosaicDimensions.Controls.Add(this.label2);
            this.gbxMosaicDimensions.Controls.Add(this.label1);
            this.gbxMosaicDimensions.Controls.Add(this.numericUpDown1);
            this.gbxMosaicDimensions.Controls.Add(this.lblMessage);
            this.gbxMosaicDimensions.Controls.Add(this.tbRatio);
            this.gbxMosaicDimensions.Controls.Add(this.lblPercentage);
            this.gbxMosaicDimensions.Location = new System.Drawing.Point(6, 6);
            this.gbxMosaicDimensions.Name = "gbxMosaicDimensions";
            this.gbxMosaicDimensions.Size = new System.Drawing.Size(372, 190);
            this.gbxMosaicDimensions.TabIndex = 0;
            this.gbxMosaicDimensions.TabStop = false;
            this.gbxMosaicDimensions.Text = "Dimensions";
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(156, 26);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(210, 46);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "label1";
            this.lblMessage.Visible = false;
            // 
            // tbRatio
            // 
            this.tbRatio.Location = new System.Drawing.Point(59, 40);
            this.tbRatio.Name = "tbRatio";
            this.tbRatio.Size = new System.Drawing.Size(82, 20);
            this.tbRatio.TabIndex = 5;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(6, 43);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(32, 13);
            this.lblPercentage.TabIndex = 2;
            this.lblPercentage.Text = "Ratio";
            // 
            // btMosaicSettingsOK
            // 
            this.btMosaicSettingsOK.Location = new System.Drawing.Point(312, 446);
            this.btMosaicSettingsOK.Name = "btMosaicSettingsOK";
            this.btMosaicSettingsOK.Size = new System.Drawing.Size(75, 23);
            this.btMosaicSettingsOK.TabIndex = 1;
            this.btMosaicSettingsOK.Text = "Ok";
            this.btMosaicSettingsOK.UseVisualStyleBackColor = true;
            // 
            // btnMosaicSettingsCancel
            // 
            this.btnMosaicSettingsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMosaicSettingsCancel.Location = new System.Drawing.Point(4, 446);
            this.btnMosaicSettingsCancel.Name = "btnMosaicSettingsCancel";
            this.btnMosaicSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnMosaicSettingsCancel.TabIndex = 2;
            this.btnMosaicSettingsCancel.Text = "Cancel";
            this.btnMosaicSettingsCancel.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbxEffects);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(383, 414);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Effects";
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
            this.gbxEffects.Location = new System.Drawing.Point(6, 6);
            this.gbxEffects.Name = "gbxEffects";
            this.gbxEffects.Size = new System.Drawing.Size(372, 299);
            this.gbxEffects.TabIndex = 8;
            this.gbxEffects.TabStop = false;
            this.gbxEffects.Text = "Effects";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(123, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 35);
            this.label6.TabIndex = 12;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(123, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 35);
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // lblSharp
            // 
            this.lblSharp.Location = new System.Drawing.Point(123, 155);
            this.lblSharp.Name = "lblSharp";
            this.lblSharp.Size = new System.Drawing.Size(235, 35);
            this.lblSharp.TabIndex = 10;
            this.lblSharp.Text = "label4";
            this.lblSharp.Visible = false;
            // 
            // lblMono
            // 
            this.lblMono.Location = new System.Drawing.Point(123, 113);
            this.lblMono.Name = "lblMono";
            this.lblMono.Size = new System.Drawing.Size(235, 35);
            this.lblMono.TabIndex = 9;
            this.lblMono.Text = "label3";
            this.lblMono.Visible = false;
            // 
            // lblSepia
            // 
            this.lblSepia.Location = new System.Drawing.Point(123, 72);
            this.lblSepia.Name = "lblSepia";
            this.lblSepia.Size = new System.Drawing.Size(235, 35);
            this.lblSepia.TabIndex = 8;
            this.lblSepia.Text = "label2";
            this.lblSepia.Visible = false;
            // 
            // lblNone
            // 
            this.lblNone.Location = new System.Drawing.Point(123, 33);
            this.lblNone.Name = "lblNone";
            this.lblNone.Size = new System.Drawing.Size(235, 35);
            this.lblNone.TabIndex = 7;
            this.lblNone.Visible = false;
            // 
            // radioButton6
            // 
            this.radioButton6.Location = new System.Drawing.Point(32, 246);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(85, 37);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.Text = "radioButton6";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.Visible = false;
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(32, 200);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(85, 37);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "rbtNew1";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Visible = false;
            // 
            // rbtSharp
            // 
            this.rbtSharp.Location = new System.Drawing.Point(32, 153);
            this.rbtSharp.Name = "rbtSharp";
            this.rbtSharp.Size = new System.Drawing.Size(85, 37);
            this.rbtSharp.TabIndex = 3;
            this.rbtSharp.Text = "rbtSharp";
            this.rbtSharp.UseVisualStyleBackColor = true;
            // 
            // rbtMono
            // 
            this.rbtMono.Location = new System.Drawing.Point(32, 113);
            this.rbtMono.Name = "rbtMono";
            this.rbtMono.Size = new System.Drawing.Size(85, 35);
            this.rbtMono.TabIndex = 2;
            this.rbtMono.Text = "rbtMono";
            this.rbtMono.UseVisualStyleBackColor = true;
            // 
            // rbtSepia
            // 
            this.rbtSepia.Location = new System.Drawing.Point(32, 72);
            this.rbtSepia.Name = "rbtSepia";
            this.rbtSepia.Size = new System.Drawing.Size(85, 35);
            this.rbtSepia.TabIndex = 1;
            this.rbtSepia.Text = "rbtSepia";
            this.rbtSepia.UseVisualStyleBackColor = true;
            // 
            // rbtNone
            // 
            this.rbtNone.Checked = true;
            this.rbtNone.Location = new System.Drawing.Point(32, 33);
            this.rbtNone.Name = "rbtNone";
            this.rbtNone.Size = new System.Drawing.Size(85, 35);
            this.rbtNone.TabIndex = 0;
            this.rbtNone.TabStop = true;
            this.rbtNone.Text = "rbtNone";
            this.rbtNone.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxHueSetting);
            this.groupBox1.Location = new System.Drawing.Point(5, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 88);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            // 
            // cbxHueSetting
            // 
            this.cbxHueSetting.AutoSize = true;
            this.cbxHueSetting.Location = new System.Drawing.Point(10, 36);
            this.cbxHueSetting.Name = "cbxHueSetting";
            this.cbxHueSetting.Size = new System.Drawing.Size(121, 17);
            this.cbxHueSetting.TabIndex = 0;
            this.cbxHueSetting.Text = "Add hue to each tile";
            this.cbxHueSetting.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.rbtRandomTiles);
            this.groupBox2.Location = new System.Drawing.Point(6, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 112);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiles";
            // 
            // rbtRandomTiles
            // 
            this.rbtRandomTiles.AutoSize = true;
            this.rbtRandomTiles.Location = new System.Drawing.Point(18, 39);
            this.rbtRandomTiles.Name = "rbtRandomTiles";
            this.rbtRandomTiles.Size = new System.Drawing.Size(86, 17);
            this.rbtRandomTiles.TabIndex = 1;
            this.rbtRandomTiles.TabStop = true;
            this.rbtRandomTiles.Text = "Random tiles";
            this.rbtRandomTiles.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 81);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(104, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Find tiles to color";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(95, 70);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Buffer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tiles in group";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(95, 99);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown2.TabIndex = 10;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btMosaicSettingsOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnMosaicSettingsCancel;
            this.ClientSize = new System.Drawing.Size(391, 481);
            this.Controls.Add(this.btMosaicSettingsOK);
            this.Controls.Add(this.btnMosaicSettingsCancel);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.tabSettings.ResumeLayout(false);
            this.tabPageMainSettings.ResumeLayout(false);
            this.gbxMosaicDimensions.ResumeLayout(false);
            this.gbxMosaicDimensions.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.gbxEffects.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPageMainSettings;
        private System.Windows.Forms.Button btMosaicSettingsOK;
        private System.Windows.Forms.Button btnMosaicSettingsCancel;
        private System.Windows.Forms.GroupBox gbxMosaicDimensions;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbRatio;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbtRandomTiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxHueSetting;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
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
    }
}