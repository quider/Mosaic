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
            this.btMosaicSettingsOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.tbRatio = new System.Windows.Forms.TextBox();
            this.gbxMosaicDimensions = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.tabSettings.SuspendLayout();
            this.tabPageMainSettings.SuspendLayout();
            this.gbxMosaicDimensions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPageMainSettings);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(391, 440);
            this.tabSettings.TabIndex = 0;
            // 
            // tabPageMainSettings
            // 
            this.tabPageMainSettings.Controls.Add(this.gbxMosaicDimensions);
            this.tabPageMainSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainSettings.Name = "tabPageMainSettings";
            this.tabPageMainSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainSettings.Size = new System.Drawing.Size(383, 414);
            this.tabPageMainSettings.TabIndex = 1;
            this.tabPageMainSettings.Text = "Mosaic settings";
            this.tabPageMainSettings.UseVisualStyleBackColor = true;
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 446);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(18, 26);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(32, 13);
            this.lblPercentage.TabIndex = 2;
            this.lblPercentage.Text = "Ratio";
            // 
            // tbRatio
            // 
            this.tbRatio.Location = new System.Drawing.Point(21, 42);
            this.tbRatio.Name = "tbRatio";
            this.tbRatio.Size = new System.Drawing.Size(82, 20);
            this.tbRatio.TabIndex = 5;
            // 
            // gbxMosaicDimensions
            // 
            this.gbxMosaicDimensions.Controls.Add(this.lblMessage);
            this.gbxMosaicDimensions.Controls.Add(this.tbRatio);
            this.gbxMosaicDimensions.Controls.Add(this.lblPercentage);
            this.gbxMosaicDimensions.Location = new System.Drawing.Point(6, 6);
            this.gbxMosaicDimensions.Name = "gbxMosaicDimensions";
            this.gbxMosaicDimensions.Size = new System.Drawing.Size(372, 88);
            this.gbxMosaicDimensions.TabIndex = 0;
            this.gbxMosaicDimensions.TabStop = false;
            this.gbxMosaicDimensions.Text = "Dimensions";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(131, 45);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 6;
            this.lblMessage.Text = "label1";
            this.lblMessage.Visible = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 481);
            this.Controls.Add(this.btMosaicSettingsOK);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.tabSettings.ResumeLayout(false);
            this.tabPageMainSettings.ResumeLayout(false);
            this.gbxMosaicDimensions.ResumeLayout(false);
            this.gbxMosaicDimensions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPageMainSettings;
        private System.Windows.Forms.Button btMosaicSettingsOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbxMosaicDimensions;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox tbRatio;
        private System.Windows.Forms.Label lblPercentage;
    }
}