using System.Collections.Generic;

namespace CoreCourse.Spyshop.Domain.Catalog
{
    public class Category : BaseEntity<long>
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
