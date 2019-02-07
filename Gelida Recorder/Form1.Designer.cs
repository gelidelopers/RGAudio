namespace Gelida_Recorder
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter2 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter3 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter4 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter5 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter6 = new NAudio.Gui.VolumeMeter();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblGrabant = new MaterialSkin.Controls.MaterialLabel();
            this.btnGrabar = new MaterialSkin.Controls.MaterialFlatButton();
            this.waveformPainter1 = new NAudio.Gui.WaveformPainter();
            this.SuspendLayout();
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.volumeMeter1.Location = new System.Drawing.Point(44, 98);
            this.volumeMeter1.MaxDb = -5F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter1.Size = new System.Drawing.Size(152, 23);
            this.volumeMeter1.TabIndex = 0;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = 0F;
            this.volumeMeter2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.volumeMeter2.Location = new System.Drawing.Point(202, 98);
            this.volumeMeter2.MaxDb = -0.5F;
            this.volumeMeter2.MinDb = -5F;
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter2.Size = new System.Drawing.Size(418, 23);
            this.volumeMeter2.TabIndex = 1;
            this.volumeMeter2.Text = "volumeMeter2";
            // 
            // volumeMeter3
            // 
            this.volumeMeter3.Amplitude = 0F;
            this.volumeMeter3.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter3.Location = new System.Drawing.Point(627, 98);
            this.volumeMeter3.MaxDb = 0F;
            this.volumeMeter3.MinDb = -0.5F;
            this.volumeMeter3.Name = "volumeMeter3";
            this.volumeMeter3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter3.Size = new System.Drawing.Size(161, 23);
            this.volumeMeter3.TabIndex = 2;
            this.volumeMeter3.Text = "volumeMeter3";
            // 
            // volumeMeter4
            // 
            this.volumeMeter4.Amplitude = 0F;
            this.volumeMeter4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.volumeMeter4.Location = new System.Drawing.Point(44, 139);
            this.volumeMeter4.MaxDb = -5F;
            this.volumeMeter4.MinDb = -60F;
            this.volumeMeter4.Name = "volumeMeter4";
            this.volumeMeter4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter4.Size = new System.Drawing.Size(152, 23);
            this.volumeMeter4.TabIndex = 5;
            this.volumeMeter4.Text = "volumeMeter4";
            // 
            // volumeMeter5
            // 
            this.volumeMeter5.Amplitude = 0F;
            this.volumeMeter5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.volumeMeter5.Location = new System.Drawing.Point(202, 139);
            this.volumeMeter5.MaxDb = -0.5F;
            this.volumeMeter5.MinDb = -5F;
            this.volumeMeter5.Name = "volumeMeter5";
            this.volumeMeter5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter5.Size = new System.Drawing.Size(418, 23);
            this.volumeMeter5.TabIndex = 4;
            this.volumeMeter5.Text = "volumeMeter5";
            // 
            // volumeMeter6
            // 
            this.volumeMeter6.Amplitude = 0F;
            this.volumeMeter6.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter6.Location = new System.Drawing.Point(627, 139);
            this.volumeMeter6.MaxDb = 0F;
            this.volumeMeter6.MinDb = -0.5F;
            this.volumeMeter6.Name = "volumeMeter6";
            this.volumeMeter6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter6.Size = new System.Drawing.Size(161, 23);
            this.volumeMeter6.TabIndex = 3;
            this.volumeMeter6.Text = "volumeMeter6";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(62, 76);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(114, 19);
            this.materialLabel1.TabIndex = 6;
            this.materialLabel1.Text = "VOLUM BAIXET";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(342, 76);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(139, 19);
            this.materialLabel2.TabIndex = 7;
            this.materialLabel2.Text = "VOLUM CORRECTE";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(661, 76);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(94, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "PROBLEMES";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(12, 102);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(17, 19);
            this.materialLabel4.TabIndex = 9;
            this.materialLabel4.Text = "L";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(12, 143);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(18, 19);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "R";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblGrabant
            // 
            this.lblGrabant.AutoSize = true;
            this.lblGrabant.Depth = 0;
            this.lblGrabant.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblGrabant.ForeColor = System.Drawing.Color.Red;
            this.lblGrabant.Location = new System.Drawing.Point(342, 227);
            this.lblGrabant.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGrabant.Name = "lblGrabant";
            this.lblGrabant.Size = new System.Drawing.Size(0, 19);
            this.lblGrabant.TabIndex = 13;
            // 
            // btnGrabar
            // 
            this.btnGrabar.AutoSize = true;
            this.btnGrabar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGrabar.Depth = 0;
            this.btnGrabar.Icon = null;
            this.btnGrabar.Location = new System.Drawing.Point(16, 207);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGrabar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Primary = false;
            this.btnGrabar.Size = new System.Drawing.Size(75, 36);
            this.btnGrabar.TabIndex = 14;
            this.btnGrabar.Text = "Gravar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // waveformPainter1
            // 
            this.waveformPainter1.Location = new System.Drawing.Point(121, 287);
            this.waveformPainter1.Name = "waveformPainter1";
            this.waveformPainter1.Size = new System.Drawing.Size(634, 59);
            this.waveformPainter1.TabIndex = 15;
            this.waveformPainter1.Text = "waveformPainter1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 358);
            this.Controls.Add(this.waveformPainter1);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblGrabant);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.volumeMeter4);
            this.Controls.Add(this.volumeMeter5);
            this.Controls.Add(this.volumeMeter6);
            this.Controls.Add(this.volumeMeter3);
            this.Controls.Add(this.volumeMeter2);
            this.Controls.Add(this.volumeMeter1);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "Form1";
            this.Text = "Gelida Recorder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NAudio.Gui.VolumeMeter volumeMeter1;
        private NAudio.Gui.VolumeMeter volumeMeter2;
        private NAudio.Gui.VolumeMeter volumeMeter3;
        private NAudio.Gui.VolumeMeter volumeMeter4;
        private NAudio.Gui.VolumeMeter volumeMeter5;
        private NAudio.Gui.VolumeMeter volumeMeter6;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.Timer timer1;
        private MaterialSkin.Controls.MaterialLabel lblGrabant;
        private MaterialSkin.Controls.MaterialFlatButton btnGrabar;
        private NAudio.Gui.WaveformPainter waveformPainter1;
    }
}

