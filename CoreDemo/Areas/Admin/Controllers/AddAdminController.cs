using BusinessLayer.Concret;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.InkML;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using Context = DataAccessLayer.Concrete.Context;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddAdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        Context _context = new Context();

        public AddAdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userId = _context.UserRoles.Where(x=>x.RoleId == 1).Select(x=>x.UserId).FirstOrDefault();   
            var values = _context.Users.Where(x=>x.Id == userId).ToList().ToPagedList(1,3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.Username,
                    fullName = model.Fullname,
                    UserImage = "/writer/WriterImages/test_user.jpg"
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                _context.SaveChanges();

                int userId = user.Id;
                UserRoles roles = new UserRoles()
                {
                    UserId = userId,
                    RoleId = 1
                };
                _context.UserRoles.Add(roles);
                _context.SaveChanges();
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Widget", new { area = "Admin" });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
    }
}
