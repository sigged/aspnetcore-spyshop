using Microsoft.AspNetCore.Mvc;

namespace CoreCourse.Spyshop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchkey)
        {
            return View();  //todo: create a view named “Search” under Views/Home
        }

    }
}
