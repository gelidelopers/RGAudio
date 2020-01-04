namespace Gelida_Player
{
    partial class frmPlayerSettings
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
            this.groupBoxAudioConf = new System.Windows.Forms.GroupBox();
            this.groupBoxCh2 = new System.Windows.Forms.GroupBox();
            this.comboBoxOut2 = new System.Windows.Forms.ComboBox();
            this.groupBoxCh1 = new System.Windows.Forms.GroupBox();
            this.comboBoxOut1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelSound = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxAudioConf.SuspendLayout();
            this.groupBoxCh2.SuspendLayout();
            this.groupBoxCh1.SuspendLayout();
            this.tableLayoutPanelSound.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAudioConf
            // 
            this.groupBoxAudioConf.Controls.Add(this.tableLayoutPanelSound);
            this.groupBoxAudioConf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAudioConf.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAudioConf.Name = "groupBoxAudioConf";
            this.groupBoxAudioConf.Size = new System.Drawing.Size(265, 115);
            this.groupBoxAudioConf.TabIndex = 1;
            this.groupBoxAudioConf.TabStop = false;
            this.groupBoxAudioConf.Text = "Configuració de so";
            // 
            // groupBoxCh2
            // 
            this.groupBoxCh2.Controls.Add(this.comboBoxOut2);
            this.groupBoxCh2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCh2.Location = new System.Drawing.Point(3, 51);
            this.groupBoxCh2.Name = "groupBoxCh2";
            this.groupBoxCh2.Size = new System.Drawing.Size(253, 42);
            this.groupBoxCh2.TabIndex = 1;
            this.groupBoxCh2.TabStop = false;
            this.groupBoxCh2.Text = "Canal 2";
            // 
            // comboBoxOut2
            // 
            this.comboBoxOut2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxOut2.FormattingEnabled = true;
            this.comboBoxOut2.Location = new System.Drawing.Point(3, 16);
            this.comboBoxOut2.Name = "comboBoxOut2";
            this.comboBoxOut2.Size = new System.Drawing.Size(247, 21);
            this.comboBoxOut2.TabIndex = 0;
            // 
            // groupBoxCh1
            // 
            this.groupBoxCh1.Controls.Add(this.comboBoxOut1);
            this.groupBoxCh1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCh1.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCh1.Name = "groupBoxCh1";
            this.groupBoxCh1.Size = new System.Drawing.Size(253, 42);
            this.groupBoxCh1.TabIndex = 0;
            this.groupBoxCh1.TabStop = false;
            this.groupBoxCh1.Text = "Canal 1";
            // 
            // comboBoxOut1
            // 
            this.comboBoxOut1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxOut1.FormattingEnabled = true;
            this.comboBoxOut1.Location = new System.Drawing.Point(3, 16);
            this.comboBoxOut1.Name = "comboBoxOut1";
            this.comboBoxOut1.Size = new System.Drawing.Size(247, 21);
            this.comboBoxOut1.TabIndex = 0;
            // 
            // tableLayoutPanelSound
            // 
            this.tableLayoutPanelSound.ColumnCount = 1;
            this.tableLayoutPanelSound.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSound.Controls.Add(this.groupBoxCh1, 0, 0);
            this.tableLayoutPanelSound.Controls.Add(this.groupBoxCh2, 0, 1);
            this.tableLayoutPanelSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSound.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanelSound.Name = "tableLayoutPanelSound";
            this.tableLayoutPanelSound.RowCount = 2;
            this.tableLayoutPanelSound.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSound.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelSound.Size = new System.Drawing.Size(259, 96);
            this.tableLayoutPanelSound.TabIndex = 2;
            // 
            // frmPlayerSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 115);
            this.Controls.Add(this.groupBoxAudioConf);
            this.Name = "frmPlayerSettings";
            this.Text = "Configuració del Player";
            this.Load += new System.EventHandler(this.frmPlayerSettings_Load);
            this.groupBoxAudioConf.ResumeLayout(false);
            this.groupBoxCh2.ResumeLayout(false);
            this.groupBoxCh1.ResumeLayout(false);
            this.tableLayoutPanelSound.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAudioConf;
        private System.Windows.Forms.GroupBox groupBoxCh2;
        private System.Windows.Forms.ComboBox comboBoxOut2;
        private System.Windows.Forms.GroupBox groupBoxCh1;
        private System.Windows.Forms.ComboBox comboBoxOut1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSound;
    }
}
