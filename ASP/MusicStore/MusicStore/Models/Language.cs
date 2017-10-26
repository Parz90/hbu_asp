using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Language
    {
        [StringLength(2)]
        public virtual string LanguageId { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}