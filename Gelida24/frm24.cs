﻿using System;
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
            enumerator = new NAudio.CoreAudioApi.MMDeviceEnumerator();

            wiw = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);

            caca = (MMDevice) wiw.First();
            

        }
        public int out1 { get; set; }
        public int out2 { get; set; }
        public int out24 { get; set; }
        public int in1 { get; set; }
        public int in2 { get; set; }

        public MMDeviceCollection wiw;
        MMDevice caca;



        private NAudio.CoreAudioApi.MMDeviceEnumerator enumerator;
        
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = GenerarTimeDate();
            volumeMeter1.Amplitude = caca.AudioMeterInformation.MasterPeakValue;

            
                
                volumeMeter1.Amplitude = (int)(Math.Round(caca.AudioMeterInformation.MasterPeakValue * 100));
            


        }
        private string GenerarTimeDate()
        {
            return DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }
    }
}
