using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCourse.Spyshop.Domain;
using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Domain.Shopping;
using CoreCourse.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreCourse.Spyshop.Web.Controllers
{
    public class CartController : Controller
    {
        ICartService _cartService;
        IRepository<Product, long> _productRep;

        public CartController(ICartService cartService, IRepository<Product,long> productRep)
        {
            _productRep = productRep;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            //get cart items (from cookie)
            _cartService.LoadCart();

            //get current products
            var cartItems = _cartService.GetAll();
            var products = await _productRep.GetAll().Where(p => cartItems
                            .Select(cp => cp.ProductId)
                            .Contains(p.Id)).ToListAsync();
            
            var vm = new CartIndexVm();

            //fill VM with necessary product details, synchronizing cart item with product
            foreach (var cartItem in cartItems)
            {
                var product = products.FirstOrDefault(p => p.Id == cartItem.ProductId);
                if (product == null) continue;
                vm.Items.Add(new CartItemVm {
                    ProductId = product.Id,
                    Name  = product.Name,
                    Quantity = cartItem.Quantity,
                    UnitPrice = product.Price
                });
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(long id)
        {
            var product = await _productRep.GetByIdAsync(id);
            if (product != null)
            {
                _cartService.LoadCart();
                _cartService.AddToCart(product.Id);
                _cartService.SaveCart();

                TempData[Constants.SuccessMessage] = 
                        $"<p>Product {product.Name} has been added to your shopping cart.</p><p><a href=\"/Cart\">View Cart</a></p>";
            }
            return RedirectToAction("Product", new { controller = "Catalog", name=product?.Name, id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCart(CartIndexVm inputmdl)
        {
            _cartService.LoadCart();
            foreach (var ciVm in inputmdl.Items)
            {
                _cartService.UpdateCartItem(ciVm.ProductId, ciVm.Quantity);
            }
            _cartService.SaveCart();

            return RedirectToAction("Index");
        }
    }
}