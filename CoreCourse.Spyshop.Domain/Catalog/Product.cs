namespace CoreCourse.Spyshop.Domain.Catalog
{
    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
