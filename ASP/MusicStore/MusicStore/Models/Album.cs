using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }
        [DisplayName("Genre")]
        public virtual int GenreId { get; set; }
        [DisplayName("Artist")]
        public virtual int ArtistId { get; set; }
        [DisplayName("Editor")]
        public virtual int EditorId { get; set; }
        public virtual string Title { get; set; }
        [DisplayName("Price")]
        public virtual decimal Price { get; set; }
        [DisplayName("Album Art")]
        public virtual string AlbumArtUrl { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Editor Editors { get; set; }

        public virtual ICollection<Language> Languages { get; set; }

        [NotMapped]
        public string[] SelectedLanguages { get; set; }

        [NotMapped]
        public virtual ICollection<Language> AllLanguages { get; set; }

    }
}