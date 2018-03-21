using CoreCourse.Spyshop.Domain.Catalog;
using System.Collections.Generic;

namespace CoreCourse.Spyshop.Web.Areas.Admin.ViewModels
{
    public class CategoriesIndexVm
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}
