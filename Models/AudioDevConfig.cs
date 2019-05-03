using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AudioDevConfig
    {
        public Guid In1Number { get; set; }
        public Guid In2Number { get; set; }
        public Guid Out1Number { get; set; }
        public Guid Out2Number { get; set; }
        public Guid Out24Number { get; set; }
    }
}
