namespace ControlsLib
{
    partial class Continu
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
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelRemain = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.groupActual = new System.Windows.Forms.GroupBox();
            this.volumeMeter2 = new NAudio.Gui.VolumeMeter();
            this.flowLayoutPanelTimers = new System.Windows.Forms.FlowLayoutPanel();
            this.volumeMeter4 = new NAudio.Gui.VolumeMeter();
            this.panelVuRight = new System.Windows.Forms.Panel();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter3 = new NAudio.Gui.VolumeMeter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelVuLeft = new System.Windows.Forms.Panel();
            this.btnPLay = new System.Windows.Forms.Button();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupActual.SuspendLayout();
            this.flowLayoutPanelTimers.SuspendLayout();
            this.panelVuRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelVuLeft.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Artista";
            this.columnHeader2.Width = 99;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelRemain);
            this.groupBox3.Location = new System.Drawing.Point(130, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(73, 33);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Restant";
            // 
            // labelRemain
            // 
            this.labelRemain.AutoSize = true;
            this.labelRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRemain.Location = new System.Drawing.Point(6, 12);
            this.labelRemain.Name = "labelRemain";
            this.labelRemain.Size = new System.Drawing.Size(64, 18);
            this.labelRemain.TabIndex = 27;
            this.labelRemain.Text = "0:00:000";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCurrentTime);
            this.groupBox2.Location = new System.Drawing.Point(71, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(53, 33);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Passat";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelCurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCurrentTime.Location = new System.Drawing.Point(6, 12);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(36, 18);
            this.labelCurrentTime.TabIndex = 24;
            this.labelCurrentTime.Text = "0:00";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTotalTime);
            this.groupBox1.Location = new System.Drawing.Point(7, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(58, 33);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duracio";
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.AutoSize = true;
            this.labelTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTotalTime.Location = new System.Drawing.Point(6, 12);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(36, 18);
            this.labelTotalTime.TabIndex = 25;
            this.labelTotalTime.Text = "0:00";
            // 
            // groupActual
            // 
            this.groupActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupActual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupActual.Controls.Add(this.groupBox3);
            this.groupActual.Controls.Add(this.groupBox2);
            this.groupActual.Controls.Add(this.groupBox1);
            this.groupActual.Location = new System.Drawing.Point(3, 3);
            this.groupActual.Name = "groupActual";
            this.groupActual.Size = new System.Drawing.Size(207, 62);
            this.groupActual.TabIndex = 28;
            this.groupActual.TabStop = false;
            this.groupActual.Text = "Audio Actual";
            // 
            // volumeMeter2
            // 
            this.volumeMeter2.Amplitude = 0F;
            this.volumeMeter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeMeter2.Location = new System.Drawing.Point(0, 0);
            this.volumeMeter2.Margin = new System.Windows.Forms.Padding(6);
            this.volumeMeter2.MaxDb = -1F;
            this.volumeMeter2.MaximumSize = new System.Drawing.Size(0, 10);
            this.volumeMeter2.MinDb = -60F;
            this.volumeMeter2.MinimumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter2.Name = "volumeMeter2";
            this.volumeMeter2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter2.Size = new System.Drawing.Size(297, 10);
            this.volumeMeter2.TabIndex = 30;
            this.volumeMeter2.Text = "volumeMeter2";
            // 
            // flowLayoutPanelTimers
            // 
            this.flowLayoutPanelTimers.AutoSize = true;
            this.flowLayoutPanelTimers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelTimers.Controls.Add(this.groupActual);
            this.flowLayoutPanelTimers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelTimers.Location = new System.Drawing.Point(0, 112);
            this.flowLayoutPanelTimers.Name = "flowLayoutPanelTimers";
            this.flowLayoutPanelTimers.Size = new System.Drawing.Size(337, 68);
            this.flowLayoutPanelTimers.TabIndex = 31;
            // 
            // volumeMeter4
            // 
            this.volumeMeter4.Amplitude = 0F;
            this.volumeMeter4.Dock = System.Windows.Forms.DockStyle.Right;
            this.volumeMeter4.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter4.Location = new System.Drawing.Point(297, 0);
            this.volumeMeter4.MaxDb = 0.2F;
            this.volumeMeter4.MaximumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter4.MinDb = -1F;
            this.volumeMeter4.MinimumSize = new System.Drawing.Size(40, 10);
            this.volumeMeter4.Name = "volumeMeter4";
            this.volumeMeter4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter4.Size = new System.Drawing.Size(40, 10);
            this.volumeMeter4.TabIndex = 32;
            this.volumeMeter4.Text = "volumeMeter4";
            // 
            // panelVuRight
            // 
            this.panelVuRight.Controls.Add(this.volumeMeter2);
            this.panelVuRight.Controls.Add(this.volumeMeter4);
            this.panelVuRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVuRight.Location = new System.Drawing.Point(0, 29);
            this.panelVuRight.Name = "panelVuRight";
            this.panelVuRight.Size = new System.Drawing.Size(337, 17);
            this.panelVuRight.TabIndex = 32;
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeMeter1.Location = new System.Drawing.Point(0, 0);
            this.volumeMeter1.Margin = new System.Windows.Forms.Padding(6);
            this.volumeMeter1.MaxDb = -1F;
            this.volumeMeter1.MaximumSize = new System.Drawing.Size(0, 10);
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.MinimumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter1.Size = new System.Drawing.Size(297, 10);
            this.volumeMeter1.TabIndex = 30;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // volumeMeter3
            // 
            this.volumeMeter3.Amplitude = 0F;
            this.volumeMeter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.volumeMeter3.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter3.Location = new System.Drawing.Point(297, 0);
            this.volumeMeter3.MaxDb = 0.2F;
            this.volumeMeter3.MaximumSize = new System.Drawing.Size(50, 10);
            this.volumeMeter3.MinDb = -1F;
            this.volumeMeter3.MinimumSize = new System.Drawing.Size(40, 10);
            this.volumeMeter3.Name = "volumeMeter3";
            this.volumeMeter3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter3.Size = new System.Drawing.Size(40, 10);
            this.volumeMeter3.TabIndex = 32;
            this.volumeMeter3.Text = "volumeMeter3";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.volumeMeter1);
            this.panel1.Controls.Add(this.volumeMeter3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 29);
            this.panel1.TabIndex = 33;
            // 
            // panelVuLeft
            // 
            this.panelVuLeft.AutoSize = true;
            this.panelVuLeft.Controls.Add(this.panel1);
            this.panelVuLeft.Controls.Add(this.panelVuRight);
            this.panelVuLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVuLeft.Location = new System.Drawing.Point(0, 0);
            this.panelVuLeft.Name = "panelVuLeft";
            this.panelVuLeft.Size = new System.Drawing.Size(337, 46);
            this.panelVuLeft.TabIndex = 31;
            // 
            // btnPLay
            // 
            this.btnPLay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPLay.BackColor = System.Drawing.SystemColors.Control;
            this.btnPLay.BackgroundImage = global::ControlsLib.Properties.Resources.play;
            this.btnPLay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPLay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPLay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPLay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPLay.Location = new System.Drawing.Point(4, 6);
            this.btnPLay.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPLay.Name = "btnPLay";
            this.btnPLay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPLay.Size = new System.Drawing.Size(71, 54);
            this.btnPLay.TabIndex = 21;
            this.btnPLay.UseVisualStyleBackColor = false;
            this.btnPLay.Click += new System.EventHandler(this.BtnPLay_ClickAsync);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.Controls.Add(this.btnPLay);
            this.flowLayoutPanelButtons.Controls.Add(this.dateTimePicker1);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 46);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(337, 66);
            this.flowLayoutPanelButtons.TabIndex = 33;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(82, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 22;
            // 
            // panelBottom
            // 
            this.panelBottom.AutoSize = true;
            this.panelBottom.Controls.Add(this.flowLayoutPanelButtons);
            this.panelBottom.Controls.Add(this.panelVuLeft);
            this.panelBottom.Controls.Add(this.flowLayoutPanelTimers);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 287);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(337, 180);
            this.panelBottom.TabIndex = 32;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Titol";
            this.columnHeader1.Width = 163;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MinimumSize = new System.Drawing.Size(4, 50);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(337, 467);
            this.listView1.TabIndex = 33;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Continu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.listView1);
            this.Name = "Continu";
            this.Size = new System.Drawing.Size(337, 467);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupActual.ResumeLayout(false);
            this.flowLayoutPanelTimers.ResumeLayout(false);
            this.panelVuRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelVuLeft.ResumeLayout(false);
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelRemain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.GroupBox groupActual;
        private NAudio.Gui.VolumeMeter volumeMeter2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTimers;
        private NAudio.Gui.VolumeMeter volumeMeter4;
        private System.Windows.Forms.Panel panelVuRight;
        private NAudio.Gui.VolumeMeter volumeMeter1;
        private NAudio.Gui.VolumeMeter volumeMeter3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelVuLeft;
        private System.Windows.Forms.Button btnPLay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}
