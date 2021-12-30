using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace EUCTask.Extensions
{
    public class RequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string _otherProperty;
        public RequiredIfAttribute(string otherProperty)
        {
            _otherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_otherProperty);
            if (property == null)
            {
                return new ValidationResult(string.Format(
                    CultureInfo.CurrentCulture,
                    "Unknown property {0}",
                    new[] { _otherProperty }
                ));
            }
            var otherPropertyValue = property.GetValue(validationContext.ObjectInstance, null);

            if ((bool)otherPropertyValue == false)
            {
                if (value == null || value as string == string.Empty)
                {
                    return new ValidationResult(string.Format(
                        CultureInfo.CurrentCulture,
                        FormatErrorMessage(validationContext.DisplayName),
                        new[] { _otherProperty }
                    ));
                }
            }

            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "requiredif",
            };
            rule.ValidationParameters.Add("other", _otherProperty);
            yield return rule;
        }
    }

    public class RequiredTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            if (value.GetType() != typeof(bool)) return false;

            return (bool)value;
        }
    }

    public class BirthdayValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null || value.GetType() != typeof(DateTime)) return false;
            if ((DateTime)value > DateTime.Now) return false;
            return true;
        }
    }

}
