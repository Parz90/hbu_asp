using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public partial class ToyPic
    {
        public int ToyPicId { get; set; }
        public byte[] Picture { get; set; }
        [DisplayName("Upload File")]
        public string ImagePath { get; set; }
    }
}