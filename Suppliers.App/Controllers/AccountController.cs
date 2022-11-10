using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Suppliers.App.Models;
using Suppliers.DataModel;
using System.Security.Cryptography.X509Certificates;

namespace Suppliers.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View(new RegisterVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid == true)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.Email;
                user.Email = model.Email;
                user.Lastname = model.Lastname;
                user.Firstname = model.Firstname;
                await userManager.CreateAsync(user, model.Password);
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return View(model);
            }
        }

        public IActionResult SignIn()
        {
            SignInVM vm = new SignInVM();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInVM model)
        {
            ApplicationUser user = await userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("Login Error", "Invalid Credentials");
                    return View(model);
                }
            }

            else
            {
                ModelState.AddModelError("Login Error", "Invalid Credentials");
                return View(model);
            }
            
        }
    }
}
