using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.CoreAudioApi;

namespace Gelida24
{
    public partial class frm24 : Form
    {
        public frm24()
        {
            InitializeComponent();
            lblTime.Text = GenerarTimeDate();

        }
        public int Out1 { get; set; }
        public int Out2 { get; set; }
        public int Out24 { get; set; }
        public int In1 { get; set; }
        public int In2 { get; set; }
        public string Out1name { get; set; }

        
        //foreach que recorri tots els enumerator i els compari amb el string del nom i afegeixi cada mmdevice

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = GenerarTimeDate();
        }
        private string GenerarTimeDate()
        {
            return DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void Frm24_Load(object sender, EventArgs e)
        {
            continu1.CrearTasca();
            
            continu1.AfegirArxiu();
            continu1.PlaySong();
            gravadorContinu1.RecordMP3 = true;
            try
            {
                gravadorContinu1.StartRecording();
                MessageBox.Show("recording");
            }
            catch
            {
                MessageBox.Show("Error 5: ", "No s'ha pogut inicialitzar la gravació");
            }
        }

        private void InformacióDelProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new AboutRG24();
            frmAbout.Show();
            
        }

        private void Frm24_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                gravadorContinu1.StopRecording();
                MessageBox.Show("recording stopped");
            
        }




        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //  
        // progressBar1.Value = (int)(Math.Round(caca.AudioMeterInformation.MasterPeakValue * 100));
        //    //volumeMeter1.Amplitude = caca.AudioMeterInformation.MasterPeakValue;
        //}
    }
}
