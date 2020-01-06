using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAudioDataAccess.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Artist MainArtist { get; set; }
        public Album Album { get; set; }
        public Audio Audio { get; set; }
        public Genre Genre { get; set; }
        public TimeSpan Duration { get; set; }
        public List<Artist> Collaborators { get; set; }
    }
}
