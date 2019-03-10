using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ControlsLib
{
    public static class Utils
    {
        public static void MoveUp<T>(this IList<T> list, int index)
        {
            int newPosition = ((index > 0) ? index - 1 : list.Count - 1);
            var old = list[newPosition];
            list[newPosition] = list[index];
            list[index] = old;
        }

        public static void MoveDown<T>(this IList<T> list, int index)
        {
            int newPosition = ((index + 1 < list.Count) ? index + 1 : 0);
            var old = list[newPosition];
            list[newPosition] = list[index];
            list[index] = old;
        }
        public static void SaveLog(string path,string errno, string err, Exception ex)
        {
            File.WriteAllText(path + DateTime.Now.ToString("YYYMMdd"), GetErrorString(errno, err, ex));
        }
        public static string GetErrorString(string errno, string err, Exception ex)
        {
            return errno + ": \n" + err + "\n" + ex.ToString();
        }
        public static string GetExceptionString(Exception ex)
        {
            string excep;
            try
            {
                excep = ex.HResult.ToString() + "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite.ToString() + "\n\n" + ex.InnerException.Message + "\n" + ex.InnerException.Source + "\n" + ex.InnerException.StackTrace + "\n" + ex.InnerException.TargetSite.ToString();

            }
            catch
            {
                try
                {
                    excep = ex.HResult.ToString() + "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite.ToString() + "\n\n";

                }
                catch
                {
                    excep = "Error desconegut";
                }
            }


             return excep;
        }
        
    }
}
