using BusinessLayer.Concret;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Concrete;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context c = new Context();
        [AllowAnonymous]

        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.BlogID = id;
            var values = blogManager.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var writername = User.Identity.Name;
            var writerid = c.Users.Where(x=>x.UserName == writername).Select(y=>y.Id).FirstOrDefault();
            var values = blogManager.GetListWithCategoryByWriterBm(writerid);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog b)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(b);
            var writername = User.Identity.Name;
            var writerid = c.Users.Where(x => x.UserName == writername).Select(y => y.Id).FirstOrDefault();

            if (results.IsValid)
            {
                if (b.BlogThumbnailImage != null && b.BlogThumbnailImage.Length > 0)
                {
                    var extension = Path.GetExtension(b.BlogThumbnailImage);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages/", newImageName);

                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        //b.BlogThumbnailImage.CopyTo(stream);
                    }

                    b.BlogImage = "/BlogImages/" + newImageName;
                }

                if (b.BlogImage != null && b.BlogImage.Length > 0)
                {
                    var extension = Path.GetExtension(b.BlogImage);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImages/", newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    //b.BlogImage.CopyTo(stream);
                    b.BlogImage = newImageName;
                }

                b.BlogStatus = true;
                b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                b.WriterID = writerid;
                blogManager.TAdd(b);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = blogManager.TGetById(id);
            blogManager.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalues = blogManager.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View(blogvalues);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            var writername = User.Identity.Name;
            var writerid = c.Users.Where(x => x.UserName == writername).Select(y => y.Id).FirstOrDefault();
            b.WriterID = writerid;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.BlogStatus = true;
            blogManager.TUpdate(b);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult BlogByCategory(int id)
        {
            var values = blogManager.GetBlogByCategory(id);
            ViewBag.categoryName = c.Categories.Where(x => x.CategoryID == id).Select(y=>y.CategoryName).FirstOrDefault();  
            ViewBag.blogs = values;
            return View(values);
        }
    }
}
