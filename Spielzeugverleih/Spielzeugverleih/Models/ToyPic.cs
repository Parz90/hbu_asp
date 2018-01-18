using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public partial class ToyPic
    {
        public virtual int ToyPicId { get; set; }

        public virtual int ToyId { get; set; }


        public virtual byte[] Picture { get; set; }

        //[DisplayName("Upload File")]
        //public string ImagePath { get; set; }

        public virtual Toy Toy { get; set; }
    }
}