using BusinessLayer.Concret;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		CategoryManager manager = new CategoryManager(new EfCategoryRepository());
		
		public IViewComponentResult Invoke()
		{
			var values = manager.GetList();
			return View(values);
		}
	}
}
