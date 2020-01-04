using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;
using RAudioUtils;

namespace Gelida_Player
{
    public partial class frmPlayerSettings : Form
    {
        private int Out1Index, Out2Index;
        public frmPlayerSettings()
        {
            InitializeComponent();
        }

        private void comboBoxOut1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Out1Index = comboBoxOut1.SelectedIndex;
            Properties.Settings.Default["OutputDev1"] = Out1Index - 1;
            Properties.Settings.Default.Save();
        }

        private void comboBoxOut2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Out2Index = comboBoxOut2.SelectedIndex;
            Properties.Settings.Default["OutputDev2"] = Out2Index - 1;
            Properties.Settings.Default.Save();
        }

        private void frmPlayerSettings_Load(object sender, EventArgs e)
        {
            comboBoxOut1.Items.Add("Per defecte de windows");
            comboBoxOut2.Items.Add("Per defecte de windows");
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                comboBoxOut1.Items.Add(WaveOut.GetCapabilities(i).ProductName);
                comboBoxOut2.Items.Add(WaveOut.GetCapabilities(i).ProductName);
            }
            Out1Index = ((int) Properties.Settings.Default["OutputDev1"]) + 1;
            Out2Index = ((int)Properties.Settings.Default["OutputDev2"]) + 1;

            if (Out1Index.IsInRange(comboBoxOut1.Items.Count))
            {
                comboBoxOut1.SelectedIndex = Out1Index;
            }
            if (Out2Index.IsInRange(comboBoxOut2.Items.Count))
            {
                comboBoxOut2.SelectedIndex = Out2Index;
            }

            comboBoxOut1.SelectedIndexChanged += comboBoxOut1_SelectedIndexChanged;
            comboBoxOut2.SelectedIndexChanged += comboBoxOut2_SelectedIndexChanged;
        }


    }
}
