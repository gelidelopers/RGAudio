namespace Gelida_Player
{
    partial class frmSplash
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblVersio = new System.Windows.Forms.Label();
            this.lblDeveloping = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gelida_Player.Properties.Resources.gelida_player;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 263);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(260, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(255, 42);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Gelida Player";
            // 
            // lblVersio
            // 
            this.lblVersio.AutoSize = true;
            this.lblVersio.ForeColor = System.Drawing.Color.White;
            this.lblVersio.Location = new System.Drawing.Point(264, 91);
            this.lblVersio.Name = "lblVersio";
            this.lblVersio.Size = new System.Drawing.Size(42, 13);
            this.lblVersio.TabIndex = 2;
            this.lblVersio.Text = "Versió: ";
            this.lblVersio.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblDeveloping
            // 
            this.lblDeveloping.AutoSize = true;
            this.lblDeveloping.ForeColor = System.Drawing.Color.White;
            this.lblDeveloping.Location = new System.Drawing.Point(264, 141);
            this.lblDeveloping.Name = "lblDeveloping";
            this.lblDeveloping.Size = new System.Drawing.Size(221, 13);
            this.lblDeveloping.TabIndex = 3;
            this.lblDeveloping.Text = "Programa en fase inicial de desenvolupament";
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(530, 288);
            this.ControlBox = false;
            this.Controls.Add(this.lblDeveloping);
            this.Controls.Add(this.lblVersio);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSplash";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gelida Player - Iniciant...";
            
            this.DoubleClick += new System.EventHandler(this.frmSplash_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVersio;
        private System.Windows.Forms.Label lblDeveloping;
    }
}