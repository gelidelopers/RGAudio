using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gelida_Player
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            try
            {
                lblVersio.Text = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {

            }
        }
    }
}
