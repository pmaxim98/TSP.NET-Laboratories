using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4TSP.Model
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<AlbumArtist> AlbumArtists { get; set; }
    }
}
