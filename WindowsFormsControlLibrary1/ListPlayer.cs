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

    public partial class ListPlayer : UserControl
    {
        public ListPlayer()
        {
            InitializeComponent();
        }
        private IWavePlayer waveOut;
        private WaveOutEvent ou;
        //private AsioOut asioOut;
        private AudioFileReader audioFileReader;
        private Action<float> setVolumeDelegate;
        private ISampleProvider sampleProvider;
        private int index;
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


        private void OnOpenFileClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            string allExtensions = "*.wav;*.aiff;*.mp3;*.aac;*.flac";
            openFileDialog.Filter = String.Format("Fiters de musica coneguts|{0}|Tots els fitxers (*.*)|*.*", allExtensions);
            openFileDialog.Multiselect = true;

            //openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fl in openFileDialog.FileNames)
                {
                    Arxiu axr = new Arxiu();
                    axr.fileName = fl;

                    try
                    {
                        var tfile = TagLib.File.Create(axr.fileName);
                        axr.name = tfile.Tag.Title ?? Path.GetFileNameWithoutExtension(axr.fileName);
                        axr.artist = tfile.Tag.JoinedPerformers;

                        string[] lol = { axr.name, axr.artist, axr.fileName };

                        var item = new ListViewItem(lol);
                        item.BackColor = Color.Yellow;

                        //item.SubItems.Add(axr.artist);
                        //item.SubItems.Add(axr.duration.ToString());

                        listView1.Items.Add(item);

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
                        if (!errors.Contains("Tipus de fitxer " + Path.GetExtension(fl) + " no acceptat :("))
                        {
                            errors.Add("Tipus de fitxer " + Path.GetExtension(fl) + " no acceptat :(");
                        }
                    }
                    catch
                    {
                        if (!errors.Contains("Error al carregar el fitxer " + Path.GetFullPath(fl) + " :("))
                        {
                            errors.Add("Error al carregar el fitxer " + Path.GetFullPath(fl) + " :(");
                        }
                    }
                }
            }
    
            foreach (string error in errors)
            {
                MessageBox.Show(error);
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
            volumeMeter4.Amplitude = e.MaxSampleValues[0];
        }
        
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (waveOut != null && audioFileReader != null)
            {
                TimeSpan currentTime = (waveOut.PlaybackState == PlaybackState.Stopped) ? TimeSpan.Zero : audioFileReader.CurrentTime;
                trackBarPosition.Value = Math.Min(trackBarPosition.Maximum, (int)(100 * currentTime.TotalSeconds / audioFileReader.TotalTime.TotalSeconds));
                labelCurrentTime.Text = String.Format("{0:00}:{1:00}", (int)currentTime.TotalMinutes, currentTime.Seconds);



            }
            else
            {
                trackBarPosition.Value = 0;
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

        //volume slider changed
        private void problemes(object sender, EventArgs e)
        {
            
        }

        private void OnButtonPauseClick(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                }
            }
        }

        public void OnButtonStopClick(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                volumeMeter1.Amplitude = 0;
                volumeMeter2.Amplitude = 0;
                volumeMeter3.Amplitude = 0;
                volumeMeter4.Amplitude = 0;
                stoped = true;
                
            }
        }

        //button play onclick
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            PlaySong();
            
            /*

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

            if (String.IsNullOrEmpty(fileName))
            {
                OnOpenFileClick(sender, e);
            }
            if (String.IsNullOrEmpty(fileName))
            {
                return;
            }


            try
            {
                sampleProvider = CreateInputStream(fileName);
            }
            catch (Exception createException)
            {
                MessageBox.Show(String.Format("{0}", createException.Message), "Error Loading File");
                return;
            }


            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
                audioFileReader.TotalTime.Seconds);

            try
            {
                waveOut = new WaveOut();
                waveOut.Init(sampleProvider);
            }
            catch (Exception initException)
            {
                MessageBox.Show(String.Format("{0}", initException.Message), "Error Initializing Output");
                return;
            }


            //setVolumeDelegate(volumeSlider1.Volume);


            waveOut.Play();
            timer1.Start();
            timer2.Start();
            */


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


            try
            {
                //canviar dequeue per first si esta activat o no el borrar
                sampleProvider = CreateInputStream(listView1.Items[index].SubItems[2].Text);
            }
            catch (Exception createException)
            {
                MessageBox.Show(String.Format("{0}", createException.Message), "Error al carregar el fitxer");
                listView1.Items.RemoveAt(index);
                return;
            }


            labelTotalTime.Text = String.Format("{0:00}:{1:00}", (int)audioFileReader.TotalTime.TotalMinutes,
                audioFileReader.TotalTime.Seconds);

            try
            {

                //if (isAsio)
                //{
                //    asioOut = new AsioOut(outDev);
                //    waveOut = asioOut;
                //}
                //else
                //{
                    ou = new WaveOutEvent();
                    ou.DeviceNumber = outDev;
                    waveOut = ou;
                //}
                

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
                    if (!stoped && !clicat)
                    {

                        if (Continuar && Borrar)
                        {
                            if (listView1.Items.Count > 1 && index - 1 < listView1.Items.Count)
                            {
                                //if (!skiped)
                                //{
                                try
                                {

                                    listView1.Items.RemoveAt(index);
                                }
                                catch
                                {

                                }
                                //}
                                //playlist.Dequeue();
                                PlaySong();
                                //listView1.Items[index].Font = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
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
                                    try
                                    {
                                        listView1.Items[index - 1].Font = fntNotPlaying;
                                    }
                                    catch
                                    {

                                    }

                                }
                                else
                                {
                                    isPlaying = false;
                                }
                            }
                            else if (Bucle)
                            {
                                try
                                {
                                    listView1.Items[index].Font = fntNotPlaying;
                                }
                                catch
                                {

                                }
                                index = 0;
                                PlaySong();
                            }
                        }
                        else if (!Continuar && Borrar)
                        {
                            try
                            {

                                listView1.Items.RemoveAt(index);
                            }
                            catch
                            {

                            }
                            isPlaying = false;
                        }
                    }
                    else if (clicat)
                    {
                        if (Borrar)
                        {

                        }
                        //wiw
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
                
            };
            try
            {
                waveOut.Play();
                stoped = false;
                clicat = false;
                listView1.Items[index].Font = fntPlaying;
                isPlaying = true;
                timer1.Start();
                timer2.Start();
            }
            catch
            {

            }
            
        }
        

        private void btnContinu_Click(object sender, EventArgs e)
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
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //Begins a drag-and-drop operation in the ListView control.
           // listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Move);
            base.DoDragDrop(listView1.SelectedItems[0], DragDropEffects.Move);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {

                var item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                if (item.Font != fntPlaying)
                {
                    e.Effect = DragDropEffects.Move;
                }
                
            }else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                //if (listView1.SelectedItems.Count == 0)
                //{
                //    return;
                //}
                //Returns the location of the mouse pointer in the ListView control.
                Point cp = listView1.PointToClient(new Point(e.X, e.Y));
                //Obtain the item that is located at the specified location of the mouse pointer.
                ListViewItem dragToItem = listView1.GetItemAt(cp.X, cp.Y);
                //if (dragToItem == null)
                //{
                //    return;
                //}
                //Obtain the index of the item at the mouse pointer.
                int dragIndex = dragToItem.Index;
                ListViewItem[] sel = new ListViewItem[listView1.SelectedItems.Count];
                for (int i = 0; i <= listView1.SelectedItems.Count - 1; i++)
                {
                    sel[i] = listView1.SelectedItems[i];
                }
                for (int i = 0; i < sel.GetLength(0); i++)
                {
                    //Obtain the ListViewItem to be dragged to the target location.
                    ListViewItem dragItem = sel[i];
                    int itemIndex = dragIndex;
                    //if (itemIndex == dragItem.Index)
                    //{
                    //    return;
                    //}
                    if (dragItem.Index < itemIndex)
                        itemIndex++;
                    else
                        itemIndex = dragIndex + i;
                    //Insert the item at the mouse pointer.
                    ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                    listView1.Items.Insert(itemIndex, insertItem);
                    //Removes the item from the initial location while 
                    //the item is moved to the new location.
                    listView1.Items.Remove(dragItem);
                }



            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                List<string> errors = new List<string>();
                
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".wav"|| Path.GetExtension(file) == ".flac" || Path.GetExtension(file) == ".mp3" || Path.GetExtension(file) == ".aac")
                    {

                        Arxiu axr = new Arxiu();
                        axr.fileName = file;

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
                foreach(string error in errors)
                {
                    MessageBox.Show(error);
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
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
        }
        private void btnLoop_Click(object sender, EventArgs e)
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
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (index < listView1.Items.Count)
                {
                    listView1.Items[index].Font = fntNotPlaying;
                }
                index = listView1.SelectedItems[0].Index;

                if (waveOut != null)
                {
                    clicat = true;
                    
                    if (waveOut.PlaybackState == PlaybackState.Playing || waveOut.PlaybackState == PlaybackState.Paused)
                    {
                        waveOut.Stop();
                    }
                    else
                    {
                        PlaySong();
                    }
                    
                }
                else
                {
                    PlaySong();
                } 
            }
        }

        private void trackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            if (waveOut != null)
            {
                timer1.Start();
                timer2.Start();
                audioFileReader.CurrentTime = TimeSpan.FromSeconds(audioFileReader.TotalTime.TotalSeconds * trackBarPosition.Value / 100.0);
            }
        }

        private void trackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing || waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Stop();
                }
            }
            else if (Continuar && !Borrar)
            {
                if (listView1.Items.Count > 1 && index < listView1.Items.Count)
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
            }
            else if (!Continuar && Borrar)
            {
                listView1.Items.RemoveAt(index);
            }
        } 
    }
}
