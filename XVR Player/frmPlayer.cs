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

        
        

        public frmPlayer(Guid OutDev)
        {
            InitializeComponent();
            Form esplas = new frmSplash();
            esplas.Show();
            KeyPreview = true;
            //bool value = false;
            //DataSet data;
            // Used to store the return value
            
            var thread = new Thread(
            () =>
            {

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
            player1.OutDev = OutDev;
            //}
            //size.Width = sais;
            //MinimumSize = size;
            player1.StartedPlaying += Player1_StartedPLaying;
        }

        private void Player1_StartedPLaying(object sender, EventArgs e)
        {
            player1.CarregarWaveFormAsync();
        }

        private void fainal_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (player1.isPlaying)
            {

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

        private void frmPlayer_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F3)
            {
                player1.CarregarWaveFormAsync();
            }
        }

        private void bBDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBBDDSettings().Show();
        }
    }
}
