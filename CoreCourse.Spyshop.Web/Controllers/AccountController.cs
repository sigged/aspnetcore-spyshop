using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCourse.Spyshop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreCourse.Spyshop.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var viewModel = new AccountLoginVm();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(AccountLoginVm viewmodel)
        {
            string validUser = "Joe";
            string validPass = "unsafe";
            
            if (ModelState.IsValid) //if form was filled in correctly
            {
                //check if provided credentials are valid (user: Joe, pas: Doe)
                if (viewmodel.Username.Trim().Equals(validUser, StringComparison.InvariantCultureIgnoreCase) &&
                    viewmodel.Password == validPass)
                {
                    //todo: add authentication code

                    return new RedirectToActionResult("Index", "Home", null);   //redirect to homepage on succesful sign in.
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The credentials you have provided are invalid. Please try again.");
                    return View(viewmodel);
                }
            }
            else
            {
                return View(viewmodel);
            }
        }

        public IActionResult Register()
        {
            var viewModel = new AccountRegisterVm();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AccountRegisterVm viewmodel)
        {
            if (ModelState.IsValid)
            {
                //todo: register user account

                return new RedirectToActionResult("Index", "Home", null);   //redirect to homepage on succesful registration.
            }
            else
            {
                return View(viewmodel);
            }
        }
    }
}