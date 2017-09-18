using CoreCourse.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreCourse.Spyshop.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            //Create the View Model
            var viewModel = new AboutIndexVm();

            //Populate View Model
            viewModel.ContactEmail = "info@spysphop.example";
            viewModel.CompanyFullName = "Spy Shop Incorporated";
            viewModel.AboutTitle = "Welcome to Spy Shop";
            viewModel.AboutContent = "<p>We deliver premium gadgets to help all Clouseaus and Bonds out there.<br />To start, have a look at the <a href=\"/\">homepage</a>!</p>";

            //return View Model to the Index.cshtml view, by using the overloaded View() method
            return View(viewModel);
        }
    }
}