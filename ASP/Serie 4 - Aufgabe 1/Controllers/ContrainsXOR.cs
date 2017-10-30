using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serie_4___Aufgabe_1.Controllers
{
    public class ContrainsXOR : ValidationAttribute
    {
        private readonly string _vorname;
        private readonly string _name;

        public ContrainsXOR(string vorname, string name)
        {
            _vorname = vorname;
            _name = name;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var stringValue = value.ToString();
            if ((stringValue == _vorname) || (stringValue == _name))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name oder Vorname fehlt!");
        }
    }
}