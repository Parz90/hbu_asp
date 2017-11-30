using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_5___Aufgabe_5.Models
{
    public class Gemeinde_Agent
    {
        public virtual int Gemeinde_AgentId { get; set; }
        public virtual int AgentId { get; set; }
        public virtual string Rec_Art { get; set; }
        public virtual int BFSNR { get; set; }

        public virtual Agent Agent { get; set; }
    }
}