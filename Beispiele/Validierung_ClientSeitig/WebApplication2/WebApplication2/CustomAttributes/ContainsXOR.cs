using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.CustomAttributes
{
    public class ContainsXORAttribute : ValidationAttribute, IClientValidatable
    {

        private readonly string _value1;
        private readonly string _value2;


        public ContainsXORAttribute(string value1, string value2) : base("{0} contains invalid character.")
        {

            _value1 = value1;
            _value2 = value2;

        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {

            var rule = new ModelClientValidationRule
            {
                ErrorMessage = string.Format("{0} muss einen der Werte aus {1} oder {2} enthalten", metadata.PropertyName, _value1, _value2),
                ValidationType = "containsxor"
            };

            rule.ValidationParameters.Add("value1", _value1);
            rule.ValidationParameters.Add("value2", _value2);

            yield return rule;

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var containerType = validationContext.ObjectInstance.GetType();
            var property1 = containerType.GetProperty(_value1);
            var property2 = containerType.GetProperty(_value2);

            string property1Value = string.Empty;
            string property2Value = string.Empty;

            if (property1 != null)
            {
                property1Value = property1.GetValue(validationContext.ObjectInstance, null).ToString();
            }

            if (property2 != null)
            {
                property2Value = property2.GetValue(validationContext.ObjectInstance, null).ToString();
            }

            if (_value1 is null & _value2 is null)
            {

                return new ValidationResult("Parameter dürfen nicht leer sein");

            }

            if (!Regex.IsMatch(value.ToString(), property1Value, RegexOptions.IgnoreCase) & !Regex.IsMatch(value.ToString(), property2Value, RegexOptions.IgnoreCase))
            {

                return new ValidationResult(string.Format("{0} muss einen der Werte aus {1} oder {2} enthalten", validationContext.DisplayName, property1.Name, property2.Name));

            }

            if (Regex.IsMatch(value.ToString(), property1Value, RegexOptions.IgnoreCase) & Regex.IsMatch(value.ToString(), property2Value, RegexOptions.IgnoreCase))
            {

                return new ValidationResult(string.Format("{0} darf nur {1} oder {2} enthalten", validationContext.DisplayName, property1.Name, property2.Name));

            }

            return ValidationResult.Success;

        }


    }
}