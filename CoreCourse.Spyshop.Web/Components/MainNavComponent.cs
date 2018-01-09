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
        private IEnumerable<MainNavLinkVm> PublicLinks { get; set; }
        private IEnumerable<MainNavLinkVm> AdminLinks { get; set; }

        public MainNavComponent()
        {
            PublicLinks = new List<MainNavLinkVm>
            {
                new MainNavLinkVm{ Area=null, Controller="Home", Action="Index", Text="Start"},
                new MainNavLinkVm{ Area=null, Controller="Catalog", Action="Index", Text="Products"},
                new MainNavLinkVm{ Area=null, Controller="About", Action="Index", Text="About"},
            };

            AdminLinks = new List<MainNavLinkVm>
            {
                new MainNavLinkVm{ Area="Admin", Controller="Home", Action="Index", Text="Dashboard"},
                new MainNavLinkVm{ Area="Admin", Controller="Categories", Action="Index", Text="Categories"},
                new MainNavLinkVm{ Area="Admin", Controller="Products", Action="Index", Text="Products"},
            };
        }

        public Task<IViewComponentResult> InvokeAsync(bool showAdmin)
        {
            var navLinks = PublicLinks;
            if (showAdmin) navLinks = AdminLinks;

            foreach (var navlink in navLinks) {
                if (this.RouteData.Values["area"]?.ToString().ToLower() == navlink.Area?.ToLower()
                    &&
                    this.RouteData.Values["controller"]?.ToString().ToLower() == navlink.Controller.ToLower() 
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
