using System;
using WindowsFormsControlLibrary1;
namespace Gelida_Player
{
    public partial class frmPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayer));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.player1 = new ControlsLib.Player();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 689);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(310, 0);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // player1
            // 
            this.player1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player1.Location = new System.Drawing.Point(0, 0);
            this.player1.MinimumSize = new System.Drawing.Size(288, 650);
            this.player1.Name = "player1";
            this.player1.OutDev = new System.Guid("00000000-0000-0000-0000-000000000000");
            this.player1.Size = new System.Drawing.Size(310, 689);
            this.player1.TabIndex = 8;
            this.player1.waveColor = System.Drawing.Color.Empty;
            // 
            // frmPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 689);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(326, 728);
            this.Name = "frmPlayer";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Gelida Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fainal_FormClosing);
            this.Load += new System.EventHandler(this.fainal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPlayer_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ControlsLib.Player player1;
    }
}
