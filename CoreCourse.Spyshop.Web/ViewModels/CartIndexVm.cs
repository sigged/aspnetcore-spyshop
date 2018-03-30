using CoreCourse.Spyshop.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.ViewModels
{
    public class CartIndexVm
    {
        public CartIndexVm()
        {
            Items = new List<CartItemVm>();
        }

        public IList<CartItemVm> Items { get; set; }
        public decimal CartTotal { get {
                return Items.Sum(i => i.ProductTotal);
        } }
    }

    public class CartItemVm
    {        
        public long ProductId { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }
        
        public int Quantity { get; set; }
        public decimal ProductTotal
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }
}
