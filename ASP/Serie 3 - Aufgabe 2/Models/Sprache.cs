using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_3___Aufgabe_2.Models
{
    public class Sprache
    {
        //[System.ComponentModel.DataAnnotations.Key]
        public virtual string SpracheId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}