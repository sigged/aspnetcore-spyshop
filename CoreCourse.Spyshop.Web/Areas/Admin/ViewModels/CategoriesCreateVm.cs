using System.ComponentModel.DataAnnotations;

namespace CoreCourse.Spyshop.Web.Areas.Admin.ViewModels
{
    public class CategoriesCreateVm
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int NumberOfProducts { get; set; }

    }
}
