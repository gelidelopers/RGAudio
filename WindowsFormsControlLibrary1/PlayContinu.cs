using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;
using System.Threading;

namespace WindowsFormsControlLibrary1
{

    public partial class PlayContinu : UserControl
    {
        public PlayContinu()
        {
            InitializeComponent();
            
        }
        private IWavePlayer waveOut;
        private WaveOutEvent ou;
        private AudioFileReader audioFileReader;
        private Action<float> setVolumeDelegate;
        private ISampleProvider sampleProvider;
        private Queue<string> list = new Queue<string>();

        public sbyte outDev { get; set; }
        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        
        public void CrearLlista()
        {
            
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
        
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (waveOut != null && audioFileReader != null)
            {
                TimeSpan currentTime = (waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
                labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan currentTime = (waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
            int min, sec;
            min = (int)(audioFileReader.TotalTime.TotalSeconds - audioFileReader.CurrentTime.TotalSeconds) / 60;
            sec = (int)(audioFileReader.TotalTime.TotalMilliseconds - audioFileReader.CurrentTime.TotalMilliseconds) % 60000;

            labelRemain.Text = String.Format("{0:00}:{1:00:000}", min, sec);
        }
        //button play onclick
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            PlaySong();
            
        }

        private void PlaySong()
        {
            if (listView1.Items.Count < 1)
            {
                return;
            }

            //if (waveOut != null && waveOut.PlaybackState != PlaybackState.Stopped)
            //{
            //    waveOut.Stop();

            //}
            //if (audioFileReader != null)
            //{
            //    audioFileReader.Dispose();
            //}

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

            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
                audioFileReader.TotalTime.Seconds);
            
            try
            {

                ou = new WaveOutEvent();
                ou.DeviceNumber = outDev;
                waveOut = ou;
                
                waveOut.Init(sampleProvider);
               
            }
            catch (Exception initException)
            {
                MessageBox.Show(String.Format("{0}", initException.Message), "Error amb la sortida de so");
                return;
            }

            //setVolumeDelegate(volumeSlider1.Volume);

            waveOut.PlaybackStopped += (sender, evn) => 
            {
                try
                {
                    volumeMeter1.Amplitude = 0;
                    volumeMeter2.Amplitude = 0;
                    volumeMeter3.Amplitude = 0;
                    volumeMeter4.Amplitude = 0;
                    
                    
                    if (listView1.Items.Count > 1 && 0 - 1 < listView1.Items.Count)
                    {
                        //if (!skiped)
                        //{
                        try
                        {

                            listView1.Items.RemoveAt(0);
                        }
                        catch
                        {

                        }
                        //}
                        //playlist.Dequeue();
                        PlaySong();
                        //listView1.Items[0].Font = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
                    }
                    else if (listView1.Items.Count == 1)
                    {
                        try
                        {
                            listView1.Items.RemoveAt(0);
                        }
                        catch
                        {

                        }
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

                listView1.Items[0].Font = fntPlaying;

                timer1.Start();
                timer2.Start();
            }
            catch
            {

            }
        }
    }
}
