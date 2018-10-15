using CoreCourse.Spyshop.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace CoreCourse.Spyshop.Web.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MustBeTrueAttribute : ValidationAttribute, IClientModelValidator
    {

        public MustBeTrueAttribute(string errorMessage = null) : base(errorMessage)
        {
            ErrorMessage = errorMessage ?? $"Please check this checkbox";
        }

        /// <summary>
        /// Adds data-val attributes to the HTML output, so javascript can validate using these values
        /// </summary>
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-mustbetrue"] = ErrorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is bool && !(bool)value)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
