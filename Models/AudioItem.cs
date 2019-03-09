using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.Flac;

namespace Models
{
    public class AudioItem
    {
        public ListViewItem LstviewItem { get; set; }
        public WaveOutEvent Wave { get; set; }
        public AudioFileReader Stream { get; set; }
        public FlacReader Flac { get; set; }
        public bool Isflac { get; set; }
        public ISampleProvider SampleProvider { get; set; }
        public FadeInOutSampleProvider Fade { get; set; } 
        public string FileName { get; set; }
    }
}
