using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebApplication2.CustomAttributes;

namespace WebApplication2.Models
{
    public class User2
    {
        [ContainsXOR("Vorname", "Name")]
        [Key]
        [Required()]
        public virtual string LoginId { get; set; }
        
        public virtual string Vorname { get; set; }
     
        public virtual string Name { get; set; }

       
    }
}