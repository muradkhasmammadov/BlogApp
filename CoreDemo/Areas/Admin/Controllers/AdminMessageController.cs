using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class AdminMessageController : Controller
    {
        [Area("Admin")]
        public IActionResult Inbox()
        {
            return View();
        }
    }
}
