using CoreCourse.Spyshop.Web.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.ViewModels
{
    public class AccountRegisterVm
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please provide a username")]
        [StringLength(200, MinimumLength = 5,
            ErrorMessage = "Username must be between {2} and {1} characters")]
        [RegularExpression(@"^[\w\d.]{5,}$",
            ErrorMessage = "Username cannot contain whitespaces or special characters")]
        public string UserName { get; set; }

        [Display(Name = "E-mail address")]
        [Required]
        [EmailAddress(ErrorMessage = "Please provide a valid e-mail adress")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Your password should contain atleast {1} characters")]
        public string Password { get; set; }

        [Display(Name = "Repeat password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The passwords you have provided do not match")]
        public string RepeatPassword { get; set; }

        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "I have read and agree to the license terms")]
        [MustBeTrue(ErrorMessage = "You must read and accept the license terms to register")]
        public bool AgreeToLicense { get; set; }
    }

}
