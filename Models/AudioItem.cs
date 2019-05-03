using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Flac;
using NAudio.Wave.SampleProviders;
using System.IO;


namespace Models
{
    public class AudioItem 
    {
        public ListViewItem LstviewItem { get; set; }
        public DirectSoundOut Wave { get; set; }
        public AudioFileReader Stream { get; set; }
        public FlacReader Flac { get; set; }
        public bool Isflac { get; set; }
        public ISampleProvider SampleProvider { get; set; }
        public FadeInOutSampleProvider Fade { get; set; } 
        public string FileName { get; set; }

        public string Name { get; set; }
        public string Artist { get; set; }

        public Image myImage { get; set; }
    }
}
