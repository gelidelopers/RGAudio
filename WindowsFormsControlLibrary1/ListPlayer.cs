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
using RAudioDataAccess.Models;
using Gelida_Player;
using RAudioNAudioLib;
using RAudioUtils;

namespace RAudioControls
{

    public partial class ListPlayer : UserControl
    {
        public ListPlayer()
        {
            InitializeComponent();
            dropListView1.listView1.DoubleClick += listView1_DoubleClick;
            dropListView1.listView1.KeyUp += ListView1_KeyUp;
            dropListView1.listView1.DragDrop += ListView1_DragDrop;
            dropListView1.listView1.DragEnter += ListView1_DragEnter;
            btnContinuar.Click += BtnContinuar_Click;
            btnDel.Click += BtnDel_Click;
            btnCross.Click += BtnCross_Click; 
            btnLoop.Click += BtnLoop_Click;
        }

        private void ListView1_DragEnter(object sender, DragEventArgs e)
        {
            playing = dropListView1.listView1.Items[index];
        }

        private void ListView1_DragDrop(object sender, DragEventArgs e)
        {
            if (playing != null)
            {
                index = dropListView1.listView1.Items.IndexOf(playing);
                CalcularSeguenIndex();
            }
        }

        private int index;
        private int seguen;
        ListViewItem playing;
        private bool indexClicat = false;


        public List<RAudioNAudio> rAudio = new List<RAudioNAudio>();
        

        public int outDev { get; set; }
        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        //public bool isAsio { get; set; }
        public bool isPlaying = false;
        public List<string> extensions = new List<string>(new string[] { ".mp3" ,".wav",".aac",".m4a",".wma"});

        #region Events functions

        private void OnOpenFileClick(object sender, EventArgs e)
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
            openFileDialog.Dispose();
        }

        private void OnButtonPauseClick(object sender, EventArgs e)
        {
            //if (waveOut != null)
            //{
            //    if (waveOut.PlaybackState == PlaybackState.Playing)
            //    {
            //        waveOut.Pause();
            //        ResetVUMeter();
            //    }
            //}
        }

        #endregion

        #region Public Functions
        public void AfegirFitxers(string[] files)
        {
            List<string> errors = new List<string>();
            string extensio;

            foreach (string file in files)
            {
                extensio = Path.GetExtension(file);
                //posar el path.get en una variable i posar tots els fitxers compatibles en un List
                if (Path.GetExtension(file) == ".wav" || Path.GetExtension(file) == ".flac" || Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".aac")
                {

                    Audio axr = new Audio
                    {
                        fileName = file
                    };

                    try
                    {
                        var tfile = TagLib.File.Create(axr.fileName);
                        axr.name = tfile.Tag.Title ?? Path.GetFileNameWithoutExtension(axr.fileName);
                        axr.duration = tfile.Properties.Duration;
                        tfile.Dispose();

                        string[] lol = { axr.name, axr.duration.ToString("c"), axr.fileName };

                        var itom = new ListViewItem(lol)
                        {
                            BackColor = Color.Yellow
                        };

                        //item.SubItems.Add(axr.artist);
                        //item.SubItems.Add(axr.duration.ToString());

                        dropListView1.listView1.Items.Add(itom);
                        rAudio.Add(new RAudioNAudio(axr.fileName, outDev) { EnableAutoFadeOut = btnCross.Active});

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
            CalcularSeguenIndex();
        }

        public void BuidarLlista()
        {
            if (!isPlaying)
            {
                dropListView1.listView1.Items.Clear();
                rAudio.Clear();
            }
            CalcularSeguenIndex();
        }

        public void Stop()
        {
            try
            {
                rAudio[index].Stop();
                foreach(RAudioNAudio i in rAudio)
                {
                    
                    i.Stop();
                }
                index = -1;
                isPlaying = false;
            }
            catch { }
            ResetVUMeter();

            if (index.IsInRange(dropListView1.listView1.Items.Count))
            {
                dropListView1.listView1.Items[index].Font = fntNotPlaying;
            }

            ResetTimeLabels();

        }

        public void PlaySong()
        {

            if (seguen.IsInRange(dropListView1.listView1.Items.Count))
            {
                if (btnCross.Active)
                {
                    rAudio[seguen].PlayFade();
                }
                else
                {
                    rAudio[seguen].Play();
                }
                rAudio[seguen].postVolumeMeter.StreamVolume += PostVolumeMeter_StreamVolume;
                
                rAudio[seguen].Ending += RAudio_Ending;
                rAudio[seguen].Ended += RAudio_Ended;
                indexClicat = false;
                index = seguen;
                isPlaying = true;
                CalcularSeguenIndex();

                timer1.Start();
            }

        }

        public void Seguen()
        {
            CalcularSeguenIndex();
            PlaySong();
        }

        #endregion


        #region Windows Forms events

        private void BtnLoop_Click(object sender, EventArgs e)
        {
            CalcularSeguenIndex();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            CalcularSeguenIndex();
        }

        private void BtnContinuar_Click(object sender, EventArgs e)
        {
            CalcularSeguenIndex();
        }

        private void BtnCross_Click(object sender, EventArgs e)
        {
            rAudio[index].EnableAutoFadeOut = btnCross.Active;
            CalcularSeguenIndex();
        }

        private void ListView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ListViewItem playing = dropListView1.listView1.Items[index];
                foreach (ListViewItem i in dropListView1.listView1.SelectedItems)
                {
                    if (!i.Equals(playing))
                    {
                        rAudio.RemoveAt(i.Index);
                        dropListView1.listView1.Items.Remove(i);
                    }
                }
                index = dropListView1.listView1.Items.IndexOf(playing);
                CalcularSeguenIndex();

            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            PlaySong();
        }


        private void buidarLlistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuidarLlista();
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            Stop();
            index = -1;
        }
        private void btnDB_Click(object sender, EventArgs e)
        {
            frmAudioFinder af = new frmAudioFinder();
            af.Show();
        }

        private void toolStripMenuDelete_Click(object sender, EventArgs e)
        {
            if (dropListView1.listView1.FocusedItem.Index != index)
            {
                dropListView1.listView1.FocusedItem.Remove();
                rAudio.RemoveAt(dropListView1.listView1.FocusedItem.Index);

                CalcularSeguenIndex();
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dropListView1.listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStripSelected.Show(Cursor.Position);
                }
            }
        }

        private void listView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.MediaPlayPause)
            {
                PlaySong();
            }
        }

        private void listView1_Enter(object sender, EventArgs e)
        {
            dropListView1.listView1.BackColor = Color.LightBlue;
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            dropListView1.listView1.BackColor = Color.White;
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            if (dropListView1.listView1.SelectedItems.Count == 1)
            {


                if (index.IsInRange(dropListView1.listView1.Items.Count))
                {
                    dropListView1.listView1.Items[index].Font = fntNotPlaying;
                }

                

                if (isPlaying)
                {
                    rAudio[index].Stop();
                }
                index = dropListView1.listView1.SelectedItems[0].Index;
                indexClicat = true;
                PlaySong();
            }
        }

        private void trackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (rAudio[index] != null)
            {

                rAudio[index].CurrentTime = TimeSpan.FromSeconds(rAudio[index].TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
                timer1.Start();

            }
        }

        private void trackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Seguen();
        }

        #endregion

        private void OnTimerTick(object sender, EventArgs e)
        {
            if (index.IsInRange(rAudio.Count) && rAudio[index] != null )
            {
                TimeSpan currentTime = (rAudio[index].Status == PlaybackState.Stopped) ? TimeSpan.Zero : rAudio[index].CurrentTime;
                TimeSpan remainingTime = rAudio[index].TotalTime - currentTime;
                trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / rAudio[index].TotalTime.TotalSeconds));

                labelRemain.Text = remainingTime.ToString(@"hh\:mm\:ss");
                labelCurrentTime.Text = currentTime.ToString(@"hh\:mm\:ss");

            }
            else
            {
                trackBarPosition.Value = 0;
            }
        }
        private void ResetVUMeter()
        {
            volumeMeter1.Amplitude = 0;
            volumeMeter2.Amplitude = 0;
            volumeMeter3.Amplitude = 0;
            volumeMeter4.Amplitude = 0;
        }

        private void ResetTimeLabels()
        {
            labelCurrentTime.Text = "0:00:00";
            labelTotalTime.Text = "0:00:00";
            labelRemain.Text = "0:00:00";
        }


        /// <summary>
        /// Reestructurar funcio playsong
        /// </summary>
        
        private void CarregarDuracio()
        {
            
            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)rAudio[index].TotalTime.TotalMinutes,
               rAudio[index].TotalTime.Seconds);

            
        }

        
        private void PostVolumeMeter_StreamVolume(object sender, StreamVolumeEventArgs e)
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

        private void RAudio_Ended(object sender, EventArgs e)
        {
            
            ResetTimeLabels();

            if (btnDel.Active)
            {
                if (index.IsInRange(dropListView1.listView1.Items.Count))
                {
                    dropListView1.listView1.Items[index].Remove();
                    rAudio.RemoveAt(index);
                    rAudio[index].Dispose();
                }
            }
        }

        private void RAudio_Ending(object sender, EventArgs e)
        {
            OnEnding();
        }
        private void OnEnding()
        {
                ResetVUMeter();
            
            PlaySong();
        }
        private void CalcularSeguenIndex()
        {
            if (indexClicat)
            {
                if (btnContinuar.Active)
                {
                    if (btnLoop.Active)
                    {
                        if(index == rAudio.Count - 1)
                        {
                            seguen = 0;
                        }
                        else
                        {
                            seguen = index + 1;
                        }
                    }
                    else
                    {
                        seguen = index + 1;
                    }
                }
                else if (btnLoop.Active)
                {
                    seguen = index;
                }
                else
                {
                    seguen = -1;
                }
            }
        }
    }
}
