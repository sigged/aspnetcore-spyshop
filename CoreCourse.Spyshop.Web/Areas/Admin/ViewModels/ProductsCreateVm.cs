using System.ComponentModel.DataAnnotations;

namespace CoreCourse.Spyshop.Web.Areas.Admin.ViewModels
{
    public class ProductsCreateVm
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        [MaxLength(250)]
        public string PhotoUrl { get; set; }

        public int? SortNumber { get; set; }
    }
}
