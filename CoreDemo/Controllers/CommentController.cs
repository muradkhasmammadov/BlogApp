using BusinessLayer.Concret;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment comment, int BlogID)
        {
            if (User.Identity.IsAuthenticated)
            {
                var username = User.Identity.Name;
                string userImage = c.Users.Where(x => x.UserName == username).Select(y => y.UserImage).FirstOrDefault();

                comment.CommentUserName = username;
                comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                comment.CommentStatus = true;
                comment.BlogID = BlogID;
                comment.CommentUserImage = userImage;
                commentManager.CommentAdd(comment);

                return Redirect($"~/Blog/BlogReadAll/{BlogID}");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values = commentManager.GetList(id);
            return PartialView(values);
        }

    }
}
