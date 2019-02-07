using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using NAudio.CoreAudioApi;

namespace Gelida_Recorder
{
    public partial class Form1 : MaterialForm
    {
        private MMDeviceEnumerator enumerator;
        private MMDeviceCollection wiw;
        private MMDevice caca;

        public Form1()
        {
            InitializeComponent();
            enumerator = new MMDeviceEnumerator();
            try
            {

                wiw = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);


                caca = (MMDevice)wiw.First();
                timer1.Start();
            }

            catch
            {
                MessageBox.Show("no s'ha detectat cap dispositiu de so");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            volumeMeter1.Amplitude = caca.AudioMeterInformation.PeakValues[0];
            volumeMeter2.Amplitude = caca.AudioMeterInformation.PeakValues[0];
            volumeMeter3.Amplitude = caca.AudioMeterInformation.PeakValues[0];
            volumeMeter4.Amplitude = caca.AudioMeterInformation.PeakValues[1];
            volumeMeter5.Amplitude = caca.AudioMeterInformation.PeakValues[1];
            volumeMeter6.Amplitude = caca.AudioMeterInformation.PeakValues[1];

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            lblGrabant.Text = "GRAVANT...";
            
        }
    }
}
