using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Domain.Shopping;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreCourse.Spyshop.Web.Services
{
    public class CookieCartService : ICartService
    {
        private const string CART_COOKIENAME = "SpyCart";

        //needed to get Request and Response!
        protected HttpContext _context;
        protected Cart _cart;
        
        public CookieCartService(IHttpContextAccessor ctxAccess) //ctxAccess is injected by D.I.
        {
            _context = ctxAccess.HttpContext; //get a handle to HttpContext
        }

        public void LoadCart()
        {
            //this services uses Cookies to store the cart, so get it FROM cookie
            string cartSerialized = null;
            //get json-serialized value and parse to Cart obj
            if (_context.Request.Cookies.TryGetValue(CART_COOKIENAME, out cartSerialized))
                _cart = JsonConvert.DeserializeObject<Cart>(cartSerialized);
            else
                _cart = new Cart(); //cookie not found, create new Cart.
        }

        public void SaveCart()
        {
            //this services uses Cookies to store the cart, so save it TO cookie
            string cartSerialized = JsonConvert.SerializeObject(_cart);
            //save JSON string to cookie
            _context.Response.Cookies.Append(CART_COOKIENAME, cartSerialized, new CookieOptions {
                HttpOnly = false,
                Expires = DateTimeOffset.Now.AddDays(30) //cart expired 30 days from now
            });
        }

        public void AddToCart(long productId)
        {
            //is productid already in cart?
            CartItem item = _cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null) //product already in cart, increment qty
                item.Quantity++;
            else
                _cart.Items.Add(new CartItem {
                    ProductId = productId,
                    
                    Quantity = 1
                });
        }

        public void UpdateCartItem(long productId, int quantity)
        {
            //is productid in cart?
            CartItem item = _cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                if (quantity > 0)
                    item.Quantity = quantity;
                else
                    _cart.Items.Remove(item); //no more items with this productid
            }
        }

        public IEnumerable<CartItem> GetAll()
        {
            return _cart.Items;
        }
    }
}
