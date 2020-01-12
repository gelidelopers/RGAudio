using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RAudioControls
{
    public partial class RAudioProgressBar : UserControl
    {
        public RAudioProgressBar()
        {
            InitializeComponent();
        }
        public int Progress 
        { 
            get 
            {
                return progressBar1.Value; 
            } 
            set 
            {
                progressBar1.Value = value;
                label1.Text = progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();
            } 
        }
        public int Maximum
        {
            get
            {
                return progressBar1.Maximum;
            }
            set
            {
                progressBar1.Maximum = value;
                label1.Text = progressBar1.Value.ToString() + "/" + progressBar1.Maximum.ToString();
            }
        }
    }
}
