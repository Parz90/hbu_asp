using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_3___Aufgabe_2.Models
{
    public class Sprache
    {
        public Sprache()
        {
            this.Albums = new List<Album>();
        }

        //[System.ComponentModel.DataAnnotations.Key]
        public virtual string SpracheId { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}