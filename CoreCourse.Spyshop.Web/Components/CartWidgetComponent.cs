using CoreCourse.Spyshop.Domain.Shopping;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Components
{
    [ViewComponent(Name = "CartWidget")]
    public class CartWidgetComponent : ViewComponent
    {
        ICartService _cartService;

        public CartWidgetComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _cartService.LoadCart();
            int itemsInCard = _cartService.GetAll().Sum(i => i.Quantity);
            await Task.Delay(0); //dirty trick to prevent async warning.
            return View(itemsInCard);
        }
    }
}
