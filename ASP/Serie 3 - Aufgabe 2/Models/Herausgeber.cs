using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_3___Aufgabe_2.Models
{
    public class Herausgeber
    {
        public virtual int HerausgeberId { get; set; }
        public virtual string Name { get; set; }
        public virtual string WebsiteUrl { get; set; }
    }
}