﻿namespace ControlsLib
{
    partial class Player
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelRemain = new System.Windows.Forms.Label();
            this.groupActual = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPLay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnFolder = new System.Windows.Forms.Button();
            this.btnContinu = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.panelVuLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter3 = new NAudio.Gui.VolumeMeter();
            this.panelVuRight = new System.Windows.Forms.Panel();
            this.volumeMeter2 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter4 = new NAudio.Gui.VolumeMeter();
            this.flowLayoutPanelTimers = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dropBetweenList1 = new ControlsLib.DropBetweenList();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupActual.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.panelVuLeft.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelVuRight.SuspendLayout();
            this.flowLayoutPanelTimers.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelCurrentTime);
            this.groupBox2.Location = new System.Drawing.Point(89, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(65, 42);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Passat";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelCurrentTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCurrentTime.Location = new System.Drawing.Point(6, 18);
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
            this.groupBox1.Size = new System.Drawing.Size(76, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duracio";
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.AutoSize = true;
            this.labelTotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelTotalTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTotalTime.Location = new System.Drawing.Point(6, 18);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(36, 18);
            this.labelTotalTime.TabIndex = 25;
            this.labelTotalTime.Text = "0:00";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelRemain);
            this.groupBox3.Location = new System.Drawing.Point(159, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(86, 41);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Restant";
            // 
            // labelRemain
            // 
            this.labelRemain.AutoSize = true;
            this.labelRemain.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRemain.Location = new System.Drawing.Point(8, 17);
            this.labelRemain.Name = "labelRemain";
            this.labelRemain.Size = new System.Drawing.Size(64, 18);
            this.labelRemain.TabIndex = 27;
            this.labelRemain.Text = "0:00:000";
            // 
            // groupActual
            // 
            this.groupActual.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupActual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupActual.Controls.Add(this.groupBox3);
            this.groupActual.Controls.Add(this.groupBox2);
            this.groupActual.Controls.Add(this.groupBox1);
            this.groupActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupActual.Location = new System.Drawing.Point(3, 3);
            this.groupActual.Name = "groupActual";
            this.groupActual.Size = new System.Drawing.Size(253, 68);
            this.groupActual.TabIndex = 28;
            this.groupActual.TabStop = false;
            this.groupActual.Text = "Audio Actual";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panelBottom
            // 
            this.panelBottom.AutoSize = true;
            this.panelBottom.Controls.Add(this.trackBarPosition);
            this.panelBottom.Controls.Add(this.flowLayoutPanelButtons);
            this.panelBottom.Controls.Add(this.panelVuLeft);
            this.panelBottom.Controls.Add(this.flowLayoutPanelTimers);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 373);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(288, 277);
            this.panelBottom.TabIndex = 32;
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarPosition.Location = new System.Drawing.Point(0, 46);
            this.trackBarPosition.Maximum = 100;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(288, 45);
            this.trackBarPosition.TabIndex = 1;
            this.trackBarPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrackBarPosition_MouseDown);
            this.trackBarPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TrackBarPosition_MouseUp);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.Controls.Add(this.btnPLay);
            this.flowLayoutPanelButtons.Controls.Add(this.btnPause);
            this.flowLayoutPanelButtons.Controls.Add(this.btnStop);
            this.flowLayoutPanelButtons.Controls.Add(this.btnFolder);
            this.flowLayoutPanelButtons.Controls.Add(this.btnContinu);
            this.flowLayoutPanelButtons.Controls.Add(this.btnLoop);
            this.flowLayoutPanelButtons.Controls.Add(this.btnBorrar);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 91);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(288, 112);
            this.flowLayoutPanelButtons.TabIndex = 33;
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
            this.btnPLay.Click += new System.EventHandler(this.BtnPLay_Click);
            // 
            // btnPause
            // 
            this.btnPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPause.BackgroundImage = global::ControlsLib.Properties.Resources.pause;
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(83, 6);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(56, 45);
            this.btnPause.TabIndex = 28;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStop.BackgroundImage = global::ControlsLib.Properties.Resources.stop;
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(147, 6);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(49, 45);
            this.btnStop.TabIndex = 22;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnFolder
            // 
            this.btnFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFolder.BackgroundImage = global::ControlsLib.Properties.Resources.addfolder;
            this.btnFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.flowLayoutPanelButtons.SetFlowBreak(this.btnFolder, true);
            this.btnFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolder.Location = new System.Drawing.Point(204, 6);
            this.btnFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(52, 45);
            this.btnFolder.TabIndex = 23;
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.OnAddFolderButtonClick);
            // 
            // btnContinu
            // 
            this.btnContinu.AutoSize = true;
            this.btnContinu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnContinu.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnContinu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContinu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinu.Location = new System.Drawing.Point(4, 72);
            this.btnContinu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnContinu.Name = "btnContinu";
            this.btnContinu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnContinu.Size = new System.Drawing.Size(85, 34);
            this.btnContinu.TabIndex = 29;
            this.btnContinu.Text = "Continu";
            this.btnContinu.UseVisualStyleBackColor = false;
            this.btnContinu.Click += new System.EventHandler(this.BtnContinu_Click);
            // 
            // btnLoop
            // 
            this.btnLoop.AutoSize = true;
            this.btnLoop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoop.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoop.Location = new System.Drawing.Point(97, 72);
            this.btnLoop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLoop.Size = new System.Drawing.Size(68, 34);
            this.btnLoop.TabIndex = 32;
            this.btnLoop.Text = "Bucle";
            this.btnLoop.UseVisualStyleBackColor = false;
            this.btnLoop.Click += new System.EventHandler(this.BtnLoop_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.AutoSize = true;
            this.btnBorrar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBorrar.BackColor = System.Drawing.Color.Red;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(173, 72);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(71, 34);
            this.btnBorrar.TabIndex = 30;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // panelVuLeft
            // 
            this.panelVuLeft.AutoSize = true;
            this.panelVuLeft.Controls.Add(this.panel1);
            this.panelVuLeft.Controls.Add(this.panelVuRight);
            this.panelVuLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVuLeft.Location = new System.Drawing.Point(0, 0);
            this.panelVuLeft.Name = "panelVuLeft";
            this.panelVuLeft.Size = new System.Drawing.Size(288, 46);
            this.panelVuLeft.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.volumeMeter1);
            this.panel1.Controls.Add(this.volumeMeter3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 29);
            this.panel1.TabIndex = 33;
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
            this.volumeMeter1.Size = new System.Drawing.Size(50, 10);
            this.volumeMeter1.TabIndex = 30;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // volumeMeter3
            // 
            this.volumeMeter3.Amplitude = 0F;
            this.volumeMeter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.volumeMeter3.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter3.Location = new System.Drawing.Point(248, 0);
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
            // panelVuRight
            // 
            this.panelVuRight.Controls.Add(this.volumeMeter2);
            this.panelVuRight.Controls.Add(this.volumeMeter4);
            this.panelVuRight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelVuRight.Location = new System.Drawing.Point(0, 29);
            this.panelVuRight.Name = "panelVuRight";
            this.panelVuRight.Size = new System.Drawing.Size(288, 17);
            this.panelVuRight.TabIndex = 32;
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
            this.volumeMeter2.Size = new System.Drawing.Size(50, 10);
            this.volumeMeter2.TabIndex = 30;
            this.volumeMeter2.Text = "volumeMeter2";
            // 
            // volumeMeter4
            // 
            this.volumeMeter4.Amplitude = 0F;
            this.volumeMeter4.Dock = System.Windows.Forms.DockStyle.Right;
            this.volumeMeter4.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter4.Location = new System.Drawing.Point(248, 0);
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
            // flowLayoutPanelTimers
            // 
            this.flowLayoutPanelTimers.AutoSize = true;
            this.flowLayoutPanelTimers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelTimers.Controls.Add(this.groupActual);
            this.flowLayoutPanelTimers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelTimers.Location = new System.Drawing.Point(0, 203);
            this.flowLayoutPanelTimers.Name = "flowLayoutPanelTimers";
            this.flowLayoutPanelTimers.Size = new System.Drawing.Size(288, 74);
            this.flowLayoutPanelTimers.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 273);
            this.panel2.MaximumSize = new System.Drawing.Size(1920, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 100);
            this.panel2.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 43);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(1920, 60);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(0, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(288, 57);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 53);
            this.panel3.TabIndex = 2;
            // 
            // dropBetweenList1
            // 
            this.dropBetweenList1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dropBetweenList1.Location = new System.Drawing.Point(0, 0);
            this.dropBetweenList1.Name = "dropBetweenList1";
            this.dropBetweenList1.Size = new System.Drawing.Size(288, 273);
            this.dropBetweenList1.TabIndex = 33;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dropBetweenList1);
            this.Controls.Add(this.panelBottom);
            this.MinimumSize = new System.Drawing.Size(288, 650);
            this.Name = "Player";
            this.Size = new System.Drawing.Size(288, 650);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupActual.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelButtons.PerformLayout();
            this.panelVuLeft.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelVuRight.ResumeLayout(false);
            this.flowLayoutPanelTimers.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnPLay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label labelRemain;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button btnContinu;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.GroupBox groupActual;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Panel panelVuLeft;
        private System.Windows.Forms.Panel panel1;
        private NAudio.Gui.VolumeMeter volumeMeter1;
        private NAudio.Gui.VolumeMeter volumeMeter3;
        private System.Windows.Forms.Panel panelVuRight;
        private NAudio.Gui.VolumeMeter volumeMeter2;
        private NAudio.Gui.VolumeMeter volumeMeter4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTimers;
        public DropBetweenList dropBetweenList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
    }
}
