using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAudioDataAccess.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Parent { get; set; }
    }
}
