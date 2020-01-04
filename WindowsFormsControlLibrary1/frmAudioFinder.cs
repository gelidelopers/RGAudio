using MySql.Data.MySqlClient;
using RAudioDataAccess;
using RAudioDataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XVRImport;

namespace Gelida_Player
{
    public partial class frmAudioFinder : Form
    {
        
        public frmAudioFinder()
        {
            InitializeComponent();

        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                List<string> args = new List<string>
                {
                    "song",
                    ""
                };
                args.AddRange(files);

                

                frmImport frmImport = new frmImport(args.ToArray());
                frmImport.Show();
               
            }

        }

        

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;
                }
        }
    }
}
