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


namespace ControlsLib
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
        private TimeSpan duracioActual = new TimeSpan();
        private DateTime hfinalitzacio = DateTime.Now;

        //https://gist.github.com/tedmiston/5935757

        public sbyte outDev { get; set; }
        //public string musicPath { get; set; }
        //public string adsPath { get; set; }
        //public string jinglePath { get; set; }
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
        public async void ScheduleAction(string fileName,DateTime ExecutionTime)
        {
            await Task.Delay((int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds);
            if (list.Count > 0)
            {
                if (list.First() != fileName && list.ElementAt(1) == fileName)
                {
                    list.Dequeue();
                    
                }
                else
                {
                    list.Clear();
                    list.Enqueue(fileName);
                }
            }
            else
            {
                list.Enqueue(fileName);
                
            }
            PlaySong();
        }
        public async void SchedulePrint(string text, DateTime ExecutionTime)
        {
            await Task.Delay((int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds);
            MessageBox.Show(text);
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

        private void PlaySong()
        {
            // we are in a stopped state
            // TODO: only re-initialise if necessary
            if(waveOut != null)
            {
                if(waveOut.PlaybackState == PlaybackState.Playing || waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Stop();
                }
            }

            if (String.IsNullOrEmpty(list.First()))
            {
                CrearLlista();
            }
            CarregarFitxer();

            CarregarDuracio();

            InicialitzarSo();

            //setVolumeDelegate(volumeSlider1.Volume);

            waveOut.PlaybackStopped += (sender, evn) =>
            {
                try
                { 
                    PlaySong();
                    RestarTemps(duracioActual);
                    duracioActual = audioFileReader.TotalTime;

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
                sampleProvider = CreateInputStream(list.Dequeue());
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

        private void BtnPLay_Click(object sender, EventArgs e)
        {
            ScheduleAction("qwertyuiop.flac", dateTimePicker1.Value);
        }
    }
}
