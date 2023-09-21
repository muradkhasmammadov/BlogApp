using BusinessLayer.Concret;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterAboutOnDashboard : ViewComponent
	{
		UserManager wm = new UserManager(new EfUserRepository());
		Context c = new Context();
		public IViewComponentResult Invoke()
		{
			var writername = User.Identity.Name;
			ViewBag.writername = writername;
			var useremail = c.Users.Where(x => x.UserName == writername).Select(y => y.Email).FirstOrDefault();
			var writerid = c.Users.Where(x=>x.Email == useremail).Select(y=>y.Id).FirstOrDefault();
			var values = wm.TGetById(writerid);
			return View(values);
		}
	}
}
