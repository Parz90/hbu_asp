using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_5___Aufgabe_5.Models
{
    public class PLZ
    {
        public virtual int Id { get; set; }
        public virtual int BFSNRId { get; set; }

        public virtual string Rec_Art { get; set; }
        public virtual int ONRP { get; set; }
        public virtual int Sprachcode { get; set; }
        public virtual Gemeinde_Agent Gemeinde_Agent { get; set; }
        public virtual int Postleitzahl { get; set; }
        public virtual int Ort_Bez_27 { get; set; }
    }
}