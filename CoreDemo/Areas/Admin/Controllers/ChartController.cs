using CoreDemo.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categorycount = 12,
                categoryname = "Technology"
            });
            list.Add(new CategoryClass
            {
                categorycount = 8,
                categoryname = "Science"
            });
            list.Add(new CategoryClass
            {
                categorycount = 16,
                categoryname = "Sports"
            });
            return Json(new { jsonlist = list });
        }
    }
}
