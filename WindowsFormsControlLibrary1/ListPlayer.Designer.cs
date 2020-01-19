namespace RAudioControls
{
    partial class ListPlayer
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListPlayer));
            this.labelRemain = new System.Windows.Forms.Label();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelBottom = new System.Windows.Forms.Panel();
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPLay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnDB = new System.Windows.Forms.Button();
            this.materialFlatButton3 = new System.Windows.Forms.Button();
            this.groupBoxOnFinish = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnContinuar = new RAudioControls.RAudioButton();
            this.btnDel = new RAudioControls.RAudioButton();
            this.btnCross = new RAudioControls.RAudioButton();
            this.btnLoop = new RAudioControls.RAudioButton();
            this.panelVuLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter3 = new NAudio.Gui.VolumeMeter();
            this.panelVuRight = new System.Windows.Forms.Panel();
            this.volumeMeter2 = new NAudio.Gui.VolumeMeter();
            this.volumeMeter4 = new NAudio.Gui.VolumeMeter();
            this.flowLayoutPanelTimers = new System.Windows.Forms.FlowLayoutPanel();
            this.groupActual = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTipDesen = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buidarLlistaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropListView1 = new RAudioControls.DropListView();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.groupBoxOnFinish.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelVuLeft.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelVuRight.SuspendLayout();
            this.flowLayoutPanelTimers.SuspendLayout();
            this.groupActual.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStripSelected.SuspendLayout();
            this.contextMenuStripList.SuspendLayout();
            this.SuspendLayout();
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
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.OnTimerTick);
            // 
            // panelBottom
            // 
            this.panelBottom.AutoSize = true;
            this.panelBottom.Controls.Add(this.trackBarPosition);
            this.panelBottom.Controls.Add(this.flowLayoutPanelButtons);
            this.panelBottom.Controls.Add(this.panelVuLeft);
            this.panelBottom.Controls.Add(this.flowLayoutPanelTimers);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 209);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(421, 291);
            this.panelBottom.TabIndex = 30;
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarPosition.Location = new System.Drawing.Point(0, 46);
            this.trackBarPosition.Maximum = 100;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(421, 45);
            this.trackBarPosition.TabIndex = 1;
            this.trackBarPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseDown);
            this.trackBarPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseUp);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.Controls.Add(this.btnPLay);
            this.flowLayoutPanelButtons.Controls.Add(this.btnPause);
            this.flowLayoutPanelButtons.Controls.Add(this.btnStop);
            this.flowLayoutPanelButtons.Controls.Add(this.btnNext);
            this.flowLayoutPanelButtons.Controls.Add(this.btnDB);
            this.flowLayoutPanelButtons.Controls.Add(this.materialFlatButton3);
            this.flowLayoutPanelButtons.Controls.Add(this.groupBoxOnFinish);
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(0, 91);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(421, 132);
            this.flowLayoutPanelButtons.TabIndex = 33;
            // 
            // btnPLay
            // 
            this.btnPLay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPLay.BackColor = System.Drawing.SystemColors.Control;
            this.btnPLay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPLay.BackgroundImage")));
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
            this.btnPLay.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // btnPause
            // 
            this.btnPause.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPause.BackgroundImage")));
            this.btnPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPause.Location = new System.Drawing.Point(83, 6);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(56, 45);
            this.btnPause.TabIndex = 28;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.OnButtonPauseClick);
            // 
            // btnStop
            // 
            this.btnStop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Location = new System.Drawing.Point(147, 6);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(49, 45);
            this.btnStop.TabIndex = 22;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.OnButtonStopClick);
            // 
            // btnNext
            // 
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNext.BackgroundImage")));
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(204, 6);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(44, 45);
            this.btnNext.TabIndex = 31;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnDB
            // 
            this.btnDB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDB.BackgroundImage")));
            this.btnDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.Location = new System.Drawing.Point(256, 6);
            this.btnDB.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(52, 45);
            this.btnDB.TabIndex = 33;
            this.btnDB.UseVisualStyleBackColor = true;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("materialFlatButton3.BackgroundImage")));
            this.materialFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.materialFlatButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.flowLayoutPanelButtons.SetFlowBreak(this.materialFlatButton3, true);
            this.materialFlatButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialFlatButton3.Location = new System.Drawing.Point(316, 6);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Size = new System.Drawing.Size(52, 45);
            this.materialFlatButton3.TabIndex = 23;
            this.materialFlatButton3.UseVisualStyleBackColor = true;
            this.materialFlatButton3.Click += new System.EventHandler(this.OnOpenFileClick);
            // 
            // groupBoxOnFinish
            // 
            this.groupBoxOnFinish.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxOnFinish.Location = new System.Drawing.Point(2, 68);
            this.groupBoxOnFinish.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxOnFinish.Name = "groupBoxOnFinish";
            this.groupBoxOnFinish.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxOnFinish.Size = new System.Drawing.Size(366, 62);
            this.groupBoxOnFinish.TabIndex = 38;
            this.groupBoxOnFinish.TabStop = false;
            this.groupBoxOnFinish.Text = "Al acabar àudio actual";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnContinuar);
            this.flowLayoutPanel1.Controls.Add(this.btnDel);
            this.flowLayoutPanel1.Controls.Add(this.btnCross);
            this.flowLayoutPanel1.Controls.Add(this.btnLoop);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(362, 45);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Active = true;
            this.btnContinuar.ActiveColor = System.Drawing.Color.DodgerBlue;
            this.btnContinuar.AutoSize = true;
            this.btnContinuar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.Location = new System.Drawing.Point(4, 6);
            this.btnContinuar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(81, 34);
            this.btnContinuar.TabIndex = 34;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UnactiveColor = System.Drawing.Color.Transparent;
            this.btnContinuar.UseVisualStyleBackColor = false;
            // 
            // btnDel
            // 
            this.btnDel.Active = true;
            this.btnDel.ActiveColor = System.Drawing.Color.Red;
            this.btnDel.AutoSize = true;
            this.btnDel.BackColor = System.Drawing.Color.Red;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(93, 6);
            this.btnDel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(59, 34);
            this.btnDel.TabIndex = 37;
            this.btnDel.Text = "Borrar";
            this.btnDel.UnactiveColor = System.Drawing.Color.Transparent;
            this.btnDel.UseVisualStyleBackColor = false;
            // 
            // btnCross
            // 
            this.btnCross.Active = true;
            this.btnCross.ActiveColor = System.Drawing.Color.LawnGreen;
            this.btnCross.AutoSize = true;
            this.btnCross.BackColor = System.Drawing.Color.LawnGreen;
            this.btnCross.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCross.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCross.Location = new System.Drawing.Point(160, 6);
            this.btnCross.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCross.Name = "btnCross";
            this.btnCross.Size = new System.Drawing.Size(83, 34);
            this.btnCross.TabIndex = 36;
            this.btnCross.Text = "Crossfade";
            this.btnCross.UnactiveColor = System.Drawing.Color.Transparent;
            this.btnCross.UseVisualStyleBackColor = false;
            // 
            // btnLoop
            // 
            this.btnLoop.Active = true;
            this.btnLoop.ActiveColor = System.Drawing.Color.LightBlue;
            this.btnLoop.AutoSize = true;
            this.btnLoop.BackColor = System.Drawing.Color.LightBlue;
            this.btnLoop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoop.Location = new System.Drawing.Point(251, 6);
            this.btnLoop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(55, 34);
            this.btnLoop.TabIndex = 35;
            this.btnLoop.Text = "Bucle";
            this.btnLoop.UnactiveColor = System.Drawing.Color.Transparent;
            this.btnLoop.UseVisualStyleBackColor = false;
            // 
            // panelVuLeft
            // 
            this.panelVuLeft.AutoSize = true;
            this.panelVuLeft.Controls.Add(this.panel1);
            this.panelVuLeft.Controls.Add(this.panelVuRight);
            this.panelVuLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVuLeft.Location = new System.Drawing.Point(0, 0);
            this.panelVuLeft.Name = "panelVuLeft";
            this.panelVuLeft.Size = new System.Drawing.Size(421, 46);
            this.panelVuLeft.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.volumeMeter1);
            this.panel1.Controls.Add(this.volumeMeter3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 29);
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
            this.volumeMeter1.Size = new System.Drawing.Size(381, 10);
            this.volumeMeter1.TabIndex = 30;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // volumeMeter3
            // 
            this.volumeMeter3.Amplitude = 0F;
            this.volumeMeter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.volumeMeter3.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter3.Location = new System.Drawing.Point(381, 0);
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
            this.panelVuRight.Size = new System.Drawing.Size(421, 17);
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
            this.volumeMeter2.Size = new System.Drawing.Size(381, 10);
            this.volumeMeter2.TabIndex = 30;
            this.volumeMeter2.Text = "volumeMeter2";
            // 
            // volumeMeter4
            // 
            this.volumeMeter4.Amplitude = 0F;
            this.volumeMeter4.Dock = System.Windows.Forms.DockStyle.Right;
            this.volumeMeter4.ForeColor = System.Drawing.Color.Red;
            this.volumeMeter4.Location = new System.Drawing.Point(381, 0);
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
            this.flowLayoutPanelTimers.Location = new System.Drawing.Point(0, 223);
            this.flowLayoutPanelTimers.Name = "flowLayoutPanelTimers";
            this.flowLayoutPanelTimers.Size = new System.Drawing.Size(421, 68);
            this.flowLayoutPanelTimers.TabIndex = 31;
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
            this.groupActual.Size = new System.Drawing.Size(211, 62);
            this.groupActual.TabIndex = 28;
            this.groupActual.TabStop = false;
            this.groupActual.Text = "Audio Actual";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelRemain);
            this.groupBox3.Location = new System.Drawing.Point(130, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(72, 33);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Restant";
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
            // toolTipDesen
            // 
            this.toolTipDesen.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipDesen.ToolTipTitle = "Funcionalitat en desenvolupament";
            // 
            // contextMenuStripSelected
            // 
            this.contextMenuStripSelected.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuDelete});
            this.contextMenuStripSelected.Name = "contextMenuStrip1";
            this.contextMenuStripSelected.Size = new System.Drawing.Size(107, 26);
            // 
            // toolStripMenuDelete
            // 
            this.toolStripMenuDelete.Name = "toolStripMenuDelete";
            this.toolStripMenuDelete.Size = new System.Drawing.Size(106, 22);
            this.toolStripMenuDelete.Text = "Borrar";
            this.toolStripMenuDelete.Click += new System.EventHandler(this.toolStripMenuDelete_Click);
            // 
            // contextMenuStripList
            // 
            this.contextMenuStripList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buidarLlistaToolStripMenuItem});
            this.contextMenuStripList.Name = "contextMenuStripList";
            this.contextMenuStripList.Size = new System.Drawing.Size(136, 26);
            // 
            // buidarLlistaToolStripMenuItem
            // 
            this.buidarLlistaToolStripMenuItem.Name = "buidarLlistaToolStripMenuItem";
            this.buidarLlistaToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.buidarLlistaToolStripMenuItem.Text = "Buidar llista";
            this.buidarLlistaToolStripMenuItem.Click += new System.EventHandler(this.buidarLlistaToolStripMenuItem_Click);
            // 
            // dropListView1
            // 
            this.dropListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dropListView1.Index = 0;
            this.dropListView1.Location = new System.Drawing.Point(0, 0);
            this.dropListView1.Margin = new System.Windows.Forms.Padding(4);
            this.dropListView1.Name = "dropListView1";
            this.dropListView1.Size = new System.Drawing.Size(421, 209);
            this.dropListView1.TabIndex = 31;
            // 
            // ListPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dropListView1);
            this.Controls.Add(this.panelBottom);
            this.MaximumSize = new System.Drawing.Size(800, 45000);
            this.MinimumSize = new System.Drawing.Size(270, 500);
            this.Name = "ListPlayer";
            this.Size = new System.Drawing.Size(421, 500);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.groupBoxOnFinish.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelVuLeft.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelVuRight.ResumeLayout(false);
            this.flowLayoutPanelTimers.ResumeLayout(false);
            this.groupActual.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStripSelected.ResumeLayout(false);
            this.contextMenuStripList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label labelRemain;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Button materialFlatButton3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPLay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelBottom;
        private NAudio.Gui.VolumeMeter volumeMeter3;
        private NAudio.Gui.VolumeMeter volumeMeter1;
        private System.Windows.Forms.Panel panelVuLeft;
        private System.Windows.Forms.Panel panelVuRight;
        private NAudio.Gui.VolumeMeter volumeMeter2;
        private NAudio.Gui.VolumeMeter volumeMeter4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTimers;
        private System.Windows.Forms.ToolTip toolTipDesen;
        private System.Windows.Forms.GroupBox groupActual;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSelected;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripList;
        private System.Windows.Forms.ToolStripMenuItem buidarLlistaToolStripMenuItem;
        private DropListView dropListView1;
        private RAudioButton btnContinuar;
        private RAudioButton btnLoop;
        private RAudioButton btnCross;
        private RAudioButton btnDel;
        private System.Windows.Forms.GroupBox groupBoxOnFinish;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
