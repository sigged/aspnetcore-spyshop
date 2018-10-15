using System.ComponentModel.DataAnnotations;

namespace CoreCourse.Spyshop.Web.ViewModels
{
    public class AccountLoginVm
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
