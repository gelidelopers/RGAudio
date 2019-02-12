﻿using System;
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
using System.Threading;

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
        private Queue<Arxiu> list = new Queue<Arxiu>();
        private TimeSpan duraciototal = new TimeSpan();
        private TimeSpan duracioActual = new TimeSpan();
        private DateTime hfinalitzacio = DateTime.Now;

        //https://gist.github.com/tedmiston/5935757

        public sbyte outDev { get; set; }
        //public string musicPath { get; set; }
        //public string adsPath { get; set; }
        //public string jinglePath { get; set; }
        
        

        public void CrearLlista()
        {
            //mirar events programats
            //si nhi ha

            //sino ha passat de la hora

            //sino inclou publicitat i hi ha un bloc de publi a la hora, posar la reproduccio
            //de la publicitat a la hora del programa menys la duracio del bloc de publi

            //si ha passat de la hora --> audio.currentime == datetime.now - hora de inici del programa

            //carregar abans o despres el jignle de podcast a la web

            //sino
            //mirar si bloc de publi

            //afegir musica

            //afegir jingle
            AfegirArxiu();            

        }
        public void AfegirArxiu()
        {
            Arxiu lol = new Arxiu
            {
                fileName = "qwertyuiop.m4a"
            };
            list.Enqueue(lol);

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
        public async void ScheduleAction(Arxiu arxiu,DateTime ExecutionTime)
        {
            await Task.Delay((int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds);
            if (list.Count > 0)
            {
                if (list.First()!= arxiu && list.ElementAt(1) == arxiu)
                {
                    list.Dequeue();
                    
                }
                else
                {
                    list.Clear();
                    list.Enqueue(arxiu);
                }
            }
            else
            {
                list.Enqueue(arxiu);
                
            }
            PlaySong();
        }
        public async void SchedulePrint(string text, DateTime ExecutionTime)
        {
            await Task.Delay((int)ExecutionTime.Subtract(DateTime.Now).TotalMilliseconds);
            MessageBox.Show(text);
        }
        public async Task CrearLlistaCada(TimeSpan ExecutionTime)
        {
            while (true)
            {
                await Task.Delay((int)ExecutionTime.TotalMilliseconds);
                CrearLlista();
            }
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
            volumeMeter4.Amplitude = e.MaxSampleValues[1];
        }
        //button play onclick

        public void PlaySong()
        {
            // we are in a stopped state
            // TODO: only re-initialise if necessary
            if(waveOut != null)
            {
                if(waveOut.PlaybackState == PlaybackState.Playing || waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Stop();
                    return;
                }
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
                sampleProvider = CreateInputStream(list.Dequeue().fileName);
            }
            catch (Exception createException)
            {
                
                
                return;
            }
        }
        private void CarregarDuracio()
        {
            try
            {
                labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
                   audioFileReader.TotalTime.Seconds);
            }
            catch
            {

            }
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
            catch 
            {
                
                return;
            }
        }
        private async Task TascaHoraria()
        {
            await CrearLlistaCada(TimeSpan.FromMinutes(2));
        }

        private void BtnPLay_ClickAsync(object sender, EventArgs e)
        {
            Arxiu lol = new Arxiu();
            lol.fileName = "qwertyuiop.m4a";
            ScheduleAction(lol, dateTimePicker1.Value);
        }

        public void CrearTasca()
        {
            Task.Run(TascaHoraria);
        }
    }
}
