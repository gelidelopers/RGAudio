namespace Gelida_Player
{
    partial class frmBBDDSettings
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
            this.bbddConfig1 = new ControlsLib.BBDDConfig();
            this.SuspendLayout();
            // 
            // bbddConfig1
            // 
            this.bbddConfig1.Connection = null;
            this.bbddConfig1.Location = new System.Drawing.Point(13, 13);
            this.bbddConfig1.Name = "bbddConfig1";
            this.bbddConfig1.Size = new System.Drawing.Size(308, 340);
            this.bbddConfig1.TabIndex = 0;
            // 
            // frmBBDDSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bbddConfig1);
            this.Name = "frmBBDDSettings";
            this.Text = "frmBBDDSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlsLib.BBDDConfig bbddConfig1;
    }
}