namespace TestingForms
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
            this.dropBetweenList1 = new ControlsLib.DropBetweenList();
            this.dropBetweenList2 = new ControlsLib.DropBetweenList();
            this.SuspendLayout();
            // 
            // dropBetweenList1
            // 
            this.dropBetweenList1.Location = new System.Drawing.Point(12, 12);
            this.dropBetweenList1.Name = "dropBetweenList1";
            this.dropBetweenList1.Size = new System.Drawing.Size(268, 240);
            this.dropBetweenList1.TabIndex = 0;
            // 
            // dropBetweenList2
            // 
            this.dropBetweenList2.Location = new System.Drawing.Point(324, 12);
            this.dropBetweenList2.Name = "dropBetweenList2";
            this.dropBetweenList2.Size = new System.Drawing.Size(268, 240);
            this.dropBetweenList2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dropBetweenList2);
            this.Controls.Add(this.dropBetweenList1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlsLib.DropBetweenList dropBetweenList1;
        private ControlsLib.DropBetweenList dropBetweenList2;
    }
}

