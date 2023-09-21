using BusinessLayer.Concret;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistics
{
    public class Statistics1 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.totalBlogs = c.BLogs.Count();
            ViewBag.notifications = c.Contacts.Count();
            ViewBag.comments = c.Comments.Count();

            string apikey = "162c10a10b5042000e1401bc70cab5ed";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Quba,AZ&mode=xml&lang-en&units=metric&appid=" + apikey;
            XDocument document = XDocument.Load(connection);
            ViewBag.weather = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }

    }
}
