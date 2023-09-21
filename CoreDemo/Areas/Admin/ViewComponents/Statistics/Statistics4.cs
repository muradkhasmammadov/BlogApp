using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics4:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.admin = c.Admins.Where(x=>x.AdminID == 2).Select(y=>y.Name).FirstOrDefault();
            ViewBag.adminRole = c.Admins.Where(x=>x.AdminID == 2).Select(y=>y.Role).FirstOrDefault();
            ViewBag.adminImage = c.Admins.Where(x=>x.AdminID == 2).Select(y=>y.ImageUrl).FirstOrDefault();
            ViewBag.adminDescription = c.Admins.Where(x=>x.AdminID == 2).Select(y=>y.ShortDescription).FirstOrDefault();
            return View();
        }

    }
}
