using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Controllers
{
    public class Uhr
    {
        public int anzahlZeiger { get; set; }
        public bool IsDigital { get; set; }
        public string Material { get; set; }
        public double Preis { get; set; }
        public bool IsWasserDicht { get; set; }
    }
}