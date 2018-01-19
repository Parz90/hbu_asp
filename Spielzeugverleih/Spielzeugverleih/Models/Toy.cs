using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Spielzeugverleih.Models
{
    public class Toy
    {
        public virtual int ToyId { get; set; }
        [DisplayName("Zustand")]
        public virtual int ConditionId { get; set; }
        [DisplayName("Artikelnummer")]
        public virtual string ArticleNr { get; set; }

        //public virtual string ToyPicListId { get; set; }

        [DisplayName("Titel")]
        public virtual string Title { get; set; }
        [DisplayName("Beschreibung")]
        public virtual string Description { get; set; }
        [DisplayName("Preis/Tag")]
        public virtual decimal Price { get; set; }
        [DisplayName("Aktiv")]
        public virtual bool Active { get; set; }

        public virtual Condition Condition { get; set; }
        [DisplayName("Bilder")]
        public virtual ICollection<ToyPic> ToyPicList { get; set; }
        public virtual bool Available { get; set; }


        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }

 
        [DisplayName("Von")]
        [DataType(DataType.Date)]
        public virtual DateTime From { get; set; }


        [DisplayName("Bis")]
        [DataType(DataType.Date)]
        public virtual DateTime To { get; set; }
    }
}