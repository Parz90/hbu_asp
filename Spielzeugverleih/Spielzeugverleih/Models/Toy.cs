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
        [DisplayName("Condition")]
        public virtual int ConditionId { get; set; }
        public virtual string ArticleNr { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        [DisplayName("Price/Day")]
        public virtual decimal Price { get; set; }
        public virtual bool Active { get; set; }
        public virtual Condition Condition { get; set; }
        [DisplayName("Pictures")]
        public virtual ICollection<ToyPic> ToyPicList { get; set; }
        public virtual bool Available { get; set; }


        [NotMapped]
        [DisplayName("Pictures")]
        public HttpPostedFileBase[] files { get; set; }
    }
}