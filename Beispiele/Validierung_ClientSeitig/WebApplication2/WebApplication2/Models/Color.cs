using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Color
    {
        public virtual int ColorId { get; set; }
        [Display(Name = "Farbe")]
        public virtual string Name { get; set; }
    }
}