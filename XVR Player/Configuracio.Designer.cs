namespace Gelida_Player
{
    partial class Configuracio
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSaveAudio = new System.Windows.Forms.Button();
            this.selectIn2 = new ControlsLib.DeviceSelector();
            this.selectIn1 = new ControlsLib.DeviceSelector();
            this.selectOut2 = new ControlsLib.DeviceSelector();
            this.selectOut1 = new ControlsLib.DeviceSelector();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.devOut1 = new ControlsLib.DeviceSelector();
            this.deviceSelector2 = new ControlsLib.DeviceSelector();
            this.deviceSelectorOut1 = new ControlsLib.DeviceSelector();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(422, 227);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSaveAudio);
            this.tabPage1.Controls.Add(this.selectIn2);
            this.tabPage1.Controls.Add(this.selectIn1);
            this.tabPage1.Controls.Add(this.selectOut2);
            this.tabPage1.Controls.Add(this.selectOut1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(414, 201);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "So";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSaveAudio
            // 
            this.btnSaveAudio.Location = new System.Drawing.Point(331, 170);
            this.btnSaveAudio.Name = "btnSaveAudio";
            this.btnSaveAudio.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAudio.TabIndex = 4;
            this.btnSaveAudio.Text = "Guardar";
            this.btnSaveAudio.UseVisualStyleBackColor = true;
            this.btnSaveAudio.Click += new System.EventHandler(this.BtnSaveAudio_Click);
            // 
            // selectIn2
            // 
            this.selectIn2.Location = new System.Drawing.Point(8, 102);
            this.selectIn2.Name = "selectIn2";
            this.selectIn2.Size = new System.Drawing.Size(403, 26);
            this.selectIn2.TabIndex = 3;
            this.selectIn2.Title = "Grabacio 2";
            // 
            // selectIn1
            // 
            this.selectIn1.Location = new System.Drawing.Point(8, 70);
            this.selectIn1.Name = "selectIn1";
            this.selectIn1.Size = new System.Drawing.Size(403, 26);
            this.selectIn1.TabIndex = 2;
            this.selectIn1.Title = "Grabacio 1";
            // 
            // selectOut2
            // 
            this.selectOut2.Location = new System.Drawing.Point(8, 38);
            this.selectOut2.Name = "selectOut2";
            this.selectOut2.Size = new System.Drawing.Size(403, 26);
            this.selectOut2.TabIndex = 1;
            this.selectOut2.Title = "Canal 2";
            // 
            // selectOut1
            // 
            this.selectOut1.Location = new System.Drawing.Point(8, 6);
            this.selectOut1.Name = "selectOut1";
            this.selectOut1.Size = new System.Drawing.Size(403, 26);
            this.selectOut1.TabIndex = 0;
            this.selectOut1.Title = "Canal 1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(303, 201);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // devOut1
            // 
            this.devOut1.Location = new System.Drawing.Point(8, 6);
            this.devOut1.Name = "devOut1";
            this.devOut1.Size = new System.Drawing.Size(287, 26);
            this.devOut1.TabIndex = 0;
            this.devOut1.Title = "Canal 1";
            // 
            // deviceSelector2
            // 
            this.deviceSelector2.Location = new System.Drawing.Point(8, 38);
            this.deviceSelector2.Name = "deviceSelector2";
            this.deviceSelector2.Size = new System.Drawing.Size(287, 26);
            this.deviceSelector2.TabIndex = 1;
            this.deviceSelector2.Title = "Canal 2";
            // 
            // deviceSelectorOut1
            // 
            this.deviceSelectorOut1.Location = new System.Drawing.Point(8, 6);
            this.deviceSelectorOut1.Name = "deviceSelectorOut1";
            this.deviceSelectorOut1.Size = new System.Drawing.Size(287, 26);
            this.deviceSelectorOut1.TabIndex = 0;
            this.deviceSelectorOut1.Title = "Canal 1";
            // 
            // Configuracio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 227);
            this.Controls.Add(this.tabControl1);
            this.Name = "Configuracio";
            this.Text = "Configuracio";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ControlsLib.DeviceSelector selectOut1;
        private System.Windows.Forms.Button btnSaveAudio;
        private ControlsLib.DeviceSelector selectIn2;
        private ControlsLib.DeviceSelector selectIn1;
        private ControlsLib.DeviceSelector selectOut2;
        private ControlsLib.DeviceSelector devOut1;
        private ControlsLib.DeviceSelector deviceSelector2;
        private ControlsLib.DeviceSelector deviceSelectorOut1;
    }
}
