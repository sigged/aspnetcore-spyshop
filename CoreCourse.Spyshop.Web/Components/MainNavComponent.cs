using CoreCourse.Spyshop.Web.ViewModels.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Components
{
[ViewComponent(Name = "MainNavigation")]
public class MainNavComponent : ViewComponent
{
    private IEnumerable<MainNavLinkVm> publicLinks { get; set; }
    private IEnumerable<MainNavLinkVm> adminLinks { get; set; }

    public MainNavComponent()
    {
        publicLinks = new List<MainNavLinkVm>
        {
            new MainNavLinkVm{ Area=null, Controller="Home", Action="Index", Text="Start"},
            new MainNavLinkVm{ Area=null, Controller="Catalog", Action="Index", Text="Products"},
            new MainNavLinkVm{ Area=null, Controller="About", Action="Index", Text="About"},
        };
        adminLinks = new List<MainNavLinkVm>
        {
            new MainNavLinkVm{ Area="Admin", Controller="Home", Action="Index", Text="Dashboard"},
            new MainNavLinkVm{ Area="Admin", Controller="Categories", Action="Index", Text="Categories"},
            new MainNavLinkVm{ Area="Admin", Controller="Products", Action="Index", Text="Products"},
        };
    }

    public async Task<IViewComponentResult> InvokeAsync(bool showAdmin)
    {
        var navLinks = publicLinks;
        if (showAdmin) navLinks = adminLinks;

        foreach (var lnk in navLinks)
        {
            if (this.RouteData.Values["area"]?.ToString().ToLower() == lnk.Area?.ToLower() &&
                this.RouteData.Values["controller"]?.ToString().ToLower() == lnk.Controller.ToLower() &&
                this.RouteData.Values["action"]?.ToString().ToLower() == lnk.Action.ToLower())
            {
                lnk.IsActive = true;
            }
        }
        return await Task.FromResult<IViewComponentResult>(View(navLinks));
    }
}
}
