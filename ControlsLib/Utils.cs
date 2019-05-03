using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;

namespace ControlsLib
{
    public static class Utils
    {
        public static IList MoveUp(IList list, int index)
        {
            int newPosition = ((index > 0) ? index - 1 : list.Count - 1);
            var old = list[newPosition];
            list[newPosition] = list[index];
            list[index] = old;
            return list;
        }

        public static IList MoveDown(IList list, int index)
        {
            int newPosition = ((index + 1 < list.Count) ? index + 1 : 0);
            var old = list[newPosition];
            list[newPosition] = list[index];
            list[index] = old;
            return list;
        }
        public static void SaveLog(string path,string errno, string err, Exception ex)
        {
            File.WriteAllText(path + DateTime.Now.ToString("YYYMMdd"), GetErrorString(errno, err, ex));
        }
        public static string GetErrorString(string errno, string err, Exception ex)
        {
            return errno + ": \n" + err + "\n" + ex.ToString();
        }
        
        public static AudioDevConfig GetAudioDevConfig(string FileName)
        {
            if (!File.Exists(FileName))
            {
                using (var stream = new StreamWriter(FileName))
                {
                    var serializer = new XmlSerializer(typeof(AudioDevConfig));
                    serializer.Serialize(stream, new AudioDevConfig());
                    stream.Flush();
                }
            }
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(AudioDevConfig));
                return serializer.Deserialize(stream) as AudioDevConfig;
            }
        }

        public static void SetAudioDevConfig(AudioDevConfig config, string FileName)
        {
            using (var stream = new StreamWriter(FileName))
            {
                var serializer = new XmlSerializer(typeof(AudioDevConfig));
                serializer.Serialize(stream,config);
                stream.Flush();
            }
        }

    }
}
