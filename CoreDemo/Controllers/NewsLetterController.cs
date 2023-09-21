using BusinessLayer.Concret;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLetterController : Controller
    {
        NewsLetterManager manager = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeEmail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeEmail(NewsLetter p)
        {
            p.EmailStatus = true;
            manager.AddNewsLetter(p);
            return RedirectToAction("Index", "Blog");
        }
    }
}
