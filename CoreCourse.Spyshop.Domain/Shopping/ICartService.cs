using System.Collections.Generic;

namespace CoreCourse.Spyshop.Domain.Shopping
{
    public interface ICartService
    {
        void LoadCart();

        void SaveCart();

        IEnumerable<CartItem> GetAll();

        void AddToCart(long product);

        void UpdateCartItem(long productId, int quantity);
    }
}
