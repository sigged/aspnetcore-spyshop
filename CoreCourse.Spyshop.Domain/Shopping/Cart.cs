using System.Collections.Generic;

namespace CoreCourse.Spyshop.Domain.Shopping
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public IList<CartItem> Items { get; set; }
    }
}
