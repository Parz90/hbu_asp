using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAPITrail1.Models
{
    public class Genre
    {
        public virtual int GenreId { get; set; }
        [DisplayName("Genre")]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}