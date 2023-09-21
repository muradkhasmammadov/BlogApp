using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            Context c = new Context();
            var writername = User.Identity?.Name;
            ViewBag.writername = writername;
            var writeremail = c.Users.Where(x => x.UserName == writername).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == writeremail).Select(y => y.Id).FirstOrDefault();
            ViewBag.blogCounts = c.BLogs.Count();
            ViewBag.writerBlogCounts = c.BLogs.Where(x=>x.WriterID == writerid).Count();
            ViewBag.categoryCounts = c.Categories.Count();
            return View();
        }
    }
}
