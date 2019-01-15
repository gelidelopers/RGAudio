namespace Gelida24
{
    partial class frm24
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
            this.player2 = new Gelida24.Player();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.player1 = new Gelida24.Player();
            this.continu1 = new Gelida24.Continu();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // player2
            // 
            this.player2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player2.Location = new System.Drawing.Point(6, 6);
            this.player2.MinimumSize = new System.Drawing.Size(288, 495);
            this.player2.Name = "player2";
            this.player2.outDev = ((sbyte)(0));
            this.player2.Padding = new System.Windows.Forms.Padding(5);
            this.player2.Size = new System.Drawing.Size(336, 495);
            this.player2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 100);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.player2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.player1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.continu1, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1039, 451);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // player1
            // 
            this.player1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player1.Location = new System.Drawing.Point(351, 6);
            this.player1.MinimumSize = new System.Drawing.Size(288, 495);
            this.player1.Name = "player1";
            this.player1.outDev = ((sbyte)(0));
            this.player1.Padding = new System.Windows.Forms.Padding(5);
            this.player1.Size = new System.Drawing.Size(336, 495);
            this.player1.TabIndex = 4;
            // 
            // continu1
            // 
            this.continu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continu1.Location = new System.Drawing.Point(696, 6);
            this.continu1.Name = "continu1";
            this.continu1.outDev = ((sbyte)(0));
            this.continu1.Padding = new System.Windows.Forms.Padding(5);
            this.continu1.Size = new System.Drawing.Size(337, 439);
            this.continu1.TabIndex = 5;
            // 
            // frm24
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 551);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frm24";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Player player2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Player player1;
        private Continu continu1;
    }
}

