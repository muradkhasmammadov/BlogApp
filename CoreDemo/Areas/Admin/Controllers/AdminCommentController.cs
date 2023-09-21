using BusinessLayer.Concret;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = commentManager.GetCommentWithBlog();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            Comment commentToDelete = c.Comments.Find(id);

            if (commentToDelete != null)
            {
                c.Comments.Remove(commentToDelete);
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
