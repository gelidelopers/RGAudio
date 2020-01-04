using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAudioNAudioLib
{
    public class RAudioNAudio
    {
        #region Properites
        public bool EnableAutoFadeOut { get; set; }
        public bool IsPlaying { get { return waveOut.PlaybackState == PlaybackState.Playing; } }
        public PlaybackState Status { get { return waveOut.PlaybackState; } }

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
        #endregion

        #region Constructor
        public RAudioNAudio(string fullpath, int outdev)
        {
            OutDev = outdev;
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
            }
            waveOut.Play();

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
            postVolumeMeter = new MeteringSampleProvider(sampleChannel);
            fade = new FadeInOutSampleProvider(sampleChannel);
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
