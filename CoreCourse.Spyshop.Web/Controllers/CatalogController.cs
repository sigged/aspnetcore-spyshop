using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreCourse.Spyshop.Web.Controllers
{
    public class CatalogController : Controller
    {
        List<Category> categories;

        public CatalogController()
        {
            categories = new List<Category> {
            new Category { Name = "General" },
            new Category { Name = "Distraction" },
            new Category { Name = "Communication" }
        };

            categories[0].Products = new List<Product> {
            new Product{ Category = categories[0], Name = "Contactlenses", Price =13.95M,
                Description = "The lenses allow to zoom up to 5 km." },
            new Product{ Category = categories[0], Name = "Card game", Price =70.95M,
                Description = "This card game can target a specific person an allows him to win or lose. Comes with a mobile app." }
        };
            categories[1].Products = new List<Product> {
            new Product{ Category = categories[1], Name = "Holographic cushion", Price=55.45M,
                Description = "A small button underneath displays a hologram, where you were previously seated" },
        };
            categories[2].Products = new List<Product>();
        }
        
        public IActionResult Index()
        {
            CatalogIndexVm viewmodel = new CatalogIndexVm();
            viewmodel.Categories = categories;

            return View(viewmodel);
        }
    }
}