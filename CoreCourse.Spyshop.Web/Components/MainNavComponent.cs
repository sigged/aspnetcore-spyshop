using CoreCourse.Spyshop.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Components
{
    [ViewComponent(Name = "MainNavigation")]
    public class MainNavComponent : ViewComponent
    {
        private IEnumerable<MainNavLinkVm> navLinks { get; set; }

        public MainNavComponent()
        {
            navLinks = new List<MainNavLinkVm>
            {
                new MainNavLinkVm{ Controller="Home", Action="Index", Text="Start"},
                new MainNavLinkVm{ Controller="Catalog", Action="Index", Text="Products"},
                new MainNavLinkVm{ Controller="About", Action="Index", Text="About"},
            };
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            foreach (var navlink in navLinks) {
                if (this.RouteData.Values["controller"]?.ToString().ToLower() == navlink.Controller.ToLower() 
                    &&
                    this.RouteData.Values["action"]?.ToString().ToLower() == navlink.Action.ToLower())
                {
                    navlink.IsActive = true;
                }
            }
            //return View(navLinks);
            return Task.FromResult<IViewComponentResult>(View(navLinks)); //avoids warning about lacking await operator
        }
    }
}
