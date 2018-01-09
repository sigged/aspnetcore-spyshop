using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCourse.Spyshop.Domain.Catalog
{
    public class Category
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
