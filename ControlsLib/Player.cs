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
using Models;
using WaveFormRendererLib;

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
            waveFormPos = new Pen(Color.Black);
        }
        private int index = 0;

        private int seguen = 0;
        private List<string> errors = new List<string>();
        private int count = 0;
        private Action<float> setVolumeDelegate;
        private WaveFormRenderer waveFormRenderer;
        private Pen waveFormPos;
        private AudioItem audioActual;
        
        public bool Continuar = true;
        public bool Borrar = true;
        public bool Bucle = false;
        public sbyte OutDev { get; set; }
        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntNext = new Font("Arial", 10, System.Drawing.FontStyle.Underline);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        public List<AudioItem> playlist = new List<AudioItem>();
        //public bool isAsio { get; set; }
        public bool isPlaying;
        public List<string> extensions = new List<string>(new string[] { ".mp3", ".wav", ".aac", ".m4a", ".wma" });


        private void CreateInputStream(AudioItem audioItem)
        {
            if (Path.GetExtension(audioItem.FileName) == ".flac")
            {
                audioItem.Flac = new FlacReader(audioItem.FileName);
                SampleChannel sampleChannel = new SampleChannel(audioItem.Flac, true);

                setVolumeDelegate = vol => sampleChannel.Volume = vol;

                MeteringSampleProvider postVolumeMeter = new MeteringSampleProvider(sampleChannel);
                postVolumeMeter.StreamVolume += OnPostVolumeMeter;
                audioItem.SampleProvider = postVolumeMeter;
            }
            else
            {
                audioItem.Stream  = new AudioFileReader(audioItem.FileName);
                SampleChannel sampleChannel = new SampleChannel(audioItem.Stream, true);

                setVolumeDelegate = vol => sampleChannel.Volume = vol;

                MeteringSampleProvider postVolumeMeter = new MeteringSampleProvider(sampleChannel);
                postVolumeMeter.StreamVolume += OnPostVolumeMeter;
                audioItem.SampleProvider = postVolumeMeter;
            }
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
        
        private void CarregarDuracio(AudioFileReader audioFileReader)
        {
            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
               audioFileReader.TotalTime.Seconds);
        }
        private void InicialitzarSo(AudioItem audioItem, int devnumber)
        {
            audioItem.Wave = new WaveOutEvent
            {
                DeviceNumber = devnumber
            };
               
            audioItem.Wave.Init(audioItem.SampleProvider);
        }
        private void PlaySong()
        {
            if (playlist.ElementAt(seguen).Wave  != null)
            {
                if (playlist.ElementAt(seguen).Wave.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }

                else
                {
                    try
                    {
                        playlist.ElementAt(seguen).Wave.Play();
                        CarregarDuracio(playlist.ElementAt(seguen).Stream);

                        index = seguen;
                        
                        seguen = ObtenirSeguentIndex(index);
                            
                        
                        //listView1.Items[index].Font = fntPlaying;
                        
                        isPlaying = true;


                        playlist.ElementAt(index).Wave.PlaybackStopped += (sender, evn) =>
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

                        timer1.Start();
                        RenderWaveform();
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.ToString(),"Error al reprendre la reproduccio");
                    }

                    return;

                }
                
            }
            else
            {
                try
                {
                    CarregarFitxer(playlist.ElementAt(index));
                   
                }
                catch
                {
                    MessageBox.Show("Error amb el fitxer", "Error 1");
                    return;
                }

                //PlaySong();
                
            }
        }
        

        private void CarregarFitxer(AudioItem audioItem)
        {
            CreateInputStream(audioItem);

            CrearFader(audioItem);

            InicialitzarSo(audioItem, OutDev);
        }

        private void CrearFader(AudioItem audioItem)
        {
            audioItem.Fade = new FadeInOutSampleProvider(audioItem.Stream);
        }


        private WaveFormRendererSettings GetRendererSettings()
        {
            var settings = new StandardWaveFormRendererSettings
            {
                TopHeight = pictureBox1.Height/2,
                BottomHeight = pictureBox1.Height / 2,
                Width = pictureBox1.Width,
                DecibelScale = false,
                

            };
            return settings;
        }

        private void RenderWaveform()
        {
            if (playlist.ElementAt(index).FileName == null) return;
            var settings = GetRendererSettings();
            
            pictureBox1.Image = null;
            //labelRendering.Visible = true;
            //Enabled = false;
            var peakProvider = new RmsPeakProvider(pictureBox1.Height / 2);
            Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, settings));
        }

        private void RenderThreadFunc(IPeakProvider peakProvider, WaveFormRendererSettings settings)
        {
            Image image = null;
            try
            {
                waveFormRenderer = new WaveFormRenderer();
                
                image = waveFormRenderer.Render(playlist.ElementAt(index).FileName, peakProvider, settings);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            BeginInvoke((Action)(() => FinishedRender(image)));
        }

        private void FinishedRender(Image image)
        {
            //labelRendering.Visible = false;
            pictureBox1.Image = image;
            Enabled = true;
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
                        AudioItem ai = new AudioItem()
                        {
                            FileName = axr.fileName
                        };
                        CarregarFitxer(ai);
                        playlist.Add(ai);
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
                    catch(Exception e)
                    {
                        if (!errors.Contains("Error 4.3: Error al carregar el fitxer " + Path.GetFullPath(file) + " :( \n" + e.ToString()))
                        {
                            errors.Add("Error 4.3: Error al carregar el fitxer " + Path.GetFullPath(file) + " :( \n" + e.ToString());
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
            try
            {
                if (playlist.ElementAt(index).Wave != null && playlist.ElementAt(index).Stream != null)
                {
                    
                    TimeSpan currentTime = (playlist.ElementAt(index).Wave.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : playlist.ElementAt(index).Stream.CurrentTime;
                    trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / playlist.ElementAt(index).Stream.TotalTime.TotalSeconds));
                    panel3.Location = new Point(Math.Min(pictureBox1.Width, (int)(pictureBox1.Width * currentTime.TotalSeconds / playlist.ElementAt(index).Stream.TotalTime.TotalSeconds)), panel3.Location.Y);
                    labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
                    int min, sec;
                    min = (int)(playlist.ElementAt(index).Stream.TotalTime.TotalSeconds - playlist.ElementAt(index).Stream.CurrentTime.TotalSeconds) / 60;
                    sec = (int)(playlist.ElementAt(index).Stream.TotalTime.TotalMilliseconds - playlist.ElementAt(index).Stream.CurrentTime.TotalMilliseconds) % 60000;

                    labelRemain.Text = String.Format("{0:00}:{1:00:000}", min, sec);
                }
                else
                {
                    trackBarPosition.Value = 0;
                    panel3.Location = new Point(0,panel3.Location.Y);
                }
            }
            catch { }
        }
        private void TrackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (playlist.ElementAt(index).Stream != null)
            {
                timer1.Start();

                playlist.ElementAt(index).Stream.CurrentTime = TimeSpan.FromSeconds(playlist.ElementAt(index).Stream.TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
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
            if (playlist.ElementAt(index).Wave != null)
            {
                if (playlist.ElementAt(index).Wave.PlaybackState == PlaybackState.Playing)
                {
                    playlist.ElementAt(index).Wave.Pause();
                }
            }
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (playlist.ElementAt(index).Wave != null)
            {
                seguen = -1;
                playlist.ElementAt(index).Wave.Stop();
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
            //seguen = ObtenirSeguentIndex(index);
            //necesitaCalcularSeguen = false;
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
            //seguen = ObtenirSeguentIndex(index);
            //necesitaCalcularSeguen = false;
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
            //seguen = ObtenirSeguentIndex(index);
            //necesitaCalcularSeguen = false;
        }
    }
}
