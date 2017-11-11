using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Serie_5___Aufgabe_1.Models
{
    public class User
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LoginId.Contains(Vorname) || LoginId.Contains(Name))
            {

            }
            else
            {
                yield return new ValidationResult("Use a Login ID which contains Firstname or Lastname!");
            }
        }
        public virtual int UserId { get; set; }
        public virtual string LoginId { get; set; }
        public virtual string Vorname { get; set; }
        public virtual string Name { get; set; }
    }
}