using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Entity.Entities;
using MyBlog.Entity.Models.Users;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;


        public AuthController(UserManager<AppUser> user,SignInManager<AppUser> signInManager)
        {
            this.userManager = user;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLogin)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLogin.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLogin.Password, userLogin.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta veya şifre geçersiz.");
                        return View();
                    }

                }
                else
                {
                    ModelState.AddModelError("", "E-posta veya şifre geçersiz.");
                    return View();
                }
            }
            else
            {
                return View();
            }
            
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        { 
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {Area = ""});
        }
    }
}
