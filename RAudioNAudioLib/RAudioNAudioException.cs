using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAudioNAudioLib
{
    public class RAudioNAudioException : Exception
    {
        public RAudioNAudioException(string msg, Exception inner)
           : base(msg, inner)
        {
        }
    }
}
