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
        public virtual string ToyPicId { get; set; }
        [DisplayName("Titel")]
        public virtual string Title { get; set; }
        [DisplayName("Beschreibung")]
        public virtual string Description { get; set; }
        [DisplayName("Preis/Tag")]
        public virtual decimal Price { get; set; }
        [DisplayName("Aktiv")]
        public virtual bool Active { get; set; }

        public virtual Condition Condition { get; set; }
        public virtual List<ToyPic> ToyPicList { get; set; }
        public virtual bool Available { get; set; }
    }
}