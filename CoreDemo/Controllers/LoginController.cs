using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        Context context = new Context();

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var userId = context.Users.Where(x => x.UserName == p.username).Select(p => p.Id).FirstOrDefault();
                var userRole = context.UserRoles.Where(x => x.UserId == userId).Select(y => y.RoleId).FirstOrDefault();
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);

                if (result.Succeeded && userRole == 2)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (result.Succeeded && userRole == 1)
                {
                    return RedirectToAction("Index", "Widget", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }
            return View(p);
        }


        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}