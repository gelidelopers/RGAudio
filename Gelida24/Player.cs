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
using NAudio.Flac;
using NAudio.Wave.SampleProviders;
using System.IO;
using WindowsFormsControlLibrary1;
using System.Diagnostics;


namespace Gelida24
{
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
        }
        private IWavePlayer waveOut;
        private WaveOutEvent ou;
        //private AsioOut asioOut;
        private WaveStream audioFileReader;
        private Action<float> setVolumeDelegate;
        private ISampleProvider sampleProvider;
        private int index = 0;
        //private int seguen;
        private bool stoped = false;
        private List<string> errors = new List<string>();
        bool clicat = false;

        public bool Continuar = true;
        public bool Borrar = true;
        public bool Bucle = false;
        public sbyte outDev { get; set; }
        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        //public bool isAsio { get; set; }
        public bool isPlaying;
        public List<string> extensions = new List<string>(new string[] { ".mp3", ".wav", ".aac", ".m4a", ".wma" });

        private ISampleProvider CreateInputStream(string fileName)
        {
            if (Path.GetExtension(fileName) == ".flac")
            {
                audioFileReader = new FlacReader(fileName);
            }
            else
            {
                audioFileReader = new AudioFileReader(fileName);
            }

            SampleChannel sampleChannel = new SampleChannel(audioFileReader, true);

            setVolumeDelegate = vol => sampleChannel.Volume = vol;

            MeteringSampleProvider postVolumeMeter = new MeteringSampleProvider(sampleChannel);
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

        //volume slider changed


        private void OnButtonPauseClick(object sender, EventArgs e)
        {

        }

        public void OnButtonStopClick(object sender, EventArgs e)
        {

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



        /// <summary>
        /// Reestructurar funcio playsong
        /// </summary>
        private void CarregarFitxer()
        {
            try
            {
                //canviar dequeue per first si esta activat o no el borrar
                sampleProvider = CreateInputStream(listView1.Items[index].SubItems[2].Text);
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


            if (String.IsNullOrEmpty(listView1.Items[index].SubItems[2].Text))
            {
                return;
            }


            CarregarFitxer();

            CarregarDuracio();

            InicialitzarSo();

            //setVolumeDelegate(volumeSlider1.Volume);

            waveOut.PlaybackStopped += (sender, evn) =>
            {
                

                //waveOut.Dispose();

            };
            try
            {
                waveOut.Play();
                listView1.Items[index].Font = fntPlaying;
                stoped = false;
                clicat = false;
                isPlaying = true;
                timer1.Start();

            }
            catch
            {

            }

        }


        private void AfegirFitxers(string[] files)
        {
            List<string> errors = new List<string>();
            string extensio;

            foreach (string file in files)
            {
                extensio = Path.GetExtension(file);
                //posar el path.get en una variable i posar tots els fitxers compatibles en un List
                if (Path.GetExtension(file) == ".wav" || Path.GetExtension(file) == ".flac" || Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".aac")
                {

                    Arxiu axr = new Arxiu
                    {
                        fileName = file
                    };

                    try
                    {
                        var tfile = TagLib.File.Create(axr.fileName);
                        axr.name = tfile.Tag.Title ?? Path.GetFileNameWithoutExtension(axr.fileName);
                        axr.artist = tfile.Tag.JoinedPerformers;

                        string[] lol = { axr.name, axr.artist, axr.fileName };

                        var itom = new ListViewItem(lol);
                        itom.BackColor = Color.Yellow;

                        //item.SubItems.Add(axr.artist);
                        //item.SubItems.Add(axr.duration.ToString());

                        listView1.Items.Add(itom);

                    }
                    catch (TagLib.CorruptFileException)
                    {

                        if (!errors.Contains("Fitxer/s Corrupte/s :("))
                        {
                            errors.Add("Fitxer/s Corrupte/s :(");
                        }

                    }
                    catch (TagLib.UnsupportedFormatException)
                    {
                        if (!errors.Contains("Tipus de fitxer " + Path.GetExtension(file) + " no acceptat :("))
                        {
                            errors.Add("Tipus de fitxer " + Path.GetExtension(file) + " no acceptat :(");
                        }
                    }
                    catch
                    {
                        if (!errors.Contains("Error al carregar el fitxer " + Path.GetFullPath(file) + " :("))
                        {
                            errors.Add("Error al carregar el fitxer " + Path.GetFullPath(file) + " :(");
                        }
                    }
                }
                else
                {
                    if (!errors.Contains("El format " + Path.GetExtension(file) + " no esta soportat :("))
                    {

                        errors.Add("El format " + Path.GetExtension(file) + " no esta soportat :(");
                    }
                }
            }
            foreach (string error in errors)
            {
                MessageBox.Show(error);
            }
        }

        private int ObtenirSeguentIndex(int actual)
        {
            int i = -1;

            try
            {

                ResetVUMeter();

                if (!stoped && !clicat)
                {
                    if (Continuar && Borrar)
                    {
                        if (listView1.Items.Count > 1 && index - 1 < listView1.Items.Count)
                        {
                            listView1.Items.RemoveAt(index);
                            PlaySong();
                        }
                        else if (listView1.Items.Count == 1)
                        {
                            listView1.Items.RemoveAt(0);
                        }
                        else
                        {
                            isPlaying = false;
                        }
                    }
                    else if (Continuar && !Borrar)
                    {
                        if (listView1.Items.Count > 1 && index < listView1.Items.Count - 1 && !Bucle)
                        {
                            index++;
                            PlaySong();

                            if (index < listView1.Items.Count)
                            {
                                listView1.Items[index - 1].Font = fntNotPlaying;
                            }
                            else
                            {
                                isPlaying = false;
                            }
                        }
                        else if (Bucle)
                        {
                            listView1.Items[index].Font = fntNotPlaying;
                            index = 0;
                            
                            PlaySong();
                        }
                    }
                    else if (!Continuar && Borrar)
                    {
                        listView1.Items.RemoveAt(index);

                        isPlaying = false;
                    }
                    else if (!Continuar && Bucle)
                    {
                        PlaySong();
                    }
                }
                else if (clicat)
                {
                    PlaySong();
                }
                else
                {
                    isPlaying = false;
                }
            }
            catch
            {

            }

            return i;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //addfolder
        private void OnAddFolderButtonClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            string allExtensions = "*.wav;*.aiff;*.mp3;*.aac;*.flac";
            openFileDialog.Filter = String.Format("Fiters de musica coneguts|{0}|Tots els fitxers (*.*)|*.*", allExtensions);
            openFileDialog.Multiselect = true;

            //openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AfegirFitxers(openFileDialog.FileNames);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPLay_Click(object sender, EventArgs e)
        {
            PlaySong();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (waveOut != null && audioFileReader != null)
            {
                TimeSpan currentTime = (waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
                trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / audioFileReader.TotalTime.TotalSeconds));
                labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
                int min, sec;
                min = (int)(audioFileReader.TotalTime.TotalSeconds - audioFileReader.CurrentTime.TotalSeconds) / 60;
                sec = (int)(audioFileReader.TotalTime.TotalMilliseconds - audioFileReader.CurrentTime.TotalMilliseconds) % 60000;

                labelRemain.Text = String.Format("{0:00}:{1:00:000}", min, sec);

            }
            else
            {
                trackBarPosition.Value = 0;
            }
        }

        private void trackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (waveOut != null)
            {
                timer1.Start();

                audioFileReader.CurrentTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
            }
        }

        private void trackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            string fl;
            if (listView1.SelectedItems.Count > 0)
            {
                fl = listView1.SelectedItems[0].SubItems[2].Text;

                Process proc = null;

                proc = Process.Start("C:/Program Files/ocenaudio/ocenaudio.exe ", $"\"{fl}\"");
                proc.WaitForInputIdle();

            }
        }
    }
}
