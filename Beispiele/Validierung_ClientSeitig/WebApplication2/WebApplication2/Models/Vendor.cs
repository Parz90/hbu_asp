using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Vendor
    {
        public virtual int VendorId { get; set; }
        [Display(Name = "Hersteller")]
        public virtual string Name { get; set; }
    }
}