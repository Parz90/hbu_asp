using System.ComponentModel;

namespace MusicStore.Models
{
    public class Editor
    {
        [DisplayName("Editor")]
        public virtual int EditorId { get; set; }

        public virtual string Name { get; set; }
        public virtual string WebsiteUrl { get; set; }
    }
}