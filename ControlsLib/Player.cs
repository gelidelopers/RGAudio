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

using Quartz;
using System.Diagnostics;

namespace ControlsLib
{
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
            ColumnHeader column = new ColumnHeader() { Text = "Titol" };
            dropBetweenList1.AddColumn(column);
            column = new ColumnHeader() { Text = "Artista" };
            dropBetweenList1.AddColumn(column);
        }
        private IWavePlayer waveOut;
        private WaveOutEvent ou;
        //private AsioOut asioOut;
        private WaveStream audioFileReader;
        private Action<float> setVolumeDelegate;
        private ISampleProvider sampleProvider;
        private int index = 0;
        private bool necesitaCalcularSeguen = true;
        private int seguen = 0;
        private List<string> errors = new List<string>();
        private string failneim;
        private int count = 0;
        
        public bool Continuar = true;
        public bool Borrar = true;
        public bool Bucle = false;
        public sbyte OutDev { get; set; }
        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntNext = new Font("Arial", 10, System.Drawing.FontStyle.Underline);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        public List<string> playlist = new List<string>();
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
        private void ResetVUMeter()
        {
            volumeMeter1.Amplitude = 0;
            volumeMeter2.Amplitude = 0;
            volumeMeter3.Amplitude = 0;
            volumeMeter4.Amplitude = 0;
        }
        private void CarregarFitxer()
        {
            
                failneim = playlist.ElementAt(seguen);
                //canviar dequeue per first si esta activat o no el borrar
                sampleProvider = CreateInputStream(failneim);
            
            
        }
        private void CarregarDuracio()
        {
            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
               audioFileReader.TotalTime.Seconds);
        }
        private void InicialitzarSo()
        {
            
                ou = new WaveOutEvent
                {
                    DeviceNumber = OutDev
                };
                waveOut = ou;

                waveOut.Init(sampleProvider);

            
            
        }
        private void PlaySong()
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }


                else if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    try
                    {
                        waveOut.Play();
                        timer1.Start();
                    }
                    catch
                    {
                        MessageBox.Show("Error al reprendre la reproduccio");
                    }

                    return;

                }
            }

            try
            {
                CarregarFitxer();
            }
            catch
            {
                MessageBox.Show("Error amb el fitxer","Error 1");
                return;
            }

            CarregarDuracio();

            try
            {
                InicialitzarSo();
            }
            catch
            {
                MessageBox.Show("Error amb la sortida de so","Error 2");
                return;
            }

            //setVolumeDelegate(volumeSlider1.Volume);
            try
            {
                waveOut.Play();
            }
            catch
            {
                MessageBox.Show("Error al reproduir","Error 3");
            }
            timer1.Start();
            //listView1.Items[index].Font = fntNotPlaying;
            index = seguen;
            if (necesitaCalcularSeguen)
            {
                seguen = ObtenirSeguentIndex(index);
            }
            //listView1.Items[index].Font = fntPlaying;
            necesitaCalcularSeguen = true;
            isPlaying = true;
            

            waveOut.PlaybackStopped += (sender, evn) =>
            {
                ResetVUMeter();
                if (Borrar)
                {
                    playlist.RemoveAt(index);
                    count = playlist.Count;
                            
                }
                if (seguen >= 0)
                {
                    PlaySong();
                }
                else
                {
                    isPlaying = false;
                }
                if (Borrar)
                {
                    //listView1.Items.RemoveAt(index);
                    dropBetweenList1.DeleteItemAt(index);
                }
                //waveOut.Dispose();
            };
                
            
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

                        var itom = new ListViewItem(lol)
                        {
                            BackColor = Color.Yellow
                        };

                        //item.SubItems.Add(axr.artist);
                        //item.SubItems.Add(axr.duration.ToString());
                        playlist.Add(axr.fileName);
                        //listView1.Items.Add(itom);
                        dropBetweenList1.AddItem(itom);

                    }
                    catch (TagLib.CorruptFileException)
                    {

                        if (!errors.Contains("Error 4.1: Fitxer/s Corrupte/s :("))
                        {
                            errors.Add("Error 4.1: Fitxer/s Corrupte/s :(");
                        }

                    }
                    catch (TagLib.UnsupportedFormatException)
                    {
                        if (!errors.Contains("Error 4.2: Tipus de fitxer " + Path.GetExtension(file) + " no acceptat :("))
                        {
                            errors.Add("Error 4.2: Tipus de fitxer " + Path.GetExtension(file) + " no acceptat :(");
                        }
                    }
                    catch
                    {
                        if (!errors.Contains("Error 4.3: Error al carregar el fitxer " + Path.GetFullPath(file) + " :("))
                        {
                            errors.Add("Error 4.3: Error al carregar el fitxer " + Path.GetFullPath(file) + " :(");
                        }
                    }
                }
                else
                {
                    if (!errors.Contains("Error 4.4: El format " + Path.GetExtension(file) + " no esta soportat :("))
                    {

                        errors.Add("Error 4.4: El format " + Path.GetExtension(file) + " no esta soportat :(");
                    }
                }
            }
            foreach (string error in errors)
            {
                MessageBox.Show(error,"Error 4");
            }
            count = playlist.Count;
        }
        private int ObtenirSeguentIndex(int actual)
        {
            int i = -1;
            
            if (Continuar)
            {
                if (!Borrar)
                {
                    if (count > 1 && actual < count - 1)
                    {
                        //if (seguen >= 0) listView1.Items[seguen].Font = fntPlaying;
                        i = index + 1;
                        
                    }
                    else if (Bucle && actual == count - 1)
                    {
                        i = 0;
                    }
                }
                else
                {
                    i = actual;
                }
            }
            else if (Bucle)
            {
                //if (seguen >= 0 && listView1.Items[seguen].Font == fntNext) listView1.Items[seguen].Font = fntNotPlaying;
                i = actual;
            }
            else
            {
                //if (seguen >= 0 && listView1.Items[seguen].Font == fntNext) listView1.Items[seguen].Font = fntNotPlaying;
            }
            //if (i >= 0) listView1.Items[i].Font = fntNext;
            return i;
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
        private void BtnPLay_Click(object sender, EventArgs e)
        {
            if (seguen == -1)
            {
                if(count > 0)
                {
                    //seguen = listView1.SelectedItems[0].Index;
                }
                else
                {
                    seguen = 0;
                }
                
            }
            PlaySong();
        }
        private void Timer1_Tick(object sender, EventArgs e)
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
        private void TrackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (waveOut != null)
            {
                timer1.Start();

                audioFileReader.CurrentTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
            }
        }
        private void TrackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }
        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if(count > 0)
            {
                //seguen = listView1.SelectedItems[0].Index;
                PlaySong();
            }
        }
        private void BtnPause_Click(object sender, EventArgs e)
        {
            ResetVUMeter();
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                }
            }
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                seguen = -1;
                waveOut.Stop();
            }
            ResetVUMeter();
        }
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (Borrar)
            {
                Borrar = false;
                btnBorrar.BackColor = Control.DefaultBackColor;
            }
            else
            {
                Borrar = true;
                btnBorrar.BackColor = Color.Red;
            }
            seguen = ObtenirSeguentIndex(index);
            necesitaCalcularSeguen = false;
        }
        private void BtnContinu_Click(object sender, EventArgs e)
        {
            if (Continuar)
            {
                Continuar = false;
                btnContinu.BackColor = Control.DefaultBackColor;
            }
            else
            {
                Continuar = true;
                btnContinu.BackColor = SystemColors.Highlight;
            }
            seguen = ObtenirSeguentIndex(index);
            necesitaCalcularSeguen = false;
        }
        private void BtnLoop_Click(object sender, EventArgs e)
        {
            if (Bucle)
            {
                Bucle = false;
                btnLoop.BackColor = Control.DefaultBackColor;
            }
            else
            {
                Bucle = true;
                btnLoop.BackColor = Color.Lime;
            }
            seguen = ObtenirSeguentIndex(index);
            necesitaCalcularSeguen = false;
        }
    }
}
