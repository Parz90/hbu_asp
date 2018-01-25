using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public partial class ToyPic
    {
        public virtual int ToyPicId { get; set; }
        [DisplayName("Toy ID")]
        public virtual int ToyId { get; set; }
        public virtual byte[] Picture { get; set; }

        [NotMapped]
        public virtual bool Delete { get; set; }
        public virtual Toy Toy { get; set; }
    }
}