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
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabPageMainSettings);
            this.tabSettings.Location = new System.Drawing.Point(3, 3);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(479, 479);
            this.tabSettings.TabIndex = 0;
            // 
            // tabPageMainSettings
            // 
            this.tabPageMainSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainSettings.Name = "tabPageMainSettings";
            this.tabPageMainSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainSettings.Size = new System.Drawing.Size(471, 453);
            this.tabPageMainSettings.TabIndex = 1;
            this.tabPageMainSettings.Text = "Mosaic settings";
            this.tabPageMainSettings.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 481);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.tabSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabPageMainSettings;
    }
}