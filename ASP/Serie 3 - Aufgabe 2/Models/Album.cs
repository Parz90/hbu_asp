﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_3___Aufgabe_2.Models
{
    public class Album
    {
        public Album()
        {
            this.Sprache = new List<Sprache>();
        }

        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual int HerausgeberId { get; set; }
        
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Herausgeber Herausgeber { get; set; }
        public virtual ICollection<Sprache> Sprache { get; set; }

    }
}