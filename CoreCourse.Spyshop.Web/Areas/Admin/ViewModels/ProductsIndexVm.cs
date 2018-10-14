using CoreCourse.Spyshop.Domain.Catalog;
using System.Collections.Generic;

namespace CoreCourse.Spyshop.Web.Areas.Admin.ViewModels
{
    public class ProductsIndexVm
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
