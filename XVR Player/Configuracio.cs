using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlsLib;

namespace Gelida_Player
{
    public partial class Configuracio : Form
    {
        public Configuracio()
        {
            InitializeComponent();

            audioDevConfig = Utils.GetAudioDevConfig("nomano.xml");

            selectIn1.SelectedDevice   =     audioDevConfig.In1Number   ;
            selectIn2.SelectedDevice   =     audioDevConfig.In2Number   ;
            selectOut1.SelectedDevice  =     audioDevConfig.Out1Number  ;
            selectOut2.SelectedDevice  =     audioDevConfig.Out2Number  ;

        }
        public Models.AudioDevConfig audioDevConfig { get; set; }

        private void BtnSaveAudio_Click(object sender, EventArgs e)
        {
            audioDevConfig.In1Number = selectIn1.SelectedDevice;
            audioDevConfig.In2Number = selectIn2.SelectedDevice;
            audioDevConfig.Out1Number = selectOut1.SelectedDevice;
            audioDevConfig.Out2Number = selectOut2.SelectedDevice;
            Utils.SetAudioDevConfig(audioDevConfig, "nomano.xml");
        }
    }
}
