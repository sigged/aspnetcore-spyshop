using CoreCourse.Spyshop.Web.Data;
using CoreCourse.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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