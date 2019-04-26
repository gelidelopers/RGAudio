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
            listView1.Columns.Add(column);
            column = new ColumnHeader() { Text = "Artista" };
            listView1.Columns.Add(column);
            waveFormPos = new Pen(Color.Black);
            listView1.DoubleClick += ListView1_DoubleClick;
            
           
        }

        private int index = 0;

        private int seguen = 0;
        private List<string> errors = new List<string>();
        private int count = 0;
        private Action<float> setVolumeDelegate;
        private WaveFormRenderer waveFormRenderer;
        private Pen waveFormPos;
        private AudioItem audioActual;
        private sbyte trais = 0;
        
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
                audioItem.Isflac = true;
                
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
        
        private void CarregarDuracio(AudioItem audioItem)
        {
            if (audioItem.Isflac)
            {
                labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioItem.Flac.TotalTime.TotalMinutes,
                   audioItem.Flac.TotalTime.Seconds);
            }
            else
            {
                labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioItem.Stream.TotalTime.TotalMinutes,
                   audioItem.Stream.TotalTime.Seconds);
            }
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
            if (count > 0 && seguen >= 0 && index < playlist.Count)
            {
                if (playlist.ElementAt(index).Wave != null)
                {
                    //problemes al borrar dona out of bounds
                    if (playlist.ElementAt(index).Wave.PlaybackState == PlaybackState.Playing)
                    {
                        return;
                    }
                    else if (playlist.ElementAt(index).Wave.PlaybackState == PlaybackState.Paused)
                    {
                        playlist.ElementAt(index).Wave.Play();
                        return;
                    }

                    else
                    {
                        try
                        {
                            if (playlist.ElementAt(seguen).Wave != null)
                            {
                                playlist.ElementAt(seguen).Wave.Play();
                                audioActual = playlist.ElementAt(seguen);
                                lblName.Text = playlist.ElementAt(seguen).Name;
                                lblArtist.Text = playlist.ElementAt(seguen).Artist;
                                listView1.Items[seguen].Font = fntPlaying;
                                CarregarDuracio(playlist.ElementAt(seguen));
                                pictureBox1.Image = playlist.ElementAt(seguen).myImage;


                                index = seguen;

                                seguen = ObtenirSeguentIndex(index);
                                OnStartedPlaying(EventArgs.Empty);

                                //listView1.Items[index].Font = fntPlaying;

                                isPlaying = true;


                                playlist.ElementAt(index).Wave.PlaybackStopped += (sender, evn) =>
                                {
                                    ResetVUMeter();
                                    panelCursor.Location = new Point(0, panelCursor.Location.Y);
                                    if (count > index)
                                    {
                                        if (playlist.ElementAt(index) != null)
                                        {
                                            if (playlist.ElementAt(index).Isflac)
                                            {
                                                if (playlist.ElementAt(index).Flac != null)
                                                {
                                                    playlist.ElementAt(index).Flac.CurrentTime = TimeSpan.FromMilliseconds(5);
                                                }
                                            }
                                            else
                                            {
                                                if (playlist.ElementAt(index).Stream != null)
                                                {
                                                    playlist.ElementAt(index).Stream.CurrentTime = TimeSpan.FromMilliseconds(5);
                                                }
                                            }
                                            lblName.Text = "";
                                            lblArtist.Text = "";
                                            try
                                            {
                                                listView1.Items[index].Font = fntNotPlaying;
                                            }
                                            catch
                                            {

                                            }
                                            if (Borrar)
                                            {
                                                listView1.Items.Remove(audioActual.LstviewItem);
                                                playlist.Remove(audioActual);

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



                                            }
                                        }
                                    }
                                    //waveOut.Dispose();
                                };

                                timer1.Start();
                            }
                            else
                            {
                                CarregarFitxer(playlist.ElementAt(seguen));
                                if (trais < 3)
                                {
                                    PlaySong();
                                }
                                else
                                {
                                    listView1.Items.RemoveAt(seguen);
                                    playlist.RemoveAt(seguen);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString(), "Error de reproduccio");
                        }

                        return;

                    }

                }
                else
                {
                    CarregarFitxer(playlist.ElementAt(index));
                    if (trais < 3)
                    {
                        PlaySong();
                    }
                    else
                    {
                        listView1.Items.RemoveAt(index);
                        playlist.RemoveAt(index);
                        

                    }

                    return;
                    

                    //

                }
            }
        }


        private void CarregarFitxer(AudioItem audioItem)
        {
            try
            {
                CreateInputStream(audioItem);
            }
            catch
            {
                MessageBox.Show("Error amb el fitxer");
                trais++;
                try
                {
                    playlist.Remove(audioItem);
                }
                catch
                {

                }
                return;
            }

            CrearFader(audioItem);


            try
            {
                InicialitzarSo(audioItem, OutDev);
                
            }
            catch
            {
                trais++;
                MessageBox.Show("Error amb la sortida de so.");
                audioItem.Wave.Dispose();
                audioItem.Wave = null;
                return;
            }
            trais = 0;

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
                BottomPeakPen = new Pen(Color.Green),
                TopPeakPen = new Pen(Color.Green)

            };
            return settings;
        }

        private async Task<Image> RenderWaveformAsync(string filename)
        {
           
            var settings = GetRendererSettings();

            //labelRendering.Visible = true;
            //Enabled = false;
            var peakProvider = new RmsPeakProvider(pictureBox1.Height / 2);
            return await Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, settings,filename));
        }

        private Image RenderThreadFunc(IPeakProvider peakProvider, WaveFormRendererSettings settings, string filename)
        {
            Image image = null;
            try
            {
                waveFormRenderer = new WaveFormRenderer();
                
                image = waveFormRenderer.Render(filename, peakProvider, settings);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //BeginInvoke((Action)(() => FinishedRender(image)));
            return image;
        }

        private void FinishedRender(Image image)
        {
            //labelRendering.Visible = false;
            pictureBox1.Image = image;
            Enabled = true;
        }


        private void AfegirFitxers(string file)
        {
            List<string> errors = new List<string>();
            string extensio;


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
                        FileName = axr.fileName,
                        Name = axr.name,
                        Artist = axr.artist,
                        LstviewItem = itom

                    };
                    //await CarregarFitxer(ai);
                    //ai.myImage = await RenderWaveformAsync(ai.FileName);
                    playlist.Add(ai);
                    //listView1.Items.Add(itom);
                    listView1.Items.Add(itom);

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
                catch (Exception e)
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

            foreach (string error in errors)
            {
                MessageBox.Show(error, "Error 4");
            }
            
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
                if(playlist.ElementAt(i).Wave == null)
                {
                    CarregarFitxer(playlist.ElementAt(i));
                }
            }
            else if (Bucle)
            {
                //if (seguen >= 0 && listView1.Items[seguen].Font == fntNext) listView1.Items[seguen].Font = fntNotPlaying;
                if (!Borrar)
                {
                    i = actual;
                }
            }
            else
            {
                //if (seguen >= 0 && listView1.Items[seguen].Font == fntNext) listView1.Items[seguen].Font = fntNotPlaying;
            }
            //if (i >= 0) listView1.Items[i].Font = fntNext;
            return i;
        }
        //addfolder
        private void OnAddFolderBtnClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            string allExtensions = "*.wav;*.aiff;*.mp3;*.aac;*.flac";
            openFileDialog.Filter = String.Format("Fiters de musica coneguts|{0}|Tots els fitxers (*.*)|*.*", allExtensions);
            openFileDialog.Multiselect = true;

            //openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    AfegirFitxers(file);
                }
            }
            count = playlist.Count;
            seguen = ObtenirSeguentIndex(index);
        }
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                if (seguen == -1)
                {
                    if (listView1.SelectedItems.Count > 0)
                    {
                        seguen = listView1.SelectedItems[0].Index;
                    }
                    else
                    {
                        seguen = 0;
                    }

                }
                PlaySong();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                if (!playlist.ElementAt(index).Isflac)
                {
                    if (playlist.ElementAt(index).Wave != null && playlist.ElementAt(index).Stream != null)
                    {

                        TimeSpan currentTime = (playlist.ElementAt(index).Wave.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : playlist.ElementAt(index).Stream.CurrentTime;
                        //trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / playlist.ElementAt(index).Stream.TotalTime.TotalSeconds));
                        panelCursor.Location = new Point(Math.Min(panelTop.Width, (int)(panelTop.Width * currentTime.TotalSeconds / playlist.ElementAt(index).Stream.TotalTime.TotalSeconds)), panelCursor.Location.Y);
                        labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
                        int min, sec;
                        min = (int)(playlist.ElementAt(index).Stream.TotalTime.TotalSeconds - playlist.ElementAt(index).Stream.CurrentTime.TotalSeconds) / 60;
                        sec = (int)(playlist.ElementAt(index).Stream.TotalTime.TotalMilliseconds - playlist.ElementAt(index).Stream.CurrentTime.TotalMilliseconds) % 60000;

                        labelRemain.Text = String.Format("{0:00}:{1:00:000}", min, sec);
                    }
                    else
                    {
                       //trackBarPosition.Value = 0;
                        panelCursor.Location = new Point(0, panelCursor.Location.Y);
                    }
                }
                else
                {
                    if (playlist.ElementAt(index).Wave != null && playlist.ElementAt(index).Flac != null)
                    {

                        TimeSpan currentTime = (playlist.ElementAt(index).Wave.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : playlist.ElementAt(index).Flac.CurrentTime;
                        //trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / playlist.ElementAt(index).Flac.TotalTime.TotalSeconds));
                        panelCursor.Location = new Point(Math.Min(panelTop.Width, (int)(panelTop.Width * currentTime.TotalSeconds / playlist.ElementAt(index).Flac.TotalTime.TotalSeconds)), panelCursor.Location.Y);
                        labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
                        int min, sec;
                        min = (int)(playlist.ElementAt(index).Flac.TotalTime.TotalSeconds - playlist.ElementAt(index).Flac.CurrentTime.TotalSeconds) / 60;
                        sec = (int)(playlist.ElementAt(index).Flac.TotalTime.TotalMilliseconds - playlist.ElementAt(index).Flac.CurrentTime.TotalMilliseconds) % 60000;

                        labelRemain.Text = String.Format("{0:00}:{1:00:000}", min, sec);
                    }
                    else
                    {
                        //trackBarPosition.Value = 0;
                        panelCursor.Location = new Point(0, panelCursor.Location.Y);
                    }
                }
            }
            catch { }
        }
       
        private void ListView1_DoubleClick(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                seguen = listView1.SelectedItems[0].Index;
                PlaySong();
            }
        }
        private void BtnPause_Click(object sender, EventArgs e)
        {
            ResetVUMeter();
            if (count > 0)
            {
                if (playlist.ElementAt(index).Wave != null)
                {
                    if (playlist.ElementAt(index).Wave.PlaybackState == PlaybackState.Playing)
                    {
                        playlist.ElementAt(index).Wave.Pause();
                    }
                }
            }
        }
        private void BtnStop_Click(object sender, EventArgs e)
        {
            PararTot();
            timer1.Stop();
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
            seguen = ObtenirSeguentIndex(index);
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
            seguen = ObtenirSeguentIndex(index);
            //necesitaCalcularSeguen = false;
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            int mouseX = 2;
            if(e.X > 2)
            {
                mouseX = e.X;
            }
            
            panelCursor.Location = new Point(Math.Min(panelTop.Width, mouseX), panelCursor.Location.Y);
            if (count > 0)
            {
                if (!playlist.ElementAt(index).Isflac)
                {
                    if (playlist.ElementAt(index).Stream != null)
                    {

                        playlist.ElementAt(index).Stream.CurrentTime = TimeSpan.FromSeconds(playlist.ElementAt(index).Stream.TotalTime.TotalSeconds * mouseX / panelTop.Width);
                    }
                }
                else
                {
                    if (playlist.ElementAt(index).Flac != null)
                    {
                        playlist.ElementAt(index).Flac.CurrentTime = TimeSpan.FromSeconds(playlist.ElementAt(index).Flac.TotalTime.TotalSeconds * mouseX / panelTop.Width);
                        
                    }
                }
                timer1.Start();

            }
        }

        private void OnBtnUpClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    AudioItem audioItem = playlist.ElementAt(listView1.SelectedIndices[0]);
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx == 0)
                    {
                        listView1.Items.Remove(selected);
                        playlist.Remove(audioItem);

                        listView1.Items.Insert(totl - 1, selected);
                        playlist.Insert(totl - 1, audioItem);
                    }
                    else
                    {
                        listView1.Items.Remove(selected);
                        playlist.Remove(audioItem);

                        listView1.Items.Insert(indx - 1, selected);
                        playlist.Insert(indx - 1, audioItem);
                    }
                }
                
                index = playlist.IndexOf(audioActual);
                seguen = ObtenirSeguentIndex(index);
            }
            catch 
            {

            }
            
        }

        private void OnBtnDownClick(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem selected = listView1.SelectedItems[0];
                    AudioItem audioItem = playlist.ElementAt(listView1.SelectedIndices[0]);
                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx == totl - 1)
                    {
                        listView1.Items.Remove(selected);
                        playlist.Remove(audioItem);

                        listView1.Items.Insert(0, selected);
                        playlist.Insert(0, audioItem);
                    }
                    else
                    {
                        listView1.Items.Remove(selected);
                        playlist.Remove(audioItem);
                        listView1.Items.Insert(indx + 1, selected);
                        playlist.Insert(indx + 1, audioItem);
                    }
                }
                index = playlist.IndexOf(audioActual);
                seguen = ObtenirSeguentIndex(index);

            }
            catch 
            {
            }
            
        }
        private void PararTot()
        {
            foreach (AudioItem audioItem in playlist)
            {
                
                seguen = -1;
                if (audioItem.Wave != null)
                {
                    audioItem.Wave.Stop();
                    audioItem.Wave.Dispose();
                    audioItem.Wave = null;
                }
                if (audioItem.Isflac)
                {
                    if (audioItem.Flac != null)
                    {
                        audioItem.Flac.Dispose();
                        audioItem.Flac = null;
                    }
                }
                else
                {
                    if (audioItem.Stream != null)
                    {
                        audioItem.Stream.Dispose();

                        audioItem.Stream = null;
                    }
                }
                
            }
        }
        private void OnBtnDeleteClick(object sender, EventArgs e)
        {
            foreach(ListViewItem lst in listView1.SelectedItems)
            {
                listView1.Items.Remove(lst);
            }
        }

        private void OnBtnClearClick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            PararTot();
            playlist.Clear();
            count = 0;
        }
        public async void CarregarWaveFormAsync()
        {
            pictureBox1.Image = await RenderWaveformAsync(playlist.ElementAt(index).FileName);
        }

        protected virtual void OnStartedPlaying(EventArgs e)
        {
            StartedPlaying?.Invoke(this, e);
        }

        public event EventHandler StartedPlaying;
    }
}
