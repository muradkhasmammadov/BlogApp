using BusinessLayer.Concret;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.IdentityModel.Tokens;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        //[AllowAnonymous]
        [Authorize]
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var useremail = User.Identity.Name;
                ViewBag.Useremail = useremail;
                Context c = new Context();
                ViewBag.Username = c.Users.Where(x => x.Email == useremail).Select(y => y.UserName).FirstOrDefault();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public IActionResult WriterProfile()
        {
            return View();
        }

        public IActionResult WriterEmail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                UserUpdateViewModel model = new UserUpdateViewModel();
                model.Email = values.Email;
                model.fullName = values.fullName;
                model.UserName = values.UserName;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel model)
        {
            if (User.Identity == null && !User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                return View(model);
            }

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.fullName = model.fullName;
            values.Email = model.Email;
            values.UserName = model.UserName;

            if (model.UserImage != null && model.UserImage.Length > 0)
            {
                var extension = Path.GetExtension(model.UserImage.FileName);
                var newImageName = Guid.NewGuid() + "/writer/WriterImages/" + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writer/WriterImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                model.UserImage.CopyTo(stream);
                values.UserImage = newImageName;
            }
            else if (model.UserImage == null)
            {
                values.UserImage = "/writer/WriterImages/test_user.jpg";
                return View(model);
            }


            if (model.ChangePassword)
            {
                if (string.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("Password", "Password can't be empty!");
                    return View(model);
                }

                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.Password);
            }

            var result = await _userManager.UpdateAsync(values);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
    }

}
