using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4TSP.Model
{
    public class AlbumArtist
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
