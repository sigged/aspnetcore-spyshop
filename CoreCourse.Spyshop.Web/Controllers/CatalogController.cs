using CoreCourse.Spyshop.Domain;
using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IRepository<Category, long> _cRepository;

        public CatalogController(IRepository<Category, long> cRepository)
        {
            this._cRepository = cRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _cRepository.GetAll()
                .Include(c => c.Products)
                .ToListAsync();

            CatalogIndexVm viewmodel = new CatalogIndexVm();
            viewmodel.Categories = categories;

            return View(viewmodel);
        }
    }
}