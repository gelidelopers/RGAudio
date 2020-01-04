using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XVRImport
{
    public partial class frmImport : Form
    {
        private string tipus, categoria;
        public frmImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem it in listView1.Items)
            {
                string mp3gainPath = Path.Combine("C:\\Program Files (x86)\\MP3Gain", "mp3gain.exe");
                var proc = System.Diagnostics.Process.Start(mp3gainPath, it.Text);

                proc.OutputDataReceived += Proc_OutputDataReceived;
                proc.WaitForExit();
            }
        }

        private void Proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            label1.Text = e.Data;
        }

        public frmImport(string [] args)
        {
            InitializeComponent();
            for (int i = 2; i > args.Count(); i++) 
            {
                listView1.Items.Add(args[i]);
            }
        }
    }
}
