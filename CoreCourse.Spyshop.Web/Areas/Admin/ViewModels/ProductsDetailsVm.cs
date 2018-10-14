using System.ComponentModel.DataAnnotations;

namespace CoreCourse.Spyshop.Web.Areas.Admin.ViewModels
{
    public class ProductsDetailsVm : ProductsEditVm
    {
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
    }
}