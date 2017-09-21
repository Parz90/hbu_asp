using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_2___Aufgabe_1.Models
{
    public class Fahrzeug
    {
        public virtual int FahrzeugId { get; set; }
        public virtual int Hubraum { get; set; }
        public virtual int PS { get; set; }
        public virtual Farbe FarbId { get; set; }
        public virtual Hersteller HerstellerId { get; set; }

        public enum Farbe
        {
            Green = 0,
            Red = 1,
            Blue = 2,
            White = 3
        }

        public enum Hersteller
        {
            Mercedes = 0,
            Audi = 1,
            BMW = 2,
            VW = 3
        }
    }
}