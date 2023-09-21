using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Context context = new Context();
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = p.Email,
                    UserName = p.Username,
                    fullName = p.Fullname,
                    UserImage = "/writer/WriterImages/test_user.jpg"
                };
                var result = await _userManager.CreateAsync(user, p.Password);
                context.SaveChanges();

                int userId = user.Id;
                UserRoles roles = new UserRoles()
                {
                    UserId = userId,
                    RoleId = 2
                };
                context.UserRoles.Add(roles);
                context.SaveChanges();
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }


    }
}
