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
            audio = new AudioItem[2];

        }

        private int index = 0;
        private sbyte actualAudio = 0;
        private sbyte nextAudio = 0;
        private int seguen = 0;
        private List<string> errors = new List<string>();
        private int count = 0;
        private Action<float> setVolumeDelegate;
        private WaveFormRenderer waveFormRenderer;
        private Pen waveFormPos;
        private sbyte trais = 0;

        private AudioItem[] audio;

        public bool Continuar = true;
        public bool Borrar = true;
        public bool Bucle = false;
        public Guid OutDev { get; set; }
        public Color waveColor {get; set;}

        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntNext = new Font("Arial", 10, System.Drawing.FontStyle.Underline);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        //public bool isAsio { get; set; }
        public bool isPlaying;
        public List<string> extensions = new List<string>(new string[] { ".mp3", ".wav", ".aac", ".m4a", ".wma" });


        private void CreateInputStream(AudioItem audioItem)
        {
            //audioItem = new AudioItem();
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
        private void InicialitzarSo(AudioItem audioItem, Guid devnumber)
        {
            audioItem.Wave = new WaveOutEvent();
               
            audioItem.Wave.Init(audioItem.SampleProvider);
            audioItem.Wave.Volume = 0;
            audioItem.Wave.Play();
            audioItem.Wave.Pause();
            audioItem.Wave.Volume = 1;
        }
        private void PlaySong()
        {
            if (count > 0 && seguen >= 0 )
            {
                if (audio[actualAudio] != null)
                {
                    //problemes al borrar dona out of bounds
                    if (audio[actualAudio].Wave.PlaybackState == PlaybackState.Playing)
                    {
                        return;
                    }
                    else 
                    {
                        try
                        {
                            audio[actualAudio].Wave.Play();
                            audio[actualAudio].Wave.PlaybackStopped += PlayNext;
                            lblName.Text = audio[actualAudio].Name;
                            lblArtist.Text = audio[actualAudio].Artist;
                            listView1.Items[index].Font = fntPlaying;
                            CarregarDuracio(audio[actualAudio]);
                            pictureBox1.Image = audio[actualAudio].myImage;
                            seguen = ObtenirSeguentIndex(index);
                            OnStartedPlaying(EventArgs.Empty);

                            if (Borrar)
                            {
                                listView1.Items.RemoveAt(index);
                            }
                            else
                            {
                                listView1.Items[index].Font = fntNotPlaying;
                            }


                            CarregarSeguenAudio();

                            //listView1.Items[index].Font = fntPlaying;

                            isPlaying = true;

                            timer1.Start();
                            
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
                    audio[actualAudio] = CarregarFitxer(audio[actualAudio], index);
                    if (trais < 3)
                    {
                        PlaySong();
                    }
                    else
                    {

                        listView1.Items.RemoveAt(index);
                        
                    }

                    return;
                    

                    //

                }
            }
        }

        private void PlayNext(object sender, StoppedEventArgs e)
        {
            audio[nextAudio].Wave.Play();

            actualAudio = nextAudio;
        }

        private void CarregarSeguenAudio()
        {
            if (!Continuar && Bucle)
            {
                nextAudio = actualAudio;
            }
            else
            {
                if (actualAudio == 0)
                {
                    nextAudio = 1;

                }
                else
                {
                    nextAudio = 0;
                }
                audio[nextAudio] = CarregarFitxer(audio[nextAudio], seguen);

            }
        }

        private AudioItem CarregarFitxer(AudioItem audioItem, int num)
        {
            try
            {
                audioItem = new AudioItem { FileName = listView1.Items[num].SubItems[2].Text };
                CreateInputStream(audioItem);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error amb el fitxer");
                trais++;
                
                var window = MessageBox.Show(
                "S'ha intentat varies vegades carregar el fitxer = "+e.ToString() +", vols borrar-lo de la llista de reproducció?",
                "Error al carregar el fitxer"/*Barra de titulo*/,
                MessageBoxButtons.YesNo);

                try
                { 
                    if (window == DialogResult.No) listView1.Items.Remove(audioItem.LstviewItem);
                }
                catch
                {

                }
                return null;
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
                return null;
            }
            trais = 0;
            return audioItem;

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
                BottomPeakPen = new Pen(waveColor),
                TopPeakPen = new Pen(waveColor)

            };
            return settings;
        }

        private async Task<Image> RenderWaveformAsync(string filename)
        {
           
            var settings = GetRendererSettings();

            //labelRendering.Visible = true;
            //Enabled = false;
            var peakProvider = new RmsPeakProvider(pictureBox1.Height / 2);
            var img = await Task.Factory.StartNew(() => RenderThreadFunc(peakProvider, settings, filename));
            return img;
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
            string extensio = Path.GetExtension(file);

            //posar el path.get en una variable i posar tots els fitxers compatibles en un List
            if (extensio == ".wav" || extensio == ".flac" || extensio == ".mp3" || extensio == ".aac")
            {
                

                try
                {
                    var tfile = TagLib.File.Create(file);
                    Arxiu axr = new Arxiu
                    {
                        fileName = file,
                        name = tfile.Tag.Title ?? file.Replace(extensio,""),
                        artist = tfile.Tag.JoinedPerformers

                    };
                    
                    string[] lol = { axr.name, axr.artist, axr.fileName };

                    var itom = new ListViewItem(lol)
                    {
                        BackColor = Color.Yellow
                    };

                    //item.SubItems.Add(axr.artist);
                    //item.SubItems.Add(axr.duration.ToString());
                    
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
                        i = index + 1;
                    }
                }
                else
                {
                    i = index +1;

                }
                if(audio[nextAudio] != null)
                {
                    if(audio[nextAudio].FileName != listView1.Items[i].SubItems[2].Text)
                    {
                        audio[nextAudio].FileName = listView1.Items[i].SubItems[2].Text;
                    }
                }
            }
            else if (Bucle)
            {
                //if (seguen >= 0 && listView1.Items[seguen].Font == fntNext) listView1.Items[seguen].Font = fntNotPlaying;
                if (!Borrar)
                {
                    i = actual;
                    audio[nextAudio] = audio[actualAudio];
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
            count = listView1.Items.Count;
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
                
                if (!audio[actualAudio].Isflac)
                {
                    if (audio[actualAudio].Wave != null)
                    {

                        TimeSpan currentTime = (audio[actualAudio].Wave.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audio[actualAudio].Stream.CurrentTime;
                        //trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / audio[actualAudio].Stream.TotalTime.TotalSeconds));
                        panelCursor.Location = new Point(Math.Min(panelTop.Width, (int)(panelTop.Width * currentTime.TotalSeconds / audio[actualAudio].Stream.TotalTime.TotalSeconds)), panelCursor.Location.Y);
                        labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
                        int min, sec;

                        min = (int)(audio[actualAudio].Stream.TotalTime.TotalSeconds - audio[actualAudio].Stream.CurrentTime.TotalSeconds) / 60;
                        sec = (int)(audio[actualAudio].Stream.TotalTime.TotalMilliseconds - audio[actualAudio].Stream.CurrentTime.TotalMilliseconds) % 60000;

                        if (min == 0 && sec == 5)
                        {
                            StartFade();
                        }

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
                    if (audio[actualAudio].Wave != null)
                    {

                        TimeSpan currentTime = (audio[actualAudio].Wave.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audio[actualAudio].Flac.CurrentTime;
                        //trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / audio[actualAudio].Flac.TotalTime.TotalSeconds));
                        panelCursor.Location = new Point(Math.Min(panelTop.Width, (int)(panelTop.Width * currentTime.TotalSeconds / audio[actualAudio].Flac.TotalTime.TotalSeconds)), panelCursor.Location.Y);
                        labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);
                        int min, sec;
                        min = (int)(audio[actualAudio].Flac.TotalTime.TotalSeconds - audio[actualAudio].Flac.CurrentTime.TotalSeconds) / 60;
                        sec = (int)(audio[actualAudio].Flac.TotalTime.TotalMilliseconds - audio[actualAudio].Flac.CurrentTime.TotalMilliseconds) % 60000;

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

        private void StartFade()
        {
            audio[actualAudio].Fade.BeginFadeOut(5000);
            audio[actualAudio].Fade.FollowedBy(audio[nextAudio].Stream);
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
                if (audio[actualAudio].Wave != null)
                {
                    if (audio[actualAudio].Wave.PlaybackState == PlaybackState.Playing)
                    {
                        audio[actualAudio].Wave.Pause();
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
                if (!audio[actualAudio].Isflac)
                {
                    if (audio[actualAudio].Stream != null)
                    {

                        audio[actualAudio].Stream.CurrentTime = TimeSpan.FromSeconds(audio[actualAudio].Stream.TotalTime.TotalSeconds * mouseX / panelTop.Width);
                    }
                }
                else
                {
                    if (audio[actualAudio].Flac != null)
                    {
                        audio[actualAudio].Flac.CurrentTime = TimeSpan.FromSeconds(audio[actualAudio].Flac.TotalTime.TotalSeconds * mouseX / panelTop.Width);
                        
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

                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx == 0)
                    {
                        listView1.Items.Remove(selected);


                        listView1.Items.Insert(totl - 1, selected);

                    }
                    else
                    {
                        listView1.Items.Remove(selected);


                        listView1.Items.Insert(indx - 1, selected);

                    }
                }
                

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

                    int indx = selected.Index;
                    int totl = listView1.Items.Count;

                    if (indx == totl - 1)
                    {
                        listView1.Items.Remove(selected);


                        listView1.Items.Insert(0, selected);

                    }
                    else
                    {
                        listView1.Items.Remove(selected);

                        listView1.Items.Insert(indx + 1, selected);
                        
                    }
                }

                seguen = ObtenirSeguentIndex(index);

            }
            catch 
            {
            }
            
        }
        private void PararTot()
        {
            try
            {
                audio[actualAudio].Wave.PlaybackStopped -= PlayNext;
                audio[nextAudio].Wave.PlaybackStopped -= PlayNext;


                audio[actualAudio].Wave.Stop();
                audio[nextAudio].Wave.Stop();

                audio[actualAudio].Wave.Dispose();
                audio[nextAudio].Wave.Dispose();

                audio[actualAudio].Wave = null;
                audio[nextAudio].Wave = null;

                audio[actualAudio] = null;
                audio[nextAudio] = null;


            }
            catch
            {

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

            count = 0;
        }
        public async void CarregarWaveFormAsync()
        {
            pictureBox1.Image = await RenderWaveformAsync(audio[actualAudio].FileName);
        }

        protected virtual void OnStartedPlaying(EventArgs e)
        {
            StartedPlaying?.Invoke(this, e);
        }

        public event EventHandler StartedPlaying;
    }
}
