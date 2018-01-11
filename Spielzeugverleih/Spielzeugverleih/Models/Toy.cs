using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public class Toy
    {
        public virtual int ToyId { get; set; }
        [DisplayName("Zustand")]
        public virtual int ConditionId { get; set; }
        [DisplayName("Artikelnummer")]
        public virtual string ArticleNr { get; set; }
        [DisplayName("Titel")]
        public virtual string Title { get; set; }
        [DisplayName("Beschreibung")]
        public virtual string Description { get; set; }
        [DisplayName("Preis/Tag")]
        public virtual decimal Price { get; set; }
        public virtual string ImagePath { get; set; }
        [DisplayName("Aktiv")]
        public virtual bool Active { get; set; }

        public virtual Condition Condition { get; set; }
        public enum Zustand
        {
            [Description("Neu")]
            New,

            [Description("Neuwertig")]
            Mint,

            [Description("Gebraucht")]
            Secondhand,

            [Description("Antik")]
            Antique,

            [Description("Verloren")]
            Lost,

            [Description("Defekt")]
            Defect,

            [Description("Andere")]
            Others
        }
        public virtual bool Available { get; set; }
    }
}