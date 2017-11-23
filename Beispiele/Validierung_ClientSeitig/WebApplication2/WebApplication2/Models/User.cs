using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication2.Models
{
    public class User : IValidatableObject
    {
        [Key]
        [Required()]
        public virtual string LoginId { get; set; }
        
        public virtual string Vorname { get; set; }
     
        public virtual string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(this.Vorname,
               new ValidationContext(this, null, null) { MemberName = "Vorname" },
               results);

            Validator.TryValidateProperty(this.Name,
              new ValidationContext(this, null, null) { MemberName = "Name" },
              results);

            if (!Regex.IsMatch(this.LoginId, Vorname, RegexOptions.IgnoreCase) & !Regex.IsMatch(this.LoginId, Name, RegexOptions.IgnoreCase))
            {
                results.Add(new ValidationResult("LoginId muss Name oder Vorname enthalten"));
            }

            if (Regex.IsMatch(this.LoginId, Vorname, RegexOptions.IgnoreCase) & Regex.IsMatch(this.LoginId, Name, RegexOptions.IgnoreCase))
           
            {
                results.Add(new ValidationResult("LoginId darf nur Name oder Vorname enthalten, nicht beides"));
            }

            return results;
        }
    }
}