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

namespace Gelida24
{
    public partial class frm24 : Form
    {
        public frm24()
        {
            InitializeComponent();
            lblTime.Text = GenerarTimeDate();
           
        }
        public int out1 { get; set; }
        public int out2 { get; set; }
        public int out24 { get; set; }
        public int in1 { get; set; }
        public int in2 { get; set; }

        private NAudio.CoreAudioApi.MMDevice device;
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = GenerarTimeDate();
            volumeMeter1.Amplitude = device.AudioMeterInformation.MasterPeakValue;
        }
        private string GenerarTimeDate()
        {
            return DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
    }
}
