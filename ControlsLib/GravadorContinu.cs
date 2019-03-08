using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Lame;
using System.IO;
using System.Globalization;
using NAudio.Wave.SampleProviders;

namespace ControlsLib
{
    public partial class GravadorContinu : UserControl
    {
        public int InDev { get; set; }
        public string OutPath { get; set; }
        public string OutFormat { get; set; }
        public string Programa { get; set; }
        public bool RecordMP3 { get; set; }
        public bool Recording ;

        IWaveIn sourceStream;
        NAudio.Lame.LameMP3FileWriter mp3Writer;
        NAudio.Wave.WaveFileWriter waveWriter;

        bool recording = false;
        
        string path = "";
        string filename = "";
        string filetype = "";
        Timer timer;
        int incrementNumber = 0;
        private string Format { get; set; }
        public GravadorContinu()
        {
            InitializeComponent();

            timer = new Timer(); //a timer for stopping recording at a certain time
            timer.Interval = 120000; //max recording of 120000ms (2 minutes)
            timer.Tick += new EventHandler(Timer_Tick);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (recording)
            {
                StopRecording();
            }
        }

        public void StartRecording()
        {
            if (!recording)
            {
                sourceStream = new NAudio.Wave.WaveIn();
                sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(SourceStream_DataAvailable);
                path = OutPath + "\\";
                filename = GetFileName(false);

                if (RecordMP3)
                {
                    filetype = ".mp3";
                    mp3Writer = new NAudio.Lame.LameMP3FileWriter(filename + filetype, sourceStream.WaveFormat, 128);
                }
                else
                {
                    filetype = ".wav";
                    waveWriter = new NAudio.Wave.WaveFileWriter(filename + filetype, sourceStream.WaveFormat);
                }

                sourceStream.StartRecording();
                recording = true;
                timer.Start();

                

            }
            else
            {
                StopRecording();
            }

        }

        private void meteringProvider_StreamVolume(object sender, StreamVolumeEventArgs e)
        {
            volumeMeter1.Amplitude =  e.MaxSampleValues[0];
            volumeMeter2.Amplitude = e.MaxSampleValues[1];
        }

        public void RestartRecord()
        {
            Recording = false;
            sourceStream.StopRecording();

            filename = GetFileName(false);

            filetype = ".mp3";
            mp3Writer = new LameMP3FileWriter(filename + filetype, sourceStream.WaveFormat, NAudio.Lame.LAMEPreset.STANDARD_FAST);
            sourceStream.StartRecording();
            Recording = true;

        }
        public void StopRecording()
        {
            if (Recording)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                if (mp3Writer != null)
                    mp3Writer.Dispose();
                if (waveWriter != null)
                    waveWriter.Dispose();
                Recording = false;
                timer.Stop();

                MessageBox.Show("moved : " + Path.GetFullPath(filename + filetype) + "to: " + Path.GetFullPath(path + filename + filetype));

                File.Move(filename + filetype, path + filename + filetype);

            }

        }

        private string GetFileName(bool preview)
        {

            string filename = "";
            string format = Format;
            DateTime dt = DateTime.Now;

            //return default if format is empty
            if (string.IsNullOrEmpty(format))
            {
                format = "%y-%mo-%d %h-%mi-%s QuickRecording";
            }

            //remove illegal characters
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                format = format.Replace(c.ToString(), "");
            }

            StringBuilder sb = new StringBuilder(format);

            sb.Replace("%mon2", CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(dt.Month))
                .Replace("%mon", CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt.Month))
                .Replace("%yy", dt.ToString("yy"))
                .Replace("%y", dt.Year.ToString())
                .Replace("%mo", Helpers.AddZeroes(dt.Month))
                .Replace("%d", Helpers.AddZeroes(dt.Day));

            string hour;

            if (sb.ToString().Contains("%pm"))
            {
                hour = Helpers.HourTo12(dt.Hour);
            }
            else
            {
                hour = Helpers.AddZeroes(dt.Hour);
            }

            sb.Replace("%h", hour)
                .Replace("%mi", Helpers.AddZeroes(dt.Minute))
                .Replace("%s", Helpers.AddZeroes(dt.Second))
                .Replace("%ms", Helpers.AddZeroes(dt.Millisecond, 3))
                .Replace("%w2", CultureInfo.InvariantCulture.DateTimeFormat.GetDayName(dt.DayOfWeek))
                .Replace("%w", CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek))
                .Replace("%pm", (dt.Hour >= 12 ? "PM" : "AM"));

            if (sb.ToString().Contains("%i"))
            {
                if (!preview)
                {
                    incrementNumber++;
                }
                sb.Replace("%i", incrementNumber.ToString());
                sb.Replace("%i", incrementNumber.ToString());
            }

            sb.Replace("%un", Environment.UserName);
            sb.Replace("%uln", Environment.UserDomainName);
            sb.Replace("%cn", Environment.MachineName);

            filename = sb.ToString();

            

            return filename;
        }

        private void SourceStream_DataAvailable(object sender, WaveInEventArgs e)
        {

            if (RecordMP3)
            {
                if (mp3Writer == null || !mp3Writer.CanWrite)
                    return;

                mp3Writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
            else
            {
                if (waveWriter == null)
                    return;
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                waveWriter.Flush();
            }


        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //var enumerator = new MMDeviceEnumerator();
            //enumerator.
        }
    }
}
