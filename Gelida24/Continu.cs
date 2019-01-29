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
using NAudio.Wave.SampleProviders;
using System.IO;
using Quartz;
using WindowsFormsControlLibrary1;

namespace Gelida24
{
    public partial class Continu : UserControl
    {
        public Continu()
        {
            InitializeComponent();
        }
        private IWavePlayer waveOut;
        private WaveOutEvent ou;
        private AudioFileReader audioFileReader;
        private Action<float> setVolumeDelegate;
        private ISampleProvider sampleProvider;
        private Queue<string> list = new Queue<string>();
        private TimeSpan duraciototal = new TimeSpan();
        private DateTime hfinalitzacio = DateTime.Now;

        public sbyte outDev { get; set; }
        public string musicPath { get; set; }
        public string adsPath { get; set; }
        public string jinglePath { get; set; }
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);

        public void CrearLlista()
        {

        }
        private DateTime CalcularHora()
        {
            return DateTime.Now.Add(duraciototal);
        }
        private void SumarTemps(TimeSpan duraciocanso)
        {
            duraciototal.Add(duraciocanso);
        }
        private void RestarTemps(TimeSpan duraciocanso)
        {
            duraciototal.Subtract(duraciocanso);
        }

        private ISampleProvider CreateInputStream(string fileName)
        {
            audioFileReader = new AudioFileReader(fileName);

            var sampleChannel = new SampleChannel(audioFileReader, true);

            setVolumeDelegate = vol => sampleChannel.Volume = vol;

            var postVolumeMeter = new MeteringSampleProvider(sampleChannel);
            postVolumeMeter.StreamVolume += OnPostVolumeMeter;

            return postVolumeMeter;
        }

        void OnPostVolumeMeter(object sender, StreamVolumeEventArgs e)
        {
            ///left 
            ///-
            ///-60 to 0 dB volume
            /// 0 dB to 5 dB volume            
            volumeMeter1.Amplitude = e.MaxSampleValues[0];
            volumeMeter3.Amplitude = e.MaxSampleValues[0];

            ///right
            ///-
            ///-60 to 0 dB volume
            /// 0 dB to 5 dB volume    
            volumeMeter2.Amplitude = e.MaxSampleValues[1];
            volumeMeter4.Amplitude = e.MaxSampleValues[0];
        }
        //button play onclick
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            PlaySong();

        }
        private void ResetVUMeter()
        {
            volumeMeter1.Amplitude = 0;
            volumeMeter2.Amplitude = 0;
            volumeMeter3.Amplitude = 0;
            volumeMeter4.Amplitude = 0;
        }

        private void PlaySong()
        {
            if (listView1.Items.Count < 1)
            {
                return;
            }

            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }
                else if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Play();
                    timer1.Start();

                    return;
                }
            }

            // we are in a stopped state
            // TODO: only re-initialise if necessary

            if (String.IsNullOrEmpty(listView1.Items[0].SubItems[2].Text))
            {
                return;
            }
            CarregarFitxer();

            CarregarDuracio();

            InicialitzarSo();

            //setVolumeDelegate(volumeSlider1.Volume);

            waveOut.PlaybackStopped += (sender, evn) =>
            {
                try
                {
                    ResetVUMeter();
                    RestarTemps(audioFileReader.TotalTime);

                    if (listView1.Items.Count > 1)
                    {
                        listView1.Items.RemoveAt(0);
                        //playlist.Dequeue();
                        PlaySong();
                    }
                }
                catch
                {

                }

                //waveOut.Dispose();  
            };
            try
            {
                waveOut.Play();
                timer1.Start();
                listView1.Items[0].Font = fntPlaying;
            }
            catch
            {

            }
        }
        private void CarregarFitxer()
        {
            try
            {
                //canviar dequeue per first si esta activat o no el borrar
                sampleProvider = CreateInputStream(listView1.Items[0].SubItems[2].Text);
            }
            catch (Exception createException)
            {
                MessageBox.Show(String.Format("{0}", createException.Message), "Error al carregar el fitxer");
                listView1.Items.RemoveAt(0);
                return;
            }
        }
        private void CarregarDuracio()
        {
            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
               audioFileReader.TotalTime.Seconds);
        }
        private void InicialitzarSo()
        {
            try
            {
                ou = new WaveOutEvent
                {
                    DeviceNumber = outDev
                };
                waveOut = ou;

                waveOut.Init(sampleProvider);

            }
            catch (Exception initException)
            {
                MessageBox.Show(String.Format("{0}", initException.Message), "Error amb la sortida de so");
                return;
            }
        }
    }
}
