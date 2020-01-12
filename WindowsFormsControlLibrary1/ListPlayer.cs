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
        }
        
        private int index;
        private int seguen;
        private bool stoped = false;
        private List<string> errors = new List<string>();
        bool clicat = false;

        public RAudioNAudio[] rAudio = new RAudioNAudio[2];
        public int actualRaudio = 0;
        public int nextRaudio = 1; 
        

        public int outDev { get; set; }
        public Font fntNotPlaying = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
        public Font fntPlaying = new Font("Arial", 12, System.Drawing.FontStyle.Bold);
        //public bool isAsio { get; set; }
        public bool isPlaying;
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

        public void OnButtonStopClick(object sender, EventArgs e)
        {
            Stop();
        }
 
        #endregion

        public void BuidarLlista()
        {
            if (!isPlaying)
            {
                dropListView1.listView1.Items.Clear();
            }
        }

        
        private void OnTimerTick(object sender, EventArgs e)
        {
            
            if (((RAudioNAudio)dropListView1.listView1.Items[index].Tag) != null )
            {
                TimeSpan currentTime = (((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Status == PlaybackState.Stopped) ? TimeSpan.Zero : ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).CurrentTime;
                TimeSpan remainingTime = ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).TotalTime - currentTime;
                trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).TotalTime.TotalSeconds));
                labelCurrentTime.Text = currentTime.ToString();
                

                labelRemain.Text = remainingTime.ToString();

            }
            else
            {
                trackBarPosition.Value = 0;
            }
            
        }

        //volume slider changed



        public void Stop()
        {
            try
            {
                foreach (ListViewItem i in dropListView1.listView1.Items)
                {
                    ((RAudioNAudio)i.Tag).Stop();
                }
            }
            catch { }
            ResetVUMeter();

            if (index > -1 &&  dropListView1.listView1.Items.Count > index)
            {
                dropListView1.listView1.Items[index].Font = fntNotPlaying;
            }
            index = -1;

            ResetTimeLabels();

            stoped = true;
            
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
            /*
            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
               audioFileReader.TotalTime.Seconds);

            */
        }

        private void PlaySong()
        {

            if (!index.IsInRange(dropListView1.listView1.Items.Count))
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

            if (dropListView1.listView1.Items[index].Tag != null)
            {
                if (((RAudioNAudio)dropListView1.listView1.Items[index].Tag).IsPlaying)
                {
                    return;
                }
                else if (((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Status == PlaybackState.Paused)
                {

                    ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Play();
                    timer1.Start();

                    return;
                }
            }
            else
            {
                dropListView1.listView1.Items[index].Tag = new RAudioNAudio(dropListView1.listView1.Items[index].SubItems[2].Text, outDev);
            }


            if (btnCross.Active)
            {
                ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).PlayFade();
            }
            else
            {
                ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Play();
            }

            //setVolumeDelegate(volumeSlider1.Volume);

            ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).postVolumeMeter.StreamVolume += PostVolumeMeter_StreamVolume; 

            ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Ending += RAudio_Ending;
            ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Ended += RAudio_Ended;

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
            if (!btnCross.Active)
            {
                OnEnding();
            }
            ResetTimeLabels();
        }

        private void RAudio_Ending(object sender, EventArgs e)
        {
            if (btnCross.Active)
            {
                OnEnding();
            }
        }

        private void OnEnding()
        {
            
                try
                {

                    ResetVUMeter();

                    if (!stoped && !clicat)
                    {
                        if (btnContinuar.Active && btnDel.Active)
                        {
                            if (index.IsInRange(dropListView1.listView1.Items.Count))
                            {
                                dropListView1.listView1.Items.RemoveAt(index);
                                PlaySong();
                            }
                            else if (dropListView1.listView1.Items.Count == 1)
                            {
                                dropListView1.listView1.Items.RemoveAt(0);  
                            }
                            else
                            {
                                isPlaying = false;
                            }
                        }
                        else if (btnContinuar.Active && !btnDel.Active)
                        {
                            //TODO: Fer que funcioni el mode bucle
                            if (btnLoop.Active)
                            {
                                if (index.IsInRange(dropListView1.listView1.Items.Count) && !btnLoop.Active)
                                {
                                    index++;
                                    PlaySong();

                                    if (index < dropListView1.listView1.Items.Count)
                                    {
                                        dropListView1.listView1.Items[index - 1].Font = fntNotPlaying;
                                    }
                                    else
                                    {
                                        isPlaying = false;
                                    }
                                }
                                else 
                                {
                                    dropListView1.listView1.Items[index].Font = fntNotPlaying;
                                    index = 0;
                                    PlaySong();
                                }
                            }
                            else
                            {
                                index++;
                                PlaySong();

                                if (index < dropListView1.listView1.Items.Count)
                                {
                                    dropListView1.listView1.Items[index - 1].Font = fntNotPlaying;
                                }
                                else
                                {
                                    isPlaying = false;
                                }
                            }
                        }
                        else if (!btnContinuar.Active && btnDel.Active)
                        {
                            dropListView1.listView1.Items.RemoveAt(index);
                            
                            isPlaying = false;
                        }
                        else if(!btnContinuar.Active && btnLoop.Active)
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

                //waveOut.Dispose();
            
        }


        private void AfegirFitxers(string[]files)
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

       

        private void listView1_DoubleClick(object sender, EventArgs e)
        {


            if (dropListView1.listView1.SelectedItems.Count == 1)
            {


                if (index.IsInRange(dropListView1.listView1.Items.Count))
                {
                    dropListView1.listView1.Items[index].Font = fntNotPlaying;
                }


                clicat = true;

                if (isPlaying)
                {
                    ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Stop();
                }
                index = dropListView1.listView1.SelectedItems[0].Index;
                PlaySong();
                    
                
                
                
            }
        }

        private void trackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            //if (waveOut != null)
            //{
            //    timer1.Start();
                
            //    audioFileReader.CurrentTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
            //}
        }

        private void trackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();  
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dropListView1.listView1.Items[index].Tag != null)
            {
                if (((RAudioNAudio) dropListView1.listView1.Items[index].Tag).Status == PlaybackState.Playing || ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Status == PlaybackState.Paused)
                {
                    ((RAudioNAudio)dropListView1.listView1.Items[index].Tag).Stop();
                }
            }
            if (btnContinuar.Active && !btnDel.Active)
            {
                if (dropListView1.listView1.Items.Count > 1 && index < dropListView1.listView1.Items.Count)
                {
                    index++;
                    PlaySong();

                    if (index < dropListView1.listView1.Items.Count)
                    {
                        dropListView1.listView1.Items[index - 1].Font = fntNotPlaying;
                    }
                    else
                    {
                        isPlaying = false;
                    }
                }
            }
            else if (!btnContinuar.Active && btnDel.Active)
            {
                dropListView1.listView1.Items.RemoveAt(index);
            }
        }



        #region Windows Forms events


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
            if(e.KeyCode == Keys.MediaPlayPause)
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

        private void buidarLlistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuidarLlista();
        }


        #endregion
    }
}
