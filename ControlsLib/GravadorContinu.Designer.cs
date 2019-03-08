namespace ControlsLib
{
    partial class GravadorContinu
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter2 = new NAudio.Gui.VolumeMeter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.volumeMeter1.Location = new System.Drawing.Point(0, 26);
            this.volumeMeter1.MaxDb = 18F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Padding = new System.Windows.Forms.Padding(3);
            this.volumeMeter1.Size = new System.Drawing.Size(488, 20);
            this.volumeMeter1.TabIndex = 0;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = 0F;
            this.volumeMeter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.volumeMeter2.Location = new System.Drawing.Point(0, 6);
            this.volumeMeter2.MaxDb = 18F;
            this.volumeMeter2.MinDb = -60F;
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.Padding = new System.Windows.Forms.Padding(3);
            this.volumeMeter2.Size = new System.Drawing.Size(488, 20);
            this.volumeMeter2.TabIndex = 1;
            this.volumeMeter2.Text = "volumeMeter2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // GravadorContinu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.volumeMeter2);
            this.Controls.Add(this.volumeMeter1);
            this.Name = "GravadorContinu";
            this.Size = new System.Drawing.Size(488, 46);
            this.ResumeLayout(false);

        }

        #endregion

        private NAudio.Gui.VolumeMeter volumeMeter1;
        private NAudio.Gui.VolumeMeter volumeMeter2;
        private System.Windows.Forms.Timer timer1;
    }
}
