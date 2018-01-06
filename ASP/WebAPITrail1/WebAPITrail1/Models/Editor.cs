using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAPITrail1.Models
{
    public class Editor
    {
        [DisplayName("Editor")]
        public virtual int EditorId { get; set; }

        public virtual string Name { get; set; }
        public virtual string WebsiteUrl { get; set; }
    }
}