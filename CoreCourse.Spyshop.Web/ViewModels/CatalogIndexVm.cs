using CoreCourse.Spyshop.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.ViewModels
{
    public class CatalogIndexVm
    {
        public List<Category> Categories { get; set; }
    }
}