using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4TSP.Model
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public ICollection<AlbumArtist> AlbumArtists { get; set; }
    }
}
