namespace Gelida_Player
{
    partial class frmAbout
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
            this.lblDeveloping = new System.Windows.Forms.Label();
            this.lblVersio = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeveloping
            // 
            this.lblDeveloping.AutoSize = true;
            this.lblDeveloping.ForeColor = System.Drawing.Color.Black;
            this.lblDeveloping.Location = new System.Drawing.Point(270, 133);
            this.lblDeveloping.Name = "lblDeveloping";
            this.lblDeveloping.Size = new System.Drawing.Size(221, 13);
            this.lblDeveloping.TabIndex = 7;
            this.lblDeveloping.Text = "Programa en fase inicial de desenvolupament";
            // 
            // lblVersio
            // 
            this.lblVersio.AutoSize = true;
            this.lblVersio.ForeColor = System.Drawing.Color.Black;
            this.lblVersio.Location = new System.Drawing.Point(270, 83);
            this.lblVersio.Name = "lblVersio";
            this.lblVersio.Size = new System.Drawing.Size(42, 13);
            this.lblVersio.TabIndex = 6;
            this.lblVersio.Text = "Versió: ";
            this.lblVersio.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(266, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 42);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Gelida Player";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gelida_Player.Properties.Resources.gelida_player;
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 263);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(270, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Desenvolupat per Xavi Barriendos ";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 263);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDeveloping);
            this.Controls.Add(this.lblVersio);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDeveloping;
        private System.Windows.Forms.Label lblVersio;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}