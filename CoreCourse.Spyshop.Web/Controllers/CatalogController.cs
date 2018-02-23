using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Web.Data;
using CoreCourse.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreCourse.Spyshop.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly SpyShopContext context;

        public CatalogController(SpyShopContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await context.Categories
                .Include(c => c.Products)
                .ToListAsync();
            
            CatalogIndexVm viewmodel = new CatalogIndexVm();
            viewmodel.Categories = categories;

            return View(viewmodel);
        }
    }
}