
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;



namespace Gelida_Player
{
    public partial class frmPlayer : Form
    {
        public frmPlayer(string[] args)
        {
            InitializeComponent();
            Form esplas = new frmSplash();
            esplas.Show();
            //bool value = false;
            //DataSet data;
            
            // Used to store the return value
            
            var thread = new Thread(
            () =>
            {
                Size size = new Size(15, 450);
                int sais = size.Width;
                for (byte i = 0; i <= Gelida_Player.Properties.Settings.Default.Players; i++)
                {
                    ListPlayer lp = new ListPlayer();
                    if ((i + 1) % 2 == 0)
                    {
                        lp.outDev = Properties.Settings.Default.OutputDev2;
                    }
                    else
                    {
                        lp.outDev = Properties.Settings.Default.OutputDev1;
                    }
                    lp.Dock = DockStyle.Fill;
                    lp.AutoSize = true;
                    lp.AutoSizeMode = AutoSizeMode.GrowOnly;
                    lp.Padding = new Padding(5);
                    //panel1.Controls.Add(lp);
                }
                //value = true; // Publish the return value
            });
            
            var t2 = new Thread(
            () =>
            {


                
            
            });
            thread.Start();
            t2.Start();
            //thread.Join();
            thread.Join();
            //thread.Join();
            

            esplas.Close();
            //foreach (Control ctr in GetAll(this, typeof(ListPlayer)))
            //{
                

            //    sais += (ctr.MinimumSize.Width);

            //}
            //size.Width = sais;
            //MinimumSize = size;

        }

        private void fainal_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool willClose = true;
            
            foreach(ListPlayer lp in GetAll(this, typeof(ListPlayer)))
            {
                
                  if(lp.isPlaying)
                  {
                        willClose = false;
                        break;
                  }
                
            }
            if (!willClose) {
                var window = MessageBox.Show(
                "Close the window?",
                "Are you sure?",
                MessageBoxButtons.YesNo);

                e.Cancel = (window == DialogResult.No);
            }
            
        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void fainal_Load(object sender, EventArgs e)
        {

           // fainal.ActiveForm.MaximumSize = listPlayer1.MaximumSize + listPlayer2.MaximumSize + listPlayer3.MaximumSize + listPlayer4.MaximumSize;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAbout();
            form.Show();
        }
    }
}
