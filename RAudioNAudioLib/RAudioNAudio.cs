using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace RAudioNAudioLib
{
    public class RAudioNAudio
    {
        #region Properites
        public bool EnableAutoFadeOut { get; set; }
        public bool IsPlaying { get { return waveOut.PlaybackState == PlaybackState.Playing; } }
        public PlaybackState Status { get { return waveOut.PlaybackState; } }
        private double _fadems = 2000;


        public TimeSpan TotalTime
        {
            get { return audioFileReader.TotalTime; }
        }
        public TimeSpan CurrentTime
        {
            get { return audioFileReader.CurrentTime; }
            set { audioFileReader.CurrentTime = value; }
        }

        public double FadeMs
        {
            get { return _fadems; }
            set { _fadems = value; }
        }



        #endregion

        #region Public NAudio Variables
        public MeteringSampleProvider postVolumeMeter;
        #endregion

        #region  Public events
        public delegate void EndingEventHandler(object sender, EventArgs e);
        public event EndingEventHandler Ending;

        public delegate void EndedEventHandler(object sender, EventArgs e);
        public event EndedEventHandler Ended;
        #endregion

        #region Private variables
        private IWavePlayer waveOut;
        private WaveOutEvent ou;
        private AudioFileReader audioFileReader;
        private ISampleProvider sampleProvider;
        private FadeInOutSampleProvider fade;
        private readonly string FullPath;
        private int OutDev;
        private Timer fadeTimer;
        
        #endregion

        #region Constructor
        public RAudioNAudio(string fullpath, int outdev)
        {
            OutDev = -1;
            FullPath = fullpath;
            CarregarFitxer();
            InicialitzarSo();
        }

        #endregion

        #region Public functions
        public void Play()
        {
            if (waveOut != null)
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    return;
                }
                else if (waveOut.PlaybackState == PlaybackState.Paused)
                {
                    waveOut.Play();
                    return;
                }
                
                waveOut.Play();
                if (EnableAutoFadeOut)
                {
                    fadeTimer = new Timer
                    {
                        Interval = 100
                    };
                    fadeTimer.Elapsed += FadeTimer_Elapsed;
                    fadeTimer.Start();
                }
                waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            }
            
        }

        private void FadeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if ((audioFileReader.TotalTime - audioFileReader.CurrentTime) <= TimeSpan.FromMilliseconds(_fadems))
            {
                Ending.Invoke(sender, e);
                fade.BeginFadeOut(_fadems);
                fadeTimer.Stop();
            }
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Ended.Invoke(sender, e);
        }

        public void PlayFade()
        {
            //audioFileReader.Volume = 0;
            fade.BeginFadeIn(_fadems);
            Play();
            
        }
        public void Stop()
        {
            try
            {
                waveOut.Stop();
            }
            catch (Exception e)
            {
                throw new RAudioNAudioException("error al parar la reproduccio", e);
            }
        }
        #endregion

        #region Private NAudioFunctions
        private void CarregarFitxer()
        {
            if (!File.Exists(FullPath)) throw new RAudioNAudioException("el fitxer d'audio no existeix", new FileNotFoundException(FullPath));
            try
            {
                sampleProvider = CreateInputStream(FullPath);
            }
            catch (Exception e)
            {
                throw new RAudioNAudioException("error al carregar el fitxer", e);
            }
        }
        private ISampleProvider CreateInputStream(string fileName)
        {
            audioFileReader = new AudioFileReader(fileName);
            SampleChannel sampleChannel = new SampleChannel(audioFileReader, true);
            fade = new FadeInOutSampleProvider(audioFileReader);
            postVolumeMeter = new MeteringSampleProvider(fade);
            
            return fade;
        }
        private void InicialitzarSo()
        {
            try
            {
                ou = new WaveOutEvent
                {
                    DeviceNumber = OutDev
                };
                waveOut = ou;
                waveOut.Init(sampleProvider);
            }
            catch (Exception e)
            {
                throw new RAudioNAudioException("error al inicialitzar el so", e);
            }
        }
        
        #endregion
    }
}
