using CoreCourse.Spyshop.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace CoreCourse.Spyshop.Web.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class UploadedImageAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _maxLength;
        private readonly string[] _allowedExtensions;

        public UploadedImageAttribute(int maxLength)
        {
            _maxLength = maxLength;
            _allowedExtensions = new[] { ".jpg", ".png" };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ProductsCreateVm vm = validationContext.ObjectInstance as ProductsCreateVm;

            if (vm?.UploadedImage != null)
            {
                if (vm.UploadedImage.Length > _maxLength * 1024)
                {
                    return new ValidationResult($"The file cannot exceed {_maxLength} kB");
                }
                else if (!_allowedExtensions
                          .Any(ext => ext == Path.GetExtension(vm.UploadedImage.FileName).ToLower()))
                {
                    string allowedExt = _allowedExtensions.Aggregate((cur, next) => cur + ", " + next);
                    return new ValidationResult(
                        $"The file must be one of {allowedExt}");
                }
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// Adds data-val attributes to the HTML output, so javascript can validate using these values
        /// </summary>
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-uploadedimage"] = $"This file is invalid";
            context.Attributes["data-val-uploadedimage-maxlength"] = _maxLength.ToString();
            context.Attributes["data-val-uploadedimage-maxlengthmessage"] = $"The file cannot exceed {_maxLength} kB";
            string allowedExt = _allowedExtensions.Aggregate((cur, next) => cur + "," + next).Replace(".", "");
            context.Attributes["data-val-uploadedimage-extensions"] = allowedExt;
            context.Attributes["data-val-uploadedimage-extensionsmessage"] = $"The file must be one of {allowedExt}";
        }

    }

}
