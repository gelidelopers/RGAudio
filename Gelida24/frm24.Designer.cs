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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.volumeMeter5 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter6 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter7 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter8 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter2 = new NAudio.Gui.VolumeMeter();
            this.lblTime = new System.Windows.Forms.Label();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter4 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter3 = new NAudio.Gui.VolumeMeter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.continu1 = new Gelida24.Continu();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.player1 = new Gelida24.Player();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.player2 = new Gelida24.Player();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.volumeMeter5);
            this.panel1.Controls.Add(this.volumeMeter6);
            this.panel1.Controls.Add(this.volumeMeter7);
            this.panel1.Controls.Add(this.volumeMeter8);
            this.panel1.Controls.Add(this.volumeMeter2);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.volumeMeter1);
            this.panel1.Controls.Add(this.volumeMeter4);
            this.panel1.Controls.Add(this.volumeMeter3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 76);
            this.panel1.TabIndex = 4;
            // 
            // volumeMeter5
            // 
            this.volumeMeter5.Amplitude = 0F;
            this.volumeMeter5.Location = new System.Drawing.Point(453, 59);
            this.volumeMeter5.Margin = new System.Windows.Forms.Padding(6);
            this.volumeMeter5.MaxDb = -1F;
            this.volumeMeter5.MaximumSize = new System.Drawing.Size(0, 10);
            this.volumeMeter5.MinDb = -60F;
            this.volumeMeter5.MinimumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter5.Name = "volumeMeter5";
            this.volumeMeter5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter5.Size = new System.Drawing.Size(50, 10);
            this.volumeMeter5.TabIndex = 37;
            this.volumeMeter5.Text = "volumeMeter5";
            // 
            // volumeMeter6
            // 
            this.volumeMeter6.Amplitude = 0F;
            this.volumeMeter6.Location = new System.Drawing.Point(453, 43);
            this.volumeMeter6.Margin = new System.Windows.Forms.Padding(6);
            this.volumeMeter6.MaxDb = -1F;
            this.volumeMeter6.MaximumSize = new System.Drawing.Size(0, 10);
            this.volumeMeter6.MinDb = -60F;
            this.volumeMeter6.MinimumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter6.Name = "volumeMeter6";
            this.volumeMeter6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter6.Size = new System.Drawing.Size(50, 10);
            this.volumeMeter6.TabIndex = 38;
            this.volumeMeter6.Text = "volumeMeter6";
            // 
            // volumeMeter7
            // 
            this.volumeMeter7.Amplitude = 0F;
            this.volumeMeter7.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter7.Location = new System.Drawing.Point(704, 59);
            this.volumeMeter7.MaxDb = 0.2F;
            this.volumeMeter7.MaximumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter7.MinDb = -1F;
            this.volumeMeter7.MinimumSize = new System.Drawing.Size(40, 10);
            this.volumeMeter7.Name = "volumeMeter7";
            this.volumeMeter7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter7.Size = new System.Drawing.Size(40, 10);
            this.volumeMeter7.TabIndex = 39;
            this.volumeMeter7.Text = "volumeMeter7";
            // 
            // volumeMeter8
            // 
            this.volumeMeter8.Amplitude = 0F;
            this.volumeMeter8.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter8.Location = new System.Drawing.Point(704, 43);
            this.volumeMeter8.MaxDb = 0.2F;
            this.volumeMeter8.MaximumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter8.MinDb = -1F;
            this.volumeMeter8.MinimumSize = new System.Drawing.Size(40, 10);
            this.volumeMeter8.Name = "volumeMeter8";
            this.volumeMeter8.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter8.Size = new System.Drawing.Size(40, 10);
            this.volumeMeter8.TabIndex = 40;
            this.volumeMeter8.Text = "volumeMeter8";
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = 0F;
            this.volumeMeter2.Location = new System.Drawing.Point(9, 59);
            this.volumeMeter2.Margin = new System.Windows.Forms.Padding(6);
            this.volumeMeter2.MaxDb = -1F;
            this.volumeMeter2.MaximumSize = new System.Drawing.Size(0, 10);
            this.volumeMeter2.MinDb = -60F;
            this.volumeMeter2.MinimumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter2.Size = new System.Drawing.Size(50, 10);
            this.volumeMeter2.TabIndex = 33;
            this.volumeMeter2.Text = "volumeMeter2";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(0, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(151, 37);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "23:59:59";
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.Location = new System.Drawing.Point(9, 43);
            this.volumeMeter1.Margin = new System.Windows.Forms.Padding(6);
            this.volumeMeter1.MaxDb = -1F;
            this.volumeMeter1.MaximumSize = new System.Drawing.Size(0, 10);
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.MinimumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter1.Size = new System.Drawing.Size(50, 10);
            this.volumeMeter1.TabIndex = 34;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // volumeMeter4
            // 
            this.volumeMeter4.Amplitude = 0F;
            this.volumeMeter4.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter4.Location = new System.Drawing.Point(260, 59);
            this.volumeMeter4.MaxDb = 0.2F;
            this.volumeMeter4.MaximumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter4.MinDb = -1F;
            this.volumeMeter4.MinimumSize = new System.Drawing.Size(40, 10);
            this.volumeMeter4.Name = "volumeMeter4";
            this.volumeMeter4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter4.Size = new System.Drawing.Size(40, 10);
            this.volumeMeter4.TabIndex = 35;
            this.volumeMeter4.Text = "volumeMeter4";
            // 
            // volumeMeter3
            // 
            this.volumeMeter3.Amplitude = 0F;
            this.volumeMeter3.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter3.Location = new System.Drawing.Point(260, 43);
            this.volumeMeter3.MaxDb = 0.2F;
            this.volumeMeter3.MaximumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter3.MinDb = -1F;
            this.volumeMeter3.MinimumSize = new System.Drawing.Size(40, 10);
            this.volumeMeter3.Name = "volumeMeter3";
            this.volumeMeter3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter3.Size = new System.Drawing.Size(40, 10);
            this.volumeMeter3.TabIndex = 36;
            this.volumeMeter3.Text = "volumeMeter3";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1336, 692);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.continu1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(894, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 680);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "24 H";
            // 
            // continu1
            // 
            this.continu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continu1.Location = new System.Drawing.Point(3, 18);
            this.continu1.Margin = new System.Windows.Forms.Padding(4);
            this.continu1.Name = "continu1";
            this.continu1.outDev = ((sbyte)(0));
            this.continu1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.continu1.Size = new System.Drawing.Size(430, 659);
            this.continu1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.player1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(450, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 680);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Canal 2";
            // 
            // player1
            // 
            this.player1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player1.Location = new System.Drawing.Point(3, 18);
            this.player1.Margin = new System.Windows.Forms.Padding(4);
            this.player1.MinimumSize = new System.Drawing.Size(384, 609);
            this.player1.Name = "player1";
            this.player1.outDev = ((sbyte)(0));
            this.player1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.player1.Size = new System.Drawing.Size(429, 659);
            this.player1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.player2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 680);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canal 1";
            // 
            // player2
            // 
            this.player2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player2.Location = new System.Drawing.Point(3, 18);
            this.player2.Margin = new System.Windows.Forms.Padding(4);
            this.player2.MinimumSize = new System.Drawing.Size(384, 609);
            this.player2.Name = "player2";
            this.player2.outDev = ((sbyte)(0));
            this.player2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.player2.Size = new System.Drawing.Size(429, 659);
            this.player2.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm24
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frm24";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Player player2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Player player1;
        private Continu continu1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private NAudio.Gui.VolumeMeter volumeMeter5;
        private NAudio.Gui.VolumeMeter volumeMeter6;
        private NAudio.Gui.VolumeMeter volumeMeter7;
        private NAudio.Gui.VolumeMeter volumeMeter8;
        private NAudio.Gui.VolumeMeter volumeMeter2;
        private NAudio.Gui.VolumeMeter volumeMeter1;
        private NAudio.Gui.VolumeMeter volumeMeter4;
        private NAudio.Gui.VolumeMeter volumeMeter3;
    }
}

